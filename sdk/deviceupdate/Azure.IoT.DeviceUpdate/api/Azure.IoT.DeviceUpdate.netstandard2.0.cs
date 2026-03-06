namespace Azure.IoT.DeviceUpdate
{
    public partial class DeviceManagementClient
    {
        protected DeviceManagementClient() { }
        public DeviceManagementClient(System.Uri endpoint, string instanceId, Azure.Core.TokenCredential credential) { }
        public DeviceManagementClient(System.Uri endpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CollectLogs(string operationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CollectLogsAsync(string operationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateDeployment(string groupId, string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateDeploymentAsync(string groupId, string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeployment(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeploymentAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeviceClass(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeviceClassAsync(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeviceClassSubgroup(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeviceClassSubgroupAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeviceClassSubgroupDeployment(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeviceClassSubgroupDeploymentAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteGroup(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGroupAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBestUpdatesForDeviceClassSubgroups(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBestUpdatesForDeviceClassSubgroupsAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetBestUpdatesForGroups(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetBestUpdatesForGroupsAsync(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentForDeviceClassSubgroup(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentForDeviceClassSubgroupAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentsForDeviceClassSubgroups(string groupId, string deviceClassId, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsForDeviceClassSubgroupsAsync(string groupId, string deviceClassId, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentsForGroups(string groupId, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsForGroupsAsync(string groupId, string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDevice(string deviceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceAsync(string deviceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClass(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassAsync(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeviceClasses(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeviceClassesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClassSubgroupDeploymentStatus(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassSubgroupDeploymentStatusAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClassSubgroupDetails(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassSubgroupDetailsAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClassSubgroupsForGroups(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassSubgroupsForGroupsAsync(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClassSubgroupUpdateCompliance(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassSubgroupUpdateComplianceAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceHealths(string filter, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceHealthsAsync(string filter, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceModule(string deviceId, string moduleId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceModuleAsync(string deviceId, string moduleId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevices(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevicesAsync(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevicesForDeviceClassSubgroupDeployments(string groupId, string deviceClassId, string deploymentId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevicesForDeviceClassSubgroupDeploymentsAsync(string groupId, string deviceClassId, string deploymentId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGroup(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGroupAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetGroups(string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetGroupsAsync(string orderby = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGroupUpdateCompliance(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGroupUpdateComplianceAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetInstallableUpdatesForDeviceClasses(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetInstallableUpdatesForDeviceClassesAsync(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLogCollectionOperation(string operationId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLogCollectionOperationAsync(string operationId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLogCollectionOperationDetailedStatus(string operationId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLogCollectionOperationDetailedStatusAsync(string operationId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLogCollectionOperations(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLogCollectionOperationsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetOperation(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperations(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationsAsync(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUpdateCompliance(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateComplianceAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation ImportDevices(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportDevicesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RetryDeployment(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RetryDeploymentAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StopDeployment(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopDeploymentAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateDeviceClass(string deviceClassId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDeviceClassAsync(string deviceClassId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DeviceUpdateClient
    {
        protected DeviceUpdateClient() { }
        public DeviceUpdateClient(System.Uri endpoint, string instanceId, Azure.Core.TokenCredential credential) { }
        public DeviceUpdateClient(System.Uri endpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation DeleteUpdate(Azure.WaitUntil waitUntil, string provider, string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteUpdateAsync(Azure.WaitUntil waitUntil, string provider, string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetFile(string provider, string name, string version, string fileId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string provider, string name, string version, string fileId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetFiles(string provider, string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetFilesAsync(string provider, string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetNames(string provider, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetNamesAsync(string provider, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetOperation(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationAsync(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperations(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationsAsync(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProviders(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProvidersAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUpdate(string provider, string name, string version, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateAsync(string provider, string name, string version, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUpdates(string search = null, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUpdatesAsync(string search = null, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVersions(string provider, string name, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVersionsAsync(string provider, string name, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation StartImportUpdate(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> StartImportUpdateAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DeviceUpdateClientOptions : Azure.Core.ClientOptions
    {
        public DeviceUpdateClientOptions(Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion version = Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion.V2022_07_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_07_01_Preview = 1,
        }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class IoTDeviceUpdateClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.IoT.DeviceUpdate.DeviceManagementClient, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions> AddDeviceManagementClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string instanceId) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.IoT.DeviceUpdate.DeviceManagementClient, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions> AddDeviceManagementClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.IoT.DeviceUpdate.DeviceUpdateClient, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions> AddDeviceUpdateClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string instanceId) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.IoT.DeviceUpdate.DeviceUpdateClient, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions> AddDeviceUpdateClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
