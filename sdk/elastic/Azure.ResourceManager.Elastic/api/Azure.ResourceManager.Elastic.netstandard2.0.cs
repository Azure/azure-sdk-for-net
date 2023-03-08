namespace Azure.ResourceManager.Elastic
{
    public static partial class ElasticExtensions
    {
        public static Azure.ResourceManager.Elastic.ElasticMonitorResource GetElasticMonitorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetElasticMonitorResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorResourceCollection GetElasticMonitorResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoringTagRuleResource GetMonitoringTagRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ElasticMonitorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ElasticMonitorResource() { }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse> DetailsVMIngestion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>> DetailsVMIngestionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse> GetDeploymentInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>> GetDeploymentInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.MonitoredResource> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.MonitoredResource> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetMonitoringTagRule(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetMonitoringTagRuleAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoringTagRuleCollection GetMonitoringTagRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.VmResources> GetVMHosts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.VmResources> GetVMHostsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> Update(Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> UpdateAsync(Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateVMCollection(Azure.ResourceManager.Elastic.Models.VmCollectionUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateVMCollectionAsync(Azure.ResourceManager.Elastic.Models.VmCollectionUpdate body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ElasticMonitorResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>, System.Collections.IEnumerable
    {
        protected ElasticMonitorResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Elastic.ElasticMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.ElasticMonitorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitorName, Azure.ResourceManager.Elastic.ElasticMonitorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> Get(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.ElasticMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.ElasticMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ElasticMonitorResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.MonitorProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
    }
    public partial class MonitoringTagRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>, System.Collections.IEnumerable
    {
        protected MonitoringTagRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleSetName, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> Get(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitoringTagRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitoringTagRuleData() { }
        public Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties Properties { get { throw null; } set { } }
    }
    public partial class MonitoringTagRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoringTagRuleResource() { }
        public virtual Azure.ResourceManager.Elastic.MonitoringTagRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string monitorName, string ruleSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Elastic.MonitoringTagRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Elastic.Mock
{
    public partial class ElasticMonitorResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ElasticMonitorResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResourceCollection GetElasticMonitorResources() { throw null; }
    }
}
namespace Azure.ResourceManager.Elastic.Models
{
    public partial class CompanyInfo
    {
        public CompanyInfo() { }
        public string Business { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string EmployeesNumber { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
    public partial class DeploymentInfoResponse
    {
        internal DeploymentInfoResponse() { }
        public string DiskCapacity { get { throw null; } }
        public string MemoryCapacity { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ElasticCloudDeployment
    {
        public ElasticCloudDeployment() { }
        public string AzureSubscriptionId { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public string ElasticsearchRegion { get { throw null; } }
        public System.Uri ElasticsearchServiceUri { get { throw null; } }
        public System.Uri KibanaServiceUri { get { throw null; } }
        public System.Uri KibanaSsoUri { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ElasticCloudUser
    {
        public ElasticCloudUser() { }
        public System.Uri ElasticCloudSsoDefaultUri { get { throw null; } }
        public string EmailAddress { get { throw null; } }
        public string Id { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticDeploymentStatus : System.IEquatable<Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticDeploymentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus left, Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus left, Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticMonitorResourcePatch
    {
        public ElasticMonitorResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ElasticProperties
    {
        public ElasticProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment ElasticCloudDeployment { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudUser ElasticCloudUser { get { throw null; } set { } }
    }
    public partial class FilteringTag
    {
        public FilteringTag() { }
        public Azure.ResourceManager.Elastic.Models.TagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LiftrResourceCategory : System.IEquatable<Azure.ResourceManager.Elastic.Models.LiftrResourceCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LiftrResourceCategory(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.LiftrResourceCategory MonitorLogs { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.LiftrResourceCategory Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory left, Azure.ResourceManager.Elastic.Models.LiftrResourceCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.LiftrResourceCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory left, Azure.ResourceManager.Elastic.Models.LiftrResourceCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogRules
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Elastic.Models.FilteringTag> FilteringTags { get { throw null; } }
        public bool? SendAadLogs { get { throw null; } set { } }
        public bool? SendActivityLogs { get { throw null; } set { } }
        public bool? SendSubscriptionLogs { get { throw null; } set { } }
    }
    public partial class MonitoredResource
    {
        internal MonitoredResource() { }
        public string Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.SendingLog? SendingLogs { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringStatus : System.IEquatable<Azure.ResourceManager.Elastic.Models.MonitoringStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringStatus(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitoringStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.MonitoringStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.MonitoringStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.MonitoringStatus left, Azure.ResourceManager.Elastic.Models.MonitoringStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.MonitoringStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.MonitoringStatus left, Azure.ResourceManager.Elastic.Models.MonitoringStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonitoringTagRulesProperties
    {
        public MonitoringTagRulesProperties() { }
        public Azure.ResourceManager.Elastic.Models.LogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class MonitorProperties
    {
        public MonitorProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticProperties ElasticProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.LiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.UserInfo UserInfo { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationName : System.IEquatable<Azure.ResourceManager.Elastic.Models.OperationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationName(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.OperationName Add { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.OperationName Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.OperationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.OperationName left, Azure.ResourceManager.Elastic.Models.OperationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.OperationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.OperationName left, Azure.ResourceManager.Elastic.Models.OperationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Elastic.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.ProvisioningState left, Azure.ResourceManager.Elastic.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.ProvisioningState left, Azure.ResourceManager.Elastic.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SendingLog : System.IEquatable<Azure.ResourceManager.Elastic.Models.SendingLog>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SendingLog(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.SendingLog False { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.SendingLog True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.SendingLog other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.SendingLog left, Azure.ResourceManager.Elastic.Models.SendingLog right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.SendingLog (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.SendingLog left, Azure.ResourceManager.Elastic.Models.SendingLog right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TagAction : System.IEquatable<Azure.ResourceManager.Elastic.Models.TagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TagAction(string value) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.TagAction Exclude { get { throw null; } }
        public static Azure.ResourceManager.Elastic.Models.TagAction Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Elastic.Models.TagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Elastic.Models.TagAction left, Azure.ResourceManager.Elastic.Models.TagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Elastic.Models.TagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Elastic.Models.TagAction left, Azure.ResourceManager.Elastic.Models.TagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserInfo
    {
        public UserInfo() { }
        public Azure.ResourceManager.Elastic.Models.CompanyInfo CompanyInfo { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
    }
    public partial class VmCollectionUpdate
    {
        public VmCollectionUpdate() { }
        public Azure.ResourceManager.Elastic.Models.OperationName? OperationName { get { throw null; } set { } }
        public string VmResourceId { get { throw null; } set { } }
    }
    public partial class VmIngestionDetailsResponse
    {
        internal VmIngestionDetailsResponse() { }
        public string CloudId { get { throw null; } }
        public string IngestionKey { get { throw null; } }
    }
    public partial class VmResources
    {
        internal VmResources() { }
        public string VmResourceId { get { throw null; } }
    }
}
