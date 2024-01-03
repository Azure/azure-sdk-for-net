namespace Azure.ResourceManager.LargeInstance
{
    public partial class AzureLargeInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>, System.Collections.IEnumerable
    {
        protected AzureLargeInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> Get(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> GetAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetIfExists(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> GetIfExistsAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureLargeInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        internal AzureLargeInstanceData() { }
        public string AzureLargeInstanceId { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.HardwareProfile HardwareProfile { get { throw null; } }
        public string HwRevision { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.NetworkProfile NetworkProfile { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.OSProfile OSProfile { get { throw null; } }
        public string PartnerNodeId { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum? PowerState { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum? ProvisioningState { get { throw null; } }
        public string ProximityPlacementGroup { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.StorageProfile StorageProfile { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AzureLargeInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureLargeInstanceResource() { }
        public virtual Azure.ResourceManager.LargeInstance.AzureLargeInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureLargeInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult> Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.LargeInstance.Models.ForceState forceParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult>> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.LargeInstance.Models.ForceState forceParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult> Shutdown(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult>> ShutdownAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> Update(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> UpdateAsync(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureLargeStorageInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>, System.Collections.IEnumerable
    {
        protected AzureLargeStorageInstanceCollection() { }
        public virtual Azure.Response<bool> Exists(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> Get(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> GetAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetIfExists(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> GetIfExistsAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureLargeStorageInstanceData : Azure.ResourceManager.Models.ResourceData
    {
        internal AzureLargeStorageInstanceData() { }
        public string AzureLargeStorageInstanceUniqueIdentifier { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.StorageProperties StorageProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AzureLargeStorageInstanceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureLargeStorageInstanceResource() { }
        public virtual Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureLargeStorageInstanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> Update(Azure.ResourceManager.LargeInstance.Models.AzureLargeStorageInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> UpdateAsync(Azure.ResourceManager.LargeInstance.Models.AzureLargeStorageInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class LargeInstanceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAzureLargeInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> GetAzureLargeInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource GetAzureLargeInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LargeInstance.AzureLargeInstanceCollection GetAzureLargeInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAzureLargeInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAzureLargeInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAzureLargeStorageInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> GetAzureLargeStorageInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource GetAzureLargeStorageInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceCollection GetAzureLargeStorageInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAzureLargeStorageInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAzureLargeStorageInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LargeInstance.Mocking
{
    public partial class MockableLargeInstanceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLargeInstanceArmClient() { }
        public virtual Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource GetAzureLargeInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource GetAzureLargeStorageInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableLargeInstanceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLargeInstanceResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAzureLargeInstance(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource>> GetAzureLargeInstanceAsync(string azureLargeInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LargeInstance.AzureLargeInstanceCollection GetAzureLargeInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAzureLargeStorageInstance(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource>> GetAzureLargeStorageInstanceAsync(string azureLargeStorageInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceCollection GetAzureLargeStorageInstances() { throw null; }
    }
    public partial class MockableLargeInstanceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLargeInstanceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAzureLargeInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.AzureLargeInstanceResource> GetAzureLargeInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAzureLargeStorageInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceResource> GetAzureLargeStorageInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LargeInstance.Models
{
    public static partial class ArmLargeInstanceModelFactory
    {
        public static Azure.ResourceManager.LargeInstance.AzureLargeInstanceData AzureLargeInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.LargeInstance.Models.HardwareProfile hardwareProfile = null, Azure.ResourceManager.LargeInstance.Models.StorageProfile storageProfile = null, Azure.ResourceManager.LargeInstance.Models.OSProfile osProfile = null, Azure.ResourceManager.LargeInstance.Models.NetworkProfile networkProfile = null, string azureLargeInstanceId = null, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum? powerState = default(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum?), string proximityPlacementGroup = null, string hwRevision = null, string partnerNodeId = null, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum? provisioningState = default(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.AzureLargeStorageInstanceData AzureLargeStorageInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string azureLargeStorageInstanceUniqueIdentifier = null, Azure.ResourceManager.LargeInstance.Models.StorageProperties storageProperties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.Disk Disk(string name = null, int? diskSizeGB = default(int?), int? lun = default(int?)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.HardwareProfile HardwareProfile(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum? hardwareType = default(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum?), Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum? azureLargeInstanceSize = default(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum?)) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.IPAddress IPAddress(string ipAddressValue = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.NetworkProfile NetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.Models.IPAddress> networkInterfaces = null, string circuitId = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.OperationStatusResult OperationStatusResult(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier resourceId = null, string name = null, string status = null, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult> operations = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.OSProfile OSProfile(string computerName = null, string osType = null, string version = null, string sshPublicKey = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.StorageBillingProperties StorageBillingProperties(string billingMode = null, string sku = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.StorageProfile StorageProfile(string nfsIPAddress = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LargeInstance.Models.Disk> osDisks = null) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.StorageProperties StorageProperties(Azure.ResourceManager.LargeInstance.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.LargeInstance.Models.ProvisioningState?), string offeringType = null, string storageType = null, string generation = null, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum? hardwareType = default(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum?), string workloadType = null, Azure.ResourceManager.LargeInstance.Models.StorageBillingProperties storageBillingProperties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureLargeInstanceForcePowerState : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureLargeInstanceForcePowerState(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState Active { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureLargeInstanceHardwareTypeNamesEnum : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureLargeInstanceHardwareTypeNamesEnum(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum CiscoUCS { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum HPE { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum Sdflex { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureLargeInstancePatch
    {
        public AzureLargeInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureLargeInstancePowerStateEnum : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureLargeInstancePowerStateEnum(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum Restarting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum Started { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum Starting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum Stopped { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum Stopping { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstancePowerStateEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureLargeInstanceProvisioningStatesEnum : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureLargeInstanceProvisioningStatesEnum(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Accepted { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Canceled { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Creating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Deleting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Failed { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Migrating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Succeeded { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceProvisioningStatesEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureLargeInstanceSizeNamesEnum : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureLargeInstanceSizeNamesEnum(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S112 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S144 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S144M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S192 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S192M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S192Xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S224 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S224M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S224Om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S224Oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S224Oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S224Ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S224Se { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S384 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S384M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S384Xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S384Xxm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S448 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S448M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S448Om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S448Oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S448Oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S448Ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S448Se { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S576M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S576Xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S672 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S672M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S672Om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S672Oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S672Oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S672Ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S72 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S72M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S768 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S768M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S768Xm { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S896 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S896M { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S896Om { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S896Oo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S896Oom { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S896Ooo { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S96 { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum S960M { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum left, Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureLargeStorageInstancePatch
    {
        public AzureLargeStorageInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class Disk
    {
        internal Disk() { }
        public int? DiskSizeGB { get { throw null; } }
        public int? Lun { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ForceState
    {
        public ForceState() { }
        public Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceForcePowerState? ForceStateValue { get { throw null; } set { } }
    }
    public partial class HardwareProfile
    {
        internal HardwareProfile() { }
        public Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceSizeNamesEnum? AzureLargeInstanceSize { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum? HardwareType { get { throw null; } }
    }
    public partial class IPAddress
    {
        internal IPAddress() { }
        public string IPAddressValue { get { throw null; } }
    }
    public partial class NetworkProfile
    {
        internal NetworkProfile() { }
        public string CircuitId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LargeInstance.Models.IPAddress> NetworkInterfaces { get { throw null; } }
    }
    public partial class OperationStatusResult
    {
        internal OperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LargeInstance.Models.OperationStatusResult> Operations { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class OSProfile
    {
        internal OSProfile() { }
        public string ComputerName { get { throw null; } }
        public string OSType { get { throw null; } }
        public string SshPublicKey { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.LargeInstance.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Migrating { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.LargeInstance.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LargeInstance.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LargeInstance.Models.ProvisioningState left, Azure.ResourceManager.LargeInstance.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LargeInstance.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LargeInstance.Models.ProvisioningState left, Azure.ResourceManager.LargeInstance.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageBillingProperties
    {
        internal StorageBillingProperties() { }
        public string BillingMode { get { throw null; } }
        public string Sku { get { throw null; } }
    }
    public partial class StorageProfile
    {
        internal StorageProfile() { }
        public string NfsIPAddress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.LargeInstance.Models.Disk> OSDisks { get { throw null; } }
    }
    public partial class StorageProperties
    {
        internal StorageProperties() { }
        public string Generation { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.AzureLargeInstanceHardwareTypeNamesEnum? HardwareType { get { throw null; } }
        public string OfferingType { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LargeInstance.Models.StorageBillingProperties StorageBillingProperties { get { throw null; } }
        public string StorageType { get { throw null; } }
        public string WorkloadType { get { throw null; } }
    }
}
