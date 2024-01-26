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
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent> GetMonitoredResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent> GetMonitoredResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetIfExists(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetIfExistsAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.ElasticMonitorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.ElasticMonitorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.ElasticMonitorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ElasticMonitorResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>
    {
        public ElasticMonitorResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.MonitorProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.ElasticMonitorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.ElasticMonitorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.ElasticMonitorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> GetIfExists(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>> GetIfExistsAsync(string ruleSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Elastic.MonitoringTagRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Elastic.MonitoringTagRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitoringTagRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>
    {
        public MonitoringTagRuleData() { }
        public Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.MonitoringTagRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.MonitoringTagRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.MonitoringTagRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Azure.ResourceManager.Elastic.Mocking
{
    public partial class MockableElasticArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticArmClient() { }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResource GetElasticMonitorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Elastic.MonitoringTagRuleResource GetMonitoringTagRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableElasticResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResource(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Elastic.ElasticMonitorResource>> GetElasticMonitorResourceAsync(string monitorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Elastic.ElasticMonitorResourceCollection GetElasticMonitorResources() { throw null; }
    }
    public partial class MockableElasticSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableElasticSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Elastic.ElasticMonitorResource> GetElasticMonitorResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Elastic.Models
{
    public static partial class ArmElasticModelFactory
    {
        public static Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse DeploymentInfoResponse(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? status = default(Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus?), string version = null, string memoryCapacity = null, string diskCapacity = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment ElasticCloudDeployment(string name = null, string deploymentId = null, string azureSubscriptionId = null, string elasticsearchRegion = null, System.Uri elasticsearchServiceUri = null, System.Uri kibanaServiceUri = null, System.Uri kibanaSsoUri = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.ElasticCloudUser ElasticCloudUser(string emailAddress = null, string id = null, System.Uri elasticCloudSsoDefaultUri = null) { throw null; }
        public static Azure.ResourceManager.Elastic.ElasticMonitorResourceData ElasticMonitorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, Azure.ResourceManager.Elastic.Models.MonitorProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitoredResourceContent MonitoredResourceContent(string id = null, Azure.ResourceManager.Elastic.Models.SendingLog? sendingLogs = default(Azure.ResourceManager.Elastic.Models.SendingLog?), string reasonForLogsStatus = null) { throw null; }
        public static Azure.ResourceManager.Elastic.MonitoringTagRuleData MonitoringTagRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.MonitorProperties MonitorProperties(Azure.ResourceManager.Elastic.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Elastic.Models.ProvisioningState?), Azure.ResourceManager.Elastic.Models.MonitoringStatus? monitoringStatus = default(Azure.ResourceManager.Elastic.Models.MonitoringStatus?), Azure.ResourceManager.Elastic.Models.ElasticProperties elasticProperties = null, Azure.ResourceManager.Elastic.Models.UserInfo userInfo = null, Azure.ResourceManager.Elastic.Models.LiftrResourceCategory? liftrResourceCategory = default(Azure.ResourceManager.Elastic.Models.LiftrResourceCategory?), int? liftrResourcePreference = default(int?)) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse VmIngestionDetailsResponse(string cloudId = null, string ingestionKey = null) { throw null; }
        public static Azure.ResourceManager.Elastic.Models.VmResources VmResources(string vmResourceId = null) { throw null; }
    }
    public partial class CompanyInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>
    {
        public CompanyInfo() { }
        public string Business { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public string EmployeesNumber { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.CompanyInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.CompanyInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.CompanyInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentInfoResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>
    {
        internal DeploymentInfoResponse() { }
        public string DiskCapacity { get { throw null; } }
        public string MemoryCapacity { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.ElasticDeploymentStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.DeploymentInfoResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticCloudDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>
    {
        public ElasticCloudDeployment() { }
        public string AzureSubscriptionId { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public string ElasticsearchRegion { get { throw null; } }
        public System.Uri ElasticsearchServiceUri { get { throw null; } }
        public System.Uri KibanaServiceUri { get { throw null; } }
        public System.Uri KibanaSsoUri { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticCloudUser : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>
    {
        public ElasticCloudUser() { }
        public System.Uri ElasticCloudSsoDefaultUri { get { throw null; } }
        public string EmailAddress { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticCloudUser System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticCloudUser System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticCloudUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ElasticMonitorResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>
    {
        public ElasticMonitorResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticMonitorResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ElasticProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>
    {
        public ElasticProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudDeployment ElasticCloudDeployment { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ElasticCloudUser ElasticCloudUser { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.ElasticProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.ElasticProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.ElasticProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilteringTag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.FilteringTag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>
    {
        public FilteringTag() { }
        public Azure.ResourceManager.Elastic.Models.TagAction? Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.FilteringTag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.FilteringTag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.FilteringTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LogRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.LogRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>
    {
        public LogRules() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Elastic.Models.FilteringTag> FilteringTags { get { throw null; } }
        public bool? SendAadLogs { get { throw null; } set { } }
        public bool? SendActivityLogs { get { throw null; } set { } }
        public bool? SendSubscriptionLogs { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.LogRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.LogRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.LogRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.LogRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.LogRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitoredResourceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>
    {
        internal MonitoredResourceContent() { }
        public string Id { get { throw null; } }
        public string ReasonForLogsStatus { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.SendingLog? SendingLogs { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.MonitoredResourceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoredResourceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoredResourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MonitoringTagRulesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>
    {
        public MonitoringTagRulesProperties() { }
        public Azure.ResourceManager.Elastic.Models.LogRules LogRules { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitoringTagRulesProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>
    {
        public MonitorProperties() { }
        public Azure.ResourceManager.Elastic.Models.ElasticProperties ElasticProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.LiftrResourceCategory? LiftrResourceCategory { get { throw null; } }
        public int? LiftrResourcePreference { get { throw null; } }
        public Azure.ResourceManager.Elastic.Models.MonitoringStatus? MonitoringStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Elastic.Models.UserInfo UserInfo { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.MonitorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.MonitorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.MonitorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class UserInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>
    {
        public UserInfo() { }
        public Azure.ResourceManager.Elastic.Models.CompanyInfo CompanyInfo { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.UserInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.UserInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.UserInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmCollectionUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>
    {
        public VmCollectionUpdate() { }
        public Azure.ResourceManager.Elastic.Models.OperationName? OperationName { get { throw null; } set { } }
        public string VmResourceId { get { throw null; } set { } }
        Azure.ResourceManager.Elastic.Models.VmCollectionUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmCollectionUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmCollectionUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmIngestionDetailsResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>
    {
        internal VmIngestionDetailsResponse() { }
        public string CloudId { get { throw null; } }
        public string IngestionKey { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmIngestionDetailsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>
    {
        internal VmResources() { }
        public string VmResourceId { get { throw null; } }
        Azure.ResourceManager.Elastic.Models.VmResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Elastic.Models.VmResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Elastic.Models.VmResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Elastic.Models.VmResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
