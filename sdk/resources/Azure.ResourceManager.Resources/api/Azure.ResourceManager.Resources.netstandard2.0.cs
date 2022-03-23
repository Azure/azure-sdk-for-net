namespace Azure.ResourceManager.Resources
{
<<<<<<< HEAD
    public partial class ApplicationDefinition : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationDefinition() { }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDefinitionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ApplicationDefinition>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ApplicationDefinition>, System.Collections.IEnumerable
=======
    public partial class ApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ApplicationResource>, System.Collections.IEnumerable
    {
        protected ApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Resources.ApplicationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Resources.ApplicationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationData : Azure.ResourceManager.Resources.Models.ApplicationResource
    {
        public ApplicationData(Azure.Core.AzureLocation location, string kind) : base (default(Azure.Core.AzureLocation)) { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public string BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementMode? ManagementMode { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageSupportUrls SupportUrls { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
    }
    public partial class ApplicationDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ApplicationDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ApplicationDefinitionResource>, System.Collections.IEnumerable
>>>>>>> ac26fe3cdb1f0f614cbd1bd9ba2a7ae2cdffe46b
    {
        protected ApplicationDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ApplicationDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationDefinitionName, Azure.ResourceManager.Resources.ApplicationDefinitionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationDefinitionName, Azure.ResourceManager.Resources.ApplicationDefinitionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource> Get(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ApplicationDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ApplicationDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> GetAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource> GetIfExists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> GetIfExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ApplicationDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ApplicationDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ApplicationDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ApplicationDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationDefinitionData : Azure.ResourceManager.Resources.Models.ApplicationResource
    {
        public ApplicationDefinitionData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ApplicationLockLevel lockLevel) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public System.BinaryData CreateUiDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentMode DeploymentMode { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LockingAllowedActions { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationLockLevel LockLevel { get { throw null; } set { } }
        public System.BinaryData MainTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementMode? ManagementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationNotificationEndpoint> NotificationEndpoints { get { throw null; } set { } }
        public System.Uri PackageFileUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationPolicy> Policies { get { throw null; } }
    }
<<<<<<< HEAD
    public partial class ArmApplication : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmApplication() { }
        public virtual Azure.ResourceManager.Resources.ArmApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplication> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplication> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshPermissions(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshPermissionsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplication> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplication> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplication> Update(Azure.ResourceManager.Resources.Models.PatchableArmApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> UpdateAsync(Azure.ResourceManager.Resources.Models.PatchableArmApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArmApplicationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmApplication>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmApplication>, System.Collections.IEnumerable
    {
        protected ArmApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplication> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Resources.ArmApplicationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.ArmApplication>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.Resources.ArmApplicationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplication> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ArmApplication> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmApplication> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ArmApplication> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ArmApplication> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ArmApplication>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ArmApplication> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ArmApplication>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmApplicationData : Azure.ResourceManager.Resources.Models.ApplicationResource
    {
        public ArmApplicationData(Azure.Core.AzureLocation location, string kind) : base (default(Azure.Core.AzureLocation)) { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public string BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementMode? ManagementMode { get { throw null; } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageSupportUrls SupportUrls { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
    }
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Resources.ApplicationDefinition GetApplicationDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplication GetArmApplication(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.Deployment GetDeployment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentScript GetDeploymentScript(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.JitRequest GetJitRequest(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ScriptLog GetScriptLog(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpec GetTemplateSpec(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecVersion GetTemplateSpecVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
=======
    public partial class ApplicationDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
>>>>>>> ac26fe3cdb1f0f614cbd1bd9ba2a7ae2cdffe46b
    }
    public partial class ApplicationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationResource() { }
        public virtual Azure.ResourceManager.Resources.ApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshPermissions(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshPermissionsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> Update(Azure.ResourceManager.Resources.Models.PatchableApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.PatchableApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentResource>, System.Collections.IEnumerable
    {
        protected DeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentData : Azure.ResourceManager.Models.ResourceData
    {
        internal DeploymentData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentResource() { }
        public virtual Azure.ResourceManager.Resources.DeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistence(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetDeploymentOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation>> GetDeploymentOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetDeploymentOperations(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetDeploymentOperationsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult> WhatIf(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WhatIfAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.DeploymentWhatIf parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentScriptResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentScriptResource>, System.Collections.IEnumerable
    {
        protected DeploymentScriptCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentScriptResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Resources.DeploymentScriptData deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentScriptResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Resources.DeploymentScriptData deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> Get(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentScriptResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentScriptResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> GetAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> GetIfExists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> GetIfExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentScriptResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentScriptResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentScriptResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentScriptResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentScriptData : Azure.ResourceManager.Models.ResourceData
    {
        public DeploymentScriptData(string location) { }
        public Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeploymentScriptResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentScriptResource() { }
        public virtual Azure.ResourceManager.Resources.DeploymentScriptData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scriptName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ScriptLogResource> GetLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ScriptLogResource> GetLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ScriptLogResource GetScriptLog() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> Update(Azure.ResourceManager.Resources.Models.PatchableDeploymentScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.PatchableDeploymentScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JitRequestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.JitRequestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.JitRequestResource>, System.Collections.IEnumerable
    {
        protected JitRequestCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.JitRequestResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jitRequestName, Azure.ResourceManager.Resources.JitRequestData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.JitRequestResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jitRequestName, Azure.ResourceManager.Resources.JitRequestData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> Get(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.JitRequestResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.JitRequestResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> GetAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequestResource> GetIfExists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequestResource>> GetIfExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.JitRequestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.JitRequestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.JitRequestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.JitRequestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JitRequestData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public JitRequestData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ApplicationResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.JitAuthorizationPolicies> JitAuthorizationPolicies { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.JitRequestState? JitRequestState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.JitSchedulingPolicy JitSchedulingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
    }
<<<<<<< HEAD
    public static partial class ManagementGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Deployment> GetDeployment(this Azure.ResourceManager.Management.ManagementGroup managementGroup, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployment>> GetDeploymentAsync(this Azure.ResourceManager.Management.ManagementGroup managementGroup, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Management.ManagementGroup managementGroup) { throw null; }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> GetApplicationDefinition(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> GetApplicationDefinitionAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.ApplicationDefinitionCollection GetApplicationDefinitions(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ArmApplication> GetArmApplication(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ArmApplication>> GetArmApplicationAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.ArmApplicationCollection GetArmApplications(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Deployment> GetDeployment(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployment>> GetDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentScript> GetDeploymentScript(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScript>> GetDeploymentScriptAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentScriptCollection GetDeploymentScripts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.JitRequest> GetJitRequest(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> GetJitRequestAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.JitRequestCollection GetJitRequests(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.TemplateSpec> GetTemplateSpec(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpec>> GetTemplateSpecAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecCollection GetTemplateSpecs(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ScriptLog : Azure.ResourceManager.Core.ArmResource
=======
    public partial class JitRequestResource : Azure.ResourceManager.ArmResource
>>>>>>> ac26fe3cdb1f0f614cbd1bd9ba2a7ae2cdffe46b
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
    }
    public static partial class ResourcesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult> CalculateDeploymentTemplateHash(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult>> CalculateDeploymentTemplateHashAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.BinaryData template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ApplicationResource> GetApplication(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationResource>> GetApplicationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource> GetApplicationDefinition(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinitionResource>> GetApplicationDefinitionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.ApplicationDefinitionResource GetApplicationDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ApplicationDefinitionCollection GetApplicationDefinitions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.ApplicationResource GetApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ApplicationCollection GetApplications(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.ApplicationResource> GetApplications(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.ApplicationResource> GetApplicationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> GetDeployment(this Azure.ResourceManager.Management.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> GetDeployment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> GetDeployment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentResource> GetDeployment(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.Management.ManagementGroupResource managementGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentResource>> GetDeploymentAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentResource GetDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Management.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource> GetDeploymentScript(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScriptResource>> GetDeploymentScriptAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentScriptResource GetDeploymentScriptResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentScriptCollection GetDeploymentScripts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.DeploymentScriptResource> GetDeploymentScripts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentScriptResource> GetDeploymentScriptsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    }
    public partial class ScriptLogData : Azure.ResourceManager.Models.ResourceData
    {
        public ScriptLogData() { }
        public string Log { get { throw null; } }
    }
<<<<<<< HEAD
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Resources.ArmApplication> GetArmApplications(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.ArmApplication> GetArmApplicationsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Deployment> GetDeployment(this Azure.ResourceManager.Resources.Subscription subscription, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployment>> GetDeploymentAsync(this Azure.ResourceManager.Resources.Subscription subscription, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.DeploymentScript> GetDeploymentScripts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentScript> GetDeploymentScriptsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.JitRequest> GetJitRequestDefinitions(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.JitRequest> GetJitRequestDefinitionsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpec> GetTemplateSpecs(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpec> GetTemplateSpecsAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpec : Azure.ResourceManager.Core.ArmResource
=======
    public partial class ScriptLogResource : Azure.ResourceManager.ArmResource
>>>>>>> ac26fe3cdb1f0f614cbd1bd9ba2a7ae2cdffe46b
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptLogResource() { }
        public virtual Azure.ResourceManager.Resources.ScriptLogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scriptName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ScriptLogResource> Get(int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ScriptLogResource>> GetAsync(int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>, System.Collections.IEnumerable
    {
        protected TemplateSpecCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string templateSpecName, Azure.ResourceManager.Resources.TemplateSpecData templateSpec, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string templateSpecName, Azure.ResourceManager.Resources.TemplateSpecData templateSpec, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> Get(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetAll(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpecResource> GetAllAsync(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> GetAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> GetIfExists(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> GetIfExistsAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TemplateSpecResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TemplateSpecResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TemplateSpecData : Azure.ResourceManager.Models.ResourceData
    {
        public TemplateSpecData(string location) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo> Versions { get { throw null; } }
    }
    public partial class TemplateSpecResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource> Update(Azure.ResourceManager.Resources.Models.PatchableTemplateSpecData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.PatchableTemplateSpecData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>, System.Collections.IEnumerable
    {
        protected TemplateSpecVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string templateSpecVersion, Azure.ResourceManager.Resources.TemplateSpecVersionData templateSpecVersionModel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string templateSpecVersion, Azure.ResourceManager.Resources.TemplateSpecVersionData templateSpecVersionModel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> Get(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpecVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpecVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> GetAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> GetIfExists(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> GetIfExistsAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TemplateSpecVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TemplateSpecVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TemplateSpecVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public TemplateSpecVersionData(string location) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact> LinkedTemplates { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public System.BinaryData MainTemplate { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.BinaryData UiFormDefinition { get { throw null; } set { } }
    }
    public partial class TemplateSpecVersionResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource> Update(Azure.ResourceManager.Resources.Models.PatchableTemplateSpecVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersionResource>> UpdateAsync(Azure.ResourceManager.Resources.Models.PatchableTemplateSpecVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class ApplicationArtifact
    {
        internal ApplicationArtifact() { }
        public Azure.ResourceManager.Resources.Models.ApplicationArtifactType ApplicationArtifactType { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationArtifactName Name { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationArtifactName : System.IEquatable<Azure.ResourceManager.Resources.Models.ApplicationArtifactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationArtifactName(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ApplicationArtifactName Authorizations { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationArtifactName CustomRoleDefinition { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationArtifactName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationArtifactName ViewDefinition { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ApplicationArtifactName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ApplicationArtifactName left, Azure.ResourceManager.Resources.Models.ApplicationArtifactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ApplicationArtifactName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ApplicationArtifactName left, Azure.ResourceManager.Resources.Models.ApplicationArtifactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ApplicationArtifactType
    {
        NotSpecified = 0,
        Template = 1,
        Custom = 2,
    }
    public partial class ApplicationAuthorization
    {
        public ApplicationAuthorization(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class ApplicationClientDetails
    {
        internal ApplicationClientDetails() { }
        public string ApplicationId { get { throw null; } }
        public string Oid { get { throw null; } }
        public string Puid { get { throw null; } }
    }
    public partial class ApplicationDefinitionArtifact
    {
        public ApplicationDefinitionArtifact(Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName name, System.Uri uri, Azure.ResourceManager.Resources.Models.ApplicationArtifactType applicationArtifactType) { }
        public Azure.ResourceManager.Resources.Models.ApplicationArtifactType ApplicationArtifactType { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName Name { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationDefinitionArtifactName : System.IEquatable<Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationDefinitionArtifactName(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName ApplicationResourceTemplate { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName CreateUiDefinition { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName MainTemplateParameters { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName left, Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName left, Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationJitAccessPolicy
    {
        public ApplicationJitAccessPolicy(bool jitAccessEnabled) { }
        public bool JitAccessEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitApprovalMode? JitApprovalMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.JitApprover> JitApprovers { get { throw null; } }
        public System.TimeSpan? MaximumJitAccessDuration { get { throw null; } set { } }
    }
    public enum ApplicationLockLevel
    {
        None = 0,
        CanNotDelete = 1,
        ReadOnly = 2,
    }
    public partial class ApplicationManagedIdentity
    {
        public ApplicationManagedIdentity() { }
        public Azure.ResourceManager.Resources.Models.ApplicationManagedIdentityType? ApplicationManagedIdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedResourceIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public enum ApplicationManagedIdentityType
    {
        None = 0,
        SystemAssigned = 1,
        UserAssigned = 2,
        SystemAssignedUserAssigned = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationManagementMode : System.IEquatable<Azure.ResourceManager.Resources.Models.ApplicationManagementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationManagementMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ApplicationManagementMode Managed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationManagementMode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ApplicationManagementMode Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ApplicationManagementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ApplicationManagementMode left, Azure.ResourceManager.Resources.Models.ApplicationManagementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ApplicationManagementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ApplicationManagementMode left, Azure.ResourceManager.Resources.Models.ApplicationManagementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationNotificationEndpoint
    {
        public ApplicationNotificationEndpoint(System.Uri uri) { }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ApplicationPackageContact
    {
        internal ApplicationPackageContact() { }
        public string ContactName { get { throw null; } }
        public string Email { get { throw null; } }
        public string Phone { get { throw null; } }
    }
    public partial class ApplicationPackageSupportUrls
    {
        internal ApplicationPackageSupportUrls() { }
        public string GovernmentCloud { get { throw null; } }
        public string PublicAzure { get { throw null; } }
    }
    public partial class ApplicationPolicy
    {
        public ApplicationPolicy() { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } set { } }
    }
    public partial class ApplicationResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicationResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationSku Sku { get { throw null; } set { } }
    }
    public partial class ApplicationSku
    {
        public ApplicationSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class ArmDependency
    {
        internal ArmDependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.BasicDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class AzureCliScript : Azure.ResourceManager.Resources.DeploymentScriptData
    {
        public AzureCliScript(string location, System.TimeSpan retentionInterval, string azCliVersion) : base (default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzCliVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public string ContainerGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Outputs { get { throw null; } }
        public System.Uri PrimaryScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptStatus Status { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class AzurePowerShellScript : Azure.ResourceManager.Resources.DeploymentScriptData
    {
        public AzurePowerShellScript(string location, System.TimeSpan retentionInterval, string azPowerShellVersion) : base (default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzPowerShellVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public string ContainerGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Outputs { get { throw null; } }
        public System.Uri PrimaryScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public string ScriptContent { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ScriptStatus Status { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StorageAccountConfiguration StorageAccountSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportingScriptUris { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class BasicDependency
    {
        internal BasicDependency() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum ChangeType
    {
        Create = 0,
        Delete = 1,
        Ignore = 2,
        Deploy = 3,
        NoChange = 4,
        Modify = 5,
        Unsupported = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CleanupOptions : System.IEquatable<Azure.ResourceManager.Resources.Models.CleanupOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CleanupOptions(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.CleanupOptions Always { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CleanupOptions OnExpiration { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CleanupOptions OnSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.CleanupOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.CleanupOptions left, Azure.ResourceManager.Resources.Models.CleanupOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.CleanupOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.CleanupOptions left, Azure.ResourceManager.Resources.Models.CleanupOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentExportResult
    {
        internal DeploymentExportResult() { }
        public System.BinaryData Template { get { throw null; } }
    }
    public partial class DeploymentInput
    {
        public DeploymentInput(Azure.ResourceManager.Resources.Models.DeploymentProperties properties) { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentMode : System.IEquatable<Azure.ResourceManager.Resources.Models.DeploymentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentMode Complete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentMode Incremental { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentMode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DeploymentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DeploymentMode left, Azure.ResourceManager.Resources.Models.DeploymentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DeploymentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DeploymentMode left, Azure.ResourceManager.Resources.Models.DeploymentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentOperation
    {
        internal DeploymentOperation() { }
        public string Id { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentOperationProperties Properties { get { throw null; } }
    }
    public partial class DeploymentOperationProperties
    {
        internal DeploymentOperationProperties() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProvisioningOperation? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.BinaryData RequestContent { get { throw null; } }
        public System.BinaryData ResponseContent { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StatusMessage StatusMessage { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DeploymentProperties
    {
        public DeploymentProperties(Azure.ResourceManager.Resources.Models.DeploymentMode mode) { }
        public string DebugDetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType? ExpressionEvaluationScope { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentMode Mode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeployment OnErrorDeployment { get { throw null; } set { } }
        public object Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ParametersLink ParametersLink { get { throw null; } set { } }
        public object Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.TemplateLink TemplateLink { get { throw null; } set { } }
    }
    public partial class DeploymentPropertiesExtended
    {
        internal DeploymentPropertiesExtended() { }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ArmDependency> Dependencies { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentMode? Mode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentExtended OnErrorDeployment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> OutputResources { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.ResourceProviderData> Providers { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
    }
    public partial class DeploymentScriptManagedIdentity
    {
        public DeploymentScriptManagedIdentity() { }
        public Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType? DeploymentScriptManagedIdentityType { get { throw null; } set { } }
        public string TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentScriptManagedIdentityType : System.IEquatable<Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentScriptManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType left, Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType left, Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentValidateResult
    {
        internal DeploymentValidateResult() { }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
    }
    public partial class DeploymentWhatIf
    {
        public DeploymentWhatIf(Azure.ResourceManager.Resources.Models.DeploymentWhatIfProperties properties) { }
        public string Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentWhatIfProperties Properties { get { throw null; } }
    }
    public partial class DeploymentWhatIfProperties : Azure.ResourceManager.Resources.Models.DeploymentProperties
    {
        public DeploymentWhatIfProperties(Azure.ResourceManager.Resources.Models.DeploymentMode mode) : base (default(Azure.ResourceManager.Resources.Models.DeploymentMode)) { }
        public Azure.ResourceManager.Resources.Models.WhatIfResultFormat? WhatIfResultFormat { get { throw null; } set { } }
    }
    public partial class EnvironmentVariable
    {
        public EnvironmentVariable(string name) { }
        public string Name { get { throw null; } set { } }
        public string SecureValue { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionEvaluationOptionsScopeType : System.IEquatable<Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionEvaluationOptionsScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType Inner { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType Outer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType left, Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType left, Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType right) { throw null; }
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
    public partial class JitApprover
    {
        public JitApprover(string id) { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitApproverType? JitApproverType { get { throw null; } set { } }
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
    public partial class JitAuthorizationPolicies
    {
        public JitAuthorizationPolicies(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
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
    public partial class JitSchedulingPolicy
    {
        public JitSchedulingPolicy(Azure.ResourceManager.Resources.Models.JitSchedulingType jitSchedulingType, System.TimeSpan duration, System.DateTimeOffset startTime) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitSchedulingType JitSchedulingType { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
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
    public partial class LinkedTemplateArtifact
    {
        public LinkedTemplateArtifact(string path, System.BinaryData template) { }
        public string Path { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
    }
    public partial class OnErrorDeployment
    {
        public OnErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentType? OnErrorDeploymentType { get { throw null; } set { } }
    }
    public partial class OnErrorDeploymentExtended
    {
        internal OnErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentType? OnErrorDeploymentType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public enum OnErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    public partial class ParametersLink
    {
        public ParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class PatchableArmApplicationData : Azure.ResourceManager.Resources.Models.ApplicationResource
    {
        public PatchableArmApplicationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public string BillingDetailsResourceUsageId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementMode? ManagementMode { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageSupportUrls SupportUrls { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
    }
    public partial class PatchableDeploymentScriptData : Azure.ResourceManager.Models.ResourceData
    {
        public PatchableDeploymentScriptData() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableTemplateSpecData : Azure.ResourceManager.Models.ResourceData
    {
        public PatchableTemplateSpecData() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PatchableTemplateSpecVersionData : Azure.ResourceManager.Models.ResourceData
    {
        public PatchableTemplateSpecVersionData() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum PropertyChangeType
    {
        Create = 0,
        Delete = 1,
        Modify = 2,
        Array = 3,
        NoEffect = 4,
    }
    public enum ProvisioningOperation
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ProvisioningState left, Azure.ResourceManager.Resources.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ProvisioningState left, Azure.ResourceManager.Resources.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ScriptStatus
    {
        internal ScriptStatus() { }
        public string ContainerInstanceId { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public System.DateTimeOffset? ExpirationTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string StorageAccountId { get { throw null; } }
    }
    public partial class StatusMessage
    {
        internal StatusMessage() { }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class StorageAccountConfiguration
    {
        public StorageAccountConfiguration() { }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
    }
    public partial class TargetResource
    {
        internal TargetResource() { }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class TemplateHashResult
    {
        internal TemplateHashResult() { }
        public string MinifiedTemplate { get { throw null; } }
        public string TemplateHash { get { throw null; } }
    }
    public partial class TemplateLink
    {
        public TemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
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
    public partial class TemplateSpecVersionInfo
    {
        internal TemplateSpecVersionInfo() { }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeModified { get { throw null; } }
    }
    public partial class UserAssignedResourceIdentity
    {
        public UserAssignedResourceIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class WhatIfChange
    {
        internal WhatIfChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Delta { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string UnsupportedReason { get { throw null; } }
    }
    public partial class WhatIfOperationResult
    {
        internal WhatIfOperationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfChange> Changes { get { throw null; } }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class WhatIfPropertyChange
    {
        internal WhatIfPropertyChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.WhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.PropertyChangeType PropertyChangeType { get { throw null; } }
    }
    public enum WhatIfResultFormat
    {
        ResourceIdOnly = 0,
        FullResourcePayloads = 1,
    }
}
