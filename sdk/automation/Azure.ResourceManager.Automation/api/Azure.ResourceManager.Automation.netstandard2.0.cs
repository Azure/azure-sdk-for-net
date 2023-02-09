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
        public Azure.ResourceManager.Automation.Models.AutomationEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsPublicNetworkAccessAllowed { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
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
        public virtual Azure.ResourceManager.Automation.AutomationModuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string moduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationActivity> GetActivities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationActivity> GetActivitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AutomationActivity> GetActivity(string activityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AutomationActivity>> GetActivityAsync(string activityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationModuleField> GetFieldsByModuleAndType(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationModuleField> GetFieldsByModuleAndTypeAsync(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationModuleField> GetFieldsByType(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationModuleField> GetFieldsByTypeAsync(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.Automation.AutomationModuleData Data { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.DscNodeCount> GetAllNodeCountInformation(Azure.ResourceManager.Automation.Models.AutomationCountType countType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.DscNodeCount> GetAllNodeCountInformationAsync(Azure.ResourceManager.Automation.Models.AutomationCountType countType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationKey> GetAutomationAccountKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationKey> GetAutomationAccountKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource> GetAutomationAccountModule(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountModuleResource>> GetAutomationAccountModuleAsync(string moduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationAccountModuleCollection GetAutomationAccountModules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource> GetAutomationAccountPython2Package(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountPython2PackageResource>> GetAutomationAccountPython2PackageAsync(string packageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationAccountPython2PackageCollection GetAutomationAccountPython2Packages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource> GetAutomationCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource>> GetAutomationCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationCertificateCollection GetAutomationCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource> GetAutomationConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource>> GetAutomationConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationConnectionCollection GetAutomationConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> GetAutomationConnectionType(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>> GetAutomationConnectionTypeAsync(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationConnectionTypeCollection GetAutomationConnectionTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource> GetAutomationCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource>> GetAutomationCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationCredentialCollection GetAutomationCredentials() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationJobResource> GetAutomationJob(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationJobResource>> GetAutomationJobAsync(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationJobCollection GetAutomationJobs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationJobScheduleResource> GetAutomationJobSchedule(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationJobScheduleResource>> GetAutomationJobScheduleAsync(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationJobScheduleCollection GetAutomationJobSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource> GetAutomationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource>> GetAutomationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionCollection GetAutomationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource> GetAutomationRunbook(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource>> GetAutomationRunbookAsync(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationRunbookCollection GetAutomationRunbooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource> GetAutomationSchedule(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource>> GetAutomationScheduleAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationScheduleCollection GetAutomationSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource> GetAutomationSourceControl(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource>> GetAutomationSourceControlAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationSourceControlCollection GetAutomationSourceControls() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource> GetAutomationVariable(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource>> GetAutomationVariableAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationVariableCollection GetAutomationVariables() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource> GetAutomationWatcher(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource>> GetAutomationWatcherAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationWatcherCollection GetAutomationWatchers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource> GetAutomationWebhook(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource>> GetAutomationWebhookAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.AutomationWebhookCollection GetAutomationWebhooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource> GetDscCompilationJob(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscCompilationJobResource>> GetDscCompilationJobAsync(string compilationJobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.DscCompilationJobCollection GetDscCompilationJobs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetDscCompilationJobStreams(System.Guid jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetDscCompilationJobStreamsAsync(System.Guid jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource> GetDscConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscConfigurationResource>> GetDscConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.DscConfigurationCollection GetDscConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeResource> GetDscNode(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeResource>> GetDscNodeAsync(string nodeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource> GetDscNodeConfiguration(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.DscNodeConfigurationResource>> GetDscNodeConfigurationAsync(string nodeConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.DscNodeConfigurationCollection GetDscNodeConfigurations() { throw null; }
        public virtual Azure.ResourceManager.Automation.DscNodeCollection GetDscNodes() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationModuleField> GetFieldsByType(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationModuleField> GetFieldsByTypeAsync(string typeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> GetHybridRunbookWorkerGroup(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> GetHybridRunbookWorkerGroupAsync(string hybridRunbookWorkerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.HybridRunbookWorkerGroupCollection GetHybridRunbookWorkerGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AutomationLinkedWorkspace> GetLinkedWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AutomationLinkedWorkspace>> GetLinkedWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource> GetSoftwareUpdateConfiguration(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource>> GetSoftwareUpdateConfigurationAsync(string softwareUpdateConfigurationName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun> GetSoftwareUpdateConfigurationMachineRun(System.Guid softwareUpdateConfigurationMachineRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun>> GetSoftwareUpdateConfigurationMachineRunAsync(System.Guid softwareUpdateConfigurationMachineRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun> GetSoftwareUpdateConfigurationMachineRuns(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun> GetSoftwareUpdateConfigurationMachineRunsAsync(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun> GetSoftwareUpdateConfigurationRun(System.Guid softwareUpdateConfigurationRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun>> GetSoftwareUpdateConfigurationRunAsync(System.Guid softwareUpdateConfigurationRunId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun> GetSoftwareUpdateConfigurationRuns(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun> GetSoftwareUpdateConfigurationRunsAsync(string clientRequestId = null, string filter = null, string skip = null, string top = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automation.SoftwareUpdateConfigurationCollection GetSoftwareUpdateConfigurations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationAccountStatistics> GetStatistics(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationAccountStatistics> GetStatisticsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetStreamDscCompilationJob(System.Guid jobId, string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AutomationJobStream>> GetStreamDscCompilationJobAsync(System.Guid jobId, string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationUsage> GetUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationUsage> GetUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AgentRegistration> RegenerateKeyAgentRegistrationInformation(Azure.ResourceManager.Automation.Models.AgentRegistrationRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AgentRegistration>> RegenerateKeyAgentRegistrationInformationAsync(Azure.ResourceManager.Automation.Models.AgentRegistrationRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource> Update(Azure.ResourceManager.Automation.Models.AutomationAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationAccountResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationCertificateResource>, System.Collections.IEnumerable
    {
        protected AutomationCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Automation.Models.AutomationCertificateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Automation.Models.AutomationCertificateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationCertificateData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationCertificateData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public bool? IsExportable { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
    }
    public partial class AutomationCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationCertificateResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource> Update(Azure.ResourceManager.Automation.Models.AutomationCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCertificateResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationCertificatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationConnectionResource>, System.Collections.IEnumerable
    {
        protected AutomationConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.Automation.Models.AutomationConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionName, Azure.ResourceManager.Automation.Models.AutomationConnectionCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource> Get(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource>> GetAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationConnectionData() { }
        public string ConnectionTypeName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FieldDefinitionValues { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class AutomationConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationConnectionResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string connectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource> Update(Azure.ResourceManager.Automation.Models.AutomationConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationConnectionTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>, System.Collections.IEnumerable
    {
        protected AutomationConnectionTypeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectionTypeName, Azure.ResourceManager.Automation.Models.AutomationConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectionTypeName, Azure.ResourceManager.Automation.Models.AutomationConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> Get(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>> GetAsync(string connectionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationConnectionTypeData : Azure.ResourceManager.Models.ResourceData
    {
        internal AutomationConnectionTypeData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Automation.Models.AutomationConnectionFieldDefinition> FieldDefinitions { get { throw null; } }
        public bool? IsGlobal { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class AutomationConnectionTypeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationConnectionTypeResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationConnectionTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string connectionTypeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationConnectionTypeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.AutomationConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationConnectionTypeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.AutomationConnectionTypeCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationCredentialCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationCredentialResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationCredentialResource>, System.Collections.IEnumerable
    {
        protected AutomationCredentialCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationCredentialResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Automation.Models.AutomationCredentialCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationCredentialResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string credentialName, Azure.ResourceManager.Automation.Models.AutomationCredentialCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource> Get(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationCredentialResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationCredentialResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource>> GetAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationCredentialResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationCredentialResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationCredentialResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationCredentialResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationCredentialData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationCredentialData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class AutomationCredentialResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationCredentialResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationCredentialData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string credentialName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource> Update(Azure.ResourceManager.Automation.Models.AutomationCredentialPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationCredentialResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationCredentialPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.Automation.AutomationCertificateResource GetAutomationCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationConnectionResource GetAutomationConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationConnectionTypeResource GetAutomationConnectionTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationCredentialResource GetAutomationCredentialResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationJobResource GetAutomationJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationJobScheduleResource GetAutomationJobScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionResource GetAutomationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationRunbookResource GetAutomationRunbookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationScheduleResource GetAutomationScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationSourceControlResource GetAutomationSourceControlResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationVariableResource GetAutomationVariableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationWatcherResource GetAutomationWatcherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationWebhookResource GetAutomationWebhookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automation.Models.DeletedAutomationAccount> GetDeletedAutomationAccountsBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.DeletedAutomationAccount> GetDeletedAutomationAccountsBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automation.DscCompilationJobResource GetDscCompilationJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.DscConfigurationResource GetDscConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.DscNodeConfigurationResource GetDscNodeConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.DscNodeResource GetDscNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource GetHybridRunbookWorkerGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.HybridRunbookWorkerResource GetHybridRunbookWorkerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automation.SoftwareUpdateConfigurationResource GetSoftwareUpdateConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AutomationJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData>, System.Collections.IEnumerable
    {
        protected AutomationJobCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Automation.Models.AutomationJobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string jobName, Azure.ResourceManager.Automation.Models.AutomationJobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationJobResource> Get(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData> GetAll(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData> GetAllAsync(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationJobResource>> GetAsync(string jobName, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationJobData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationJobData() { }
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
        public Azure.ResourceManager.Automation.Models.AutomationJobStatus? Status { get { throw null; } set { } }
        public string StatusDetails { get { throw null; } set { } }
    }
    public partial class AutomationJobResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationJobResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationJobResource> Get(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationJobResource>> GetAsync(string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetJobStream(string jobStreamId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AutomationJobStream>> GetJobStreamAsync(string jobStreamId, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetJobStreams(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetJobStreamsAsync(string filter = null, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.AutomationJobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.AutomationJobCreateOrUpdateContent content, string clientRequestId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationJobScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationJobScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationJobScheduleResource>, System.Collections.IEnumerable
    {
        protected AutomationJobScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid jobScheduleId, Azure.ResourceManager.Automation.Models.AutomationJobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid jobScheduleId, Azure.ResourceManager.Automation.Models.AutomationJobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationJobScheduleResource> Get(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationJobScheduleResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationJobScheduleResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationJobScheduleResource>> GetAsync(System.Guid jobScheduleId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationJobScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationJobScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationJobScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationJobScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationJobScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        internal AutomationJobScheduleData() { }
        public System.Guid? JobScheduleId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } }
        public string RunOn { get { throw null; } }
        public string ScheduleName { get { throw null; } }
    }
    public partial class AutomationJobScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationJobScheduleResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationJobScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, System.Guid jobScheduleId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationJobScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationJobScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobScheduleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.AutomationJobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationJobScheduleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automation.Models.AutomationJobScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationModuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutomationModuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? ActivityCount { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationContentLink ContentLink { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationModuleErrorInfo Error { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsComposite { get { throw null; } set { } }
        public bool? IsGlobal { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.ModuleProvisioningState? ProvisioningState { get { throw null; } set { } }
        public long? SizeInBytes { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
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
    public partial class AutomationRunbookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationRunbookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationRunbookResource>, System.Collections.IEnumerable
    {
        protected AutomationRunbookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationRunbookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string runbookName, Azure.ResourceManager.Automation.Models.AutomationRunbookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationRunbookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string runbookName, Azure.ResourceManager.Automation.Models.AutomationRunbookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource> Get(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationRunbookResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationRunbookResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource>> GetAsync(string runbookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationRunbookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationRunbookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationRunbookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationRunbookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationRunbookData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutomationRunbookData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationRunbookDraft Draft { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public bool? IsLogProgressEnabled { get { throw null; } set { } }
        public bool? IsLogVerboseEnabled { get { throw null; } set { } }
        public int? JobCount { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public int? LogActivityTrace { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OutputTypes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.RunbookParameterDefinition> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.RunbookProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationContentLink PublishContentLink { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationRunbookType? RunbookType { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.RunbookState? State { get { throw null; } set { } }
    }
    public partial class AutomationRunbookResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationRunbookResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationRunbookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string runbookName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.RunbookTestJob> CreateTestJob(Azure.ResourceManager.Automation.Models.RunbookTestJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.RunbookTestJob>> CreateTestJobAsync(Azure.ResourceManager.Automation.Models.RunbookTestJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetContent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetContentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> GetContentRunbookDraft(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetContentRunbookDraftAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AutomationRunbookDraft> GetRunbookDraft(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AutomationRunbookDraft>> GetRunbookDraftAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.RunbookTestJob> GetTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.RunbookTestJob>> GetTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetTestJobStream(string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.AutomationJobStream>> GetTestJobStreamAsync(string jobStreamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetTestJobStreams(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.AutomationJobStream> GetTestJobStreamsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Publish(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PublishAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReplaceContentRunbookDraft(Azure.WaitUntil waitUntil, System.IO.Stream runbookContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReplaceContentRunbookDraftAsync(Azure.WaitUntil waitUntil, System.IO.Stream runbookContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResumeTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SuspendTestJob(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SuspendTestJobAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.RunbookDraftUndoEditResult> UndoEditRunbookDraft(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.RunbookDraftUndoEditResult>> UndoEditRunbookDraftAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource> Update(Azure.ResourceManager.Automation.Models.AutomationRunbookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationRunbookResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationRunbookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationScheduleResource>, System.Collections.IEnumerable
    {
        protected AutomationScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.Automation.Models.AutomationScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scheduleName, Azure.ResourceManager.Automation.Models.AutomationScheduleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource> Get(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationScheduleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationScheduleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource>> GetAsync(string scheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationScheduleData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationScheduleData() { }
        public Azure.ResourceManager.Automation.Models.AutomationAdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public double? ExpireInMinutes { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency? Frequency { get { throw null; } set { } }
        public System.BinaryData Interval { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public double? NextRunInMinutes { get { throw null; } set { } }
        public System.DateTimeOffset? NextRunOn { get { throw null; } set { } }
        public double? StartInMinutes { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class AutomationScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationScheduleResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string scheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource> Update(Azure.ResourceManager.Automation.Models.AutomationSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationScheduleResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationSourceControlCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationSourceControlResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationSourceControlResource>, System.Collections.IEnumerable
    {
        protected AutomationSourceControlCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationSourceControlResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sourceControlName, Azure.ResourceManager.Automation.Models.AutomationSourceControlCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationSourceControlResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sourceControlName, Azure.ResourceManager.Automation.Models.AutomationSourceControlCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource> Get(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationSourceControlResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationSourceControlResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource>> GetAsync(string sourceControlName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationSourceControlResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationSourceControlResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationSourceControlResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationSourceControlResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationSourceControlData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationSourceControlData() { }
        public string Branch { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public bool? IsAutoPublishRunbookEnabled { get { throw null; } set { } }
        public bool? IsAutoSyncEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceControlSourceType? SourceType { get { throw null; } set { } }
    }
    public partial class AutomationSourceControlResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationSourceControlResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationSourceControlData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string sourceControlName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJob> CreateSourceControlSyncJob(System.Guid sourceControlSyncJobId, Azure.ResourceManager.Automation.Models.SourceControlSyncJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJob>> CreateSourceControlSyncJobAsync(System.Guid sourceControlSyncJobId, Azure.ResourceManager.Automation.Models.SourceControlSyncJobCreateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobResult> GetSourceControlSyncJob(System.Guid sourceControlSyncJobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobResult>> GetSourceControlSyncJobAsync(System.Guid sourceControlSyncJobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJob> GetSourceControlSyncJobs(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJob> GetSourceControlSyncJobsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStreamResult> GetSourceControlSyncJobStream(System.Guid sourceControlSyncJobId, string streamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStreamResult>> GetSourceControlSyncJobStreamAsync(System.Guid sourceControlSyncJobId, string streamId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStream> GetSourceControlSyncJobStreams(System.Guid sourceControlSyncJobId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.Models.SourceControlSyncJobStream> GetSourceControlSyncJobStreamsAsync(System.Guid sourceControlSyncJobId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource> Update(Azure.ResourceManager.Automation.Models.AutomationSourceControlPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationSourceControlResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationSourceControlPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationVariableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationVariableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationVariableResource>, System.Collections.IEnumerable
    {
        protected AutomationVariableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationVariableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string variableName, Azure.ResourceManager.Automation.Models.AutomationVariableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationVariableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string variableName, Azure.ResourceManager.Automation.Models.AutomationVariableCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource> Get(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationVariableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationVariableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource>> GetAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationVariableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationVariableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationVariableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationVariableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationVariableData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationVariableData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AutomationVariableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationVariableResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationVariableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string variableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource> Update(Azure.ResourceManager.Automation.Models.AutomationVariablePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationVariableResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationVariablePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationWatcherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationWatcherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationWatcherResource>, System.Collections.IEnumerable
    {
        protected AutomationWatcherCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationWatcherResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.Automation.AutomationWatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationWatcherResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.Automation.AutomationWatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource> Get(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationWatcherResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationWatcherResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource>> GetAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationWatcherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationWatcherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationWatcherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationWatcherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationWatcherData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutomationWatcherData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class AutomationWatcherResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationWatcherResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationWatcherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string watcherName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource> Update(Azure.ResourceManager.Automation.Models.AutomationWatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWatcherResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationWatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomationWebhookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationWebhookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationWebhookResource>, System.Collections.IEnumerable
    {
        protected AutomationWebhookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationWebhookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.Automation.Models.AutomationWebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.AutomationWebhookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.Automation.Models.AutomationWebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource> Get(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automation.AutomationWebhookResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automation.AutomationWebhookResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource>> GetAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automation.AutomationWebhookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.AutomationWebhookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automation.AutomationWebhookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationWebhookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomationWebhookData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationWebhookData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastInvokedOn { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class AutomationWebhookResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomationWebhookResource() { }
        public virtual Azure.ResourceManager.Automation.AutomationWebhookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string automationAccountName, string webhookName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource> Update(Azure.ResourceManager.Automation.Models.AutomationWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.AutomationWebhookResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.AutomationWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Automation.Models.AutomationJobStatus? Status { get { throw null; } set { } }
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
        public bool? IsLogVerboseEnabled { get { throw null; } set { } }
        public int? JobCount { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public int? NodeConfigurationCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.DscConfigurationParameterDefinition> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationContentSource Source { get { throw null; } set { } }
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
        public bool? IsIncrementNodeConfigurationBuildRequired { get { throw null; } set { } }
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
        public System.DateTimeOffset? LastSeenOn { get { throw null; } set { } }
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
        public Azure.Core.ResourceIdentifier VmResourceId { get { throw null; } set { } }
        public string WorkerName { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.HybridWorkerType? WorkerType { get { throw null; } set { } }
    }
    public partial class HybridRunbookWorkerGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>, System.Collections.IEnumerable
    {
        protected HybridRunbookWorkerGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hybridRunbookWorkerGroupName, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hybridRunbookWorkerGroupName, Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Automation.Models.HybridWorkerGroup? GroupType { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource> Update(Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automation.HybridRunbookWorkerGroupResource>> UpdateAsync(Azure.ResourceManager.Automation.Models.HybridRunbookWorkerGroupCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public SoftwareUpdateConfigurationData(Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationSpecificProperties updateConfiguration, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationScheduleProperties scheduleInfo) { }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationResponseError Error { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationScheduleProperties ScheduleInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTasks Tasks { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationSpecificProperties UpdateConfiguration { get { throw null; } set { } }
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
}
namespace Azure.ResourceManager.Automation.Models
{
    public partial class AgentRegistration
    {
        internal AgentRegistration() { }
        public string DscMetaConfiguration { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
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
    public partial class AgentRegistrationRegenerateKeyContent
    {
        public AgentRegistrationRegenerateKeyContent(Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName keyName) { }
        public Azure.ResourceManager.Automation.Models.AgentRegistrationKeyName KeyName { get { throw null; } }
    }
    public static partial class ArmAutomationModelFactory
    {
        public static Azure.ResourceManager.Automation.Models.AgentRegistration AgentRegistration(string dscMetaConfiguration = null, System.Uri endpoint = null, Azure.ResourceManager.Automation.Models.AgentRegistrationKeys keys = null, Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AgentRegistrationKeys AgentRegistrationKeys(string primary = null, string secondary = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationAccountData AutomationAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Automation.Models.AutomationSku sku = null, string lastModifiedBy = null, Azure.ResourceManager.Automation.Models.AutomationAccountState? state = default(Azure.ResourceManager.Automation.Models.AutomationAccountState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.Automation.Models.AutomationEncryptionProperties encryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData> privateEndpointConnections = null, bool? isPublicNetworkAccessAllowed = default(bool?), bool? isLocalAuthDisabled = default(bool?), System.Uri automationHybridServiceUri = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationAccountStatistics AutomationAccountStatistics(string counterProperty = null, long? counterValue = default(long?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string id = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationActivity AutomationActivity(Azure.Core.ResourceIdentifier id = null, string name = null, string definition = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.AutomationActivityParameterSet> parameterSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.AutomationActivityOutputType> outputTypes = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationActivityOutputType AutomationActivityOutputType(string name = null, string activityOutputType = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationActivityParameterDefinition AutomationActivityParameterDefinition(string name = null, string activityParameterType = null, bool? isMandatory = default(bool?), bool? isDynamic = default(bool?), long? position = default(long?), bool? canTakeValueFromPipeline = default(bool?), bool? canTakeValueFromPipelineByPropertyName = default(bool?), bool? canTakeValueValueFromRemainingArguments = default(bool?), string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.AutomationActivityParameterValidationSet> validationSet = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationActivityParameterSet AutomationActivityParameterSet(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.AutomationActivityParameterDefinition> parameters = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationActivityParameterValidationSet AutomationActivityParameterValidationSet(string memberValue = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationCertificateData AutomationCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData thumbprint = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), bool? isExportable = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationConnectionData AutomationConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string connectionTypeName = null, System.Collections.Generic.IReadOnlyDictionary<string, string> fieldDefinitionValues = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationConnectionTypeData AutomationConnectionTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isGlobal = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Automation.Models.AutomationConnectionFieldDefinition> fieldDefinitions = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationCredentialData AutomationCredentialData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string userName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationJobCollectionItemData AutomationJobCollectionItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string runbookName = null, System.Guid? jobId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.AutomationJobStatus? status = default(Azure.ResourceManager.Automation.Models.AutomationJobStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string provisioningState = null, string runOn = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationJobData AutomationJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string runbookName = null, string startedBy = null, string runOn = null, System.Guid? jobId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.AutomationJobStatus? status = default(Azure.ResourceManager.Automation.Models.AutomationJobStatus?), string statusDetails = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string exception = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastStatusModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> parameters = null, Azure.ResourceManager.Automation.Models.JobProvisioningState? provisioningState = default(Azure.ResourceManager.Automation.Models.JobProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationJobScheduleData AutomationJobScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? jobScheduleId = default(System.Guid?), string scheduleName = null, string runbookName = null, string runOn = null, System.Collections.Generic.IReadOnlyDictionary<string, string> parameters = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStream AutomationJobStream(Azure.Core.ResourceIdentifier id = null, string jobStreamId = null, System.DateTimeOffset? time = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.AutomationJobStreamType? streamType = default(Azure.ResourceManager.Automation.Models.AutomationJobStreamType?), string streamText = null, string summary = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> value = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationKey AutomationKey(Azure.ResourceManager.Automation.Models.AutomationKeyName? keyName = default(Azure.ResourceManager.Automation.Models.AutomationKeyName?), Azure.ResourceManager.Automation.Models.AutomationKeyPermission? permissions = default(Azure.ResourceManager.Automation.Models.AutomationKeyPermission?), string value = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationLinkedWorkspace AutomationLinkedWorkspace(string id = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationModuleData AutomationModuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), bool? isGlobal = default(bool?), string version = null, long? sizeInBytes = default(long?), int? activityCount = default(int?), Azure.ResourceManager.Automation.Models.ModuleProvisioningState? provisioningState = default(Azure.ResourceManager.Automation.Models.ModuleProvisioningState?), Azure.ResourceManager.Automation.Models.AutomationContentLink contentLink = null, Azure.ResourceManager.Automation.Models.AutomationModuleErrorInfo error = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null, bool? isComposite = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationModuleField AutomationModuleField(string name = null, string fieldType = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationPrivateEndpointConnectionData AutomationPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Automation.Models.AutomationPrivateLinkServiceConnectionStateProperty connectionState = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationPrivateLinkResource AutomationPrivateLinkResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationPrivateLinkServiceConnectionStateProperty AutomationPrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationRunbookData AutomationRunbookData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Automation.Models.AutomationRunbookType? runbookType = default(Azure.ResourceManager.Automation.Models.AutomationRunbookType?), Azure.ResourceManager.Automation.Models.AutomationContentLink publishContentLink = null, Azure.ResourceManager.Automation.Models.RunbookState? state = default(Azure.ResourceManager.Automation.Models.RunbookState?), bool? isLogVerboseEnabled = default(bool?), bool? isLogProgressEnabled = default(bool?), int? logActivityTrace = default(int?), int? jobCount = default(int?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.RunbookParameterDefinition> parameters = null, System.Collections.Generic.IEnumerable<string> outputTypes = null, Azure.ResourceManager.Automation.Models.AutomationRunbookDraft draft = null, Azure.ResourceManager.Automation.Models.RunbookProvisioningState? provisioningState = default(Azure.ResourceManager.Automation.Models.RunbookProvisioningState?), string lastModifiedBy = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationScheduleData AutomationScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), double? startInMinutes = default(double?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), double? expireInMinutes = default(double?), bool? isEnabled = default(bool?), System.DateTimeOffset? nextRunOn = default(System.DateTimeOffset?), double? nextRunInMinutes = default(double?), System.BinaryData interval = null, Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency? frequency = default(Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency?), string timeZone = null, Azure.ResourceManager.Automation.Models.AutomationAdvancedSchedule advancedSchedule = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationSourceControlData AutomationSourceControlData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Uri repoUri = null, string branch = null, string folderPath = null, bool? isAutoSyncEnabled = default(bool?), bool? isAutoPublishRunbookEnabled = default(bool?), Azure.ResourceManager.Automation.Models.SourceControlSourceType? sourceType = default(Azure.ResourceManager.Automation.Models.SourceControlSourceType?), string description = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationUsage AutomationUsage(string id = null, Azure.ResourceManager.Automation.Models.AutomationUsageCounterName name = null, string unit = null, double? currentValue = default(double?), long? limit = default(long?), string throttleStatus = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationUsageCounterName AutomationUsageCounterName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationVariableData AutomationVariableData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, bool? isEncrypted = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationWatcherData AutomationWatcherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), long? executionFrequencyInSeconds = default(long?), string scriptName = null, System.Collections.Generic.IDictionary<string, string> scriptParameters = null, string scriptRunOn = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.AutomationWebhookData AutomationWebhookData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isEnabled = default(bool?), System.Uri uri = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastInvokedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> parameters = null, string runbookName = null, string runOn = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DeletedAutomationAccount DeletedAutomationAccount(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier automationAccountResourceId = null, string automationAccountId = null, string locationPropertiesLocation = null, System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Automation.DscCompilationJobData DscCompilationJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string configurationName = null, string startedBy = null, System.Guid? jobId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.JobProvisioningState? provisioningState = default(Azure.ResourceManager.Automation.Models.JobProvisioningState?), string runOn = null, Azure.ResourceManager.Automation.Models.AutomationJobStatus? status = default(Azure.ResourceManager.Automation.Models.AutomationJobStatus?), string statusDetails = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string exception = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastStatusModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> parameters = null) { throw null; }
        public static Azure.ResourceManager.Automation.DscConfigurationData DscConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.Automation.Models.DscConfigurationProvisioningState?), int? jobCount = default(int?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.DscConfigurationParameterDefinition> parameters = null, Azure.ResourceManager.Automation.Models.AutomationContentSource source = null, Azure.ResourceManager.Automation.Models.DscConfigurationState? state = default(Azure.ResourceManager.Automation.Models.DscConfigurationState?), bool? isLogVerboseEnabled = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), int? nodeConfigurationCount = default(int?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscMetaConfiguration DscMetaConfiguration(int? configurationModeFrequencyMins = default(int?), bool? rebootNodeIfNeeded = default(bool?), string configurationMode = null, string actionAfterReboot = null, string certificateId = null, int? refreshFrequencyMins = default(int?), bool? allowModuleOverwrite = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Automation.DscNodeConfigurationData DscNodeConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string configurationName = null, string source = null, long? nodeCount = default(long?), bool? isIncrementNodeConfigurationBuildRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscNodeCount DscNodeCount(string name = null, int? nameCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Automation.DscNodeData DscNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastSeenOn = default(System.DateTimeOffset?), System.DateTimeOffset? registrationOn = default(System.DateTimeOffset?), string ip = null, string accountId = null, string status = null, string nodeId = null, Azure.ETag? etag = default(Azure.ETag?), int? totalCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.DscNodeExtensionHandlerAssociationProperty> extensionHandler = null, string namePropertiesNodeConfigurationName = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscNodeReport DscNodeReport(System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string dscNodeReportType = null, string reportId = null, string status = null, string refreshMode = null, string rebootRequested = null, string reportFormatVersion = null, string configurationVersion = null, string id = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.DscReportError> errors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.DscReportResource> resources = null, Azure.ResourceManager.Automation.Models.DscMetaConfiguration metaConfiguration = null, string hostName = null, System.Collections.Generic.IEnumerable<string> ipV4Addresses = null, System.Collections.Generic.IEnumerable<string> ipV6Addresses = null, int? numberOfResources = default(int?), string rawErrors = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscReportError DscReportError(string errorSource = null, string resourceId = null, string errorCode = null, string errorMessage = null, string locale = null, string errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscReportResource DscReportResource(string resourceId = null, string sourceInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automation.Models.DscReportResourceNavigation> dependsOn = null, string moduleName = null, string moduleVersion = null, string resourceName = null, string error = null, string status = null, double? durationInSeconds = default(double?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.DscReportResourceNavigation DscReportResourceNavigation(string resourceId = null) { throw null; }
        public static Azure.ResourceManager.Automation.HybridRunbookWorkerData HybridRunbookWorkerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string ip = null, System.DateTimeOffset? registeredOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSeenOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier vmResourceId = null, Azure.ResourceManager.Automation.Models.HybridWorkerType? workerType = default(Azure.ResourceManager.Automation.Models.HybridWorkerType?), string workerName = null) { throw null; }
        public static Azure.ResourceManager.Automation.HybridRunbookWorkerGroupData HybridRunbookWorkerGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Automation.Models.HybridWorkerGroup? groupType = default(Azure.ResourceManager.Automation.Models.HybridWorkerGroup?), string credentialName = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.RunbookDraftUndoEditResult RunbookDraftUndoEditResult(Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode? statusCode = default(Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode?), string requestId = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.RunbookTestJob RunbookTestJob(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string status = null, string statusDetails = null, string runOn = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string exception = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastStatusModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> parameters = null, int? logActivityTrace = default(int?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationCollectionItem SoftwareUpdateConfigurationCollectionItem(string name = null, Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationSpecificProperties updateConfiguration = null, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTasks tasks = null, Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency? frequency = default(Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string provisioningState = null, System.DateTimeOffset? nextRunOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Automation.SoftwareUpdateConfigurationData SoftwareUpdateConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationSpecificProperties updateConfiguration = null, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationScheduleProperties scheduleInfo = null, string provisioningState = null, Azure.ResourceManager.Automation.Models.AutomationResponseError error = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTasks tasks = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationMachineRun SoftwareUpdateConfigurationMachineRun(string name = null, Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier targetComputerId = null, string targetComputerType = null, string softwareUpdateName = null, string status = null, string osType = null, System.Guid? correlationId = default(System.Guid?), System.Guid? sourceComputerId = default(System.Guid?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.TimeSpan? configuredDuration = default(System.TimeSpan?), System.Guid? jobId = default(System.Guid?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.ResourceManager.Automation.Models.AutomationResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRun SoftwareUpdateConfigurationRun(string name = null, Azure.Core.ResourceIdentifier id = null, string softwareUpdateName = null, string status = null, System.TimeSpan? configuredDuration = default(System.TimeSpan?), string osType = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), int? computerCount = default(int?), int? failedCount = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTasks tasks = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTaskProperties SoftwareUpdateConfigurationRunTaskProperties(string status = null, string source = null, System.Guid? jobId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTasks SoftwareUpdateConfigurationRunTasks(Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTaskProperties preTask = null, Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTaskProperties postTask = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationScheduleProperties SoftwareUpdateConfigurationScheduleProperties(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), double? startInMinutes = default(double?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), double? expireInMinutes = default(double?), bool? isEnabled = default(bool?), System.DateTimeOffset? nextRunOn = default(System.DateTimeOffset?), double? nextRunInMinutes = default(double?), long? interval = default(long?), Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency? frequency = default(Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency?), string timeZone = null, Azure.ResourceManager.Automation.Models.AutomationAdvancedSchedule advancedSchedule = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string description = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlSyncJob SourceControlSyncJob(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string sourceControlSyncJobId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.SourceControlProvisioningState? provisioningState = default(Azure.ResourceManager.Automation.Models.SourceControlProvisioningState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.SourceControlSyncType? syncType = default(Azure.ResourceManager.Automation.Models.SourceControlSyncType?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlSyncJobResult SourceControlSyncJobResult(Azure.Core.ResourceIdentifier id = null, string sourceControlSyncJobId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.SourceControlProvisioningState? provisioningState = default(Azure.ResourceManager.Automation.Models.SourceControlProvisioningState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.SourceControlSyncType? syncType = default(Azure.ResourceManager.Automation.Models.SourceControlSyncType?), string exception = null) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlSyncJobStream SourceControlSyncJobStream(Azure.Core.ResourceIdentifier id = null, string sourceControlSyncJobStreamId = null, string summary = null, System.DateTimeOffset? time = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.SourceControlStreamType? streamType = default(Azure.ResourceManager.Automation.Models.SourceControlStreamType?)) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlSyncJobStreamResult SourceControlSyncJobStreamResult(Azure.Core.ResourceIdentifier id = null, string sourceControlSyncJobStreamId = null, string summary = null, System.DateTimeOffset? time = default(System.DateTimeOffset?), Azure.ResourceManager.Automation.Models.SourceControlStreamType? streamType = default(Azure.ResourceManager.Automation.Models.SourceControlStreamType?), string streamText = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> value = null) { throw null; }
    }
    public partial class AutomationAccountCreateOrUpdateContent
    {
        public AutomationAccountCreateOrUpdateContent() { }
        public Azure.ResourceManager.Automation.Models.AutomationEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsPublicNetworkAccessAllowed { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountModuleCreateOrUpdateContent
    {
        public AutomationAccountModuleCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.AutomationContentLink contentLink) { }
        public Azure.ResourceManager.Automation.Models.AutomationContentLink ContentLink { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountModulePatch
    {
        public AutomationAccountModulePatch() { }
        public Azure.ResourceManager.Automation.Models.AutomationContentLink ContentLink { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountPatch
    {
        public AutomationAccountPatch() { }
        public Azure.ResourceManager.Automation.Models.AutomationEncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public bool? IsPublicNetworkAccessAllowed { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationAccountPython2PackageCreateOrUpdateContent
    {
        public AutomationAccountPython2PackageCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.AutomationContentLink contentLink) { }
        public Azure.ResourceManager.Automation.Models.AutomationContentLink ContentLink { get { throw null; } }
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
    public partial class AutomationAccountStatistics
    {
        internal AutomationAccountStatistics() { }
        public string CounterProperty { get { throw null; } }
        public long? CounterValue { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class AutomationActivity
    {
        internal AutomationActivity() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.AutomationActivityOutputType> OutputTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.AutomationActivityParameterSet> ParameterSets { get { throw null; } }
    }
    public partial class AutomationActivityOutputType
    {
        internal AutomationActivityOutputType() { }
        public string ActivityOutputType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class AutomationActivityParameterDefinition
    {
        internal AutomationActivityParameterDefinition() { }
        public string ActivityParameterType { get { throw null; } }
        public bool? CanTakeValueFromPipeline { get { throw null; } }
        public bool? CanTakeValueFromPipelineByPropertyName { get { throw null; } }
        public bool? CanTakeValueValueFromRemainingArguments { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsMandatory { get { throw null; } }
        public string Name { get { throw null; } }
        public long? Position { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.AutomationActivityParameterValidationSet> ValidationSet { get { throw null; } }
    }
    public partial class AutomationActivityParameterSet
    {
        internal AutomationActivityParameterSet() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automation.Models.AutomationActivityParameterDefinition> Parameters { get { throw null; } }
    }
    public partial class AutomationActivityParameterValidationSet
    {
        internal AutomationActivityParameterValidationSet() { }
        public string MemberValue { get { throw null; } }
    }
    public partial class AutomationAdvancedSchedule
    {
        public AutomationAdvancedSchedule() { }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.Models.AutomationAdvancedScheduleMonthlyOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<string> WeekDays { get { throw null; } }
    }
    public partial class AutomationAdvancedScheduleMonthlyOccurrence
    {
        public AutomationAdvancedScheduleMonthlyOccurrence() { }
        public Azure.ResourceManager.Automation.Models.AutomationDayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class AutomationCertificateCreateOrUpdateContent
    {
        public AutomationCertificateCreateOrUpdateContent(string name, string base64Value) { }
        public string Base64Value { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsExportable { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
    }
    public partial class AutomationCertificatePatch
    {
        public AutomationCertificatePatch() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AutomationConnectionCreateOrUpdateContent
    {
        public AutomationConnectionCreateOrUpdateContent(string name, Azure.ResourceManager.Automation.Models.ConnectionTypeAssociationProperty connectionType) { }
        public string ConnectionTypeName { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FieldDefinitionValues { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class AutomationConnectionFieldDefinition
    {
        public AutomationConnectionFieldDefinition(string fieldDefinitionType) { }
        public string FieldDefinitionType { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public bool? IsOptional { get { throw null; } set { } }
    }
    public partial class AutomationConnectionPatch
    {
        public AutomationConnectionPatch() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FieldDefinitionValues { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AutomationConnectionTypeCreateOrUpdateContent
    {
        public AutomationConnectionTypeCreateOrUpdateContent(string name, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.AutomationConnectionFieldDefinition> fieldDefinitions) { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.AutomationConnectionFieldDefinition> FieldDefinitions { get { throw null; } }
        public bool? IsGlobal { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class AutomationContentHash
    {
        public AutomationContentHash(string algorithm, string value) { }
        public string Algorithm { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AutomationContentLink
    {
        public AutomationContentLink() { }
        public Azure.ResourceManager.Automation.Models.AutomationContentHash ContentHash { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class AutomationContentSource
    {
        public AutomationContentSource() { }
        public Azure.ResourceManager.Automation.Models.AutomationContentHash Hash { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationContentSourceType? SourceType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationContentSourceType : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationContentSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationContentSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationContentSourceType EmbeddedContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationContentSourceType Uri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationContentSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationContentSourceType left, Azure.ResourceManager.Automation.Models.AutomationContentSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationContentSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationContentSourceType left, Azure.ResourceManager.Automation.Models.AutomationContentSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationCountType : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationCountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationCountType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationCountType NodeConfiguration { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationCountType Status { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationCountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationCountType left, Azure.ResourceManager.Automation.Models.AutomationCountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationCountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationCountType left, Azure.ResourceManager.Automation.Models.AutomationCountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationCredentialCreateOrUpdateContent
    {
        public AutomationCredentialCreateOrUpdateContent(string name, string userName, string password) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Password { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class AutomationCredentialPatch
    {
        public AutomationCredentialPatch() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationDayOfWeek : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationDayOfWeek left, Azure.ResourceManager.Automation.Models.AutomationDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationDayOfWeek left, Azure.ResourceManager.Automation.Models.AutomationDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationEncryptionProperties
    {
        public AutomationEncryptionProperties() { }
        public Azure.ResourceManager.Automation.Models.EncryptionKeySourceType? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.BinaryData UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationHttpStatusCode : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationHttpStatusCode(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Accepted { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Ambiguous { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode BadGateway { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode BadRequest { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Conflict { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Continue { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Created { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode ExpectationFailed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Forbidden { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Found { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode GatewayTimeout { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Gone { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode HttpVersionNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode InternalServerError { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode LengthRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode MethodNotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Moved { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode MovedPermanently { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode MultipleChoices { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode NoContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode NonAuthoritativeInformation { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode NotAcceptable { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode NotFound { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode NotImplemented { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode NotModified { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode OK { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode PartialContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode PaymentRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode PreconditionFailed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode ProxyAuthenticationRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Redirect { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode RedirectKeepVerb { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode RedirectMethod { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode RequestedRangeNotSatisfiable { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode RequestEntityTooLarge { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode RequestTimeout { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode RequestUriTooLong { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode ResetContent { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode SeeOther { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode ServiceUnavailable { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode SwitchingProtocols { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode TemporaryRedirect { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Unauthorized { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode UnsupportedMediaType { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode Unused { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode UpgradeRequired { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode UseProxy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode left, Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode left, Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationJobCollectionItemData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomationJobCollectionItemData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Guid? JobId { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunbookName { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationJobStatus? Status { get { throw null; } }
    }
    public partial class AutomationJobCreateOrUpdateContent
    {
        public AutomationJobCreateOrUpdateContent() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
    }
    public partial class AutomationJobScheduleCreateOrUpdateContent
    {
        public AutomationJobScheduleCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.ScheduleAssociationProperty schedule, Azure.ResourceManager.Automation.Models.RunbookAssociationProperty runbook) { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
        public string ScheduleName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationJobStatus : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationJobStatus(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Activating { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Blocked { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus New { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Removing { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Resuming { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Stopping { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStatus Suspending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationJobStatus left, Azure.ResourceManager.Automation.Models.AutomationJobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationJobStatus left, Azure.ResourceManager.Automation.Models.AutomationJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationJobStream
    {
        internal AutomationJobStream() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string JobStreamId { get { throw null; } }
        public string StreamText { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationJobStreamType? StreamType { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationJobStreamType : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationJobStreamType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationJobStreamType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStreamType Any { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStreamType Debug { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStreamType Error { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStreamType Output { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStreamType Progress { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStreamType Verbose { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationJobStreamType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationJobStreamType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationJobStreamType left, Azure.ResourceManager.Automation.Models.AutomationJobStreamType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationJobStreamType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationJobStreamType left, Azure.ResourceManager.Automation.Models.AutomationJobStreamType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationKey
    {
        internal AutomationKey() { }
        public Azure.ResourceManager.Automation.Models.AutomationKeyName? KeyName { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationKeyPermission? Permissions { get { throw null; } }
        public string Value { get { throw null; } }
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
    public partial class AutomationKeyVaultProperties
    {
        public AutomationKeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyvaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    public partial class AutomationLinkedWorkspace
    {
        internal AutomationLinkedWorkspace() { }
        public string Id { get { throw null; } }
    }
    public partial class AutomationModuleErrorInfo
    {
        public AutomationModuleErrorInfo() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class AutomationModuleField
    {
        internal AutomationModuleField() { }
        public string FieldType { get { throw null; } }
        public string Name { get { throw null; } }
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
    public partial class AutomationResponseError
    {
        public AutomationResponseError() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class AutomationRunbookCreateOrUpdateContent
    {
        public AutomationRunbookCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.AutomationRunbookType runbookType) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationRunbookDraft Draft { get { throw null; } set { } }
        public bool? IsLogProgressEnabled { get { throw null; } set { } }
        public bool? IsLogVerboseEnabled { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? LogActivityTrace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationContentLink PublishContentLink { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationRunbookType RunbookType { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomationRunbookDraft
    {
        public AutomationRunbookDraft() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationContentLink DraftContentLink { get { throw null; } set { } }
        public bool? IsInEditMode { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OutputTypes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.RunbookParameterDefinition> Parameters { get { throw null; } }
    }
    public partial class AutomationRunbookPatch
    {
        public AutomationRunbookPatch() { }
        public string Description { get { throw null; } set { } }
        public bool? IsLogProgressEnabled { get { throw null; } set { } }
        public bool? IsLogVerboseEnabled { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? LogActivityTrace { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationRunbookType : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationRunbookType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationRunbookType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType Graph { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType GraphPowerShell { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType GraphPowerShellWorkflow { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType PowerShell { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType PowerShellWorkflow { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType Python2 { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType Python3 { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationRunbookType Script { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationRunbookType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationRunbookType left, Azure.ResourceManager.Automation.Models.AutomationRunbookType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationRunbookType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationRunbookType left, Azure.ResourceManager.Automation.Models.AutomationRunbookType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationScheduleCreateOrUpdateContent
    {
        public AutomationScheduleCreateOrUpdateContent(string name, System.DateTimeOffset startOn, Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency frequency) { }
        public Azure.ResourceManager.Automation.Models.AutomationAdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency Frequency { get { throw null; } }
        public System.BinaryData Interval { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationScheduleFrequency : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationScheduleFrequency(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency OneTime { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency left, Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency left, Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationSchedulePatch
    {
        public AutomationSchedulePatch() { }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AutomationSku
    {
        public AutomationSku(Azure.ResourceManager.Automation.Models.AutomationSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomationSkuName : System.IEquatable<Azure.ResourceManager.Automation.Models.AutomationSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomationSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.AutomationSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.AutomationSkuName Free { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.AutomationSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.AutomationSkuName left, Azure.ResourceManager.Automation.Models.AutomationSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.AutomationSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.AutomationSkuName left, Azure.ResourceManager.Automation.Models.AutomationSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutomationSourceControlCreateOrUpdateContent
    {
        public AutomationSourceControlCreateOrUpdateContent() { }
        public string Branch { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public bool? IsAutoPublishRunbookEnabled { get { throw null; } set { } }
        public bool? IsAutoSyncEnabled { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceControlSecurityTokenProperties SecurityToken { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceControlSourceType? SourceType { get { throw null; } set { } }
    }
    public partial class AutomationSourceControlPatch
    {
        public AutomationSourceControlPatch() { }
        public string Branch { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public bool? IsAutoPublishRunbookEnabled { get { throw null; } set { } }
        public bool? IsAutoSyncEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceControlSecurityTokenProperties SecurityToken { get { throw null; } set { } }
    }
    public partial class AutomationUsage
    {
        internal AutomationUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationUsageCounterName Name { get { throw null; } }
        public string ThrottleStatus { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class AutomationUsageCounterName
    {
        internal AutomationUsageCounterName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class AutomationVariableCreateOrUpdateContent
    {
        public AutomationVariableCreateOrUpdateContent(string name) { }
        public string Description { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AutomationVariablePatch
    {
        public AutomationVariablePatch() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class AutomationWatcherPatch
    {
        public AutomationWatcherPatch() { }
        public long? ExecutionFrequencyInSeconds { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class AutomationWebhookCreateOrUpdateContent
    {
        public AutomationWebhookCreateOrUpdateContent(string name) { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunbookName { get { throw null; } set { } }
        public string RunOn { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class AutomationWebhookPatch
    {
        public AutomationWebhookPatch() { }
        public string Description { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
    }
    public partial class AzureQueryProperties
    {
        public AzureQueryProperties() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> Scope { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.QueryTagSettingsProperties TagSettings { get { throw null; } set { } }
    }
    public partial class ConnectionTypeAssociationProperty
    {
        public ConnectionTypeAssociationProperty() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class DeletedAutomationAccount : Azure.ResourceManager.Models.ResourceData
    {
        internal DeletedAutomationAccount() { }
        public string AutomationAccountId { get { throw null; } }
        public Azure.Core.ResourceIdentifier AutomationAccountResourceId { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string LocationPropertiesLocation { get { throw null; } }
    }
    public partial class DscCompilationJobCreateOrUpdateContent
    {
        public DscCompilationJobCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.DscConfigurationAssociationProperty configuration) { }
        public string ConfigurationName { get { throw null; } }
        public bool? IsIncrementNodeConfigurationBuildRequired { get { throw null; } set { } }
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
        public DscConfigurationCreateOrUpdateContent(Azure.ResourceManager.Automation.Models.AutomationContentSource source) { }
        public string Description { get { throw null; } set { } }
        public bool? IsLogProgressEnabled { get { throw null; } set { } }
        public bool? IsLogVerboseEnabled { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.DscConfigurationParameterDefinition> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationContentSource Source { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DscConfigurationParameterDefinition
    {
        public DscConfigurationParameterDefinition() { }
        public string DefaultValue { get { throw null; } set { } }
        public string DscConfigurationParameterType { get { throw null; } set { } }
        public bool? IsMandatory { get { throw null; } set { } }
        public int? Position { get { throw null; } set { } }
    }
    public partial class DscConfigurationPatch
    {
        public DscConfigurationPatch() { }
        public string Description { get { throw null; } set { } }
        public bool? IsLogProgressEnabled { get { throw null; } set { } }
        public bool? IsLogVerboseEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Automation.Models.DscConfigurationParameterDefinition> Parameters { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationContentSource Source { get { throw null; } set { } }
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
        public bool? IsIncrementNodeConfigurationBuildRequired { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationContentSource Source { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DscNodeCount
    {
        internal DscNodeCount() { }
        public string Name { get { throw null; } }
        public int? NameCount { get { throw null; } }
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
    public partial class HybridRunbookWorkerCreateOrUpdateContent
    {
        public HybridRunbookWorkerCreateOrUpdateContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmResourceId { get { throw null; } set { } }
    }
    public partial class HybridRunbookWorkerGroupCreateOrUpdateContent
    {
        public HybridRunbookWorkerGroupCreateOrUpdateContent() { }
        public string CredentialName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class HybridRunbookWorkerMoveContent
    {
        public HybridRunbookWorkerMoveContent() { }
        public string HybridRunbookWorkerGroupName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridWorkerGroup : System.IEquatable<Azure.ResourceManager.Automation.Models.HybridWorkerGroup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridWorkerGroup(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.HybridWorkerGroup System { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HybridWorkerGroup User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.HybridWorkerGroup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.HybridWorkerGroup left, Azure.ResourceManager.Automation.Models.HybridWorkerGroup right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.HybridWorkerGroup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.HybridWorkerGroup left, Azure.ResourceManager.Automation.Models.HybridWorkerGroup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridWorkerType : System.IEquatable<Azure.ResourceManager.Automation.Models.HybridWorkerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridWorkerType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.HybridWorkerType HybridV1 { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.HybridWorkerType HybridV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.HybridWorkerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.HybridWorkerType left, Azure.ResourceManager.Automation.Models.HybridWorkerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.HybridWorkerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.HybridWorkerType left, Azure.ResourceManager.Automation.Models.HybridWorkerType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxUpdateClassification : System.IEquatable<Azure.ResourceManager.Automation.Models.LinuxUpdateClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxUpdateClassification(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClassification Critical { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClassification Other { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClassification Security { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.LinuxUpdateClassification Unclassified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.LinuxUpdateClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.LinuxUpdateClassification left, Azure.ResourceManager.Automation.Models.LinuxUpdateClassification right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.LinuxUpdateClassification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.LinuxUpdateClassification left, Azure.ResourceManager.Automation.Models.LinuxUpdateClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxUpdateConfigurationProperties
    {
        public LinuxUpdateConfigurationProperties() { }
        public System.Collections.Generic.IList<string> ExcludedPackageNameMasks { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.LinuxUpdateClassification? IncludedPackageClassifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IncludedPackageNameMasks { get { throw null; } }
        public string RebootSetting { get { throw null; } set { } }
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
    public partial class NonAzureQueryProperties
    {
        public NonAzureQueryProperties() { }
        public string FunctionAlias { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public enum QueryTagOperator
    {
        All = 0,
        Any = 1,
    }
    public partial class QueryTagSettingsProperties
    {
        public QueryTagSettingsProperties() { }
        public Azure.ResourceManager.Automation.Models.QueryTagOperator? FilterOperator { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
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
    public partial class RunbookDraftUndoEditResult
    {
        internal RunbookDraftUndoEditResult() { }
        public string RequestId { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationHttpStatusCode? StatusCode { get { throw null; } }
    }
    public partial class RunbookParameterDefinition
    {
        public RunbookParameterDefinition() { }
        public string DefaultValue { get { throw null; } set { } }
        public bool? IsMandatory { get { throw null; } set { } }
        public int? Position { get { throw null; } set { } }
        public string RunbookParameterType { get { throw null; } set { } }
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
    public partial class RunbookTestJob
    {
        internal RunbookTestJob() { }
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
    public partial class RunbookTestJobCreateContent
    {
        public RunbookTestJobCreateContent() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string RunOn { get { throw null; } set { } }
    }
    public partial class ScheduleAssociationProperty
    {
        public ScheduleAssociationProperty() { }
        public string Name { get { throw null; } set { } }
    }
    public partial class SoftwareUpdateConfigurationCollectionItem
    {
        internal SoftwareUpdateConfigurationCollectionItem() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency? Frequency { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextRunOn { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTasks Tasks { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationSpecificProperties UpdateConfiguration { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationMachineRun
    {
        internal SoftwareUpdateConfigurationMachineRun() { }
        public System.TimeSpan? ConfiguredDuration { get { throw null; } }
        public System.Guid? CorrelationId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.AutomationResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.Guid? JobId { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string OSType { get { throw null; } }
        public string SoftwareUpdateName { get { throw null; } }
        public System.Guid? SourceComputerId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetComputerId { get { throw null; } }
        public string TargetComputerType { get { throw null; } }
    }
    public enum SoftwareUpdateConfigurationOperatingSystemType
    {
        Windows = 0,
        Linux = 1,
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
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
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
        public System.Guid? JobId { get { throw null; } }
        public string Source { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationRunTasks
    {
        internal SoftwareUpdateConfigurationRunTasks() { }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTaskProperties PostTask { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationRunTaskProperties PreTask { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationScheduleProperties
    {
        public SoftwareUpdateConfigurationScheduleProperties() { }
        public Azure.ResourceManager.Automation.Models.AutomationAdvancedSchedule AdvancedSchedule { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public double? ExpireInMinutes { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.AutomationScheduleFrequency? Frequency { get { throw null; } set { } }
        public long? Interval { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public double? NextRunInMinutes { get { throw null; } set { } }
        public System.DateTimeOffset? NextRunOn { get { throw null; } set { } }
        public double? StartInMinutes { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class SoftwareUpdateConfigurationSpecificProperties
    {
        public SoftwareUpdateConfigurationSpecificProperties(Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationOperatingSystemType operatingSystem) { }
        public System.Collections.Generic.IList<string> AzureVirtualMachines { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.LinuxUpdateConfigurationProperties Linux { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NonAzureComputerNames { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationOperatingSystemType OperatingSystem { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTargetProperties Targets { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.WindowsUpdateConfigurationProperties Windows { get { throw null; } set { } }
    }
    public partial class SoftwareUpdateConfigurationTargetProperties
    {
        public SoftwareUpdateConfigurationTargetProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.Models.AzureQueryProperties> AzureQueries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Automation.Models.NonAzureQueryProperties> NonAzureQueries { get { throw null; } }
    }
    public partial class SoftwareUpdateConfigurationTaskProperties
    {
        public SoftwareUpdateConfigurationTaskProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public string Source { get { throw null; } set { } }
    }
    public partial class SoftwareUpdateConfigurationTasks
    {
        public SoftwareUpdateConfigurationTasks() { }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTaskProperties PostTask { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SoftwareUpdateConfigurationTaskProperties PreTask { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlProvisioningState : System.IEquatable<Azure.ResourceManager.Automation.Models.SourceControlProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceControlProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceControlProvisioningState Running { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SourceControlProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SourceControlProvisioningState left, Azure.ResourceManager.Automation.Models.SourceControlProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SourceControlProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SourceControlProvisioningState left, Azure.ResourceManager.Automation.Models.SourceControlProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceControlSecurityTokenProperties
    {
        public SourceControlSecurityTokenProperties() { }
        public string AccessToken { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public Azure.ResourceManager.Automation.Models.SourceControlTokenType? TokenType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlSourceType : System.IEquatable<Azure.ResourceManager.Automation.Models.SourceControlSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlSourceType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlSourceType GitHub { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceControlSourceType VsoGit { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceControlSourceType VsoTfvc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SourceControlSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SourceControlSourceType left, Azure.ResourceManager.Automation.Models.SourceControlSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SourceControlSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SourceControlSourceType left, Azure.ResourceManager.Automation.Models.SourceControlSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlStreamType : System.IEquatable<Azure.ResourceManager.Automation.Models.SourceControlStreamType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlStreamType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlStreamType Error { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceControlStreamType Output { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SourceControlStreamType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SourceControlStreamType left, Azure.ResourceManager.Automation.Models.SourceControlStreamType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SourceControlStreamType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SourceControlStreamType left, Azure.ResourceManager.Automation.Models.SourceControlStreamType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceControlSyncJob : Azure.ResourceManager.Models.ResourceData
    {
        internal SourceControlSyncJob() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SourceControlProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceControlSyncJobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SourceControlSyncType? SyncType { get { throw null; } }
    }
    public partial class SourceControlSyncJobCreateContent
    {
        public SourceControlSyncJobCreateContent(string commitId) { }
        public string CommitId { get { throw null; } }
    }
    public partial class SourceControlSyncJobResult
    {
        internal SourceControlSyncJobResult() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Exception { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SourceControlProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceControlSyncJobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SourceControlSyncType? SyncType { get { throw null; } }
    }
    public partial class SourceControlSyncJobStream
    {
        internal SourceControlSyncJobStream() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string SourceControlSyncJobStreamId { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SourceControlStreamType? StreamType { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class SourceControlSyncJobStreamResult
    {
        internal SourceControlSyncJobStreamResult() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string SourceControlSyncJobStreamId { get { throw null; } }
        public string StreamText { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.SourceControlStreamType? StreamType { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlSyncType : System.IEquatable<Azure.ResourceManager.Automation.Models.SourceControlSyncType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlSyncType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlSyncType FullSync { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceControlSyncType PartialSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SourceControlSyncType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SourceControlSyncType left, Azure.ResourceManager.Automation.Models.SourceControlSyncType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SourceControlSyncType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SourceControlSyncType left, Azure.ResourceManager.Automation.Models.SourceControlSyncType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlTokenType : System.IEquatable<Azure.ResourceManager.Automation.Models.SourceControlTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlTokenType(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.SourceControlTokenType OAuth { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.SourceControlTokenType PersonalAccessToken { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.SourceControlTokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.SourceControlTokenType left, Azure.ResourceManager.Automation.Models.SourceControlTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.SourceControlTokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.SourceControlTokenType left, Azure.ResourceManager.Automation.Models.SourceControlTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsUpdateClassification : System.IEquatable<Azure.ResourceManager.Automation.Models.WindowsUpdateClassification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsUpdateClassification(string value) { throw null; }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification Critical { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification Definition { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification FeaturePack { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification Security { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification ServicePack { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification Tools { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification Unclassified { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification UpdateRollup { get { throw null; } }
        public static Azure.ResourceManager.Automation.Models.WindowsUpdateClassification Updates { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Automation.Models.WindowsUpdateClassification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Automation.Models.WindowsUpdateClassification left, Azure.ResourceManager.Automation.Models.WindowsUpdateClassification right) { throw null; }
        public static implicit operator Azure.ResourceManager.Automation.Models.WindowsUpdateClassification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Automation.Models.WindowsUpdateClassification left, Azure.ResourceManager.Automation.Models.WindowsUpdateClassification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsUpdateConfigurationProperties
    {
        public WindowsUpdateConfigurationProperties() { }
        public System.Collections.Generic.IList<string> ExcludedKBNumbers { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedKBNumbers { get { throw null; } }
        public Azure.ResourceManager.Automation.Models.WindowsUpdateClassification? IncludedUpdateClassifications { get { throw null; } set { } }
        public string RebootSetting { get { throw null; } set { } }
    }
}
