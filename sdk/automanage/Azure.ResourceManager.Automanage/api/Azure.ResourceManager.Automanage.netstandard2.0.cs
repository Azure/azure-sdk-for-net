namespace Azure.ResourceManager.Automanage
{
    public partial class AutomanageConfigurationProfileAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomanageConfigurationProfileAssignmentData() { }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Automanage.Models.ConfigurationProfileAssignmentProperties Properties { get { throw null; } set { } }
    }
    public partial class AutomanageConfigurationProfileAssignmentReportData : Azure.ResourceManager.Models.ResourceData
    {
        public AutomanageConfigurationProfileAssignmentReportData() { }
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
    public static partial class AutomanageExtensions
    {
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
        public static Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource> GetBestPractice(this Azure.ResourceManager.Resources.TenantResource tenantResource, string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.BestPracticeResource>> GetBestPracticeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string bestPracticeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.BestPracticeResource GetBestPracticeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.BestPracticeCollection GetBestPractices(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetConfigurationProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> GetConfigurationProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configurationProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.ConfigurationProfileResource GetConfigurationProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.ConfigurationProfileCollection GetConfigurationProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetConfigurationProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Automanage.ConfigurationProfileResource> GetConfigurationProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource GetConfigurationProfileVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Automanage.ServicePrincipalResource GetServicePrincipal(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Automanage.ServicePrincipalResource GetServicePrincipalResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> GetConfigurationProfileVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> GetConfigurationProfileVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Automanage.ConfigurationProfileVersionCollection GetConfigurationProfileVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource> Update(Azure.ResourceManager.Automanage.Models.ConfigurationProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileResource>> UpdateAsync(Azure.ResourceManager.Automanage.Models.ConfigurationProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationProfileVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>, System.Collections.IEnumerable
    {
        protected ConfigurationProfileVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Automanage.ConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.Automanage.ConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationProfileVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationProfileVersionResource() { }
        public virtual Azure.ResourceManager.Automanage.ConfigurationProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configurationProfileName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.ConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Automanage.ConfigurationProfileVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Automanage.ConfigurationProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServicePrincipalData : Azure.ResourceManager.Models.ResourceData
    {
        public ServicePrincipalData() { }
        public bool? AuthorizationSet { get { throw null; } }
        public string ServicePrincipalId { get { throw null; } }
    }
    public partial class ServicePrincipalResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServicePrincipalResource() { }
        public virtual Azure.ResourceManager.Automanage.ServicePrincipalData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Automanage.ServicePrincipalResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Automanage.ServicePrincipalResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
