namespace Azure.Iot.DeviceUpdate
{
    public partial class DeploymentsClient
    {
        protected DeploymentsClient() { }
        public DeploymentsClient(string accountEndpoint, string instanceId, Azure.Core.TokenCredential credential) { }
        public DeploymentsClient(string accountEndpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.Iot.DeviceUpdate.DeviceUpdateClientOptions options) { }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment> CancelDeployment(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment>> CancelDeploymentAsync(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment> CreateOrUpdateDeployment(string deploymentId, Azure.Iot.DeviceUpdate.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment>> CreateOrUpdateDeploymentAsync(string deploymentId, Azure.Iot.DeviceUpdate.Models.Deployment deployment, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDeployment(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDeploymentAsync(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.Deployment> GetAllDeployments(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.Deployment> GetAllDeploymentsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment> GetDeployment(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment>> GetDeploymentAsync(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.DeploymentDeviceState> GetDeploymentDevices(string deploymentId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.DeploymentDeviceState> GetDeploymentDevicesAsync(string deploymentId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.DeploymentStatus> GetDeploymentStatus(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.DeploymentStatus>> GetDeploymentStatusAsync(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment> RetryDeployment(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Deployment>> RetryDeploymentAsync(string deploymentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevicesClient
    {
        protected DevicesClient() { }
        public DevicesClient(string accountEndpoint, string instanceId, Azure.Core.TokenCredential credential) { }
        public DevicesClient(string accountEndpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.Iot.DeviceUpdate.DeviceUpdateClientOptions options) { }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Group> CreateOrUpdateGroup(string groupId, Azure.Iot.DeviceUpdate.Models.Group group, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Group>> CreateOrUpdateGroupAsync(string groupId, Azure.Iot.DeviceUpdate.Models.Group group, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.DeviceClass> GetAllDeviceClasses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.DeviceClass> GetAllDeviceClassesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.Device> GetAllDevices(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.Device> GetAllDevicesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.DeviceTag> GetAllDeviceTags(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.DeviceTag> GetAllDeviceTagsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.Group> GetAllGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.Group> GetAllGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Device> GetDevice(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Device>> GetDeviceAsync(string deviceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.DeviceClass> GetDeviceClass(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.DeviceClass>> GetDeviceClassAsync(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetDeviceClassDeviceIds(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetDeviceClassDeviceIdsAsync(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.UpdateId> GetDeviceClassInstallableUpdates(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.UpdateId> GetDeviceClassInstallableUpdatesAsync(string deviceClassId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.DeviceTag> GetDeviceTag(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.DeviceTag>> GetDeviceTagAsync(string tagName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Group> GetGroup(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Group>> GetGroupAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.UpdatableDevices> GetGroupBestUpdates(string groupId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.UpdatableDevices> GetGroupBestUpdatesAsync(string groupId, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.UpdateCompliance> GetGroupUpdateCompliance(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.UpdateCompliance>> GetGroupUpdateComplianceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.UpdateCompliance> GetUpdateCompliance(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.UpdateCompliance>> GetUpdateComplianceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateClientOptions : Azure.Core.ClientOptions
    {
        public DeviceUpdateClientOptions(Azure.Iot.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion version = Azure.Iot.DeviceUpdate.DeviceUpdateClientOptions.ServiceVersion.V2020_09_01) { }
        public enum ServiceVersion
        {
            V2020_09_01 = 1,
        }
    }
    public partial class UpdatesClient
    {
        protected UpdatesClient() { }
        public UpdatesClient(string accountEndpoint, string instanceId, Azure.Core.TokenCredential credential) { }
        public UpdatesClient(string accountEndpoint, string instanceId, Azure.Core.TokenCredential credential, Azure.Iot.DeviceUpdate.DeviceUpdateClientOptions options) { }
        public virtual Azure.Response<string> DeleteUpdate(string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> DeleteUpdateAsync(string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.File> GetFile(string provider, string name, string version, string fileId, Azure.Iot.DeviceUpdate.Models.AccessCondition accessCondition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.File>> GetFileAsync(string provider, string name, string version, string fileId, Azure.Iot.DeviceUpdate.Models.AccessCondition accessCondition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetFiles(string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetFilesAsync(string provider, string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetNames(string provider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetNamesAsync(string provider, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Operation> GetOperation(string operationId, Azure.Iot.DeviceUpdate.Models.AccessCondition accessCondition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Operation>> GetOperationAsync(string operationId, Azure.Iot.DeviceUpdate.Models.AccessCondition accessCondition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Iot.DeviceUpdate.Models.Operation> GetOperations(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Iot.DeviceUpdate.Models.Operation> GetOperationsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetProviders(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetProvidersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Iot.DeviceUpdate.Models.Update> GetUpdate(string provider, string name, string version, Azure.Iot.DeviceUpdate.Models.AccessCondition accessCondition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Iot.DeviceUpdate.Models.Update>> GetUpdateAsync(string provider, string name, string version, Azure.Iot.DeviceUpdate.Models.AccessCondition accessCondition = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetVersions(string provider, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetVersionsAsync(string provider, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<string> ImportUpdate(Azure.Iot.DeviceUpdate.Models.ImportUpdateInput updateToImport, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> ImportUpdateAsync(Azure.Iot.DeviceUpdate.Models.ImportUpdateInput updateToImport, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Iot.DeviceUpdate.Models
{
    public partial class AccessCondition
    {
        public AccessCondition() { }
        public string IfNoneMatch { get { throw null; } set { } }
    }
    public partial class Compatibility
    {
        internal Compatibility() { }
        public string DeviceManufacturer { get { throw null; } }
        public string DeviceModel { get { throw null; } }
    }
    public partial class Deployment
    {
        public Deployment(string deploymentId, Azure.Iot.DeviceUpdate.Models.DeploymentType deploymentType, System.DateTimeOffset startDateTime, Azure.Iot.DeviceUpdate.Models.DeviceGroupType deviceGroupType, System.Collections.Generic.IEnumerable<string> deviceGroupDefinition, Azure.Iot.DeviceUpdate.Models.UpdateId updateId) { }
        public string DeploymentId { get { throw null; } set { } }
        public Azure.Iot.DeviceUpdate.Models.DeploymentType DeploymentType { get { throw null; } set { } }
        public string DeviceClassId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DeviceGroupDefinition { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.DeviceGroupType DeviceGroupType { get { throw null; } set { } }
        public bool? IsCanceled { get { throw null; } set { } }
        public bool? IsCompleted { get { throw null; } set { } }
        public bool? IsRetried { get { throw null; } set { } }
        public System.DateTimeOffset StartDateTime { get { throw null; } set { } }
        public Azure.Iot.DeviceUpdate.Models.UpdateId UpdateId { get { throw null; } set { } }
    }
    public partial class DeploymentDeviceState
    {
        internal DeploymentDeviceState() { }
        public string DeviceId { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState DeviceState { get { throw null; } }
        public bool MovedOnToNewDeployment { get { throw null; } }
        public int RetryCount { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentState : System.IEquatable<Azure.Iot.DeviceUpdate.Models.DeploymentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentState(string value) { throw null; }
        public static Azure.Iot.DeviceUpdate.Models.DeploymentState Active { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeploymentState Canceled { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeploymentState Superseded { get { throw null; } }
        public bool Equals(Azure.Iot.DeviceUpdate.Models.DeploymentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.DeviceUpdate.Models.DeploymentState left, Azure.Iot.DeviceUpdate.Models.DeploymentState right) { throw null; }
        public static implicit operator Azure.Iot.DeviceUpdate.Models.DeploymentState (string value) { throw null; }
        public static bool operator !=(Azure.Iot.DeviceUpdate.Models.DeploymentState left, Azure.Iot.DeviceUpdate.Models.DeploymentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStatus
    {
        internal DeploymentStatus() { }
        public Azure.Iot.DeviceUpdate.Models.DeploymentState DeploymentState { get { throw null; } }
        public int? DevicesCanceledCount { get { throw null; } }
        public int? DevicesCompletedFailedCount { get { throw null; } }
        public int? DevicesCompletedSucceededCount { get { throw null; } }
        public int? DevicesIncompatibleCount { get { throw null; } }
        public int? DevicesInProgressCount { get { throw null; } }
        public int? TotalDevices { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentType : System.IEquatable<Azure.Iot.DeviceUpdate.Models.DeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentType(string value) { throw null; }
        public static Azure.Iot.DeviceUpdate.Models.DeploymentType Complete { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeploymentType Download { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeploymentType Install { get { throw null; } }
        public bool Equals(Azure.Iot.DeviceUpdate.Models.DeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.DeviceUpdate.Models.DeploymentType left, Azure.Iot.DeviceUpdate.Models.DeploymentType right) { throw null; }
        public static implicit operator Azure.Iot.DeviceUpdate.Models.DeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.Iot.DeviceUpdate.Models.DeploymentType left, Azure.Iot.DeviceUpdate.Models.DeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Device
    {
        internal Device() { }
        public Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState? DeploymentStatus { get { throw null; } }
        public string DeviceClassId { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string GroupId { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.UpdateId InstalledUpdateId { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.UpdateId LastAttemptedUpdateId { get { throw null; } }
        public string LastDeploymentId { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public string Model { get { throw null; } }
        public bool OnLatestUpdate { get { throw null; } }
    }
    public partial class DeviceClass
    {
        internal DeviceClass() { }
        public Azure.Iot.DeviceUpdate.Models.UpdateId BestCompatibleUpdateId { get { throw null; } }
        public string DeviceClassId { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public string Model { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceDeploymentState : System.IEquatable<Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceDeploymentState(string value) { throw null; }
        public static Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState Canceled { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState Failed { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState Incompatible { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState InProgress { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState Succeeded { get { throw null; } }
        public bool Equals(Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState left, Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState right) { throw null; }
        public static implicit operator Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState (string value) { throw null; }
        public static bool operator !=(Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState left, Azure.Iot.DeviceUpdate.Models.DeviceDeploymentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceGroupType : System.IEquatable<Azure.Iot.DeviceUpdate.Models.DeviceGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceGroupType(string value) { throw null; }
        public static Azure.Iot.DeviceUpdate.Models.DeviceGroupType All { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeviceGroupType DeviceGroupDefinitions { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.DeviceGroupType Devices { get { throw null; } }
        public bool Equals(Azure.Iot.DeviceUpdate.Models.DeviceGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.DeviceUpdate.Models.DeviceGroupType left, Azure.Iot.DeviceUpdate.Models.DeviceGroupType right) { throw null; }
        public static implicit operator Azure.Iot.DeviceUpdate.Models.DeviceGroupType (string value) { throw null; }
        public static bool operator !=(Azure.Iot.DeviceUpdate.Models.DeviceGroupType left, Azure.Iot.DeviceUpdate.Models.DeviceGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceTag
    {
        internal DeviceTag() { }
        public int DeviceCount { get { throw null; } }
        public string TagName { get { throw null; } }
    }
    public partial class Error
    {
        internal Error() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.DeviceUpdate.Models.Error> Details { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? OccurredDateTime { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class File
    {
        internal File() { }
        public string Etag { get { throw null; } }
        public string FileId { get { throw null; } }
        public string FileName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Hashes { get { throw null; } }
        public string MimeType { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
    }
    public partial class FileImportMetadata
    {
        public FileImportMetadata(string filename, string url) { }
        public string Filename { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class Group
    {
        public Group(string groupId, Azure.Iot.DeviceUpdate.Models.GroupType groupType, System.Collections.Generic.IEnumerable<string> tags, string createdDateTime) { }
        public string CreatedDateTime { get { throw null; } set { } }
        public int? DeviceCount { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.Iot.DeviceUpdate.Models.GroupType GroupType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupType : System.IEquatable<Azure.Iot.DeviceUpdate.Models.GroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupType(string value) { throw null; }
        public static Azure.Iot.DeviceUpdate.Models.GroupType IoTHubTag { get { throw null; } }
        public bool Equals(Azure.Iot.DeviceUpdate.Models.GroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.DeviceUpdate.Models.GroupType left, Azure.Iot.DeviceUpdate.Models.GroupType right) { throw null; }
        public static implicit operator Azure.Iot.DeviceUpdate.Models.GroupType (string value) { throw null; }
        public static bool operator !=(Azure.Iot.DeviceUpdate.Models.GroupType left, Azure.Iot.DeviceUpdate.Models.GroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum HashType
    {
        Sha256 = 1,
    }
    public sealed partial class ImportManifest
    {
        public ImportManifest(Azure.Iot.DeviceUpdate.Models.UpdateId updateId, string updateType, string installedCriteria, System.Collections.Generic.List<Azure.Iot.DeviceUpdate.Models.ImportManifestCompatibilityInfo> compatibility, System.DateTime createdDateTime, System.Version manifestVersion, System.Collections.Generic.List<Azure.Iot.DeviceUpdate.Models.ImportManifestFile> files) { }
        public System.Collections.Generic.List<Azure.Iot.DeviceUpdate.Models.ImportManifestCompatibilityInfo> Compatibility { get { throw null; } }
        public System.DateTime CreatedDateTime { get { throw null; } }
        public System.Collections.Generic.List<Azure.Iot.DeviceUpdate.Models.ImportManifestFile> Files { get { throw null; } }
        public string InstalledCriteria { get { throw null; } }
        public System.Version ManifestVersion { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.UpdateId UpdateId { get { throw null; } }
        public string UpdateType { get { throw null; } }
    }
    public partial class ImportManifestCompatibilityInfo
    {
        public ImportManifestCompatibilityInfo(string deviceManufacturer, string deviceModel) { }
        public string DeviceManufacturer { get { throw null; } }
        public string DeviceModel { get { throw null; } }
    }
    public partial class ImportManifestFile
    {
        public ImportManifestFile(string fileName, long sizeInBytes, System.Collections.Generic.Dictionary<Azure.Iot.DeviceUpdate.Models.HashType, string> hashes) { }
        public string FileName { get { throw null; } set { } }
        public System.Collections.Generic.Dictionary<Azure.Iot.DeviceUpdate.Models.HashType, string> Hashes { get { throw null; } }
        public long SizeInBytes { get { throw null; } set { } }
    }
    public partial class ImportManifestMetadata
    {
        public ImportManifestMetadata(string url, long sizeInBytes, System.Collections.Generic.IDictionary<string, string> hashes) { }
        public System.Collections.Generic.IDictionary<string, string> Hashes { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class ImportUpdateInput
    {
        public ImportUpdateInput(Azure.Iot.DeviceUpdate.Models.ImportManifestMetadata importManifest, System.Collections.Generic.IEnumerable<Azure.Iot.DeviceUpdate.Models.FileImportMetadata> files) { }
        public System.Collections.Generic.IList<Azure.Iot.DeviceUpdate.Models.FileImportMetadata> Files { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.ImportManifestMetadata ImportManifest { get { throw null; } }
    }
    public partial class InnerError
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public string ErrorDetail { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.InnerError InnerErrorValue { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.Error Error { get { throw null; } }
        public string Etag { get { throw null; } }
        public System.DateTimeOffset LastActionDateTime { get { throw null; } }
        public string OperationId { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.OperationStatus Status { get { throw null; } }
        public string TraceId { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.UpdateId UpdateId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.Iot.DeviceUpdate.Models.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.Iot.DeviceUpdate.Models.OperationStatus Failed { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.OperationStatus NotStarted { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.OperationStatus Running { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.OperationStatus Succeeded { get { throw null; } }
        public static Azure.Iot.DeviceUpdate.Models.OperationStatus Undefined { get { throw null; } }
        public bool Equals(Azure.Iot.DeviceUpdate.Models.OperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Iot.DeviceUpdate.Models.OperationStatus left, Azure.Iot.DeviceUpdate.Models.OperationStatus right) { throw null; }
        public static implicit operator Azure.Iot.DeviceUpdate.Models.OperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Iot.DeviceUpdate.Models.OperationStatus left, Azure.Iot.DeviceUpdate.Models.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdatableDevices
    {
        internal UpdatableDevices() { }
        public int DeviceCount { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.UpdateId UpdateId { get { throw null; } }
    }
    public partial class Update
    {
        internal Update() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Iot.DeviceUpdate.Models.Compatibility> Compatibility { get { throw null; } }
        public System.DateTimeOffset CreatedDateTime { get { throw null; } }
        public string Etag { get { throw null; } }
        public System.DateTimeOffset ImportedDateTime { get { throw null; } }
        public string InstalledCriteria { get { throw null; } }
        public string ManifestVersion { get { throw null; } }
        public Azure.Iot.DeviceUpdate.Models.UpdateId UpdateId { get { throw null; } }
        public string UpdateType { get { throw null; } }
    }
    public partial class UpdateCompliance
    {
        internal UpdateCompliance() { }
        public int NewUpdatesAvailableDeviceCount { get { throw null; } }
        public int OnLatestUpdateDeviceCount { get { throw null; } }
        public int TotalDeviceCount { get { throw null; } }
        public int UpdatesInProgressDeviceCount { get { throw null; } }
    }
    public partial class UpdateId
    {
        public UpdateId(string provider, string name, string version) { }
        public string Name { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
}
