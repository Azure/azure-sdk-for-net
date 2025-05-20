namespace Azure.IoT.DeviceUpdate
{
    public partial class AzureIoTDeviceUpdateContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureIoTDeviceUpdateContext() { }
        public static Azure.IoT.DeviceUpdate.AzureIoTDeviceUpdateContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeviceManagementClient
    {
        protected DeviceManagementClient() { }
        public DeviceManagementClient(System.Uri endpoint, string instanceId, Azure.Core.TokenCredential credential) { }
        public DeviceManagementClient(System.Uri endpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateOrUpdateDeployment(string groupId, string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateDeploymentAsync(string groupId, string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeployment(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeploymentAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeploymentForDeviceClassSubgroup(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeploymentForDeviceClassSubgroupAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeviceClass(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeviceClassAsync(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeviceClassSubgroup(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeviceClassSubgroupAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteGroup(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGroupAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetBestUpdatesForDeviceClassSubgroup(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetBestUpdatesForDeviceClassSubgroupAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetBestUpdatesForGroups(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetBestUpdatesForGroupsAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentForDeviceClassSubgroup(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentForDeviceClassSubgroupAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentsForDeviceClassSubgroups(string groupId, string deviceClassId, string orderBy = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsForDeviceClassSubgroupsAsync(string groupId, string deviceClassId, string orderBy = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentsForGroups(string groupId, string orderBy = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsForGroupsAsync(string groupId, string orderBy = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDevice(string deviceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceAsync(string deviceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClass(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassAsync(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeviceClasses(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeviceClassesAsync(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClassSubgroup(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassSubgroupAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClassSubgroupDeploymentStatus(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassSubgroupDeploymentStatusAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeviceClassSubgroupsForGroups(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeviceClassSubgroupsForGroupsAsync(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClassSubgroupUpdateCompliance(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassSubgroupUpdateComplianceAsync(string groupId, string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceModule(string deviceId, string moduleId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceModuleAsync(string deviceId, string moduleId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevices(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevicesAsync(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeviceStatesForDeviceClassSubgroupDeployments(string groupId, string deviceClassId, string deploymentId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeviceStatesForDeviceClassSubgroupDeploymentsAsync(string groupId, string deviceClassId, string deploymentId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGroup(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGroupAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetGroups(string orderBy = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetGroupsAsync(string orderBy = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetHealthOfDevices(string filter, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetHealthOfDevicesAsync(string filter, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetInstallableUpdatesForDeviceClasses(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetInstallableUpdatesForDeviceClassesAsync(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLogCollection(string logCollectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLogCollectionAsync(string logCollectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetLogCollectionDetailedStatus(string logCollectionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetLogCollectionDetailedStatusAsync(string logCollectionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetLogCollections(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetLogCollectionsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetOperationStatus(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationStatusAsync(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperationStatuses(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationStatusesAsync(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUpdateCompliance(Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateComplianceAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUpdateComplianceForGroup(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpdateComplianceForGroupAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation ImportDevices(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> ImportDevicesAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RetryDeployment(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RetryDeploymentAsync(string groupId, string deviceClassId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StartLogCollection(string logCollectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartLogCollectionAsync(string logCollectionId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Response GetOperationStatus(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationStatusAsync(string operationId, Azure.ETag? ifNoneMatch = default(Azure.ETag?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetOperationStatuses(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetOperationStatusesAsync(string filter = null, int? top = default(int?), Azure.RequestContext context = null) { throw null; }
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
        public DeviceUpdateClientOptions(Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion version = Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion.V2022_10_01) { }
        public enum ServiceVersion
        {
            V2022_10_01 = 1,
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
