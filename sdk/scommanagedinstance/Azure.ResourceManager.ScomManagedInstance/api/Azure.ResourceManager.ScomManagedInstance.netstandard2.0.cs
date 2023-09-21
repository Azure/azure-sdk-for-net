namespace Azure.ResourceManager.ScomManagedInstance
{
    public partial class ManagedGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>, System.Collections.IEnumerable
    {
        protected ManagedGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> Get(string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>> GetAsync(string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedGatewayData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedGatewayData() { }
        public Azure.ResourceManager.ScomManagedInstance.Models.ManagedGatewayProperties Properties { get { throw null; } set { } }
    }
    public partial class ManagedGatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedGatewayResource() { }
        public virtual Azure.ResourceManager.ScomManagedInstance.ManagedGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string managedGatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>, System.Collections.IEnumerable
    {
        protected ManagedInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.ScomManagedInstance.ManagedInstanceData data, bool? validationMode = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.ScomManagedInstance.ManagedInstanceData data, bool? validationMode = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> Get(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> GetAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.MonitoringInstanceProperties Properties { get { throw null; } set { } }
    }
    public partial class ManagedInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedInstanceResource() { }
        public virtual Azure.ResourceManager.ScomManagedInstance.ManagedInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource> GetManagedGateway(string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource>> GetManagedGatewayAsync(string managedGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScomManagedInstance.ManagedGatewayCollection GetManagedGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> GetMonitoredResource(string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>> GetMonitoredResourceAsync(string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ScomManagedInstance.MonitoredResourceCollection GetMonitoredResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsConfiguration> LinkLogAnalytics(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsConfiguration>> LinkLogAnalyticsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.PatchServersResponseProperties> PatchServers(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.PatchServersResponseProperties>> PatchServersAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.SetServerCountResponseProperties> Scale(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.ScalingProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.SetServerCountResponseProperties>> ScaleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.ScalingProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.UnlinkLogAnalyticsResponseProperties> UnlinkLogAnalytics(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.UnlinkLogAnalyticsResponseProperties>> UnlinkLogAnalyticsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.ManagedInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.ManagedInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsUpdateConfiguration> UpdateLogAnalytics(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsUpdateConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsUpdateConfiguration>> UpdateLogAnalyticsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsUpdateConfiguration body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitoredResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoredResource() { }
        public virtual Azure.ResourceManager.ScomManagedInstance.MonitoredResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string monitoredResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitoredResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>, System.Collections.IEnumerable
    {
        protected MonitoredResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> Get(string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>> GetAsync(string monitoredResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ScomManagedInstance.MonitoredResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.MonitoredResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitoredResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitoredResourceData() { }
        public Azure.ResourceManager.ScomManagedInstance.Models.MonitoredResourceProperties Properties { get { throw null; } set { } }
    }
    public static partial class ScomManagedInstanceExtensions
    {
        public static Azure.ResourceManager.ScomManagedInstance.ManagedGatewayResource GetManagedGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> GetManagedInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource>> GetManagedInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource GetManagedInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.ManagedInstanceCollection GetManagedInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> GetManagedInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ScomManagedInstance.ManagedInstanceResource> GetManagedInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.MonitoredResource GetMonitoredResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.ScomManagedInstance.Models
{
    public static partial class ArmScomManagedInstanceModelFactory
    {
        public static Azure.ResourceManager.ScomManagedInstance.Models.DatabaseInstanceProperties DatabaseInstanceProperties(string databaseInstanceId = null, string databaseFqdn = null, string dwDatabaseName = null, string operationalDatabaseId = null, string dwDatabaseId = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.ManagedGatewayData ManagedGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ScomManagedInstance.Models.ManagedGatewayProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.ManagedGatewayProperties ManagedGatewayProperties(string resourceId = null, string resourceLocation = null, string computerName = null, string domainName = null, string managementServerEndpoint = null, string healthStatus = null, string connectionStatus = null, string version = null, string installType = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.ManagedInstanceData ManagedInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ScomManagedInstance.Models.MonitoringInstanceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.ManagedInstanceOperationStatus ManagedInstanceOperationStatus(string operationName = null, string operationState = null, string id = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.ManagementServerProperties ManagementServerProperties(string serverName = null, string vmResId = null, string fqdn = null, string serverRoles = null, string healthState = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.MonitoredResourceData MonitoredResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ScomManagedInstance.Models.MonitoredResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.MonitoredResourceProperties MonitoredResourceProperties(string resourceId = null, string resourceLocation = null, string computerName = null, string domainName = null, string managementServerEndpoint = null, string healthStatus = null, string connectionStatus = null, string agentVersion = null, string installType = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.MonitoringInstanceProperties MonitoringInstanceProperties(string productVersion = null, string vNetSubnetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.Models.ManagementServerProperties> managementEndpoints = null, Azure.ResourceManager.ScomManagedInstance.Models.DatabaseInstanceProperties databaseInstance = null, Azure.ResourceManager.ScomManagedInstance.Models.DomainControllerProperties domainController = null, Azure.ResourceManager.ScomManagedInstance.Models.DomainUserCredentials domainUserCredentials = null, Azure.ResourceManager.ScomManagedInstance.Models.GmsaDetails gmsaDetails = null, Azure.ResourceManager.ScomManagedInstance.Models.AzureHybridBenefitProperties azureHybridBenefit = null, string provisioningState = null, Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsConfiguration logAnalyticsProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ScomManagedInstance.Models.ManagedInstanceOperationStatus> operationsStatus = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.PatchServersResponseProperties PatchServersResponseProperties(string status = null) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.SetServerCountResponseProperties SetServerCountResponseProperties(long? serverCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.UnlinkLogAnalyticsResponseProperties UnlinkLogAnalyticsResponseProperties(string status = null) { throw null; }
    }
    public partial class AzureHybridBenefitProperties
    {
        public AzureHybridBenefitProperties() { }
        public Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType? ScomLicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType? WindowsServerLicenseType { get { throw null; } set { } }
    }
    public partial class DatabaseInstanceProperties
    {
        public DatabaseInstanceProperties() { }
        public string DatabaseFqdn { get { throw null; } }
        public string DatabaseInstanceId { get { throw null; } set { } }
        public string DwDatabaseId { get { throw null; } }
        public string DwDatabaseName { get { throw null; } }
        public string OperationalDatabaseId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataType : System.IEquatable<Azure.ResourceManager.ScomManagedInstance.Models.DataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataType(string value) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.DataType Audit { get { throw null; } }
        public static Azure.ResourceManager.ScomManagedInstance.Models.DataType Event { get { throw null; } }
        public static Azure.ResourceManager.ScomManagedInstance.Models.DataType Performance { get { throw null; } }
        public static Azure.ResourceManager.ScomManagedInstance.Models.DataType State { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScomManagedInstance.Models.DataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScomManagedInstance.Models.DataType left, Azure.ResourceManager.ScomManagedInstance.Models.DataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScomManagedInstance.Models.DataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScomManagedInstance.Models.DataType left, Azure.ResourceManager.ScomManagedInstance.Models.DataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainControllerProperties
    {
        public DomainControllerProperties() { }
        public string DnsServer { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string OuPath { get { throw null; } set { } }
    }
    public partial class DomainUserCredentials
    {
        public DomainUserCredentials() { }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string PasswordSecret { get { throw null; } set { } }
        public string UserNameSecret { get { throw null; } set { } }
    }
    public partial class GmsaDetails
    {
        public GmsaDetails() { }
        public string DnsName { get { throw null; } set { } }
        public string GmsaAccount { get { throw null; } set { } }
        public string LoadBalancerIP { get { throw null; } set { } }
        public string ManagementServerGroupName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridLicenseType : System.IEquatable<Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType AzureHybridBenefit { get { throw null; } }
        public static Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType left, Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType left, Azure.ResourceManager.ScomManagedInstance.Models.HybridLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalyticsConfiguration
    {
        public LogAnalyticsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScomManagedInstance.Models.DataType> DataTypes { get { throw null; } }
        public bool? ImportData { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
    }
    public partial class LogAnalyticsUpdateConfiguration
    {
        public LogAnalyticsUpdateConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ScomManagedInstance.Models.DataType> DataTypes { get { throw null; } }
    }
    public partial class ManagedGatewayProperties
    {
        public ManagedGatewayProperties() { }
        public string ComputerName { get { throw null; } set { } }
        public string ConnectionStatus { get { throw null; } }
        public string DomainName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } }
        public string InstallType { get { throw null; } }
        public string ManagementServerEndpoint { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class ManagedInstanceOperationStatus
    {
        internal ManagedInstanceOperationStatus() { }
        public string Id { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string OperationState { get { throw null; } }
    }
    public partial class ManagedInstancePatch
    {
        public ManagedInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ManagementServerProperties
    {
        internal ManagementServerProperties() { }
        public string Fqdn { get { throw null; } }
        public string HealthState { get { throw null; } }
        public string ServerName { get { throw null; } }
        public string ServerRoles { get { throw null; } }
        public string VmResId { get { throw null; } }
    }
    public partial class MonitoredResourceProperties
    {
        public MonitoredResourceProperties() { }
        public string AgentVersion { get { throw null; } }
        public string ComputerName { get { throw null; } set { } }
        public string ConnectionStatus { get { throw null; } }
        public string DomainName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } }
        public string InstallType { get { throw null; } }
        public string ManagementServerEndpoint { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ResourceId { get { throw null; } set { } }
        public string ResourceLocation { get { throw null; } set { } }
    }
    public partial class MonitoringInstanceProperties
    {
        public MonitoringInstanceProperties() { }
        public Azure.ResourceManager.ScomManagedInstance.Models.AzureHybridBenefitProperties AzureHybridBenefit { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.DatabaseInstanceProperties DatabaseInstance { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.DomainControllerProperties DomainController { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.DomainUserCredentials DomainUserCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.GmsaDetails GmsaDetails { get { throw null; } set { } }
        public Azure.ResourceManager.ScomManagedInstance.Models.LogAnalyticsConfiguration LogAnalyticsProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ScomManagedInstance.Models.ManagementServerProperties> ManagementEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ScomManagedInstance.Models.ManagedInstanceOperationStatus> OperationsStatus { get { throw null; } }
        public string ProductVersion { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string VNetSubnetId { get { throw null; } set { } }
    }
    public partial class PatchServersResponseProperties
    {
        internal PatchServersResponseProperties() { }
        public string Status { get { throw null; } }
    }
    public partial class ScalingProperties
    {
        public ScalingProperties() { }
        public long? ServerCount { get { throw null; } set { } }
    }
    public partial class SetServerCountResponseProperties
    {
        internal SetServerCountResponseProperties() { }
        public long? ServerCount { get { throw null; } }
    }
    public partial class UnlinkLogAnalyticsResponseProperties
    {
        internal UnlinkLogAnalyticsResponseProperties() { }
        public string Status { get { throw null; } }
    }
}
