namespace Azure.ResourceManager.Automanage
{
    public partial class AutomanageBestPracticeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource>, System.Collections.IEnumerable
    {
        protected AutomanageBestPracticeCollection() { }
        public virtual Azure.Response<bool> Exists(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource> Get(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource>> GetAsync(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageBestPracticeData : Azure.ResourceManager.Models.ResourceData
    {
        internal AutomanageBestPracticeData() { }
        public System.BinaryData Configuration { get { throw null; } }
    }
    public partial class AutomanageBestPracticeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageBestPracticeResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageBestPracticeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string bestPracticeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageConfigurationProfileAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomanageConfigurationProfileAssignmentData() { }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Automanage.Models.AutomanageConfigurationProfileAssignmentProperties Properties { get { throw null; } set { } }
    }
    public partial class AutomanageConfigurationProfileAssignmentReportData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomanageConfigurationProfileAssignmentReportData() { }
        public string ConfigurationProfile { get { throw null; } }
        public string ConfigurationProfileAssignmentProcessingType { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string ReportFormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automanage.Models.ConfigurationProfileAssignmentReportResourceDetails> Resources { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    public partial class AutomanageConfigurationProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>, System.Collections.IEnumerable
    {
        protected AutomanageConfigurationProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationProfileName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationProfileName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> Get(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> GetAsync(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageConfigurationProfileData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AutomanageConfigurationProfileData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.BinaryData Configuration { get { throw null; } set { } }
    }
    public partial class AutomanageConfigurationProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageConfigurationProfileResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configurationProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> GetAutomanageConfigurationProfileVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> GetAutomanageConfigurationProfileVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionCollection GetAutomanageConfigurationProfileVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> Update(Azure.ResourceManager.Automanage.Models.AutomanageConfigurationProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> UpdateAsync(Azure.ResourceManager.Automanage.Models.AutomanageConfigurationProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageConfigurationProfileVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>, System.Collections.IEnumerable
    {
        protected AutomanageConfigurationProfileVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageConfigurationProfileVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageConfigurationProfileVersionResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configurationProfileName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AutomanageExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource> GetAutomanageBestPractice(this Azure.ResourceManager.Resources.TenantResource tenantResource, string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageBestPracticeResource>> GetAutomanageBestPracticeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageBestPracticeResource GetAutomanageBestPracticeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageBestPracticeCollection GetAutomanageBestPractices(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> GetAutomanageConfigurationProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource>> GetAutomanageConfigurationProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource GetAutomanageConfigurationProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageConfigurationProfileCollection GetAutomanageConfigurationProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> GetAutomanageConfigurationProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageConfigurationProfileResource> GetAutomanageConfigurationProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageConfigurationProfileVersionResource GetAutomanageConfigurationProfileVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> GetAutomanageHciClusterConfigurationProfileAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>> GetAutomanageHciClusterConfigurationProfileAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource GetAutomanageHciClusterConfigurationProfileAssignmentReportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource GetAutomanageHciClusterConfigurationProfileAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentCollection GetAutomanageHciClusterConfigurationProfileAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> GetAutomanageHcrpConfigurationProfileAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>> GetAutomanageHcrpConfigurationProfileAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource GetAutomanageHcrpConfigurationProfileAssignmentReportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource GetAutomanageHcrpConfigurationProfileAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentCollection GetAutomanageHcrpConfigurationProfileAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> GetAutomanageVmConfigurationProfileAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>> GetAutomanageVmConfigurationProfileAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource GetAutomanageVmConfigurationProfileAssignmentReportResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource GetAutomanageVmConfigurationProfileAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentCollection GetAutomanageVmConfigurationProfileAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.Models.AutomanageServicePrincipalData> GetServicePrincipal(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.Models.AutomanageServicePrincipalData>> GetServicePrincipalAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automanage.Models.AutomanageServicePrincipalData> GetServicePrincipals(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automanage.Models.AutomanageServicePrincipalData> GetServicePrincipalsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageHciClusterConfigurationProfileAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>, System.Collections.IEnumerable
    {
        protected AutomanageHciClusterConfigurationProfileAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> Get(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>> GetAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageHciClusterConfigurationProfileAssignmentReportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource>, System.Collections.IEnumerable
    {
        protected AutomanageHciClusterConfigurationProfileAssignmentReportCollection() { }
        public virtual Azure.Response<bool> Exists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource> Get(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource>> GetAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageHciClusterConfigurationProfileAssignmentReportResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageHciClusterConfigurationProfileAssignmentReportResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentReportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationProfileAssignmentName, string reportName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageHciClusterConfigurationProfileAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageHciClusterConfigurationProfileAssignmentResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationProfileAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource> GetAutomanageHciClusterConfigurationProfileAssignmentReport(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportResource>> GetAutomanageHciClusterConfigurationProfileAssignmentReportAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentReportCollection GetAutomanageHciClusterConfigurationProfileAssignmentReports() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHciClusterConfigurationProfileAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageHcrpConfigurationProfileAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>, System.Collections.IEnumerable
    {
        protected AutomanageHcrpConfigurationProfileAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> Get(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>> GetAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageHcrpConfigurationProfileAssignmentReportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource>, System.Collections.IEnumerable
    {
        protected AutomanageHcrpConfigurationProfileAssignmentReportCollection() { }
        public virtual Azure.Response<bool> Exists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource> Get(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource>> GetAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageHcrpConfigurationProfileAssignmentReportResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageHcrpConfigurationProfileAssignmentReportResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentReportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName, string configurationProfileAssignmentName, string reportName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageHcrpConfigurationProfileAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageHcrpConfigurationProfileAssignmentResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName, string configurationProfileAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource> GetAutomanageHcrpConfigurationProfileAssignmentReport(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportResource>> GetAutomanageHcrpConfigurationProfileAssignmentReportAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentReportCollection GetAutomanageHcrpConfigurationProfileAssignmentReports() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageHcrpConfigurationProfileAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageVmConfigurationProfileAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>, System.Collections.IEnumerable
    {
        protected AutomanageVmConfigurationProfileAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> Get(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>> GetAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageVmConfigurationProfileAssignmentReportCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource>, System.Collections.IEnumerable
    {
        protected AutomanageVmConfigurationProfileAssignmentReportCollection() { }
        public virtual Azure.Response<bool> Exists(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource> Get(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource>> GetAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutomanageVmConfigurationProfileAssignmentReportResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageVmConfigurationProfileAssignmentReportResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentReportData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string configurationProfileAssignmentName, string reportName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AutomanageVmConfigurationProfileAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutomanageVmConfigurationProfileAssignmentResource() { }
        public virtual Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vmName, string configurationProfileAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource> GetAutomanageVmConfigurationProfileAssignmentReport(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportResource>> GetAutomanageVmConfigurationProfileAssignmentReportAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentReportCollection GetAutomanageVmConfigurationProfileAssignmentReports() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.AutomanageVmConfigurationProfileAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.AutomanageConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Automanage.Models
{
    public partial class AutomanageConfigurationProfileAssignmentProperties
    {
        public AutomanageConfigurationProfileAssignmentProperties() { }
        public Azure.Core.ResourceIdentifier ConfigurationProfile { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
    }
    public partial class AutomanageConfigurationProfilePatch : Azure.ResourceManager.Automanage.Models.AutomanageResourceUpdateDetails
    {
        public AutomanageConfigurationProfilePatch() { }
        public System.BinaryData Configuration { get { throw null; } set { } }
    }
    public partial class AutomanageResourceUpdateDetails
    {
        public AutomanageResourceUpdateDetails() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AutomanageServicePrincipalData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomanageServicePrincipalData() { }
        public bool? IsAuthorizationSet { get { throw null; } }
        public string ServicePrincipalId { get { throw null; } }
    }
    public partial class ConfigurationProfileAssignmentReportResourceDetails : Azure.ResourceManager.Models.ResourceData
    {
        internal ConfigurationProfileAssignmentReportResourceDetails() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
}
