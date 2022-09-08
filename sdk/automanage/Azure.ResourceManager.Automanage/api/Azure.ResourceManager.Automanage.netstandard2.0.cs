namespace Azure.ResourceManager.Automanage
{
    public static partial class AutomanageExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource> GetBestPractice(this Azure.ResourceManager.Resources.TenantResource tenantResource, string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource>> GetBestPracticeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.BestPracticeResource GetBestPracticeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.BestPracticeCollection GetBestPractices(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetConfigurationProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> GetConfigurationProfileAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>> GetConfigurationProfileAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource GetConfigurationProfileAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentCollection GetConfigurationProfileAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> GetConfigurationProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.ConfigurationProfileResource GetConfigurationProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.ConfigurationProfileCollection GetConfigurationProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetConfigurationProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetConfigurationProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automanage.Models.Report> GetHCIReportsByConfigurationProfileAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automanage.Models.Report> GetHCIReportsByConfigurationProfileAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automanage.Models.Report> GetHCRPReportsByConfigurationProfileAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automanage.Models.Report> GetHCRPReportsByConfigurationProfileAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automanage.Models.Report> GetReportsByConfigurationProfileAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automanage.Models.Report> GetReportsByConfigurationProfileAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vmName, string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BestPracticeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.BestPracticeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.BestPracticeResource>, System.Collections.IEnumerable
    {
        protected BestPracticeCollection() { }
        public virtual Azure.Response<bool> Exists(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource> Get(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.BestPracticeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.BestPracticeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource>> GetAsync(string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.BestPracticeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.BestPracticeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.BestPracticeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.BestPracticeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BestPracticeData : Azure.ResourceManager.Models.ResourceData
    {
        internal BestPracticeData() { }
        public System.BinaryData Configuration { get { throw null; } }
    }
    public partial class BestPracticeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BestPracticeResource() { }
        public virtual Azure.ResourceManager.Automanage.BestPracticeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string bestPracticeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationProfileAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>, System.Collections.IEnumerable
    {
        protected ConfigurationProfileAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationProfileAssignmentName, Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> Get(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>> GetAsync(string configurationProfileAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationProfileAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationProfileAssignmentData() { }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Automanage.Models.ConfigurationProfileAssignmentProperties Properties { get { throw null; } set { } }
    }
    public partial class ConfigurationProfileAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationProfileAssignmentResource() { }
        public virtual Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string configurationProfileAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.Models.Report> GetReport(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.Models.Report>> GetReportAsync(string reportName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.ConfigurationProfileAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileResource>, System.Collections.IEnumerable
    {
        protected ConfigurationProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationProfileName, Azure.ResourceManager.Automanage.ConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationProfileName, Azure.ResourceManager.Automanage.ConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> Get(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> GetAsync(string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.ConfigurationProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.ConfigurationProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationProfileData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ConfigurationProfileData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.BinaryData Configuration { get { throw null; } set { } }
    }
    public partial class ConfigurationProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationProfileResource() { }
        public virtual Azure.ResourceManager.Automanage.ConfigurationProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configurationProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> Update(Azure.ResourceManager.Automanage.Models.ConfigurationProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> UpdateAsync(Azure.ResourceManager.Automanage.Models.ConfigurationProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Automanage.Models
{
    public partial class ConfigurationProfileAssignmentProperties
    {
        public ConfigurationProfileAssignmentProperties() { }
        public string ConfigurationProfile { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string TargetId { get { throw null; } }
    }
    public partial class ConfigurationProfilePatch : Azure.ResourceManager.Automanage.Models.UpdateResource
    {
        public ConfigurationProfilePatch() { }
        public System.BinaryData Configuration { get { throw null; } set { } }
    }
    public partial class Report : Azure.ResourceManager.Models.ResourceData
    {
        public Report() { }
        public string ConfigurationProfile { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public string EndTime { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public string LastModifiedTime { get { throw null; } }
        public string ReportFormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Automanage.Models.ReportResource> Resources { get { throw null; } }
        public string StartTime { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string TypePropertiesType { get { throw null; } }
    }
    public partial class ReportResource : Azure.ResourceManager.Models.ResourceData
    {
        internal ReportResource() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class UpdateResource
    {
        public UpdateResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
