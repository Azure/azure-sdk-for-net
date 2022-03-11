namespace Azure.IoT.DeviceUpdate
{
    public partial class DeviceManagementClient
    {
        protected DeviceManagementClient() { }
        public DeviceManagementClient(string endpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CollectLogs(string operationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CollectLogsAsync(string operationId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateDeployment(string groupId, string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateDeploymentAsync(string groupId, string deploymentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateGroup(string groupId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateGroupAsync(string groupId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDeployment(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeploymentAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteGroup(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGroupAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetBestUpdatesForGroups(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetBestUpdatesForGroupsAsync(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeployment(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentDevices(string groupId, string deploymentId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentDevicesAsync(string groupId, string deploymentId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeploymentsForGroups(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeploymentsForGroupsAsync(string groupId, string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeploymentStatus(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeploymentStatusAsync(string groupId, string deploymentId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDevice(string deviceId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceAsync(string deviceId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceClass(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceClassAsync(string deviceClassId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeviceClasses(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeviceClassesAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceModule(string deviceId, string moduleId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceModuleAsync(string deviceId, string moduleId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevices(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevicesAsync(string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDeviceTag(string tagName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDeviceTagAsync(string tagName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDeviceTags(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDeviceTagsAsync(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetGroup(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGroupAsync(string groupId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetGroups(Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetGroupsAsync(Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Operation<System.BinaryData> ImportDevices(Azure.WaitUntil waitUntil, string action, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportDevicesAsync(Azure.WaitUntil waitUntil, string action, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response RetryDeployment(string groupId, string deploymentId, string action, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RetryDeploymentAsync(string groupId, string deploymentId, string action, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response StopDeployment(string groupId, string deploymentId, string action, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopDeploymentAsync(string groupId, string deploymentId, string action, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DeviceUpdateClient
    {
        protected DeviceUpdateClient() { }
        public DeviceUpdateClient(string endpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> DeleteUpdate(Azure.WaitUntil waitUntil, string provider, string name, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteUpdateAsync(Azure.WaitUntil waitUntil, string provider, string name, string version, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Operation<System.BinaryData> ImportUpdate(Azure.WaitUntil waitUntil, string action, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> ImportUpdateAsync(Azure.WaitUntil waitUntil, string action, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DeviceUpdateClientOptions : Azure.Core.ClientOptions
    {
        public DeviceUpdateClientOptions(Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion version = Azure.IoT.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion.V2021_06_01_preview) { }
        public enum ServiceVersion
        {
            V2021_06_01_preview = 1,
        }
    }
}
