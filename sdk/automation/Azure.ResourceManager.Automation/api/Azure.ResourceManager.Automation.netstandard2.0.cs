namespace Azure.ResourceManager.Automation
{
    public partial class AutomationAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationAccountResource>, System.Collections.IEnumerable
    {
        protected AutomationAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string automationAccountName, Azure.ResourceManager.Automation.Models.AutomationAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string automationAccountName, Azure.ResourceManager.Automation.Models.AutomationAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string automationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string automationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> Get(string automationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> GetAsync(string automationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutomationAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri AutomationHybridServiceUri { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public bool? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationAccountState? State { get { throw null; } }
    }
    public partial class AutomationAccountModuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationAccountModuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationAccountModuleResource>, System.Collections.IEnumerable
    {
        protected AutomationAccountModuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationAccountModuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string moduleName, Azure.ResourceManager.Automation.Models.AutomationAccountModuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string moduleName, Azure.ResourceManager.Automation.Models.AutomationAccountModuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> Get(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationAccountModuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationAccountModuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> GetAsync(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationAccountModuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationAccountModuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationAccountModuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationAccountModuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationAccountModuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationAccountModuleResource() { }
        public virtual Azure.ResourceManager.Automation.ModuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string moduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.Activity> GetActivities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.Activity> GetActivitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.Activity> GetActivity(string activityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.Activity>> GetActivityAsync(string activityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.TypeField> GetFieldsByModuleAndTypeObjectDataTypes(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.TypeField> GetFieldsByModuleAndTypeObjectDataTypesAsync(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.TypeField> GetFieldsByType(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.TypeField> GetFieldsByTypeAsync(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> Update(Azure.ResourceManager.Automation.Models.AutomationAccountModulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationAccountModulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationAccountPython2PackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>, System.Collections.IEnumerable
    {
        protected AutomationAccountPython2PackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string packageName, Azure.ResourceManager.Automation.Models.AutomationAccountPython2PackageCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string packageName, Azure.ResourceManager.Automation.Models.AutomationAccountPython2PackageCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> Get(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> GetAsync(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationAccountPython2PackageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationAccountPython2PackageResource() { }
        public virtual Azure.ResourceManager.Automation.ModuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string packageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> Update(Azure.ResourceManager.Automation.Models.AutomationAccountPython2PackagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationAccountPython2PackagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationAccountResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationPrivateLinkResource> AutomationPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationPrivateLinkResource> AutomationPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.GraphicalRunbookContent> ConvertGraphRunbookContent(Azure.ResourceManager.Automation.Models.GraphicalRunbookContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.GraphicalRunbookContent>> ConvertGraphRunbookContentAsync(Azure.ResourceManager.Automation.Models.GraphicalRunbookContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GenerateUriWebhook(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GenerateUriWebhookAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AgentRegistration> GetAgentRegistrationInformation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AgentRegistration>> GetAgentRegistrationInformationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.NodeCount> GetAllNodeCountInformation(Azure.ResourceManager.Automation.Models.CountType countType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.NodeCount> GetAllNodeCountInformationAsync(Azure.ResourceManager.Automation.Models.CountType countType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> GetAutomationAccountModule(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> GetAutomationAccountModuleAsync(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationAccountModuleCollection GetAutomationAccountModules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> GetAutomationAccountPython2Package(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> GetAutomationAccountPython2PackageAsync(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationAccountPython2PackageCollection GetAutomationAccountPython2Packages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> GetAutomationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>> GetAutomationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionCollection GetAutomationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.KeyListResult> GetByAutomationAccountKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.KeyListResult>> GetByAutomationAccountKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun> GetByIdSoftwareUpdateConfigurationMachineRun(System.Guid softwareUpdateConfigurationMachineRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun>> GetByIdSoftwareUpdateConfigurationMachineRunAsync(System.Guid softwareUpdateConfigurationMachineRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun> GetByIdSoftwareUpdateConfigurationRun(System.Guid softwareUpdateConfigurationRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun>> GetByIdSoftwareUpdateConfigurationRunAsync(System.Guid softwareUpdateConfigurationRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CertificateResource> GetCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CertificateResource>> GetCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.CertificateCollection GetCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ConnectionResource> GetConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ConnectionResource>> GetConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.ConnectionCollection GetConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ConnectionTypeResource> GetConnectionType(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ConnectionTypeResource>> GetConnectionTypeAsync(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.ConnectionTypeCollection GetConnectionTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CredentialResource> GetCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CredentialResource>> GetCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.CredentialCollection GetCredentials() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource> GetDscCompilationJob(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource>> GetDscCompilationJobAsync(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.DscCompilationJobCollection GetDscCompilationJobs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.JobStream> GetDscCompilationJobStreamsByJob(System.Guid jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.JobStream> GetDscCompilationJobStreamsByJobAsync(System.Guid jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> GetDscConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> GetDscConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.DscConfigurationCollection GetDscConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeResource> GetDscNode(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeResource>> GetDscNodeAsync(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource> GetDscNodeConfiguration(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource>> GetDscNodeConfigurationAsync(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.DscNodeConfigurationCollection GetDscNodeConfigurations() { throw null; }
        public virtual Azure.ResourceManager.Automation.DscNodeCollection GetDscNodes() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.TypeField> GetFieldsByTypeObjectDataTypes(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.TypeField> GetFieldsByTypeObjectDataTypesAsync(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> GetHybridRunbookWorkerGroup(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> GetHybridRunbookWorkerGroupAsync(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.HybridRunbookWorkerGroupCollection GetHybridRunbookWorkerGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.JobResource> GetJob(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.JobResource>> GetJobAsync(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.JobCollection GetJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.JobScheduleResource> GetJobSchedule(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.JobScheduleResource>> GetJobScheduleAsync(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.JobScheduleCollection GetJobSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.LinkedWorkspace> GetLinkedWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.LinkedWorkspace>> GetLinkedWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.RunbookResource> GetRunbook(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.RunbookResource>> GetRunbookAsync(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.RunbookCollection GetRunbooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ScheduleResource> GetSchedule(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ScheduleResource>> GetScheduleAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.ScheduleCollection GetSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource> GetSoftwareUpdateConfiguration(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource>> GetSoftwareUpdateConfigurationAsync(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun> GetSoftwareUpdateConfigurationMachineRuns(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun> GetSoftwareUpdateConfigurationMachineRunsAsync(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun> GetSoftwareUpdateConfigurationRuns(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun> GetSoftwareUpdateConfigurationRunsAsync(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.SoftwareUpdateConfigurationCollection GetSoftwareUpdateConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SourceControlResource> GetSourceControl(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SourceControlResource>> GetSourceControlAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.SourceControlCollection GetSourceControls() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.Statistics> GetStatistics(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.Statistics> GetStatisticsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.JobStream> GetStreamDscCompilationJob(System.Guid jobId, string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.JobStream>> GetStreamDscCompilationJobAsync(System.Guid jobId, string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationUsage> GetUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationUsage> GetUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.VariableResource> GetVariable(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.VariableResource>> GetVariableAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.VariableCollection GetVariables() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WatcherResource> GetWatcher(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WatcherResource>> GetWatcherAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.WatcherCollection GetWatchers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WebhookResource> GetWebhook(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WebhookResource>> GetWebhookAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.WebhookCollection GetWebhooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AgentRegistration> RegenerateKeyAgentRegistrationInformation(Azure.ResourceManager.Automation.Models.AgentRegistrationRegenerateKeyParameter agentRegistrationRegenerateKeyParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AgentRegistration>> RegenerateKeyAgentRegistrationInformationAsync(Azure.ResourceManager.Automation.Models.AgentRegistrationRegenerateKeyParameter agentRegistrationRegenerateKeyParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> Update(Azure.ResourceManager.Automation.Models.AutomationAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AutomationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> GetAutomationAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string automationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> GetAutomationAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string automationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationAccountModuleResource GetAutomationAccountModuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource GetAutomationAccountPython2PackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationAccountResource GetAutomationAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationAccountCollection GetAutomationAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automation.AutomationAccountResource> GetAutomationAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationAccountResource> GetAutomationAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource GetAutomationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.CertificateResource GetCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.ConnectionResource GetConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.ConnectionTypeResource GetConnectionTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.CredentialResource GetCredentialResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automation.Models.DeletedAutomationAccount> GetDeletedAutomationAccountsBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.DeletedAutomationAccount> GetDeletedAutomationAccountsBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automation.DscCompilationJobResource GetDscCompilationJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.DscConfigurationResource GetDscConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.DscNodeConfigurationResource GetDscNodeConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.DscNodeResource GetDscNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource GetHybridRunbookWorkerGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.HybridRunbookWorkerResource GetHybridRunbookWorkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.JobResource GetJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.JobScheduleResource GetJobScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.RunbookResource GetRunbookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.ScheduleResource GetScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource GetSoftwareUpdateConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.SourceControlResource GetSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.VariableResource GetVariableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.WatcherResource GetWatcherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.WebhookResource GetWebhookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AutomationPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected AutomationPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Automation.Models.AutomationPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
    }
    public partial class AutomationPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.CertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.CertificateResource>, System.Collections.IEnumerable
    {
        protected CertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.CertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Automation.Models.CertificateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.CertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Automation.Models.CertificateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.CertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.CertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.CertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.CertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.CertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.CertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public bool? IsExportable { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Thumbprint { get { throw null; } }
    }
    public partial class CertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateResource() { }
        public virtual Azure.ResourceManager.Automation.CertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CertificateResource> Update(Azure.ResourceManager.Automation.Models.CertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CertificateResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.CertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.ConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.ConnectionResource>, System.Collections.IEnumerable
    {
        protected ConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.Automation.Models.ConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.Automation.Models.ConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.ConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.ConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.ConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.ConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.ConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.ConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public ConnectionData() { }
        public string ConnectionTypeName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FieldDefinitionValues { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class ConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectionResource() { }
        public virtual Azure.ResourceManager.Automation.ConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ConnectionResource> Update(Azure.ResourceManager.Automation.Models.ConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ConnectionResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.ConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectionTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.ConnectionTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.ConnectionTypeResource>, System.Collections.IEnumerable
    {
        protected ConnectionTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ConnectionTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionTypeName, Azure.ResourceManager.Automation.Models.ConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ConnectionTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionTypeName, Azure.ResourceManager.Automation.Models.ConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ConnectionTypeResource> Get(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.ConnectionTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.ConnectionTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ConnectionTypeResource>> GetAsync(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.ConnectionTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.ConnectionTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.ConnectionTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.ConnectionTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectionTypeData : Azure.ResourceManager.Models.ResourceData
    {
        internal ConnectionTypeData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Automation.Models.FieldDefinition> FieldDefinitions { get { throw null; } }
        public bool? IsGlobal { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class ConnectionTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectionTypeResource() { }
        public virtual Azure.ResourceManager.Automation.ConnectionTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string connectionTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ConnectionTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ConnectionTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ConnectionTypeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.ConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ConnectionTypeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.ConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CredentialCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.CredentialResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.CredentialResource>, System.Collections.IEnumerable
    {
        protected CredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.CredentialResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Automation.Models.CredentialCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.CredentialResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Automation.Models.CredentialCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CredentialResource> Get(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.CredentialResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.CredentialResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CredentialResource>> GetAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.CredentialResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.CredentialResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.CredentialResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.CredentialResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CredentialData : Azure.ResourceManager.Models.ResourceData
    {
        public CredentialData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class CredentialResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CredentialResource() { }
        public virtual Azure.ResourceManager.Automation.CredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string credentialName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CredentialResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CredentialResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.CredentialResource> Update(Azure.ResourceManager.Automation.Models.CredentialPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.CredentialResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.CredentialPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DscCompilationJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscCompilationJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscCompilationJobResource>, System.Collections.IEnumerable
    {
        protected DscCompilationJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.DscCompilationJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string compilationJobName, Azure.ResourceManager.Automation.Models.DscCompilationJobCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.DscCompilationJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string compilationJobName, Azure.ResourceManager.Automation.Models.DscCompilationJobCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource> Get(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.DscCompilationJobResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.DscCompilationJobResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource>> GetAsync(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.DscCompilationJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscCompilationJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.DscCompilationJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscCompilationJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DscCompilationJobData : Azure.ResourceManager.Models.ResourceData
    {
        public DscCompilationJobData() { }
        public string ConfigurationName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Exception { get { throw null; } }
        public System.Guid? JobId { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.DateTimeOffset? LastStatusModifiedOn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.JobProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
        public string StartedBy { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.JobStatus? Status { get { throw null; } set { } }
        public string StatusDetails { get { throw null; } set { } }
    }
    public partial class DscCompilationJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DscCompilationJobResource() { }
        public virtual Azure.ResourceManager.Automation.DscCompilationJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string compilationJobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.DscCompilationJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.DscCompilationJobCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.DscCompilationJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.DscCompilationJobCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DscConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscConfigurationResource>, System.Collections.IEnumerable
    {
        protected DscConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.DscConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Automation.Models.DscConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.DscConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Automation.Models.DscConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.DscConfigurationResource> GetAll(string filter = null, int? skip = default(int?), int? top = default(int?), string inlinecount = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.DscConfigurationResource> GetAllAsync(string filter = null, int? skip = default(int?), int? top = default(int?), string inlinecount = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.DscConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.DscConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DscConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DscConfigurationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public int? JobCount { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public bool? LogVerbose { get { throw null; } set { } }
        public int? NodeConfigurationCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.DscConfigurationParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ContentSource Source { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.DscConfigurationState? State { get { throw null; } set { } }
    }
    public partial class DscConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DscConfigurationResource() { }
        public virtual Azure.ResourceManager.Automation.DscConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetContent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetContentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> Update(Azure.ResourceManager.Automation.Models.DscConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.DscConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DscNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscNodeResource>, System.Collections.IEnumerable
    {
        protected DscNodeCollection() { }
        public virtual Azure.Response<bool> Exists(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeResource> Get(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.DscNodeResource> GetAll(string filter = null, int? skip = default(int?), int? top = default(int?), string inlinecount = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.DscNodeResource> GetAllAsync(string filter = null, int? skip = default(int?), int? top = default(int?), string inlinecount = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeResource>> GetAsync(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.DscNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.DscNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DscNodeConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscNodeConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscNodeConfigurationResource>, System.Collections.IEnumerable
    {
        protected DscNodeConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string nodeConfigurationName, Azure.ResourceManager.Automation.Models.DscNodeConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodeConfigurationName, Azure.ResourceManager.Automation.Models.DscNodeConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource> Get(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.DscNodeConfigurationResource> GetAll(string filter = null, int? skip = default(int?), int? top = default(int?), string inlinecount = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.DscNodeConfigurationResource> GetAllAsync(string filter = null, int? skip = default(int?), int? top = default(int?), string inlinecount = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource>> GetAsync(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.DscNodeConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.DscNodeConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.DscNodeConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.DscNodeConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DscNodeConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public DscNodeConfigurationData() { }
        public string ConfigurationName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public bool? IncrementNodeConfigurationBuild { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public long? NodeCount { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class DscNodeConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DscNodeConfigurationResource() { }
        public virtual Azure.ResourceManager.Automation.DscNodeConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string nodeConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.DscNodeConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.DscNodeConfigurationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DscNodeData : Azure.ResourceManager.Models.ResourceData
    {
        public DscNodeData() { }
        public string AccountId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.Models.DscNodeExtensionHandlerAssociationProperty> ExtensionHandler { get { throw null; } }
        public string IP { get { throw null; } set { } }
        public System.DateTimeOffset? LastSeen { get { throw null; } set { } }
        public string NamePropertiesNodeConfigurationName { get { throw null; } set { } }
        public string NodeId { get { throw null; } set { } }
        public System.DateTimeOffset? RegistrationOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public int? TotalCount { get { throw null; } set { } }
    }
    public partial class DscNodeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DscNodeResource() { }
        public virtual Azure.ResourceManager.Automation.DscNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string nodeId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetContentNodeReport(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetContentNodeReportAsync(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.DscNodeReport> GetNodeReport(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.DscNodeReport>> GetNodeReportAsync(string reportId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.DscNodeReport> GetNodeReportsByNode(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.DscNodeReport> GetNodeReportsByNodeAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeResource> Update(Azure.ResourceManager.Automation.Models.DscNodePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.DscNodePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridRunbookWorkerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>, System.Collections.IEnumerable
    {
        protected HybridRunbookWorkerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hybridRunbookWorkerId, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hybridRunbookWorkerId, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hybridRunbookWorkerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hybridRunbookWorkerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> Get(string hybridRunbookWorkerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>> GetAsync(string hybridRunbookWorkerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridRunbookWorkerData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridRunbookWorkerData() { }
        public string IP { get { throw null; } set { } }
        public System.DateTimeOffset? LastSeenOn { get { throw null; } set { } }
        public System.DateTimeOffset? RegisteredOn { get { throw null; } set { } }
        public string VmResourceId { get { throw null; } set { } }
        public string WorkerName { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.WorkerType? WorkerType { get { throw null; } set { } }
    }
    public partial class HybridRunbookWorkerGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>, System.Collections.IEnumerable
    {
        protected HybridRunbookWorkerGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hybridRunbookWorkerGroupName, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateParameters hybridRunbookWorkerGroupCreationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hybridRunbookWorkerGroupName, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateParameters hybridRunbookWorkerGroupCreationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> Get(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> GetAsync(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridRunbookWorkerGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridRunbookWorkerGroupData() { }
        public string CredentialName { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.GroupTypeEnum? GroupType { get { throw null; } set { } }
    }
    public partial class HybridRunbookWorkerGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridRunbookWorkerGroupResource() { }
        public virtual Azure.ResourceManager.Automation.HybridRunbookWorkerGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string hybridRunbookWorkerGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> GetHybridRunbookWorker(string hybridRunbookWorkerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>> GetHybridRunbookWorkerAsync(string hybridRunbookWorkerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.HybridRunbookWorkerCollection GetHybridRunbookWorkers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> Update(Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateParameters hybridRunbookWorkerGroupUpdationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateParameters hybridRunbookWorkerGroupUpdationParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridRunbookWorkerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridRunbookWorkerResource() { }
        public virtual Azure.ResourceManager.Automation.HybridRunbookWorkerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string hybridRunbookWorkerGroupName, string hybridRunbookWorkerId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Move(Azure.ResourceManager.Automation.Models.HybridRunbookWorkerMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> MoveAsync(Azure.ResourceManager.Automation.Models.HybridRunbookWorkerMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.Models.JobCollectionItem>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.JobCollectionItem>, System.Collections.IEnumerable
    {
        protected JobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Automation.Models.JobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Automation.Models.JobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.JobResource> Get(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.JobCollectionItem> GetAll(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.JobCollectionItem> GetAllAsync(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.JobResource>> GetAsync(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.Models.JobCollectionItem> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.Models.JobCollectionItem>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.Models.JobCollectionItem> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.JobCollectionItem>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobData : Azure.ResourceManager.Models.ResourceData
    {
        public JobData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string Exception { get { throw null; } set { } }
        public System.Guid? JobId { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastStatusModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.JobProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RunbookName { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
        public string StartedBy { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.JobStatus? Status { get { throw null; } set { } }
        public string StatusDetails { get { throw null; } set { } }
    }
    public partial class JobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobResource() { }
        public virtual Azure.ResourceManager.Automation.JobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.JobResource> Get(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.JobResource>> GetAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.JobStream> GetJobStream(string jobStreamId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.JobStream>> GetJobStreamAsync(string jobStreamId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.JobStream> GetJobStreams(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.JobStream> GetJobStreamsAsync(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetOutput(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetOutputAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetRunbookContent(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetRunbookContentAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Suspend(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SuspendAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.JobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.JobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.JobScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.JobScheduleResource>, System.Collections.IEnumerable
    {
        protected JobScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid jobScheduleId, Azure.ResourceManager.Automation.Models.JobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid jobScheduleId, Azure.ResourceManager.Automation.Models.JobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.JobScheduleResource> Get(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.JobScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.JobScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.JobScheduleResource>> GetAsync(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.JobScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.JobScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.JobScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.JobScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        internal JobScheduleData() { }
        public string JobScheduleId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } }
        public string RunOn { get { throw null; } }
        public string ScheduleName { get { throw null; } }
    }
    public partial class JobScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobScheduleResource() { }
        public virtual Azure.ResourceManager.Automation.JobScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, System.Guid jobScheduleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.JobScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.JobScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.JobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.JobScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.JobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ModuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? ActivityCount { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ContentLink ContentLink { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ModuleErrorInfo Error { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsComposite { get { throw null; } set { } }
        public bool? IsGlobal { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ModuleProvisioningState? ProvisioningState { get { throw null; } set { } }
        public long? SizeInBytes { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class RunbookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.RunbookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.RunbookResource>, System.Collections.IEnumerable
    {
        protected RunbookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.RunbookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string runbookName, Azure.ResourceManager.Automation.Models.RunbookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.RunbookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string runbookName, Azure.ResourceManager.Automation.Models.RunbookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.RunbookResource> Get(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.RunbookResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.RunbookResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.RunbookResource>> GetAsync(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.RunbookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.RunbookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.RunbookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.RunbookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RunbookData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RunbookData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.RunbookDraft Draft { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public int? JobCount { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public int? LogActivityTrace { get { throw null; } set { } }
        public bool? LogProgress { get { throw null; } set { } }
        public bool? LogVerbose { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OutputTypes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.RunbookParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.RunbookProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ContentLink PublishContentLink { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.RunbookTypeEnum? RunbookType { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.RunbookState? State { get { throw null; } set { } }
    }
    public partial class RunbookResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RunbookResource() { }
        public virtual Azure.ResourceManager.Automation.RunbookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automation.RunbookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.RunbookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string runbookName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.TestJob> CreateTestJob(Azure.ResourceManager.Automation.Models.TestJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.TestJob>> CreateTestJobAsync(Azure.ResourceManager.Automation.Models.TestJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.RunbookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.RunbookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetContent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetContentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetContentRunbookDraft(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetContentRunbookDraftAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.RunbookDraft> GetRunbookDraft(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.RunbookDraft>> GetRunbookDraftAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.TestJob> GetTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.TestJob>> GetTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.JobStream> GetTestJobStream(string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.JobStream>> GetTestJobStreamAsync(string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.JobStream> GetTestJobStreamsByTestJob(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.JobStream> GetTestJobStreamsByTestJobAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Publish(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PublishAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.RunbookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.RunbookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReplaceContentRunbookDraft(Azure.WaitUntil waitUntil, System.IO.Stream runbookContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReplaceContentRunbookDraftAsync(Azure.WaitUntil waitUntil, System.IO.Stream runbookContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.RunbookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.RunbookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SuspendTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SuspendTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.RunbookDraftUndoEditResult> UndoEditRunbookDraft(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.RunbookDraftUndoEditResult>> UndoEditRunbookDraftAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.RunbookResource> Update(Azure.ResourceManager.Automation.Models.RunbookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.RunbookResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.RunbookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.ScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.ScheduleResource>, System.Collections.IEnumerable
    {
        protected ScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.Automation.Models.ScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.ScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.Automation.Models.ScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ScheduleResource> Get(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.ScheduleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.ScheduleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ScheduleResource>> GetAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.ScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.ScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.ScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.ScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public ScheduleData() { }
        public Azure.ResourceManager.Automation.Models.AdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public double? ExpiryTimeOffsetMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ScheduleFrequency? Frequency { get { throw null; } set { } }
        public System.BinaryData Interval { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.DateTimeOffset? NextRun { get { throw null; } set { } }
        public double? NextRunOffsetMinutes { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public double? StartTimeOffsetMinutes { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class ScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduleResource() { }
        public virtual Azure.ResourceManager.Automation.ScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string scheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.ScheduleResource> Update(Azure.ResourceManager.Automation.Models.SchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.ScheduleResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.SchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SoftwareUpdateConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem>, System.Collections.IEnumerable
    {
        protected SoftwareUpdateConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string softwareUpdateConfigurationName, Azure.ResourceManager.Automation.SoftwareUpdateConfigurationData data, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string softwareUpdateConfigurationName, Azure.ResourceManager.Automation.SoftwareUpdateConfigurationData data, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource> Get(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem> GetAll(string clientRequestId = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem> GetAllAsync(string clientRequestId = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource>> GetAsync(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SoftwareUpdateConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public SoftwareUpdateConfigurationData(Azure.ResourceManager.Automation.Models.UpdateConfiguration updateConfiguration, Azure.ResourceManager.Automation.Models.SUCScheduleProperties scheduleInfo) { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.ErrorResponse Error { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SUCScheduleProperties ScheduleInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTasks Tasks { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.UpdateConfiguration UpdateConfiguration { get { throw null; } set { } }
    }
    public partial class SoftwareUpdateConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SoftwareUpdateConfigurationResource() { }
        public virtual Azure.ResourceManager.Automation.SoftwareUpdateConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string softwareUpdateConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource> Get(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource>> GetAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.SoftwareUpdateConfigurationData data, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.SoftwareUpdateConfigurationData data, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SourceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.SourceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.SourceControlResource>, System.Collections.IEnumerable
    {
        protected SourceControlCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.SourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlName, Azure.ResourceManager.Automation.Models.SourceControlCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.SourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlName, Azure.ResourceManager.Automation.Models.SourceControlCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SourceControlResource> Get(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.SourceControlResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.SourceControlResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SourceControlResource>> GetAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.SourceControlResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.SourceControlResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.SourceControlResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.SourceControlResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SourceControlData : Azure.ResourceManager.Models.ResourceData
    {
        public SourceControlData() { }
        public bool? AutoSync { get { throw null; } set { } }
        public string Branch { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public bool? PublishRunbook { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceType? SourceType { get { throw null; } set { } }
    }
    public partial class SourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SourceControlResource() { }
        public virtual Azure.ResourceManager.Automation.SourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string sourceControlName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJob> CreateSourceControlSyncJob(System.Guid sourceControlSyncJobId, Azure.ResourceManager.Automation.Models.SourceControlSyncJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJob>> CreateSourceControlSyncJobAsync(System.Guid sourceControlSyncJobId, Azure.ResourceManager.Automation.Models.SourceControlSyncJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobById> GetSourceControlSyncJob(System.Guid sourceControlSyncJobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobById>> GetSourceControlSyncJobAsync(System.Guid sourceControlSyncJobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJob> GetSourceControlSyncJobsByAutomationAccount(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJob> GetSourceControlSyncJobsByAutomationAccountAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStreamById> GetSourceControlSyncJobStream(System.Guid sourceControlSyncJobId, string streamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStreamById>> GetSourceControlSyncJobStreamAsync(System.Guid sourceControlSyncJobId, string streamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStream> GetSourceControlSyncJobStreamsBySyncJob(System.Guid sourceControlSyncJobId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStream> GetSourceControlSyncJobStreamsBySyncJobAsync(System.Guid sourceControlSyncJobId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SourceControlResource> Update(Azure.ResourceManager.Automation.Models.SourceControlPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SourceControlResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.SourceControlPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VariableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.VariableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.VariableResource>, System.Collections.IEnumerable
    {
        protected VariableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.VariableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string variableName, Azure.ResourceManager.Automation.Models.VariableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.VariableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string variableName, Azure.ResourceManager.Automation.Models.VariableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.VariableResource> Get(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.VariableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.VariableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.VariableResource>> GetAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.VariableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.VariableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.VariableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.VariableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VariableData : Azure.ResourceManager.Models.ResourceData
    {
        public VariableData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class VariableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VariableResource() { }
        public virtual Azure.ResourceManager.Automation.VariableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string variableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.VariableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.VariableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.VariableResource> Update(Azure.ResourceManager.Automation.Models.VariablePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.VariableResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.VariablePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WatcherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.WatcherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.WatcherResource>, System.Collections.IEnumerable
    {
        protected WatcherCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.WatcherResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.Automation.WatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.WatcherResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.Automation.WatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WatcherResource> Get(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.WatcherResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.WatcherResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WatcherResource>> GetAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.WatcherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.WatcherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.WatcherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.WatcherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WatcherData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WatcherData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public long? ExecutionFrequencyInSeconds { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string ScriptName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ScriptParameters { get { throw null; } }
        public string ScriptRunOn { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    public partial class WatcherResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WatcherResource() { }
        public virtual Azure.ResourceManager.Automation.WatcherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string watcherName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WatcherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WatcherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WatcherResource> Update(Azure.ResourceManager.Automation.Models.WatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WatcherResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.WatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebhookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.WebhookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.WebhookResource>, System.Collections.IEnumerable
    {
        protected WebhookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.WebhookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.Automation.Models.WebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.WebhookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.Automation.Models.WebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WebhookResource> Get(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.WebhookResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.WebhookResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WebhookResource>> GetAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.WebhookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.WebhookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.WebhookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.WebhookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebhookData : Azure.ResourceManager.Models.ResourceData
    {
        public WebhookData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastInvokedOn { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class WebhookResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebhookResource() { }
        public virtual Azure.ResourceManager.Automation.WebhookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string webhookName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WebhookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WebhookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.WebhookResource> Update(Azure.ResourceManager.Automation.Models.WebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.WebhookResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.WebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Automation.Models
{
    public partial class Activity
    {
        internal Activity() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.ActivityOutputType> OutputTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.ActivityParameterSet> ParameterSets { get { throw null; } }
    }
    public partial class ActivityOutputType
    {
        internal ActivityOutputType() { }
        public string ActivityOutputTypeValue { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ActivityParameter
    {
        internal ActivityParameter() { }
        public string ActivityParameterType { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsMandatory { get { throw null; } }
        public string Name { get { throw null; } }
        public long? Position { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.ActivityParameterValidationSet> ValidationSet { get { throw null; } }
        public bool? ValueFromPipeline { get { throw null; } }
        public bool? ValueFromPipelineByPropertyName { get { throw null; } }
        public bool? ValueFromRemainingArguments { get { throw null; } }
    }
    public partial class ActivityParameterSet
    {
        internal ActivityParameterSet() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.ActivityParameter> Parameters { get { throw null; } }
    }
    public partial class ActivityParameterValidationSet
    {
        internal ActivityParameterValidationSet() { }
        public string MemberValue { get { throw null; } }
    }
    public partial class AdvancedSchedule
    {
        public AdvancedSchedule() { }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.Models.AdvancedScheduleMonthlyOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<string> WeekDays { get { throw null; } }
    }
    public partial class AdvancedScheduleMonthlyOccurrence
    {
        public AdvancedScheduleMonthlyOccurrence() { }
        public Azure.ResourceManager.Automation.Models.ScheduleDay? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class AgentRegistration
    {
        internal AgentRegistration() { }
        public string DscMetaConfiguration { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AgentRegistrationKeys Keys { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentRegistrationKeyName : System.IEquatable<Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentRegistrationKeyName(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName Primary { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName left, Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName left, Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentRegistrationKeys
    {
        internal AgentRegistrationKeys() { }
        public string Primary { get { throw null; } }
        public string Secondary { get { throw null; } }
    }
    public partial class AgentRegistrationRegenerateKeyParameter
    {
        public AgentRegistrationRegenerateKeyParameter(Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName keyName) { }
        public Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName KeyName { get { throw null; } }
    }
    public partial class AutomationAccountCreateOrUpdateContent
    {
        public AutomationAccountCreateOrUpdateContent() { }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountModuleCreateOrUpdateContent
    {
        public AutomationAccountModuleCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.ContentLink contentLink) { }
        public Azure.ResourceManager.Automation.Models.ContentLink ContentLink { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountModulePatch
    {
        public AutomationAccountModulePatch() { }
        public Azure.ResourceManager.Automation.Models.ContentLink ContentLink { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountPatch
    {
        public AutomationAccountPatch() { }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountPython2PackageCreateOrUpdateContent
    {
        public AutomationAccountPython2PackageCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.ContentLink contentLink) { }
        public Azure.ResourceManager.Automation.Models.ContentLink ContentLink { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountPython2PackagePatch
    {
        public AutomationAccountPython2PackagePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationAccountState : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationAccountState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationAccountState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationAccountState Ok { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationAccountState Suspended { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationAccountState Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationAccountState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationAccountState left, Azure.ResourceManager.Automation.Models.AutomationAccountState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationAccountState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationAccountState left, Azure.ResourceManager.Automation.Models.AutomationAccountState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationKeyName : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationKeyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationKeyName(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationKeyName Primary { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationKeyName Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationKeyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationKeyName left, Azure.ResourceManager.Automation.Models.AutomationKeyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationKeyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationKeyName left, Azure.ResourceManager.Automation.Models.AutomationKeyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationKeyPermission : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationKeyPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationKeyPermission(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationKeyPermission Full { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationKeyPermission Read { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationKeyPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationKeyPermission left, Azure.ResourceManager.Automation.Models.AutomationKeyPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationKeyPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationKeyPermission left, Azure.ResourceManager.Automation.Models.AutomationKeyPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationPrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class AutomationPrivateLinkServiceConnectionStateProperty
    {
        public AutomationPrivateLinkServiceConnectionStateProperty() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class AutomationSku
    {
        public AutomationSku(Azure.ResourceManager.Automation.Models.SkuNameEnum name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SkuNameEnum Name { get { throw null; } set { } }
    }
    public partial class AutomationUsage
    {
        internal AutomationUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.UsageCounterName Name { get { throw null; } }
        public string ThrottleStatus { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class AzureQueryProperties
    {
        public AzureQueryProperties() { }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> Scope { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.TagSettingsProperties TagSettings { get { throw null; } set { } }
    }
    public partial class CertificateCreateOrUpdateContent
    {
        public CertificateCreateOrUpdateContent(string name, string base64Value) { }
        public string Base64Value { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsExportable { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CertificatePatch
    {
        public CertificatePatch() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ConnectionCreateOrUpdateContent
    {
        public ConnectionCreateOrUpdateContent(string name, Azure.ResourceManager.Automation.Models.ConnectionTypeAssociationProperty connectionType) { }
        public string ConnectionTypeName { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FieldDefinitionValues { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ConnectionPatch
    {
        public ConnectionPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FieldDefinitionValues { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ConnectionTypeAssociationProperty
    {
        public ConnectionTypeAssociationProperty() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class ConnectionTypeCreateOrUpdateContent
    {
        public ConnectionTypeCreateOrUpdateContent(string name, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.FieldDefinition> fieldDefinitions) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.FieldDefinition> FieldDefinitions { get { throw null; } }
        public bool? IsGlobal { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class ContentHash
    {
        public ContentHash(string algorithm, string value) { }
        public string Algorithm { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ContentLink
    {
        public ContentLink() { }
        public Azure.ResourceManager.Automation.Models.ContentHash ContentHash { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ContentSource
    {
        public ContentSource() { }
        public Azure.ResourceManager.Automation.Models.ContentHash Hash { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ContentSourceType? SourceType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentSourceType : System.IEquatable<Azure.ResourceManager.Automation.Models.ContentSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.ContentSourceType EmbeddedContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ContentSourceType Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.ContentSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.ContentSourceType left, Azure.ResourceManager.Automation.Models.ContentSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.ContentSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.ContentSourceType left, Azure.ResourceManager.Automation.Models.ContentSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CountType : System.IEquatable<Azure.ResourceManager.Automation.Models.CountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CountType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.CountType Nodeconfiguration { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.CountType Status { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.CountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.CountType left, Azure.ResourceManager.Automation.Models.CountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.CountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.CountType left, Azure.ResourceManager.Automation.Models.CountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CredentialCreateOrUpdateContent
    {
        public CredentialCreateOrUpdateContent(string name, string userName, string password) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Password { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class CredentialPatch
    {
        public CredentialPatch() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class DeletedAutomationAccount : Azure.ResourceManager.Models.ResourceData
    {
        internal DeletedAutomationAccount() { }
        public string AutomationAccountId { get { throw null; } }
        public string AutomationAccountResourceId { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string LocationPropertiesLocation { get { throw null; } }
    }
    public partial class DscCompilationJobCreateOrUpdateContent
    {
        public DscCompilationJobCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.DscConfigurationAssociationProperty configuration) { }
        public string ConfigurationName { get { throw null; } }
        public bool? IncrementNodeConfigurationBuild { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DscConfigurationAssociationProperty
    {
        public DscConfigurationAssociationProperty() { }
        public string ConfigurationName { get { throw null; } set { } }
    }
    public partial class DscConfigurationCreateOrUpdateContent
    {
        public DscConfigurationCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.ContentSource source) { }
        public string Description { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public bool? LogProgress { get { throw null; } set { } }
        public bool? LogVerbose { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.DscConfigurationParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.ContentSource Source { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DscConfigurationParameter
    {
        public DscConfigurationParameter() { }
        public string DefaultValue { get { throw null; } set { } }
        public string DscConfigurationParameterType { get { throw null; } set { } }
        public bool? IsMandatory { get { throw null; } set { } }
        public int? Position { get { throw null; } set { } }
    }
    public partial class DscConfigurationPatch
    {
        public DscConfigurationPatch() { }
        public string Description { get { throw null; } set { } }
        public bool? LogProgress { get { throw null; } set { } }
        public bool? LogVerbose { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.DscConfigurationParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.ContentSource Source { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DscConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DscConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState left, Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState left, Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DscConfigurationState : System.IEquatable<Azure.ResourceManager.Automation.Models.DscConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DscConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscConfigurationState Edit { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.DscConfigurationState New { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.DscConfigurationState Published { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.DscConfigurationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.DscConfigurationState left, Azure.ResourceManager.Automation.Models.DscConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.DscConfigurationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.DscConfigurationState left, Azure.ResourceManager.Automation.Models.DscConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DscMetaConfiguration
    {
        internal DscMetaConfiguration() { }
        public string ActionAfterReboot { get { throw null; } }
        public bool? AllowModuleOverwrite { get { throw null; } }
        public string CertificateId { get { throw null; } }
        public string ConfigurationMode { get { throw null; } }
        public int? ConfigurationModeFrequencyMins { get { throw null; } }
        public bool? RebootNodeIfNeeded { get { throw null; } }
        public int? RefreshFrequencyMins { get { throw null; } }
    }
    public partial class DscNodeConfigurationCreateOrUpdateContent
    {
        public DscNodeConfigurationCreateOrUpdateContent() { }
        public string ConfigurationName { get { throw null; } set { } }
        public bool? IncrementNodeConfigurationBuild { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ContentSource Source { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DscNodeExtensionHandlerAssociationProperty
    {
        public DscNodeExtensionHandlerAssociationProperty() { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class DscNodePatch
    {
        public DscNodePatch() { }
        public string DscNodeUpdateParametersName { get { throw null; } set { } }
        public string NodeId { get { throw null; } set { } }
    }
    public partial class DscNodeReport
    {
        internal DscNodeReport() { }
        public string ConfigurationVersion { get { throw null; } }
        public string DscNodeReportType { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.DscReportError> Errors { get { throw null; } }
        public string HostName { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPV4Addresses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPV6Addresses { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.DscMetaConfiguration MetaConfiguration { get { throw null; } }
        public int? NumberOfResources { get { throw null; } }
        public string RawErrors { get { throw null; } }
        public string RebootRequested { get { throw null; } }
        public string RefreshMode { get { throw null; } }
        public string ReportFormatVersion { get { throw null; } }
        public string ReportId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.DscReportResource> Resources { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class DscReportError
    {
        internal DscReportError() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string ErrorSource { get { throw null; } }
        public string Locale { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class DscReportResource
    {
        internal DscReportResource() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.DscReportResourceNavigation> DependsOn { get { throw null; } }
        public double? DurationInSeconds { get { throw null; } }
        public string Error { get { throw null; } }
        public string ModuleName { get { throw null; } }
        public string ModuleVersion { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string SourceInfo { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class DscReportResourceNavigation
    {
        internal DscReportResourceNavigation() { }
        public string ResourceId { get { throw null; } }
    }
    public enum EncryptionKeySourceType
    {
        MicrosoftAutomation = 0,
        MicrosoftKeyvault = 1,
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties() { }
        public Azure.ResourceManager.Automation.Models.EncryptionKeySourceType? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.BinaryData UserAssignedIdentity { get { throw null; } set { } }
    }
    public partial class ErrorResponse
    {
        public ErrorResponse() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class FieldDefinition
    {
        public FieldDefinition(string fieldDefinitionType) { }
        public string FieldDefinitionType { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public bool? IsOptional { get { throw null; } set { } }
    }
    public partial class GraphicalRunbookContent
    {
        public GraphicalRunbookContent() { }
        public string GraphRunbookJson { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.RawGraphicalRunbookContent RawContent { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GraphRunbookType : System.IEquatable<Azure.ResourceManager.Automation.Models.GraphRunbookType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GraphRunbookType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.GraphRunbookType GraphPowerShell { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.GraphRunbookType GraphPowerShellWorkflow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.GraphRunbookType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.GraphRunbookType left, Azure.ResourceManager.Automation.Models.GraphRunbookType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.GraphRunbookType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.GraphRunbookType left, Azure.ResourceManager.Automation.Models.GraphRunbookType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupTypeEnum : System.IEquatable<Azure.ResourceManager.Automation.Models.GroupTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.GroupTypeEnum System { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.GroupTypeEnum User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.GroupTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.GroupTypeEnum left, Azure.ResourceManager.Automation.Models.GroupTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.GroupTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.GroupTypeEnum left, Azure.ResourceManager.Automation.Models.GroupTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HttpStatusCode : System.IEquatable<Azure.ResourceManager.Automation.Models.HttpStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HttpStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Accepted { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Ambiguous { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode BadGateway { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode BadRequest { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Conflict { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Continue { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Created { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode ExpectationFailed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Forbidden { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Found { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode GatewayTimeout { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Gone { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode HttpVersionNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode InternalServerError { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode LengthRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode MethodNotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Moved { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode MovedPermanently { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode MultipleChoices { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode NoContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode NonAuthoritativeInformation { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode NotAcceptable { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode NotFound { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode NotImplemented { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode NotModified { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode OK { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode PartialContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode PaymentRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode PreconditionFailed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode ProxyAuthenticationRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Redirect { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode RedirectKeepVerb { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode RedirectMethod { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode RequestedRangeNotSatisfiable { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode RequestEntityTooLarge { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode RequestTimeout { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode RequestUriTooLong { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode ResetContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode SeeOther { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode ServiceUnavailable { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode SwitchingProtocols { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode TemporaryRedirect { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Unauthorized { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode UnsupportedMediaType { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode Unused { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode UpgradeRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HttpStatusCode UseProxy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.HttpStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.HttpStatusCode left, Azure.ResourceManager.Automation.Models.HttpStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.HttpStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.HttpStatusCode left, Azure.ResourceManager.Automation.Models.HttpStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridRunbookWorkerCreateOrUpdateContent
    {
        public HybridRunbookWorkerCreateOrUpdateContent() { }
        public string Name { get { throw null; } set { } }
        public string VmResourceId { get { throw null; } set { } }
    }
    public partial class HybridRunbookWorkerGroupCreateOrUpdateParameters
    {
        public HybridRunbookWorkerGroupCreateOrUpdateParameters() { }
        public string CredentialName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class HybridRunbookWorkerMoveContent
    {
        public HybridRunbookWorkerMoveContent() { }
        public string HybridRunbookWorkerGroupName { get { throw null; } set { } }
    }
    public partial class JobCollectionItem : Azure.ResourceManager.Models.ResourceData
    {
        public JobCollectionItem() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Guid? JobId { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunbookName { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.JobStatus? Status { get { throw null; } }
    }
    public partial class JobCreateOrUpdateContent
    {
        public JobCreateOrUpdateContent() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobProvisioningState : System.IEquatable<Azure.ResourceManager.Automation.Models.JobProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.JobProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobProvisioningState Processing { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobProvisioningState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.JobProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.JobProvisioningState left, Azure.ResourceManager.Automation.Models.JobProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.JobProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.JobProvisioningState left, Azure.ResourceManager.Automation.Models.JobProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobScheduleCreateOrUpdateContent
    {
        public JobScheduleCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.ScheduleAssociationProperty schedule, Azure.ResourceManager.Automation.Models.RunbookAssociationProperty runbook) { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
        public string ScheduleName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.Automation.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.JobStatus Activating { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Blocked { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus New { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Removing { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Resuming { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStatus Suspending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.JobStatus left, Azure.ResourceManager.Automation.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.JobStatus left, Azure.ResourceManager.Automation.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobStream
    {
        internal JobStream() { }
        public string Id { get { throw null; } }
        public string JobStreamId { get { throw null; } }
        public string StreamText { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.JobStreamType? StreamType { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStreamType : System.IEquatable<Azure.ResourceManager.Automation.Models.JobStreamType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStreamType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.JobStreamType Any { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStreamType Debug { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStreamType Error { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStreamType Output { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStreamType Progress { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStreamType Verbose { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.JobStreamType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.JobStreamType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.JobStreamType left, Azure.ResourceManager.Automation.Models.JobStreamType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.JobStreamType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.JobStreamType left, Azure.ResourceManager.Automation.Models.JobStreamType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Key
    {
        internal Key() { }
        public Azure.ResourceManager.Automation.Models.AutomationKeyName? KeyName { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationKeyPermission? Permissions { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class KeyListResult
    {
        internal KeyListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.Key> Keys { get { throw null; } }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyvaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    public partial class LinkedWorkspace
    {
        internal LinkedWorkspace() { }
        public string Id { get { throw null; } }
    }
    public partial class LinuxProperties
    {
        public LinuxProperties() { }
        public System.Collections.Generic.IList<string> ExcludedPackageNameMasks { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.LinuxUpdateClass? IncludedPackageClassifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IncludedPackageNameMasks { get { throw null; } }
        public string RebootSetting { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxUpdateClass : System.IEquatable<Azure.ResourceManager.Automation.Models.LinuxUpdateClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxUpdateClass(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClass Critical { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClass Other { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClass Security { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClass Unclassified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.LinuxUpdateClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.LinuxUpdateClass left, Azure.ResourceManager.Automation.Models.LinuxUpdateClass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.LinuxUpdateClass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.LinuxUpdateClass left, Azure.ResourceManager.Automation.Models.LinuxUpdateClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModuleErrorInfo
    {
        public ModuleErrorInfo() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public enum ModuleProvisioningState
    {
        Created = 0,
        Creating = 1,
        StartingImportModuleRunbook = 2,
        RunningImportModuleRunbook = 3,
        ContentRetrieved = 4,
        ContentDownloaded = 5,
        ContentValidated = 6,
        ConnectionTypeImported = 7,
        ContentStored = 8,
        ModuleDataStored = 9,
        ActivitiesStored = 10,
        ModuleImportRunbookComplete = 11,
        Succeeded = 12,
        Failed = 13,
        Cancelled = 14,
        Updating = 15,
    }
    public partial class NodeCount
    {
        internal NodeCount() { }
        public string Name { get { throw null; } }
        public int? NameCount { get { throw null; } }
    }
    public partial class NonAzureQueryProperties
    {
        public NonAzureQueryProperties() { }
        public string FunctionAlias { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public enum OperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Automation.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.ProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ProvisioningState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.ProvisioningState left, Azure.ResourceManager.Automation.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.ProvisioningState left, Azure.ResourceManager.Automation.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RawGraphicalRunbookContent
    {
        public RawGraphicalRunbookContent() { }
        public string RunbookDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.GraphRunbookType? RunbookType { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } set { } }
    }
    public partial class RunbookAssociationProperty
    {
        public RunbookAssociationProperty() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class RunbookCreateOrUpdateContent
    {
        public RunbookCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.RunbookTypeEnum runbookType) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.RunbookDraft Draft { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? LogActivityTrace { get { throw null; } set { } }
        public bool? LogProgress { get { throw null; } set { } }
        public bool? LogVerbose { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ContentLink PublishContentLink { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.RunbookTypeEnum RunbookType { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class RunbookDraft
    {
        public RunbookDraft() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ContentLink DraftContentLink { get { throw null; } set { } }
        public bool? InEdit { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OutputTypes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.RunbookParameter> Parameters { get { throw null; } }
    }
    public partial class RunbookDraftUndoEditResult
    {
        internal RunbookDraftUndoEditResult() { }
        public string RequestId { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.HttpStatusCode? StatusCode { get { throw null; } }
    }
    public partial class RunbookParameter
    {
        public RunbookParameter() { }
        public string DefaultValue { get { throw null; } set { } }
        public bool? IsMandatory { get { throw null; } set { } }
        public int? Position { get { throw null; } set { } }
        public string RunbookParameterType { get { throw null; } set { } }
    }
    public partial class RunbookPatch
    {
        public RunbookPatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? LogActivityTrace { get { throw null; } set { } }
        public bool? LogProgress { get { throw null; } set { } }
        public bool? LogVerbose { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunbookProvisioningState : System.IEquatable<Azure.ResourceManager.Automation.Models.RunbookProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunbookProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.RunbookProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.RunbookProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.RunbookProvisioningState left, Azure.ResourceManager.Automation.Models.RunbookProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.RunbookProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.RunbookProvisioningState left, Azure.ResourceManager.Automation.Models.RunbookProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunbookState : System.IEquatable<Azure.ResourceManager.Automation.Models.RunbookState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunbookState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.RunbookState Edit { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookState New { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookState Published { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.RunbookState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.RunbookState left, Azure.ResourceManager.Automation.Models.RunbookState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.RunbookState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.RunbookState left, Azure.ResourceManager.Automation.Models.RunbookState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunbookTypeEnum : System.IEquatable<Azure.ResourceManager.Automation.Models.RunbookTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunbookTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum Graph { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum GraphPowerShell { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum GraphPowerShellWorkflow { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum PowerShell { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum PowerShellWorkflow { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum Python2 { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum Python3 { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.RunbookTypeEnum Script { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.RunbookTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.RunbookTypeEnum left, Azure.ResourceManager.Automation.Models.RunbookTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.RunbookTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.RunbookTypeEnum left, Azure.ResourceManager.Automation.Models.RunbookTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleAssociationProperty
    {
        public ScheduleAssociationProperty() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class ScheduleCreateOrUpdateContent
    {
        public ScheduleCreateOrUpdateContent(string name, System.DateTimeOffset startOn, Azure.ResourceManager.Automation.Models.ScheduleFrequency frequency) { }
        public Azure.ResourceManager.Automation.Models.AdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ScheduleFrequency Frequency { get { throw null; } }
        public System.BinaryData Interval { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleDay : System.IEquatable<Azure.ResourceManager.Automation.Models.ScheduleDay>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleDay(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.ScheduleDay Friday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleDay Monday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleDay Saturday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleDay Sunday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleDay Thursday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleDay Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleDay Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.ScheduleDay other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.ScheduleDay left, Azure.ResourceManager.Automation.Models.ScheduleDay right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.ScheduleDay (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.ScheduleDay left, Azure.ResourceManager.Automation.Models.ScheduleDay right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleFrequency : System.IEquatable<Azure.ResourceManager.Automation.Models.ScheduleFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleFrequency(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.ScheduleFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleFrequency OneTime { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.ScheduleFrequency Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.ScheduleFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.ScheduleFrequency left, Azure.ResourceManager.Automation.Models.ScheduleFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.ScheduleFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.ScheduleFrequency left, Azure.ResourceManager.Automation.Models.ScheduleFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SchedulePatch
    {
        public SchedulePatch() { }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuNameEnum : System.IEquatable<Azure.ResourceManager.Automation.Models.SkuNameEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuNameEnum(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SkuNameEnum Basic { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SkuNameEnum Free { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SkuNameEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SkuNameEnum left, Azure.ResourceManager.Automation.Models.SkuNameEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SkuNameEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SkuNameEnum left, Azure.ResourceManager.Automation.Models.SkuNameEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoftwareUpdateConfigurationCollectionItem
    {
        internal SoftwareUpdateConfigurationCollectionItem() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.ScheduleFrequency? Frequency { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextRun { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTasks Tasks { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.UpdateConfiguration UpdateConfiguration { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationMachineRun
    {
        internal SoftwareUpdateConfigurationMachineRun() { }
        public System.TimeSpan? ConfiguredDuration { get { throw null; } }
        public System.Guid? CorrelationId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.ErrorResponse Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Core.ResourceIdentifier JobId { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string OSType { get { throw null; } }
        public string SoftwareUpdateName { get { throw null; } }
        public System.Guid? SourceComputerId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public string TargetComputer { get { throw null; } }
        public string TargetComputerType { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationRun
    {
        internal SoftwareUpdateConfigurationRun() { }
        public int? ComputerCount { get { throw null; } }
        public System.TimeSpan? ConfiguredDuration { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public int? FailedCount { get { throw null; } }
        public string Id { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string OSType { get { throw null; } }
        public string SoftwareUpdateName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTasks Tasks { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationRunTaskProperties
    {
        internal SoftwareUpdateConfigurationRunTaskProperties() { }
        public string JobId { get { throw null; } }
        public string Source { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationRunTasks
    {
        internal SoftwareUpdateConfigurationRunTasks() { }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTaskProperties PostTask { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTaskProperties PreTask { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationTasks
    {
        public SoftwareUpdateConfigurationTasks() { }
        public Azure.ResourceManager.Automation.Models.TaskProperties PostTask { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.TaskProperties PreTask { get { throw null; } set { } }
    }
    public partial class SourceControlCreateOrUpdateContent
    {
        public SourceControlCreateOrUpdateContent() { }
        public bool? AutoSync { get { throw null; } set { } }
        public string Branch { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public bool? PublishRunbook { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceControlSecurityTokenProperties SecurityToken { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceType? SourceType { get { throw null; } set { } }
    }
    public partial class SourceControlPatch
    {
        public SourceControlPatch() { }
        public bool? AutoSync { get { throw null; } set { } }
        public string Branch { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public bool? PublishRunbook { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceControlSecurityTokenProperties SecurityToken { get { throw null; } set { } }
    }
    public partial class SourceControlSecurityTokenProperties
    {
        public SourceControlSecurityTokenProperties() { }
        public string AccessToken { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.TokenType? TokenType { get { throw null; } set { } }
    }
    public partial class SourceControlSyncJob : Azure.ResourceManager.Models.ResourceData
    {
        internal SourceControlSyncJob() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceControlSyncJobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SyncType? SyncType { get { throw null; } }
    }
    public partial class SourceControlSyncJobById
    {
        internal SourceControlSyncJobById() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Exception { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceControlSyncJobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SyncType? SyncType { get { throw null; } }
    }
    public partial class SourceControlSyncJobCreateContent
    {
        public SourceControlSyncJobCreateContent(string commitId) { }
        public string CommitId { get { throw null; } }
    }
    public partial class SourceControlSyncJobStream
    {
        internal SourceControlSyncJobStream() { }
        public string Id { get { throw null; } }
        public string SourceControlSyncJobStreamId { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.StreamType? StreamType { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class SourceControlSyncJobStreamById
    {
        internal SourceControlSyncJobStreamById() { }
        public string Id { get { throw null; } }
        public string SourceControlSyncJobStreamId { get { throw null; } }
        public string StreamText { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.StreamType? StreamType { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceType : System.IEquatable<Azure.ResourceManager.Automation.Models.SourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceType GitHub { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceType VsoGit { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceType VsoTfvc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SourceType left, Azure.ResourceManager.Automation.Models.SourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SourceType left, Azure.ResourceManager.Automation.Models.SourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Statistics
    {
        internal Statistics() { }
        public string CounterProperty { get { throw null; } }
        public long? CounterValue { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamType : System.IEquatable<Azure.ResourceManager.Automation.Models.StreamType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.StreamType Error { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.StreamType Output { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.StreamType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.StreamType left, Azure.ResourceManager.Automation.Models.StreamType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.StreamType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.StreamType left, Azure.ResourceManager.Automation.Models.StreamType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SUCScheduleProperties
    {
        public SUCScheduleProperties() { }
        public Azure.ResourceManager.Automation.Models.AdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public double? ExpiryTimeOffsetMinutes { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ScheduleFrequency? Frequency { get { throw null; } set { } }
        public long? Interval { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.DateTimeOffset? NextRun { get { throw null; } set { } }
        public double? NextRunOffsetMinutes { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public double? StartTimeOffsetMinutes { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SyncType : System.IEquatable<Azure.ResourceManager.Automation.Models.SyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SyncType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SyncType FullSync { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SyncType PartialSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SyncType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SyncType left, Azure.ResourceManager.Automation.Models.SyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SyncType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SyncType left, Azure.ResourceManager.Automation.Models.SyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum TagOperator
    {
        All = 0,
        Any = 1,
    }
    public partial class TagSettingsProperties
    {
        public TagSettingsProperties() { }
        public Azure.ResourceManager.Automation.Models.TagOperator? FilterOperator { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
    }
    public partial class TargetProperties
    {
        public TargetProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.Models.AzureQueryProperties> AzureQueries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.Models.NonAzureQueryProperties> NonAzureQueries { get { throw null; } }
    }
    public partial class TaskProperties
    {
        public TaskProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string Source { get { throw null; } set { } }
    }
    public partial class TestJob
    {
        internal TestJob() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Exception { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.DateTimeOffset? LastStatusModifiedOn { get { throw null; } }
        public int? LogActivityTrace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Parameters { get { throw null; } }
        public string RunOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
    }
    public partial class TestJobCreateContent
    {
        public TestJobCreateContent() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TokenType : System.IEquatable<Azure.ResourceManager.Automation.Models.TokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TokenType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.TokenType Oauth { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.TokenType PersonalAccessToken { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.TokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.TokenType left, Azure.ResourceManager.Automation.Models.TokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.TokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.TokenType left, Azure.ResourceManager.Automation.Models.TokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TypeField
    {
        internal TypeField() { }
        public string Name { get { throw null; } }
        public string TypeFieldType { get { throw null; } }
    }
    public partial class UpdateConfiguration
    {
        public UpdateConfiguration(Azure.ResourceManager.Automation.Models.OperatingSystemType operatingSystem) { }
        public System.Collections.Generic.IList<string> AzureVirtualMachines { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.LinuxProperties Linux { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NonAzureComputerNames { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.OperatingSystemType OperatingSystem { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.TargetProperties Targets { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.WindowsProperties Windows { get { throw null; } set { } }
    }
    public partial class UsageCounterName
    {
        internal UsageCounterName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class VariableCreateOrUpdateContent
    {
        public VariableCreateOrUpdateContent(string name) { }
        public string Description { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class VariablePatch
    {
        public VariablePatch() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class WatcherPatch
    {
        public WatcherPatch() { }
        public long? ExecutionFrequencyInSeconds { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class WebhookCreateOrUpdateContent
    {
        public WebhookCreateOrUpdateContent(string name) { }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class WebhookPatch
    {
        public WebhookPatch() { }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
    }
    public partial class WindowsProperties
    {
        public WindowsProperties() { }
        public System.Collections.Generic.IList<string> ExcludedKbNumbers { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedKbNumbers { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.WindowsUpdateClass? IncludedUpdateClassifications { get { throw null; } set { } }
        public string RebootSetting { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsUpdateClass : System.IEquatable<Azure.ResourceManager.Automation.Models.WindowsUpdateClass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsUpdateClass(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass Critical { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass Definition { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass FeaturePack { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass Security { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass ServicePack { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass Tools { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass Unclassified { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass UpdateRollup { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClass Updates { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.WindowsUpdateClass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.WindowsUpdateClass left, Azure.ResourceManager.Automation.Models.WindowsUpdateClass right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.WindowsUpdateClass (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.WindowsUpdateClass left, Azure.ResourceManager.Automation.Models.WindowsUpdateClass right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkerType : System.IEquatable<Azure.ResourceManager.Automation.Models.WorkerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkerType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.WorkerType HybridV1 { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WorkerType HybridV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.WorkerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.WorkerType left, Azure.ResourceManager.Automation.Models.WorkerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.WorkerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.WorkerType left, Azure.ResourceManager.Automation.Models.WorkerType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
