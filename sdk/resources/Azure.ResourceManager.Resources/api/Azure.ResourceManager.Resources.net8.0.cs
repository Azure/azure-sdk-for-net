namespace Azure.ResourceManager.Resources
{
    public partial class ArmApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmApplicationResource>, System.Collections.IEnumerable
    {
        protected ArmApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Resources.ArmApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Resources.ArmApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ArmApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ArmApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ArmApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ArmApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmApplicationData : Azure.ResourceManager.Resources.Models.ArmApplicationResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>
    {
        public ArmApplicationData(Azure.Core.AzureLocation location, string kind) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization> Authorizations { get { throw null; } }
        public string BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode? ManagementMode { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris SupportUris { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDetails UpdatedBy { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>, System.Collections.IEnumerable
    {
        protected ArmApplicationDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationDefinitionName, Azure.ResourceManager.Resources.ArmApplicationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationDefinitionName, Azure.ResourceManager.Resources.ArmApplicationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> Get(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> GetAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> GetIfExists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> GetIfExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmApplicationDefinitionData : Azure.ResourceManager.Resources.Models.ArmApplicationResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>
    {
        public ArmApplicationDefinitionData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ArmApplicationLockLevel lockLevel) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization> Authorizations { get { throw null; } }
        public System.BinaryData CreateUiDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode DeploymentMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release.", false)]
        public System.Collections.Generic.IList<string> LockingAllowedActions { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy LockingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationLockLevel LockLevel { get { throw null; } set { } }
        public System.BinaryData MainTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode? ManagementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint> NotificationEndpoints { get { throw null; } set { } }
        public System.Uri PackageFileUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy> Policies { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmApplicationDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmApplicationDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmApplicationDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.ArmApplicationDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ArmApplicationDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmApplicationDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.ArmApplicationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.ArmApplicationDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArmApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmApplicationResource() { }
        public virtual Azure.ResourceManager.Resources.ArmApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshPermissions(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshPermissionsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ArmApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> Update(Azure.ResourceManager.Resources.Models.ArmApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.ArmApplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArmDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>, System.Collections.IEnumerable
    {
        protected ArmDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmDeploymentResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmDeploymentResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ArmDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ArmDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ArmDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmDeploymentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>
    {
        internal ArmDeploymentData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmDeploymentResource() { }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistence(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation> GetDeploymentOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>> GetDeploymentOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation> GetDeploymentOperations(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation> GetDeploymentOperationsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult> WhatIf(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WhatIfAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArmDeploymentScriptCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>, System.Collections.IEnumerable
    {
        protected ArmDeploymentScriptCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Resources.ArmDeploymentScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Resources.ArmDeploymentScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> Get(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> GetAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetIfExists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> GetIfExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmDeploymentScriptData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>
    {
        public ArmDeploymentScriptData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentScriptData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentScriptData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentScriptResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmDeploymentScriptResource() { }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentScriptData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scriptName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ScriptLogResource> GetLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ScriptLogResource> GetLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ScriptLogResource GetScriptLog() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ArmDeploymentScriptData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ArmDeploymentScriptData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ArmDeploymentScriptData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> Update(Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerResourcesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesContext() { }
        public static Azure.ResourceManager.Resources.AzureResourceManagerResourcesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DataBoundaryCollection : Azure.ResourceManager.ArmCollection
    {
        protected DataBoundaryCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource> Get(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource>> GetAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.DataBoundaryResource> GetIfExists(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.DataBoundaryResource>> GetIfExistsAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataBoundaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>
    {
        public DataBoundaryData() { }
        public Azure.ResourceManager.Resources.Models.DataBoundaryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DataBoundaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DataBoundaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataBoundaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataBoundaryResource() { }
        public virtual Azure.ResourceManager.Resources.DataBoundaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, Azure.ResourceManager.Resources.Models.DataBoundaryName name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource> Get(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource>> GetAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DataBoundaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DataBoundaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>, System.Collections.IEnumerable
    {
        protected DeploymentStackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> Get(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentStackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentStackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStackResource> GetIfExists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStackResource>> GetIfExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentStackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentStackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentStackData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>
    {
        public DeploymentStackData() { }
        public Azure.ResourceManager.Resources.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public bool? BypassStackOutOfSyncError { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DeletedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DenySettings DenySettings { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DetachedResources { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended> FailedResources { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.DeploymentParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink ParametersLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ManagedResourceReference> Resources { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentStackResource() { }
        public virtual Azure.ResourceManager.Resources.DeploymentStackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentStackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult> ValidateStack(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>> ValidateStackAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JitRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.JitRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.JitRequestResource>, System.Collections.IEnumerable
    {
        protected JitRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.JitRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jitRequestName, Azure.ResourceManager.Resources.JitRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.JitRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jitRequestName, Azure.ResourceManager.Resources.JitRequestData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> Get(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.JitRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.JitRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> GetAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.JitRequestResource> GetIfExists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.JitRequestResource>> GetIfExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.JitRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.JitRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.JitRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.JitRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JitRequestData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.JitRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>
    {
        public JitRequestData(Azure.Core.AzureLocation location) { }
        public string ApplicationResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDetails CreatedBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies> JitAuthorizationPolicies { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.JitRequestState? JitRequestState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.JitSchedulingPolicy JitSchedulingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDetails UpdatedBy { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.JitRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.JitRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.JitRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.JitRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRequestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.JitRequestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JitRequestResource() { }
        public virtual Azure.ResourceManager.Resources.JitRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jitRequestName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.JitRequestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.JitRequestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.JitRequestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.JitRequestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.JitRequestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> Update(Azure.ResourceManager.Resources.Models.JitRequestPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.JitRequestPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourcesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult> BicepDecompile(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>> BicepDecompileAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult> CalculateDeploymentTemplateHash(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult>> CalculateDeploymentTemplateHashAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> GetArmApplication(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> GetArmApplicationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> GetArmApplicationDefinition(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> GetArmApplicationDefinitionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplicationDefinitionResource GetArmApplicationDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplicationDefinitionCollection GetArmApplicationDefinitions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplicationResource GetArmApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplicationCollection GetArmApplications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.ArmApplicationResource> GetArmApplications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmApplicationResource> GetArmApplicationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentResource GetArmDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetArmDeploymentScript(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> GetArmDeploymentScriptAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentScriptResource GetArmDeploymentScriptResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentScriptCollection GetArmDeploymentScripts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetArmDeploymentScripts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetArmDeploymentScriptsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DataBoundaryCollection GetDataBoundaries(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource> GetDataBoundary(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource>> GetDataBoundaryAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DataBoundaryResource GetDataBoundaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackResource GetDeploymentStackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> GetJitRequest(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> GetJitRequestAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.JitRequestResource> GetJitRequestDefinitions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.JitRequestResource> GetJitRequestDefinitionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.JitRequestResource GetJitRequestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.JitRequestCollection GetJitRequests(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.ScriptLogResource GetScriptLogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> GetTemplateSpec(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> GetTemplateSpecAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecResource GetTemplateSpecResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecCollection GetTemplateSpecs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetTemplateSpecs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetTemplateSpecsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecVersionResource GetTemplateSpecVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.TenantDataBoundaryCollection GetTenantDataBoundaries(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource> GetTenantDataBoundary(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource>> GetTenantDataBoundaryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.TenantDataBoundaryResource GetTenantDataBoundaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ScriptLogData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ScriptLogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>
    {
        public ScriptLogData() { }
        public string Log { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ScriptLogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ScriptLogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ScriptLogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ScriptLogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptLogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ScriptLogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptLogResource() { }
        public virtual Azure.ResourceManager.Resources.ScriptLogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scriptName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ScriptLogResource> Get(int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ScriptLogResource>> GetAsync(int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.ScriptLogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ScriptLogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.ScriptLogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.ScriptLogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.ScriptLogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateSpecCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>, System.Collections.IEnumerable
    {
        protected TemplateSpecCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string templateSpecName, Azure.ResourceManager.Resources.TemplateSpecData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string templateSpecName, Azure.ResourceManager.Resources.TemplateSpecData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> Get(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetAll(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetAllAsync(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> GetAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.TemplateSpecResource> GetIfExists(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.TemplateSpecResource>> GetIfExistsAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TemplateSpecResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TemplateSpecResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TemplateSpecData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>
    {
        public TemplateSpecData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo> Versions { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TemplateSpecData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TemplateSpecData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateSpecResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TemplateSpecResource() { }
        public virtual Azure.ResourceManager.Resources.TemplateSpecData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string templateSpecName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> Get(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> GetAsync(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> GetTemplateSpecVersion(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> GetTemplateSpecVersionAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TemplateSpecVersionCollection GetTemplateSpecVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.TemplateSpecData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TemplateSpecData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> Update(Azure.ResourceManager.Resources.Models.TemplateSpecPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.TemplateSpecPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>, System.Collections.IEnumerable
    {
        protected TemplateSpecVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string templateSpecVersion, Azure.ResourceManager.Resources.TemplateSpecVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string templateSpecVersion, Azure.ResourceManager.Resources.TemplateSpecVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> Get(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpecVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpecVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> GetAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.TemplateSpecVersionResource> GetIfExists(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> GetIfExistsAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TemplateSpecVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TemplateSpecVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TemplateSpecVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>
    {
        public TemplateSpecVersionData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact> LinkedTemplates { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public System.BinaryData MainTemplate { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.BinaryData UiFormDefinition { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TemplateSpecVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TemplateSpecVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateSpecVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TemplateSpecVersionResource() { }
        public virtual Azure.ResourceManager.Resources.TemplateSpecVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string templateSpecName, string templateSpecVersion) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.TemplateSpecVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.TemplateSpecVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.TemplateSpecVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> Update(Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantDataBoundaryCollection : Azure.ResourceManager.ArmCollection
    {
        protected TenantDataBoundaryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TenantDataBoundaryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.DataBoundaryName name, Azure.ResourceManager.Resources.DataBoundaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TenantDataBoundaryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.DataBoundaryName name, Azure.ResourceManager.Resources.DataBoundaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource> Get(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource>> GetAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.TenantDataBoundaryResource> GetIfExists(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.TenantDataBoundaryResource>> GetIfExistsAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantDataBoundaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantDataBoundaryResource() { }
        public virtual Azure.ResourceManager.Resources.DataBoundaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(Azure.ResourceManager.Resources.Models.DataBoundaryName name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DataBoundaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DataBoundaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DataBoundaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DataBoundaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TenantDataBoundaryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DataBoundaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TenantDataBoundaryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DataBoundaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Mocking
{
    public partial class MockableResourcesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesArmClient() { }
        public virtual Azure.ResourceManager.Resources.ArmApplicationDefinitionResource GetArmApplicationDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmApplicationResource GetArmApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentResource GetArmDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentScriptResource GetArmDeploymentScriptResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.DataBoundaryCollection GetDataBoundaries(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource> GetDataBoundary(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DataBoundaryResource>> GetDataBoundaryAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DataBoundaryResource GetDataBoundaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStackResource GetDeploymentStackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.JitRequestResource GetJitRequestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.ScriptLogResource GetScriptLogResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.TemplateSpecResource GetTemplateSpecResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.TemplateSpecVersionResource GetTemplateSpecVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantDataBoundaryResource GetTenantDataBoundaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourcesManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks() { throw null; }
    }
    public partial class MockableResourcesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource> GetArmApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationResource>> GetArmApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource> GetArmApplicationDefinition(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplicationDefinitionResource>> GetArmApplicationDefinitionAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmApplicationDefinitionCollection GetArmApplicationDefinitions() { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmApplicationCollection GetArmApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetArmDeploymentScript(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentScriptResource>> GetArmDeploymentScriptAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentScriptCollection GetArmDeploymentScripts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> GetJitRequest(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> GetJitRequestAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.JitRequestCollection GetJitRequests() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> GetTemplateSpec(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> GetTemplateSpecAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TemplateSpecCollection GetTemplateSpecs() { throw null; }
    }
    public partial class MockableResourcesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult> BicepDecompile(Azure.ResourceManager.Resources.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>> BicepDecompileAsync(Azure.ResourceManager.Resources.Models.DecompileOperationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmApplicationResource> GetArmApplications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmApplicationResource> GetArmApplicationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetArmDeploymentScripts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmDeploymentScriptResource> GetArmDeploymentScriptsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.JitRequestResource> GetJitRequestDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.JitRequestResource> GetJitRequestDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetTemplateSpecs(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetTemplateSpecsAsync(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourcesTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult> CalculateDeploymentTemplateHash(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult>> CalculateDeploymentTemplateHashAsync(System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource> GetArmDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmDeploymentResource>> GetArmDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ArmDeploymentCollection GetArmDeployments() { throw null; }
        public virtual Azure.ResourceManager.Resources.TenantDataBoundaryCollection GetTenantDataBoundaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource> GetTenantDataBoundary(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TenantDataBoundaryResource>> GetTenantDataBoundaryAsync(Azure.ResourceManager.Resources.Models.DataBoundaryName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class ActionOnUnmanage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>
    {
        public ActionOnUnmanage(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum resources) { }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum? ManagementGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum? ResourceGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum Resources { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ActionOnUnmanage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ActionOnUnmanage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationArtifact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact>
    {
        internal ArmApplicationArtifact() { }
        public Azure.ResourceManager.Resources.Models.ArmApplicationArtifactType ArtifactType { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName Name { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationArtifact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationArtifact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmApplicationArtifactName : System.IEquatable<Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmApplicationArtifactName(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName Authorizations { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName CustomRoleDefinition { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName ViewDefinition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName left, Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName left, Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ArmApplicationArtifactType
    {
        NotSpecified = 0,
        Template = 1,
        Custom = 2,
    }
    public partial class ArmApplicationAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization>
    {
        public ArmApplicationAuthorization(System.Guid principalId, string roleDefinitionId) { }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationDefinitionArtifact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact>
    {
        public ArmApplicationDefinitionArtifact(Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName name, System.Uri uri, Azure.ResourceManager.Resources.Models.ArmApplicationArtifactType artifactType) { }
        public Azure.ResourceManager.Resources.Models.ArmApplicationArtifactType ArtifactType { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmApplicationDefinitionArtifactName : System.IEquatable<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmApplicationDefinitionArtifactName(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName ApplicationResourceTemplate { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName CreateUiDefinition { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName MainTemplateParameters { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName left, Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName left, Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmApplicationDeploymentMode : System.IEquatable<Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmApplicationDeploymentMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode Complete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode Incremental { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode left, Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode left, Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmApplicationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDetails>
    {
        internal ArmApplicationDetails() { }
        public System.Guid? ApplicationId { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public string Puid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationJitAccessPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy>
    {
        public ArmApplicationJitAccessPolicy(bool jitAccessEnabled) { }
        public bool JitAccessEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitApprovalMode? JitApprovalMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.JitApprover> JitApprovers { get { throw null; } }
        public System.TimeSpan? MaximumJitAccessDuration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ArmApplicationLockLevel
    {
        None = 0,
        CanNotDelete = 1,
        ReadOnly = 2,
    }
    public partial class ArmApplicationManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity>
    {
        public ArmApplicationManagedIdentity() { }
        public Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentityType? IdentityType { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ArmApplicationManagedIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmApplicationManagementMode : System.IEquatable<Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmApplicationManagementMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode Managed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode left, Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode left, Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmApplicationNotificationEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint>
    {
        public ArmApplicationNotificationEndpoint(System.Uri uri) { }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationPackageContact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact>
    {
        internal ArmApplicationPackageContact() { }
        public string ContactName { get { throw null; } }
        public string Email { get { throw null; } }
        public string Phone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationPackageLockingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy>
    {
        public ArmApplicationPackageLockingPolicy() { }
        public System.Collections.Generic.IList<string> AllowedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedDataActions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationPackageSupportUris : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris>
    {
        internal ArmApplicationPackageSupportUris() { }
        public System.Uri AzureGovernmentUri { get { throw null; } }
        public System.Uri AzurePublicCloudUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationPatch : Azure.ResourceManager.Resources.Models.ArmApplicationResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPatch>
    {
        public ArmApplicationPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization> Authorizations { get { throw null; } }
        public string BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode? ManagementMode { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris SupportUris { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationDetails UpdatedBy { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy>
    {
        public ArmApplicationPolicy() { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationResourceData>
    {
        public ArmApplicationResourceData(Azure.Core.AzureLocation location) { }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmApplicationSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationSku>
    {
        public ArmApplicationSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmApplicationUserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity>
    {
        public ArmApplicationUserAssignedIdentity() { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>
    {
        internal ArmDependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.BasicArmDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>
    {
        public ArmDeploymentContent(Azure.ResourceManager.Resources.Models.ArmDeploymentProperties properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>
    {
        internal ArmDeploymentExportResult() { }
        public System.BinaryData Template { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ArmDeploymentMode
    {
        Incremental = 0,
        Complete = 1,
    }
    public partial class ArmDeploymentOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>
    {
        internal ArmDeploymentOperation() { }
        public string Id { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>
    {
        internal ArmDeploymentOperationProperties() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProvisioningOperationKind? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.BinaryData RequestContent { get { throw null; } }
        public System.BinaryData ResponseContent { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StatusMessage StatusMessage { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>
    {
        public ArmDeploymentParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>
    {
        public ArmDeploymentProperties(Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode) { }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ErrorDeployment ErrorDeployment { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? ExpressionEvaluationScope { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentMode Mode { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink ParametersLink { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink TemplateLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ValidationLevel? ValidationLevel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentPropertiesExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>
    {
        internal ArmDeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmDependency> Dependencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended ErrorDeployment { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentMode? Mode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> OutputResources { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.ResourceProviderData> Providers { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ValidationLevel? ValidationLevel { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentScriptManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity>
    {
        public ArmDeploymentScriptManagedIdentity() { }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType? IdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArmDeploymentScriptManagedIdentityType : System.IEquatable<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArmDeploymentScriptManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType left, Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType left, Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmDeploymentScriptPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch>
    {
        public ArmDeploymentScriptPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentTemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>
    {
        public ArmDeploymentTemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentValidateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>
    {
        internal ArmDeploymentValidateResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentWhatIfContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>
    {
        public ArmDeploymentWhatIfContent(Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties properties) { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ArmDeploymentWhatIfProperties : Azure.ResourceManager.Resources.Models.ArmDeploymentProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>
    {
        public ArmDeploymentWhatIfProperties(Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode) : base (default(Azure.ResourceManager.Resources.Models.ArmDeploymentMode)) { }
        public Azure.ResourceManager.Resources.Models.WhatIfResultFormat? WhatIfResultFormat { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourcesModelFactory
    {
        public static Azure.ResourceManager.Resources.Models.ArmApplicationArtifact ArmApplicationArtifact(Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName name = default(Azure.ResourceManager.Resources.Models.ArmApplicationArtifactName), System.Uri uri = null, Azure.ResourceManager.Resources.Models.ArmApplicationArtifactType artifactType = Azure.ResourceManager.Resources.Models.ArmApplicationArtifactType.NotSpecified) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplicationData ArmApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string managedBy = null, Azure.ResourceManager.Resources.Models.ArmApplicationSku sku = null, Azure.ResourceManager.Models.ArmPlan plan = null, string kind = null, Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity identity = null, Azure.Core.ResourceIdentifier managedResourceGroupId = null, Azure.Core.ResourceIdentifier applicationDefinitionId = null, System.BinaryData parameters = null, System.BinaryData outputs = null, Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState?), string billingDetailsResourceUsageId = null, Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy jitAccessPolicy = null, System.Guid? publisherTenantId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization> authorizations = null, Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode? managementMode = default(Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode?), Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact customerSupport = null, Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris supportUris = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact> artifacts = null, Azure.ResourceManager.Resources.Models.ArmApplicationDetails createdBy = null, Azure.ResourceManager.Resources.Models.ArmApplicationDetails updatedBy = null) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplicationDefinitionData ArmApplicationDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string managedBy = null, Azure.ResourceManager.Resources.Models.ArmApplicationSku sku = null, Azure.ResourceManager.Resources.Models.ArmApplicationLockLevel lockLevel = Azure.ResourceManager.Resources.Models.ArmApplicationLockLevel.None, string displayName = null, bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization> authorizations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationDefinitionArtifact> artifacts = null, string description = null, System.Uri packageFileUri = null, System.BinaryData mainTemplate = null, System.BinaryData createUiDefinition = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationNotificationEndpoint> notificationEndpoints = null, Azure.ResourceManager.Resources.Models.ArmApplicationPackageLockingPolicy lockingPolicy = null, Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode? deploymentMode = default(Azure.ResourceManager.Resources.Models.ArmApplicationDeploymentMode?), Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode? managementMode = default(Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationPolicy> policies = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationDetails ArmApplicationDetails(System.Guid? objectId = default(System.Guid?), string puid = null, System.Guid? applicationId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity ArmApplicationManagedIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentityType? identityType = default(Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact ArmApplicationPackageContact(string contactName = null, string email = null, string phone = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris ArmApplicationPackageSupportUris(System.Uri azurePublicCloudUri = null, System.Uri azureGovernmentUri = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationPatch ArmApplicationPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string managedBy = null, Azure.ResourceManager.Resources.Models.ArmApplicationSku sku = null, Azure.ResourceManager.Models.ArmPlan plan = null, string kind = null, Azure.ResourceManager.Resources.Models.ArmApplicationManagedIdentity identity = null, Azure.Core.ResourceIdentifier managedResourceGroupId = null, Azure.Core.ResourceIdentifier applicationDefinitionId = null, System.BinaryData parameters = null, System.BinaryData outputs = null, Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState?), string billingDetailsResourceUsageId = null, Azure.ResourceManager.Resources.Models.ArmApplicationJitAccessPolicy jitAccessPolicy = null, System.Guid? publisherTenantId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationAuthorization> authorizations = null, Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode? managementMode = default(Azure.ResourceManager.Resources.Models.ArmApplicationManagementMode?), Azure.ResourceManager.Resources.Models.ArmApplicationPackageContact customerSupport = null, Azure.ResourceManager.Resources.Models.ArmApplicationPackageSupportUris supportUris = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmApplicationArtifact> artifacts = null, Azure.ResourceManager.Resources.Models.ArmApplicationDetails createdBy = null, Azure.ResourceManager.Resources.Models.ArmApplicationDetails updatedBy = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationResourceData ArmApplicationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string managedBy = null, Azure.ResourceManager.Resources.Models.ArmApplicationSku sku = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmApplicationUserAssignedIdentity ArmApplicationUserAssignedIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDependency ArmDependency(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.BasicArmDependency> dependsOn = null, string id = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentContent ArmDeploymentContent(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Models.ArmDeploymentProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentData ArmDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentExportResult ArmDeploymentExportResult(System.BinaryData template = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentOperation ArmDeploymentOperation(string id = null, string operationId = null, Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentOperationProperties ArmDeploymentOperationProperties(Azure.ResourceManager.Resources.Models.ProvisioningOperationKind? provisioningOperation = default(Azure.ResourceManager.Resources.Models.ProvisioningOperationKind?), string provisioningState = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), string serviceRequestId = null, string statusCode = null, Azure.ResourceManager.Resources.Models.StatusMessage statusMessage = null, Azure.ResourceManager.Resources.Models.TargetResource targetResource = null, System.BinaryData requestContent = null, System.BinaryData responseContent = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentProperties ArmDeploymentProperties(System.BinaryData template, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink, System.BinaryData parameters, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink, Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode, string debugSettingDetailLevel, Azure.ResourceManager.Resources.Models.ErrorDeployment errorDeployment, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? expressionEvaluationScope) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentProperties ArmDeploymentProperties(System.BinaryData template = null, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink = null, Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode = Azure.ResourceManager.Resources.Models.ArmDeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Models.ErrorDeployment errorDeployment = null, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? expressionEvaluationScope = default(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope?), Azure.ResourceManager.Resources.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Models.ValidationLevel?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended ArmDeploymentPropertiesExtended(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? provisioningState, string correlationId, System.DateTimeOffset? timestamp, System.TimeSpan? duration, System.BinaryData outputs, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceProviderData> providers, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmDependency> dependencies, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink, System.BinaryData parameters, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink, Azure.ResourceManager.Resources.Models.ArmDeploymentMode? mode, string debugSettingDetailLevel, Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended errorDeployment, string templateHash, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> outputResources, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> validatedResources, Azure.ResponseError error) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended ArmDeploymentPropertiesExtended(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState?), string correlationId = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.TimeSpan? duration = default(System.TimeSpan?), System.BinaryData outputs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ResourceProviderData> providers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ArmDependency> dependencies = null, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink = null, Azure.ResourceManager.Resources.Models.ArmDeploymentMode? mode = default(Azure.ResourceManager.Resources.Models.ArmDeploymentMode?), string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended errorDeployment = null, string templateHash = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> outputResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> validatedResources = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> diagnostics = null, Azure.ResourceManager.Resources.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Models.ValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources.ArmDeploymentScriptData ArmDeploymentScriptData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity identity = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity ArmDeploymentScriptManagedIdentity(Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType? identityType = default(Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentityType?), System.Guid? tenantId = default(System.Guid?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentScriptPatch ArmDeploymentScriptPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult ArmDeploymentValidateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResponseError error = null, Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended properties = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentValidateResult ArmDeploymentValidateResult(Azure.ResponseError error, Azure.ResourceManager.Resources.Models.ArmDeploymentPropertiesExtended properties) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfContent ArmDeploymentWhatIfContent(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties ArmDeploymentWhatIfProperties(System.BinaryData template = null, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink = null, System.BinaryData parameters = null, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink = null, Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode = Azure.ResourceManager.Resources.Models.ArmDeploymentMode.Incremental, string debugSettingDetailLevel = null, Azure.ResourceManager.Resources.Models.ErrorDeployment errorDeployment = null, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? expressionEvaluationScope = default(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope?), Azure.ResourceManager.Resources.Models.ValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.Models.ValidationLevel?), Azure.ResourceManager.Resources.Models.WhatIfResultFormat? whatIfResultFormat = default(Azure.ResourceManager.Resources.Models.WhatIfResultFormat?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Resources.Models.ArmDeploymentWhatIfProperties ArmDeploymentWhatIfProperties(System.BinaryData template, Azure.ResourceManager.Resources.Models.ArmDeploymentTemplateLink templateLink, System.BinaryData parameters, Azure.ResourceManager.Resources.Models.ArmDeploymentParametersLink parametersLink, Azure.ResourceManager.Resources.Models.ArmDeploymentMode mode, string debugSettingDetailLevel, Azure.ResourceManager.Resources.Models.ErrorDeployment errorDeployment, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope? expressionEvaluationScope, Azure.ResourceManager.Resources.Models.WhatIfResultFormat? whatIfResultFormat) { throw null; }
        public static Azure.ResourceManager.Resources.Models.AzureCliScript AzureCliScript(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity identity = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, string containerGroupName = null, Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration storageAccountSettings = null, Azure.ResourceManager.Resources.Models.ScriptCleanupOptions? cleanupPreference = default(Azure.ResourceManager.Resources.Models.ScriptCleanupOptions?), Azure.ResourceManager.Resources.Models.ScriptProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.ScriptProvisioningState?), Azure.ResourceManager.Resources.Models.ScriptStatus status = null, System.BinaryData outputs = null, System.Uri primaryScriptUri = null, System.Collections.Generic.IEnumerable<System.Uri> supportingScriptUris = null, string scriptContent = null, string arguments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable> environmentVariables = null, string forceUpdateTag = null, System.TimeSpan retentionInterval = default(System.TimeSpan), System.TimeSpan? timeout = default(System.TimeSpan?), string azCliVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.AzurePowerShellScript AzurePowerShellScript(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.ArmDeploymentScriptManagedIdentity identity = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, string containerGroupName = null, Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration storageAccountSettings = null, Azure.ResourceManager.Resources.Models.ScriptCleanupOptions? cleanupPreference = default(Azure.ResourceManager.Resources.Models.ScriptCleanupOptions?), Azure.ResourceManager.Resources.Models.ScriptProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.ScriptProvisioningState?), Azure.ResourceManager.Resources.Models.ScriptStatus status = null, System.BinaryData outputs = null, System.Uri primaryScriptUri = null, System.Collections.Generic.IEnumerable<System.Uri> supportingScriptUris = null, string scriptContent = null, string arguments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable> environmentVariables = null, string forceUpdateTag = null, System.TimeSpan retentionInterval = default(System.TimeSpan), System.TimeSpan? timeout = default(System.TimeSpan?), string azPowerShellVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.BasicArmDependency BasicArmDependency(string id = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Resources.DataBoundaryData DataBoundaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.DataBoundaryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProperties DataBoundaryProperties(Azure.ResourceManager.Resources.Models.DataBoundaryRegion? dataBoundary = default(Azure.ResourceManager.Resources.Models.DataBoundaryRegion?), Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DecompiledFileDefinition DecompiledFileDefinition(string path = null, string contents = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult DecompileOperationSuccessResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition> files = null, string entryPoint = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition DeploymentDiagnosticsDefinition(Azure.ResourceManager.Resources.Models.Level level = default(Azure.ResourceManager.Resources.Models.Level), string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo> additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackData DeploymentStackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResponseError error = null, System.BinaryData template = null, Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink templateLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.DeploymentParameter> parameters = null, Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink parametersLink = null, Azure.ResourceManager.Resources.Models.ActionOnUnmanage actionOnUnmanage = null, string debugSettingDetailLevel = null, bool? bypassStackOutOfSyncError = default(bool?), string deploymentScope = null, string description = null, Azure.ResourceManager.Resources.Models.DenySettings denySettings = null, Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState?), string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> detachedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> deletedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended> failedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ManagedResourceReference> resources = null, string deploymentId = null, System.BinaryData outputs = null, System.TimeSpan? duration = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition DeploymentStackTemplateDefinition(System.BinaryData template = null, Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink templateLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult DeploymentStackValidateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties properties = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo ErrorAdditionalInfo(string errorAdditionalInfoType = null, System.BinaryData info = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended ErrorDeploymentExtended(string provisioningState = null, Azure.ResourceManager.Resources.Models.ErrorDeploymentType? deploymentType = default(Azure.ResourceManager.Resources.Models.ErrorDeploymentType?), string deploymentName = null) { throw null; }
        public static Azure.ResourceManager.Resources.JitRequestData JitRequestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string applicationResourceId = null, System.Guid? publisherTenantId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies> jitAuthorizationPolicies = null, Azure.ResourceManager.Resources.Models.JitSchedulingPolicy jitSchedulingPolicy = null, Azure.ResourceManager.Resources.Models.ResourcesProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState?), Azure.ResourceManager.Resources.Models.JitRequestState? jitRequestState = default(Azure.ResourceManager.Resources.Models.JitRequestState?), Azure.ResourceManager.Resources.Models.ArmApplicationDetails createdBy = null, Azure.ResourceManager.Resources.Models.ArmApplicationDetails updatedBy = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ManagedResourceReference ManagedResourceReference(string id = null, Azure.ResourceManager.Resources.Models.ResourceStatusMode? status = default(Azure.ResourceManager.Resources.Models.ResourceStatusMode?), Azure.ResourceManager.Resources.Models.DenyStatusMode? denyStatus = default(Azure.ResourceManager.Resources.Models.DenyStatusMode?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated ResourceReferenceAutoGenerated(string id = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceReferenceExtended ResourceReferenceExtended(string id = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.ScriptLogData ScriptLogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string log = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ScriptStatus ScriptStatus(string containerInstanceId = null, string storageAccountId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.StatusMessage StatusMessage(string status = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TargetResource TargetResource(string id = null, string resourceName = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TemplateHashResult TemplateHashResult(string minifiedTemplate = null, string templateHash = null) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecData TemplateSpecData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, string description = null, string displayName = null, System.BinaryData metadata = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo> versions = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TemplateSpecPatch TemplateSpecPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecVersionData TemplateSpecVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact> linkedTemplates = null, System.BinaryData metadata = null, System.BinaryData mainTemplate = null, System.BinaryData uiFormDefinition = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo TemplateSpecVersionInfo(string description = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), System.DateTimeOffset? timeModified = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch TemplateSpecVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Resources.Models.WhatIfChange WhatIfChange(string resourceId, Azure.ResourceManager.Resources.Models.WhatIfChangeType changeType, string unsupportedReason, System.BinaryData before, System.BinaryData after, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> delta) { throw null; }
        public static Azure.ResourceManager.Resources.Models.WhatIfChange WhatIfChange(string resourceId = null, string deploymentId = null, string symbolicName = null, System.BinaryData identifiers = null, Azure.ResourceManager.Resources.Models.WhatIfChangeType changeType = Azure.ResourceManager.Resources.Models.WhatIfChangeType.Create, string unsupportedReason = null, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> delta = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Resources.Models.WhatIfOperationResult WhatIfOperationResult(string status, Azure.ResponseError error, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfChange> changes) { throw null; }
        public static Azure.ResourceManager.Resources.Models.WhatIfOperationResult WhatIfOperationResult(string status = null, Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfChange> changes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfChange> potentialChanges = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> diagnostics = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.WhatIfPropertyChange WhatIfPropertyChange(string path = null, Azure.ResourceManager.Resources.Models.WhatIfPropertyChangeType propertyChangeType = Azure.ResourceManager.Resources.Models.WhatIfPropertyChangeType.Create, System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> children = null) { throw null; }
    }
    public partial class AzureCliScript : Azure.ResourceManager.Resources.ArmDeploymentScriptData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzureCliScript>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureCliScript>
    {
        public AzureCliScript(Azure.Core.AzureLocation location, System.TimeSpan retentionInterval, string azCliVersion) : base (default(Azure.Core.AzureLocation)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzCliVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptCleanupOptions? CleanupPreference { get { throw null; } set { } }
        public string ContainerGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.Uri PrimaryScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptStatus Status { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> SupportingScriptUris { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AzureCliScript System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzureCliScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzureCliScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AzureCliScript System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureCliScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureCliScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzureCliScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzurePowerShellScript : Azure.ResourceManager.Resources.ArmDeploymentScriptData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzurePowerShellScript>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzurePowerShellScript>
    {
        public AzurePowerShellScript(Azure.Core.AzureLocation location, System.TimeSpan retentionInterval, string azPowerShellVersion) : base (default(Azure.Core.AzureLocation)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzPowerShellVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptCleanupOptions? CleanupPreference { get { throw null; } set { } }
        public string ContainerGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.Uri PrimaryScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptStatus Status { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> SupportingScriptUris { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AzurePowerShellScript System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzurePowerShellScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.AzurePowerShellScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.AzurePowerShellScript System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzurePowerShellScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzurePowerShellScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.AzurePowerShellScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BasicArmDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>
    {
        internal BasicArmDependency() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.BasicArmDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.BasicArmDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.BasicArmDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoundaryName : System.IEquatable<Azure.ResourceManager.Resources.Models.DataBoundaryName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoundaryName(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DataBoundaryName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DataBoundaryName left, Azure.ResourceManager.Resources.Models.DataBoundaryName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DataBoundaryName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DataBoundaryName left, Azure.ResourceManager.Resources.Models.DataBoundaryName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataBoundaryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataBoundaryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataBoundaryProperties>
    {
        public DataBoundaryProperties() { }
        public Azure.ResourceManager.Resources.Models.DataBoundaryRegion? DataBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DataBoundaryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataBoundaryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DataBoundaryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DataBoundaryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataBoundaryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataBoundaryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DataBoundaryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoundaryProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoundaryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState left, Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState left, Azure.ResourceManager.Resources.Models.DataBoundaryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataBoundaryRegion : System.IEquatable<Azure.ResourceManager.Resources.Models.DataBoundaryRegion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataBoundaryRegion(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryRegion EU { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryRegion Global { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DataBoundaryRegion NotDefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DataBoundaryRegion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DataBoundaryRegion left, Azure.ResourceManager.Resources.Models.DataBoundaryRegion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DataBoundaryRegion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DataBoundaryRegion left, Azure.ResourceManager.Resources.Models.DataBoundaryRegion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DecompiledFileDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition>
    {
        internal DecompiledFileDefinition() { }
        public string Contents { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DecompiledFileDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DecompiledFileDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DecompileOperationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompileOperationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationContent>
    {
        public DecompileOperationContent(string template) { }
        public string Template { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DecompileOperationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompileOperationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompileOperationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DecompileOperationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DecompileOperationSuccessResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>
    {
        internal DecompileOperationSuccessResult() { }
        public string EntryPoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DecompiledFileDefinition> Files { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DecompileOperationSuccessResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DenySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DenySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>
    {
        public DenySettings(Azure.ResourceManager.Resources.Models.DenySettingsMode mode) { }
        public bool? ApplyToChildScopes { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedPrincipals { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DenySettingsMode Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DenySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DenySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DenySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DenySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DenySettingsMode : System.IEquatable<Azure.ResourceManager.Resources.Models.DenySettingsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DenySettingsMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DenySettingsMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenySettingsMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenySettingsMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DenySettingsMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DenySettingsMode left, Azure.ResourceManager.Resources.Models.DenySettingsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DenySettingsMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DenySettingsMode left, Azure.ResourceManager.Resources.Models.DenySettingsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DenyStatusMode : System.IEquatable<Azure.ResourceManager.Resources.Models.DenyStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DenyStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode Inapplicable { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode None { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode NotSupported { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode RemovedBySystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DenyStatusMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DenyStatusMode left, Azure.ResourceManager.Resources.Models.DenyStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DenyStatusMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DenyStatusMode left, Azure.ResourceManager.Resources.Models.DenyStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentDiagnosticsDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>
    {
        internal DeploymentDiagnosticsDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.Level Level { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>
    {
        public DeploymentParameter() { }
        public string DeploymentParameterType { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.KeyVaultParameterReference Reference { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStackProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStackProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState DeletingResources { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState UpdatingDenyAssignments { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Validating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksDeleteDetachEnum : System.IEquatable<Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksDeleteDetachEnum(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum left, Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum left, Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStacksParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>
    {
        public DeploymentStacksParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksTemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>
    {
        public DeploymentStacksTemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackTemplateDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>
    {
        internal DeploymentStackTemplateDefinition() { }
        public System.BinaryData Template { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>
    {
        public DeploymentStackValidateProperties() { }
        public Azure.ResourceManager.Resources.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DenySettings DenySettings { get { throw null; } set { } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.DeploymentParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>
    {
        public DeploymentStackValidateResult() { }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorAdditionalInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>
    {
        internal ErrorAdditionalInfo() { }
        public string ErrorAdditionalInfoType { get { throw null; } }
        public System.BinaryData Info { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorAdditionalInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>
    {
        public ErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ErrorDeploymentType? DeploymentType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDeploymentExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>
    {
        internal ErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ErrorDeploymentType? DeploymentType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ErrorDeploymentExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionEvaluationScope : System.IEquatable<Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionEvaluationScope(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope Inner { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope Outer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope left, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope left, Azure.ResourceManager.Resources.Models.ExpressionEvaluationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitApprovalMode : System.IEquatable<Azure.ResourceManager.Resources.Models.JitApprovalMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitApprovalMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.JitApprovalMode AutoApprove { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitApprovalMode ManualApprove { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitApprovalMode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.JitApprovalMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.JitApprovalMode left, Azure.ResourceManager.Resources.Models.JitApprovalMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.JitApprovalMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.JitApprovalMode left, Azure.ResourceManager.Resources.Models.JitApprovalMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitApprover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitApprover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitApprover>
    {
        public JitApprover(string id) { }
        public Azure.ResourceManager.Resources.Models.JitApproverType? ApproverType { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitApprover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitApprover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitApprover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitApprover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitApprover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitApprover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitApprover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitApproverType : System.IEquatable<Azure.ResourceManager.Resources.Models.JitApproverType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitApproverType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.JitApproverType Group { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitApproverType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.JitApproverType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.JitApproverType left, Azure.ResourceManager.Resources.Models.JitApproverType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.JitApproverType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.JitApproverType left, Azure.ResourceManager.Resources.Models.JitApproverType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitAuthorizationPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies>
    {
        public JitAuthorizationPolicies(System.Guid principalId, string roleDefinitionId) { }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JitRequestPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitRequestPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitRequestPatch>
    {
        public JitRequestPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitRequestPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitRequestPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitRequestPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitRequestPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitRequestPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitRequestPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitRequestPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitRequestState : System.IEquatable<Azure.ResourceManager.Resources.Models.JitRequestState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitRequestState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.JitRequestState Approved { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitRequestState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitRequestState Denied { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitRequestState Expired { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitRequestState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitRequestState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitRequestState Pending { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitRequestState Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.JitRequestState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.JitRequestState left, Azure.ResourceManager.Resources.Models.JitRequestState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.JitRequestState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.JitRequestState left, Azure.ResourceManager.Resources.Models.JitRequestState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JitSchedulingPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitSchedulingPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitSchedulingPolicy>
    {
        public JitSchedulingPolicy(Azure.ResourceManager.Resources.Models.JitSchedulingType schedulingType, System.TimeSpan duration, System.DateTimeOffset startOn) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitSchedulingType SchedulingType { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitSchedulingPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitSchedulingPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.JitSchedulingPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.JitSchedulingPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitSchedulingPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitSchedulingPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.JitSchedulingPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JitSchedulingType : System.IEquatable<Azure.ResourceManager.Resources.Models.JitSchedulingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JitSchedulingType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.JitSchedulingType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitSchedulingType Once { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.JitSchedulingType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.JitSchedulingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.JitSchedulingType left, Azure.ResourceManager.Resources.Models.JitSchedulingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.JitSchedulingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.JitSchedulingType left, Azure.ResourceManager.Resources.Models.JitSchedulingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultParameterReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>
    {
        public KeyVaultParameterReference(Azure.ResourceManager.Resources.Models.WritableSubResource keyVault, string secretName) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.KeyVaultParameterReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.KeyVaultParameterReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Level : System.IEquatable<Azure.ResourceManager.Resources.Models.Level>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Level(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.Level Error { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.Level Info { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.Level Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.Level other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.Level left, Azure.ResourceManager.Resources.Models.Level right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.Level (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.Level left, Azure.ResourceManager.Resources.Models.Level right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedTemplateArtifact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact>
    {
        public LinkedTemplateArtifact(string path, System.BinaryData template) { }
        public string Path { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedResourceReference : Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>
    {
        public ManagedResourceReference() { }
        public Azure.ResourceManager.Resources.Models.DenyStatusMode? DenyStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourceStatusMode? Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagedResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagedResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ProvisioningOperationKind
    {
        NotSpecified = 0,
        Create = 1,
        Delete = 2,
        Waiting = 3,
        AzureAsyncOperationWaiting = 4,
        ResourceCacheWaiting = 5,
        Action = 6,
        Read = 7,
        EvaluateDeploymentOutput = 8,
        DeploymentCleanup = 9,
    }
    public partial class ResourceReferenceAutoGenerated : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>
    {
        public ResourceReferenceAutoGenerated() { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceReferenceExtended : Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>
    {
        public ResourceReferenceExtended() { }
        public Azure.ResponseError Error { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourcesProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourcesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourcesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourcesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState left, Azure.ResourceManager.Resources.Models.ResourcesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourcesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourcesProvisioningState left, Azure.ResourceManager.Resources.Models.ResourcesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatusMode : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourceStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceStatusMode DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceStatusMode Managed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceStatusMode RemoveDenyFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourceStatusMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.Models.ResourceStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourceStatusMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.Models.ResourceStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptCleanupOptions : System.IEquatable<Azure.ResourceManager.Resources.Models.ScriptCleanupOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptCleanupOptions(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ScriptCleanupOptions Always { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptCleanupOptions OnExpiration { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptCleanupOptions OnSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ScriptCleanupOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ScriptCleanupOptions left, Azure.ResourceManager.Resources.Models.ScriptCleanupOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ScriptCleanupOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ScriptCleanupOptions left, Azure.ResourceManager.Resources.Models.ScriptCleanupOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptEnvironmentVariable : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable>
    {
        public ScriptEnvironmentVariable(string name) { }
        public string Name { get { throw null; } set { } }
        public string SecureValue { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptEnvironmentVariable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.ScriptProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState ProvisioningResources { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ScriptProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ScriptProvisioningState left, Azure.ResourceManager.Resources.Models.ScriptProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ScriptProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ScriptProvisioningState left, Azure.ResourceManager.Resources.Models.ScriptProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStatus>
    {
        internal ScriptStatus() { }
        public string ContainerInstanceId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? ExpirationOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ScriptStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ScriptStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScriptStorageConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration>
    {
        public ScriptStorageConfiguration() { }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ScriptStorageConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatusMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.StatusMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>
    {
        internal StatusMessage() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.StatusMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.StatusMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.StatusMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TargetResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>
    {
        internal TargetResource() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TargetResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TargetResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TargetResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TargetResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TargetResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateHashResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>
    {
        internal TemplateHashResult() { }
        public string MinifiedTemplate { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateHashResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateHashResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateHashResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateSpecExpandKind : System.IEquatable<Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateSpecExpandKind(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind Versions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind left, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind left, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemplateSpecPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecPatch>
    {
        public TemplateSpecPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateSpecPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateSpecPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateSpecVersionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo>
    {
        internal TemplateSpecVersionInfo() { }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeModified { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateSpecVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch>
    {
        public TemplateSpecVersionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.TemplateSpecVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionManagementGroupMode : System.IEquatable<Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionManagementGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceGroupMode : System.IEquatable<Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceMode : System.IEquatable<Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationLevel : System.IEquatable<Azure.ResourceManager.Resources.Models.ValidationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ValidationLevel Provider { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ValidationLevel ProviderNoRbac { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ValidationLevel Template { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ValidationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ValidationLevel left, Azure.ResourceManager.Resources.Models.ValidationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ValidationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ValidationLevel left, Azure.ResourceManager.Resources.Models.ValidationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WhatIfChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>
    {
        internal WhatIfChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WhatIfChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Delta { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        public string UnsupportedReason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WhatIfChangeType
    {
        Create = 0,
        Delete = 1,
        Ignore = 2,
        Deploy = 3,
        NoChange = 4,
        Modify = 5,
        Unsupported = 6,
    }
    public partial class WhatIfOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>
    {
        internal WhatIfOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfChange> Changes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.DeploymentDiagnosticsDefinition> Diagnostics { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfChange> PotentialChanges { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WhatIfPropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>
    {
        internal WhatIfPropertyChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.WhatIfPropertyChangeType PropertyChangeType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfPropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.WhatIfPropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WhatIfPropertyChangeType
    {
        Create = 0,
        Delete = 1,
        Modify = 2,
        Array = 3,
        NoEffect = 4,
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
}
