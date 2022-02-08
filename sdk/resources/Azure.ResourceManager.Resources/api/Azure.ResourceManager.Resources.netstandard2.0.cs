namespace Azure.ResourceManager.Resources
{
    public partial class Application : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Application() { }
        public virtual Azure.ResourceManager.Resources.ApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Application> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Application>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ApplicationDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ApplicationDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Application> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Application>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ApplicationRefreshPermissionsOperation RefreshPermissions(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ApplicationRefreshPermissionsOperation> RefreshPermissionsAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Application> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Application>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Application> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Application>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Application> Update(Azure.ResourceManager.Resources.Models.ApplicationPatchable parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Application>> UpdateAsync(Azure.ResourceManager.Resources.Models.ApplicationPatchable parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Application>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Application>, System.Collections.IEnumerable
    {
        protected ApplicationCollection() { }
        public virtual Azure.ResourceManager.Resources.Models.ApplicationCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string applicationName, Azure.ResourceManager.Resources.ApplicationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ApplicationCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string applicationName, Azure.ResourceManager.Resources.ApplicationData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Application> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Application> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Application> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Application>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Application> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Application>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Application> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Application>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Application> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Application>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationData : Azure.ResourceManager.Resources.Models.ApplicationResource
    {
        public ApplicationData(Azure.Core.AzureLocation location, string kind) : base (default(Azure.Core.AzureLocation)) { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationBillingDetailsDefinition BillingDetails { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementMode? ManagementMode { get { throw null; } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageSupportUrls SupportUrls { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
    }
    public partial class ApplicationDefinition : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationDefinition() { }
        public virtual Azure.ResourceManager.Resources.ApplicationDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.ApplicationDefinitionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ApplicationDefinitionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDefinitionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ApplicationDefinition>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ApplicationDefinition>, System.Collections.IEnumerable
    {
        protected ApplicationDefinitionCollection() { }
        public virtual Azure.ResourceManager.Resources.Models.ApplicationDefinitionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string applicationDefinitionName, Azure.ResourceManager.Resources.ApplicationDefinitionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.ApplicationDefinitionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string applicationDefinitionName, Azure.ResourceManager.Resources.ApplicationDefinitionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> Get(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ApplicationDefinition> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ApplicationDefinition> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> GetAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition> GetIfExists(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> GetIfExistsAsync(string applicationDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.ApplicationDefinition> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.ApplicationDefinition>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.ApplicationDefinition> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.ApplicationDefinition>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationDefinitionData : Azure.ResourceManager.Resources.Models.ApplicationResource
    {
        public ApplicationDefinitionData(Azure.Core.AzureLocation location, Azure.ResourceManager.Resources.Models.ApplicationLockLevel lockLevel) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public object CreateUiDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationDeploymentPolicy DeploymentPolicy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageLockingPolicyDefinition LockingPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationLockLevel LockLevel { get { throw null; } set { } }
        public object MainTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementPolicy ManagementPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationNotificationPolicy NotificationPolicy { get { throw null; } set { } }
        public System.Uri PackageFileUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationPolicy> Policies { get { throw null; } }
    }
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.Resources.Application GetApplication(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ApplicationDefinition GetApplicationDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.Deployment GetDeployment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentScript GetDeploymentScript(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.JitRequest GetJitRequest(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.ScriptLog GetScriptLog(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpec GetTemplateSpec(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecVersion GetTemplateSpecVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class Deployment : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Deployment() { }
        public virtual Azure.ResourceManager.Resources.DeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CheckExistence(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CheckExistenceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.DeploymentDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.DeploymentDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentExportResult>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployment> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployment>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetDeploymentOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentOperation>> GetDeploymentOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetDeploymentOperations(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.DeploymentOperation> GetDeploymentOperationsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.DeploymentValidateOperation Validate(bool waitForCompletion, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.DeploymentValidateOperation> ValidateAsync(bool waitForCompletion, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.DeploymentWhatIfOperation WhatIf(bool waitForCompletion, string location, Azure.ResourceManager.Resources.Models.DeploymentWhatIfProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.DeploymentWhatIfOperation> WhatIfAsync(bool waitForCompletion, string location, Azure.ResourceManager.Resources.Models.DeploymentWhatIfProperties properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Deployment>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployment>, System.Collections.IEnumerable
    {
        protected DeploymentCollection() { }
        public virtual Azure.ResourceManager.Resources.Models.DeploymentCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.DeploymentCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string deploymentName, Azure.ResourceManager.Resources.Models.DeploymentInput parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployment> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Deployment> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Deployment> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployment>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Deployment> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Deployment>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Deployment> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Deployment>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Deployment> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Deployment>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentData : Azure.ResourceManager.Models.Resource
    {
        internal DeploymentData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeploymentScript : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentScript() { }
        public virtual Azure.ResourceManager.Resources.DeploymentScriptData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scriptName) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.DeploymentScriptDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.DeploymentScriptDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScript> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScript>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.ScriptLog> GetLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.ScriptLog> GetLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.ScriptLog GetScriptLog() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScript> Update(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScript>> UpdateAsync(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentScript>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentScript>, System.Collections.IEnumerable
    {
        protected DeploymentScriptCollection() { }
        public virtual Azure.ResourceManager.Resources.Models.DeploymentScriptCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string scriptName, Azure.ResourceManager.Resources.DeploymentScriptData deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.DeploymentScriptCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string scriptName, Azure.ResourceManager.Resources.DeploymentScriptData deploymentScript, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScript> Get(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentScript> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentScript> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScript>> GetAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentScript> GetIfExists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentScript>> GetIfExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentScript> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentScript>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentScript> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentScript>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentScriptData : Azure.ResourceManager.Models.Resource
    {
        public DeploymentScriptData(string location) { }
        public Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class JitRequest : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JitRequest() { }
        public virtual Azure.ResourceManager.Resources.JitRequestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequest> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string jitRequestName) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.JitRequestDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.JitRequestDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequest> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequest> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequest> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequest> Update(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> UpdateAsync(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JitRequestCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.JitRequest>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.JitRequest>, System.Collections.IEnumerable
    {
        protected JitRequestCollection() { }
        public virtual Azure.ResourceManager.Resources.Models.JitRequestCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string jitRequestName, Azure.ResourceManager.Resources.JitRequestData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.JitRequestCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string jitRequestName, Azure.ResourceManager.Resources.JitRequestData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequest> Get(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.JitRequest> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.JitRequest> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> GetAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.JitRequest> GetIfExists(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> GetIfExistsAsync(string jitRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.JitRequest> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.JitRequest>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.JitRequest> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.JitRequest>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JitRequestData : Azure.ResourceManager.Models.TrackedResource
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
    public static partial class ManagementGroupExtensions
    {
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Management.ManagementGroup managementGroup) { throw null; }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.Resources.ApplicationDefinitionCollection GetApplicationDefinitions(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Resources.ApplicationCollection GetApplications(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentScriptCollection GetDeploymentScripts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Resources.JitRequestCollection GetJitRequests(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.Resources.TemplateSpecCollection GetTemplateSpecs(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ScriptLog : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptLog() { }
        public virtual Azure.ResourceManager.Resources.ScriptLogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scriptName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.ScriptLog> Get(int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.ScriptLog>> GetAsync(int? tail = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScriptLogData : Azure.ResourceManager.Models.Resource
    {
        public ScriptLogData() { }
        public string Log { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Resources.Application> GetApplications(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Application> GetApplicationsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.DeploymentScript> GetDeploymentScripts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentScript> GetDeploymentScriptsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.JitRequest> GetJitRequestDefinitions(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.JitRequest> GetJitRequestDefinitionsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpec> GetTemplateSpecs(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpec> GetTemplateSpecsAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpec : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TemplateSpec() { }
        public virtual Azure.ResourceManager.Resources.TemplateSpecData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string templateSpecName) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.TemplateSpecDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.TemplateSpecDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpec> Get(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpec>> GetAsync(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.TemplateSpecVersionCollection GetTemplateSpecVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpec> Update(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpec>> UpdateAsync(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpec>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpec>, System.Collections.IEnumerable
    {
        protected TemplateSpecCollection() { }
        public virtual Azure.ResourceManager.Resources.Models.TemplateSpecCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string templateSpecName, Azure.ResourceManager.Resources.TemplateSpecData templateSpec, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.TemplateSpecCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string templateSpecName, Azure.ResourceManager.Resources.TemplateSpecData templateSpec, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpec> Get(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpec> GetAll(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpec> GetAllAsync(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpec>> GetAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpec> GetIfExists(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpec>> GetIfExistsAsync(string templateSpecName, Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind? expand = default(Azure.ResourceManager.Resources.Models.TemplateSpecExpandKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TemplateSpec> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpec>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TemplateSpec> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpec>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TemplateSpecData : Azure.ResourceManager.Models.Resource
    {
        public TemplateSpecData(string location) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public object Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Resources.Models.TemplateSpecVersionInfo> Versions { get { throw null; } }
    }
    public partial class TemplateSpecVersion : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TemplateSpecVersion() { }
        public virtual Azure.ResourceManager.Resources.TemplateSpecVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string templateSpecName, string templateSpecVersion) { throw null; }
        public virtual Azure.ResourceManager.Resources.Models.TemplateSpecVersionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.TemplateSpecVersionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion> Update(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion>> UpdateAsync(System.Collections.Generic.IDictionary<string, string> tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecVersionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersion>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersion>, System.Collections.IEnumerable
    {
        protected TemplateSpecVersionCollection() { }
        public virtual Azure.ResourceManager.Resources.Models.TemplateSpecVersionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string templateSpecVersion, Azure.ResourceManager.Resources.TemplateSpecVersionData templateSpecVersionModel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.Resources.Models.TemplateSpecVersionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string templateSpecVersion, Azure.ResourceManager.Resources.TemplateSpecVersionData templateSpecVersionModel, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion> Get(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.TemplateSpecVersion> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.TemplateSpecVersion> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion>> GetAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion> GetIfExists(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion>> GetIfExistsAsync(string templateSpecVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.TemplateSpecVersion> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersion>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.TemplateSpecVersion> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.TemplateSpecVersion>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TemplateSpecVersionData : Azure.ResourceManager.Models.Resource
    {
        public TemplateSpecVersionData(string location) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.LinkedTemplateArtifact> LinkedTemplates { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public object MainTemplate { get { throw null; } set { } }
        public object Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public object UiFormDefinition { get { throw null; } set { } }
    }
    public static partial class TenantExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult> CalculateTemplateHashDeployment(this Azure.ResourceManager.Resources.Tenant tenant, object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.TemplateHashResult>> CalculateTemplateHashDeploymentAsync(this Azure.ResourceManager.Resources.Tenant tenant, object template, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentCollection GetDeployments(this Azure.ResourceManager.Resources.Tenant tenant) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class ApplicationArtifact
    {
        internal ApplicationArtifact() { }
        public Azure.ResourceManager.Resources.Models.ApplicationArtifactName Name { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationArtifactType Type { get { throw null; } }
        public string Uri { get { throw null; } }
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
    public partial class ApplicationBillingDetailsDefinition
    {
        internal ApplicationBillingDetailsDefinition() { }
        public string ResourceUsageId { get { throw null; } }
    }
    public partial class ApplicationClientDetails
    {
        internal ApplicationClientDetails() { }
        public string ApplicationId { get { throw null; } }
        public string Oid { get { throw null; } }
        public string Puid { get { throw null; } }
    }
    public partial class ApplicationCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.Application>
    {
        protected ApplicationCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Application Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Application>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Application>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDefinitionArtifact
    {
        public ApplicationDefinitionArtifact(Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName name, string uri, Azure.ResourceManager.Resources.Models.ApplicationArtifactType type) { }
        public Azure.ResourceManager.Resources.Models.ApplicationDefinitionArtifactName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationArtifactType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
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
    public partial class ApplicationDefinitionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.ApplicationDefinition>
    {
        protected ApplicationDefinitionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.ApplicationDefinition Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.ApplicationDefinition>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDefinitionDeleteOperation : Azure.Operation
    {
        protected ApplicationDefinitionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDeleteOperation : Azure.Operation
    {
        protected ApplicationDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationDeploymentPolicy
    {
        public ApplicationDeploymentPolicy(Azure.ResourceManager.Resources.Models.DeploymentMode deploymentMode) { }
        public Azure.ResourceManager.Resources.Models.DeploymentMode DeploymentMode { get { throw null; } set { } }
    }
    public partial class ApplicationJitAccessPolicy
    {
        public ApplicationJitAccessPolicy(bool jitAccessEnabled) { }
        public bool JitAccessEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitApprovalMode? JitApprovalMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.JitApproverDefinition> JitApprovers { get { throw null; } }
        public string MaximumJitAccessDuration { get { throw null; } set { } }
    }
    public enum ApplicationLockLevel
    {
        CanNotDelete = 0,
        ReadOnly = 1,
        None = 2,
    }
    public partial class ApplicationManagedIdentity
    {
        public ApplicationManagedIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagedIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedResourceIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public enum ApplicationManagedIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
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
    public partial class ApplicationManagementPolicy
    {
        public ApplicationManagementPolicy() { }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementMode? Mode { get { throw null; } set { } }
    }
    public partial class ApplicationNotificationEndpoint
    {
        public ApplicationNotificationEndpoint(string uri) { }
        public string Uri { get { throw null; } set { } }
    }
    public partial class ApplicationNotificationPolicy
    {
        public ApplicationNotificationPolicy(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ApplicationNotificationEndpoint> notificationEndpoints) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.ApplicationNotificationEndpoint> NotificationEndpoints { get { throw null; } }
    }
    public partial class ApplicationPackageContact
    {
        internal ApplicationPackageContact() { }
        public string ContactName { get { throw null; } }
        public string Email { get { throw null; } }
        public string Phone { get { throw null; } }
    }
    public partial class ApplicationPackageLockingPolicyDefinition
    {
        public ApplicationPackageLockingPolicyDefinition() { }
        public System.Collections.Generic.IList<string> AllowedActions { get { throw null; } }
    }
    public partial class ApplicationPackageSupportUrls
    {
        internal ApplicationPackageSupportUrls() { }
        public string GovernmentCloud { get { throw null; } }
        public string PublicAzure { get { throw null; } }
    }
    public partial class ApplicationPatchable : Azure.ResourceManager.Resources.Models.ApplicationResource
    {
        public ApplicationPatchable(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ApplicationDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationArtifact> Artifacts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ApplicationAuthorization> Authorizations { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationBillingDetailsDefinition BillingDetails { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageContact CustomerSupport { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagedIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationJitAccessPolicy JitAccessPolicy { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ApplicationManagementMode? ManagementMode { get { throw null; } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } set { } }
        public Azure.ResourceManager.Models.Plan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherTenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationPackageSupportUrls SupportUrls { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ApplicationClientDetails UpdatedBy { get { throw null; } }
    }
    public partial class ApplicationPolicy
    {
        public ApplicationPolicy() { }
        public string Name { get { throw null; } set { } }
        public string Parameters { get { throw null; } set { } }
        public string PolicyDefinitionId { get { throw null; } set { } }
    }
    public partial class ApplicationRefreshPermissionsOperation : Azure.Operation
    {
        protected ApplicationRefreshPermissionsOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApplicationResource : Azure.ResourceManager.Models.TrackedResource
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
    public partial class AzureCliScript : Azure.ResourceManager.Resources.DeploymentScriptData
    {
        public AzureCliScript(string location, System.TimeSpan retentionInterval, string azCliVersion) : base (default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string AzCliVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.CleanupOptions? CleanupPreference { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Outputs { get { throw null; } }
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
        public Azure.ResourceManager.Resources.Models.ContainerConfiguration ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Outputs { get { throw null; } }
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
    public partial class ContainerConfiguration
    {
        public ContainerConfiguration() { }
        public string ContainerGroupName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.Resources.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.CreatedByType left, Azure.ResourceManager.Resources.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.CreatedByType left, Azure.ResourceManager.Resources.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DebugSetting
    {
        public DebugSetting() { }
        public string DetailLevel { get { throw null; } set { } }
    }
    public partial class Dependency
    {
        internal Dependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.BasicDependency> DependsOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class DeploymentCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.Deployment>
    {
        protected DeploymentCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Deployment Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Deployment>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Deployment>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentDeleteOperation : Azure.Operation
    {
        protected DeploymentDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentExportResult
    {
        internal DeploymentExportResult() { }
        public object Template { get { throw null; } }
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
        public string Duration { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProvisioningOperation? ProvisioningOperation { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.HttpMessage Request { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.HttpMessage Response { get { throw null; } }
        public string ServiceRequestId { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.StatusMessage StatusMessage { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TargetResource TargetResource { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class DeploymentProperties
    {
        public DeploymentProperties(Azure.ResourceManager.Resources.Models.DeploymentMode mode) { }
        public Azure.ResourceManager.Resources.Models.DebugSetting DebugSetting { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptions ExpressionEvaluationOptions { get { throw null; } set { } }
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
        public Azure.ResourceManager.Resources.Models.DebugSetting DebugSetting { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.Dependency> Dependencies { get { throw null; } }
        public string Duration { get { throw null; } }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentMode? Mode { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentExtended OnErrorDeployment { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> OutputResources { get { throw null; } }
        public object Outputs { get { throw null; } }
        public object Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ParametersLink ParametersLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.ProviderData> Providers { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string TemplateHash { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.TemplateLink TemplateLink { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
    }
    public partial class DeploymentScriptCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.DeploymentScript>
    {
        protected DeploymentScriptCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.DeploymentScript Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.DeploymentScript>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.DeploymentScript>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptDeleteOperation : Azure.Operation
    {
        protected DeploymentScriptDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentScriptManagedIdentity
    {
        public DeploymentScriptManagedIdentity() { }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentScriptManagedIdentityType? Type { get { throw null; } set { } }
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
    public partial class DeploymentScriptUpdateParameter : Azure.ResourceManager.Models.Resource
    {
        public DeploymentScriptUpdateParameter() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeploymentValidateOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>
    {
        protected DeploymentValidateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.DeploymentValidateResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentValidateResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentValidateResult
    {
        internal DeploymentValidateResult() { }
        public Azure.ResourceManager.Models.ErrorDetail Error { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentPropertiesExtended Properties { get { throw null; } }
    }
    public partial class DeploymentWhatIfOperation : Azure.Operation<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>
    {
        protected DeploymentWhatIfOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.Models.WhatIfOperationResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.Models.WhatIfOperationResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentWhatIfProperties : Azure.ResourceManager.Resources.Models.DeploymentProperties
    {
        public DeploymentWhatIfProperties(Azure.ResourceManager.Resources.Models.DeploymentMode mode) : base (default(Azure.ResourceManager.Resources.Models.DeploymentMode)) { }
        public Azure.ResourceManager.Resources.Models.DeploymentWhatIfSettings WhatIfSettings { get { throw null; } set { } }
    }
    public partial class DeploymentWhatIfSettings
    {
        public DeploymentWhatIfSettings() { }
        public Azure.ResourceManager.Resources.Models.WhatIfResultFormat? ResultFormat { get { throw null; } set { } }
    }
    public partial class EnvironmentVariable
    {
        public EnvironmentVariable(string name) { }
        public string Name { get { throw null; } set { } }
        public string SecureValue { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ExpressionEvaluationOptions
    {
        public ExpressionEvaluationOptions() { }
        public Azure.ResourceManager.Resources.Models.ExpressionEvaluationOptionsScopeType? Scope { get { throw null; } set { } }
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
    public partial class HttpMessage
    {
        internal HttpMessage() { }
        public object Content { get { throw null; } }
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
    public partial class JitApproverDefinition
    {
        public JitApproverDefinition(string id) { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitApproverType? Type { get { throw null; } set { } }
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
    public partial class JitRequestCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.JitRequest>
    {
        protected JitRequestCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.JitRequest Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.JitRequest>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JitRequestDeleteOperation : Azure.Operation
    {
        protected JitRequestDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JitRequestListResult
    {
        internal JitRequestListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.JitRequestData> Value { get { throw null; } }
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
        public JitSchedulingPolicy(Azure.ResourceManager.Resources.Models.JitSchedulingType type, System.TimeSpan duration, System.DateTimeOffset startTime) { }
        public System.TimeSpan Duration { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.JitSchedulingType Type { get { throw null; } }
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
        public LinkedTemplateArtifact(string path, object template) { }
        public string Path { get { throw null; } set { } }
        public object Template { get { throw null; } set { } }
    }
    public partial class OnErrorDeployment
    {
        public OnErrorDeployment() { }
        public string DeploymentName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentType? Type { get { throw null; } set { } }
    }
    public partial class OnErrorDeploymentExtended
    {
        internal OnErrorDeploymentExtended() { }
        public string DeploymentName { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.OnErrorDeploymentType? Type { get { throw null; } }
    }
    public enum OnErrorDeploymentType
    {
        LastSuccessful = 0,
        SpecificDeployment = 1,
    }
    public partial class ParametersLink
    {
        public ParametersLink(string uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
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
    public partial class ScriptLogsList
    {
        internal ScriptLogsList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.ScriptLogData> Value { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.Resources.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ScriptType AzureCLI { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ScriptType AzurePowerShell { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ScriptType left, Azure.ResourceManager.Resources.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ScriptType left, Azure.ResourceManager.Resources.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
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
        public string Uri { get { throw null; } set { } }
    }
    public partial class TemplateSpecCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.TemplateSpec>
    {
        protected TemplateSpecCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.TemplateSpec Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.TemplateSpec>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.TemplateSpec>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecDeleteOperation : Azure.Operation
    {
        protected TemplateSpecDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class TemplateSpecUpdateModel : Azure.ResourceManager.Models.Resource
    {
        public TemplateSpecUpdateModel() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TemplateSpecVersionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.Resources.TemplateSpecVersion>
    {
        protected TemplateSpecVersionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.Resources.TemplateSpecVersion Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.Resources.TemplateSpecVersion>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecVersionDeleteOperation : Azure.Operation
    {
        protected TemplateSpecVersionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TemplateSpecVersionInfo
    {
        internal TemplateSpecVersionInfo() { }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public System.DateTimeOffset? TimeModified { get { throw null; } }
    }
    public partial class TemplateSpecVersionUpdateModel : Azure.ResourceManager.Models.Resource
    {
        public TemplateSpecVersionUpdateModel() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public object After { get { throw null; } }
        public object Before { get { throw null; } }
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
        public object After { get { throw null; } }
        public object Before { get { throw null; } }
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
