namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudAgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudAgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetIfExists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetIfExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudAgentPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudAgentPoolData(Azure.Core.AzureLocation location, long count, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode, string vmSkuName) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration AdministratorConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration AgentOptions { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration AttachedNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public long Count { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Labels { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode Mode { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Taints { get { throw null; } }
        public string UpgradeMaxSurge { get { throw null; } set { } }
        public string VmSkuName { get { throw null; } set { } }
    }
    public partial class NetworkCloudAgentPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudAgentPoolResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string kubernetesClusterName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudBareMetalMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> Get(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> GetAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetIfExists(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> GetIfExistsAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudBareMetalMachineData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string bmcConnectionString, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, string machineDetails, string machineName, string machineSkuId, Azure.Core.ResourceIdentifier rackId, long rackSlot, string serialNumber) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public string BmcConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials BmcCredentials { get { throw null; } set { } }
        public string BmcMacAddress { get { throw null; } set { } }
        public string BootMacAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? CordonStatus { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.HardwareInventory HardwareInventory { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus HardwareValidationStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HybridAksClustersAssociatedIds { get { throw null; } }
        public string KubernetesNodeName { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public string MachineDetails { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public string MachineSkuId { get { throw null; } set { } }
        public System.Net.IPAddress OamIPv4Address { get { throw null; } }
        public string OamIPv6Address { get { throw null; } }
        public string OSImage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier RackId { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? ReadyState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string ServiceTag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualMachinesAssociatedIds { get { throw null; } }
    }
    public partial class NetworkCloudBareMetalMachineKeySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudBareMetalMachineKeySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> Get(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> GetAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetIfExists(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> GetIfExistsAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineKeySetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudBareMetalMachineKeySetData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, System.DateTimeOffset expireOn, System.Collections.Generic.IEnumerable<System.Net.IPAddress> jumpHostsAllowed, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList) { }
        public string AzureGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> JumpHostsAllowed { get { throw null; } }
        public System.DateTimeOffset? LastValidatedOn { get { throw null; } }
        public string OSGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel PrivilegeLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> UserListStatus { get { throw null; } }
    }
    public partial class NetworkCloudBareMetalMachineKeySetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudBareMetalMachineKeySetResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string bareMetalMachineKeySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudBareMetalMachineResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Cordon(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> CordonAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string bareMetalMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> PowerOff(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> PowerOffAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Reimage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> ReimageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Replace(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> ReplaceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RunDataExtracts(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunDataExtractsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RunReadCommands(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunReadCommandsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Uncordon(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> UncordonAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudBmcKeySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudBmcKeySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> Get(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> GetAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetIfExists(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> GetIfExistsAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudBmcKeySetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudBmcKeySetData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, System.DateTimeOffset expireOn, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList) { }
        public string AzureGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.DateTimeOffset? LastValidatedOn { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel PrivilegeLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> UserListStatus { get { throw null; } }
    }
    public partial class NetworkCloudBmcKeySetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudBmcKeySetResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string bmcKeySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudCloudServicesNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudCloudServicesNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> Get(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetIfExists(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetIfExistsAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudCloudServicesNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudCloudServicesNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> AdditionalEgressEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? EnableDefaultEgressEndpoints { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> EnabledEgressEndpoints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> HybridAksClustersAssociatedIds { get { throw null; } }
        public string InterfaceName { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VirtualMachinesAssociatedIds { get { throw null; } }
    }
    public partial class NetworkCloudCloudServicesNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudCloudServicesNetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServicesNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType, string clusterVersion, Azure.Core.ResourceIdentifier networkFabricId) { }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition AggregatorOrSingleRackDefinition { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AnalyticsWorkspaceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> AvailableUpgradeVersions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity ClusterCapacity { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? ClusterConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ClusterExtendedLocation { get { throw null; } }
        public string ClusterLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? ClusterManagerConnectionStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterManagerId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation ClusterServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterType ClusterType { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold ComputeDeploymentThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> ComputeRackDefinitions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation HybridAksExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public long? ManualActionCount { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? SupportExpireOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> WorkloadResourceIds { get { throw null; } }
    }
    public partial class NetworkCloudClusterManagerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudClusterManagerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> Get(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetIfExists(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetIfExistsAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudClusterManagerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudClusterManagerData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier fabricControllerId) { }
        public Azure.Core.ResourceIdentifier AnalyticsWorkspaceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> ClusterVersions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricControllerId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ManagerExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? ProvisioningState { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class NetworkCloudClusterManagerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudClusterManagerResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterManagerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudClusterMetricsConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudClusterMetricsConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> Get(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> GetAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetIfExists(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> GetIfExistsAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudClusterMetricsConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudClusterMetricsConfigurationData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, long collectionInterval) { }
        public long CollectionInterval { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DisabledMetrics { get { throw null; } }
        public System.Collections.Generic.IList<string> EnabledMetrics { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NetworkCloudClusterMetricsConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudClusterMetricsConfigurationResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string metricsConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudClusterResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Deploy(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeployAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetNetworkCloudBareMetalMachineKeySet(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> GetNetworkCloudBareMetalMachineKeySetAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetCollection GetNetworkCloudBareMetalMachineKeySets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetNetworkCloudBmcKeySet(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> GetNetworkCloudBmcKeySetAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetCollection GetNetworkCloudBmcKeySets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetNetworkCloudClusterMetricsConfiguration(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> GetNetworkCloudClusterMetricsConfigurationAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationCollection GetNetworkCloudClusterMetricsConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> UpdateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> UpdateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetworkCloudExtensions
    {
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource GetNetworkCloudAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> GetNetworkCloudBareMetalMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource GetNetworkCloudBareMetalMachineKeySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource GetNetworkCloudBareMetalMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineCollection GetNetworkCloudBareMetalMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource GetNetworkCloudBmcKeySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetNetworkCloudCloudServicesNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource GetNetworkCloudCloudServicesNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkCollection GetNetworkCloudCloudServicesNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetNetworkCloudClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManager(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetNetworkCloudClusterManagerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource GetNetworkCloudClusterManagerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerCollection GetNetworkCloudClusterManagers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource GetNetworkCloudClusterMetricsConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource GetNetworkCloudClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterCollection GetNetworkCloudClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetNetworkCloudKubernetesClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource GetNetworkCloudKubernetesClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterCollection GetNetworkCloudKubernetesClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Network(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetNetworkCloudL2NetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource GetNetworkCloudL2NetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkCollection GetNetworkCloudL2Networks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Network(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetNetworkCloudL3NetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource GetNetworkCloudL3NetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkCollection GetNetworkCloudL3Networks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetNetworkCloudRackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource GetNetworkCloudRackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackCollection GetNetworkCloudRacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> GetNetworkCloudRackSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetNetworkCloudRackSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource GetNetworkCloudRackSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuCollection GetNetworkCloudRackSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetNetworkCloudStorageApplianceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource GetNetworkCloudStorageApplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceCollection GetNetworkCloudStorageAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetNetworkCloudTrunkedNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource GetNetworkCloudTrunkedNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkCollection GetNetworkCloudTrunkedNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> GetNetworkCloudVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource GetNetworkCloudVirtualMachineConsoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource GetNetworkCloudVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineCollection GetNetworkCloudVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolume(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetNetworkCloudVolumeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource GetNetworkCloudVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeCollection GetNetworkCloudVolumes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudKubernetesClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kubernetesClusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kubernetesClusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> Get(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetAsync(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetIfExists(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetIfExistsAsync(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudKubernetesClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration networkConfiguration) { }
        public System.Collections.Generic.IList<string> AadAdminGroupObjectIds { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration AdministratorConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AttachedNetworkIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade> AvailableUpgrades { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ConnectedClusterId { get { throw null; } }
        public string ControlPlaneKubernetesVersion { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration ControlPlaneNodeConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus> FeatureStatuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration> InitialAgentPoolConfigurations { get { throw null; } }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode> Nodes { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class NetworkCloudKubernetesClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudKubernetesClusterResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string kubernetesClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetNetworkCloudAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetNetworkCloudAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolCollection GetNetworkCloudAgentPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RestartNode(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RestartNodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudL2NetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudL2NetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> Get(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetIfExists(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetIfExistsAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudL2NetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudL2NetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.Core.ResourceIdentifier l2IsolationDomainId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier L2IsolationDomainId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VirtualMachinesAssociatedIds { get { throw null; } }
    }
    public partial class NetworkCloudL2NetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudL2NetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l2NetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudL3NetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudL3NetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> Get(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetIfExists(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetIfExistsAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudL3NetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudL3NetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.Core.ResourceIdentifier l3IsolationDomainId, long vlan) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled? HybridAksIpamEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? IPAllocationType { get { throw null; } set { } }
        public string IPv4ConnectedPrefix { get { throw null; } set { } }
        public string IPv6ConnectedPrefix { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier L3IsolationDomainId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VirtualMachinesAssociatedIds { get { throw null; } }
        public long Vlan { get { throw null; } set { } }
    }
    public partial class NetworkCloudL3NetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudL3NetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3NetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudRackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudRackCollection() { }
        public virtual Azure.Response<bool> Exists(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> Get(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetIfExists(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetIfExistsAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudRackData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudRackData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string availabilityZone, string rackLocation, string rackSerialNumber, Azure.Core.ResourceIdentifier rackSkuId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? ProvisioningState { get { throw null; } }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RackSkuId { get { throw null; } set { } }
    }
    public partial class NetworkCloudRackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudRackResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rackName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudRackSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudRackSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> Get(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetAsync(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> GetIfExists(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetIfExistsAsync(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudRackSkuData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkCloudRackSkuData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> ComputeMachines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> ControllerMachines { get { throw null; } }
        public string Description { get { throw null; } }
        public long? MaxClusterSlots { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RackSkuType? RackType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot> StorageAppliances { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedRackSkuIds { get { throw null; } }
    }
    public partial class NetworkCloudRackSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudRackSkuResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string rackSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudStorageApplianceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudStorageApplianceCollection() { }
        public virtual Azure.Response<bool> Exists(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> Get(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetIfExists(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetIfExistsAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudStorageApplianceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudStorageApplianceData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials, Azure.Core.ResourceIdentifier rackId, long rackSlot, string serialNumber, string storageApplianceSkuId) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials AdministratorCredentials { get { throw null; } set { } }
        public long? Capacity { get { throw null; } }
        public long? CapacityUsed { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Net.IPAddress ManagementIPv4Address { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier RackId { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? RemoteVendorManagementFeature { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? RemoteVendorManagementStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string StorageApplianceSkuId { get { throw null; } set { } }
    }
    public partial class NetworkCloudStorageApplianceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudStorageApplianceResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageApplianceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DisableRemoteVendorManagement(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DisableRemoteVendorManagementAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> EnableRemoteVendorManagement(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> EnableRemoteVendorManagementAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudTrunkedNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudTrunkedNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> Get(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetIfExists(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetIfExistsAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudTrunkedNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudTrunkedNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> isolationDomainIds, System.Collections.Generic.IEnumerable<long> vlans) { }
        public System.Collections.Generic.IReadOnlyList<string> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> IsolationDomainIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VirtualMachinesAssociatedIds { get { throw null; } }
        public System.Collections.Generic.IList<long> Vlans { get { throw null; } }
    }
    public partial class NetworkCloudTrunkedNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudTrunkedNetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trunkedNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudVirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetIfExists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> GetIfExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudVirtualMachineConsoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudVirtualMachineConsoleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> Get(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> GetAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetIfExists(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> GetIfExistsAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudVirtualMachineConsoleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudVirtualMachineConsoleData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey sshPublicKey) { }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkServiceId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? VirtualMachineAccessId { get { throw null; } }
    }
    public partial class NetworkCloudVirtualMachineConsoleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudVirtualMachineConsoleResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string consoleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudVirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudVirtualMachineData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string adminUsername, Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment, long cpuCores, long memorySizeInGB, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile storageProfile, string vmImage) { }
        public string AdminUsername { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } }
        public Azure.Core.ResourceIdentifier BareMetalMachineId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? BootMethod { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment CloudServicesNetworkAttachment { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public long CpuCores { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? IsolateEmulatorThread { get { throw null; } set { } }
        public long MemorySizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> NetworkAttachments { get { throw null; } }
        public string NetworkData { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> PlacementHints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> SshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? VirtioInterface { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? VmDeviceModel { get { throw null; } set { } }
        public string VmImage { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> Volumes { get { throw null; } }
    }
    public partial class NetworkCloudVirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudVirtualMachineResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetNetworkCloudVirtualMachineConsole(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> GetNetworkCloudVirtualMachineConsoleAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleCollection GetNetworkCloudVirtualMachineConsoles() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> PowerOff(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> PowerOffAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Reimage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> ReimageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkCloudVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudVolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetIfExists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetIfExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudVolumeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NetworkCloudVolumeData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, long sizeInMiB) { }
        public System.Collections.Generic.IReadOnlyList<string> AttachedTo { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public long SizeInMiB { get { throw null; } set { } }
    }
    public partial class NetworkCloudVolumeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudVolumeResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkCloud.Mocking
{
    public partial class MockableNetworkCloudArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkCloudArmClient() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource GetNetworkCloudAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource GetNetworkCloudBareMetalMachineKeySetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource GetNetworkCloudBareMetalMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource GetNetworkCloudBmcKeySetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource GetNetworkCloudCloudServicesNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource GetNetworkCloudClusterManagerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource GetNetworkCloudClusterMetricsConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource GetNetworkCloudClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource GetNetworkCloudKubernetesClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource GetNetworkCloudL2NetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource GetNetworkCloudL3NetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource GetNetworkCloudRackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource GetNetworkCloudRackSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource GetNetworkCloudStorageApplianceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource GetNetworkCloudTrunkedNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource GetNetworkCloudVirtualMachineConsoleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource GetNetworkCloudVirtualMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource GetNetworkCloudVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNetworkCloudResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkCloudResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachine(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> GetNetworkCloudBareMetalMachineAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineCollection GetNetworkCloudBareMetalMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetwork(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetNetworkCloudCloudServicesNetworkAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkCollection GetNetworkCloudCloudServicesNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetNetworkCloudClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManager(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetNetworkCloudClusterManagerAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerCollection GetNetworkCloudClusterManagers() { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterCollection GetNetworkCloudClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesCluster(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetNetworkCloudKubernetesClusterAsync(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterCollection GetNetworkCloudKubernetesClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Network(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetNetworkCloudL2NetworkAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkCollection GetNetworkCloudL2Networks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Network(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetNetworkCloudL3NetworkAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkCollection GetNetworkCloudL3Networks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRack(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetNetworkCloudRackAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackCollection GetNetworkCloudRacks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliance(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetNetworkCloudStorageApplianceAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceCollection GetNetworkCloudStorageAppliances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetwork(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetNetworkCloudTrunkedNetworkAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkCollection GetNetworkCloudTrunkedNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachine(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> GetNetworkCloudVirtualMachineAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineCollection GetNetworkCloudVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetNetworkCloudVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeCollection GetNetworkCloudVolumes() { throw null; }
    }
    public partial class MockableNetworkCloudSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkCloudSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Networks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2NetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Networks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3NetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> GetNetworkCloudRackSku(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetNetworkCloudRackSkuAsync(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuCollection GetNetworkCloudRackSkus() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachines(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachinesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class AdministrativeCredentials
    {
        public AdministrativeCredentials(string username) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class AdministratorConfiguration
    {
        public AdministratorConfiguration() { }
        public string AdminUsername { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> SshPublicKeys { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvertiseToFabric : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvertiseToFabric(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric left, Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric left, Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPoolDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPoolDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPoolProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPoolProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmNetworkCloudModelFactory
    {
        public static Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade AvailableUpgrade(Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle? availabilityLifecycle = default(Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle?), string version = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration BareMetalMachineConfiguration(string bmcConnectionString = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, string machineDetails = null, string machineName = null, long rackSlot = (long)0, string serialNumber = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion ClusterAvailableUpgradeVersion(Azure.ResourceManager.NetworkCloud.Models.ControlImpact? controlImpact = default(Azure.ResourceManager.NetworkCloud.Models.ControlImpact?), string expectedDuration = null, string impactDescription = null, System.DateTimeOffset? supportExpireOn = default(System.DateTimeOffset?), string targetClusterVersion = null, Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact? workloadImpact = default(Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion ClusterAvailableVersion(string supportExpiryDate = null, string targetClusterVersion = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity ClusterCapacity(long? availableApplianceStorageGB = default(long?), long? availableCoreCount = default(long?), long? availableHostStorageGB = default(long?), long? availableMemoryGB = default(long?), long? totalApplianceStorageGB = default(long?), long? totalCoreCount = default(long?), long? totalHostStorageGB = default(long?), long? totalMemoryGB = default(long?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.FeatureStatus FeatureStatus(Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus?), string detailedStatusMessage = null, string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareInventory HardwareInventory(string additionalHostInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface> interfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic> nics = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface HardwareInventoryNetworkInterface(string linkStatus = null, string macAddress = null, string name = null, string networkInterfaceId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus HardwareValidationStatus(System.DateTimeOffset? lastValidationOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult? result = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus KeySetUserStatus(string azureUserName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus? status = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus?), string statusMessage = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode KubernetesClusterNode(string agentPoolId = null, string availabilityZone = null, string bareMetalMachineId = null, long? cpuCores = default(long?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus?), string detailedStatusMessage = null, long? diskSizeGB = default(long?), string image = null, string kubernetesVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels = null, long? memorySizeGB = default(long?), Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode? mode = default(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode?), string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState?), Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole? role = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints = null, string vmSkuName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor LldpNeighbor(string portDescription = null, string portName = null, string systemDescription = null, string systemName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineDisk MachineDisk(long? capacityGB = default(long?), Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType? connection = default(Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType?), Azure.ResourceManager.NetworkCloud.Models.DiskType? diskType = default(Azure.ResourceManager.NetworkCloud.Models.DiskType?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot MachineSkuSlot(long? rackSlot = default(long?), Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol? bootstrapProtocol = default(Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol?), long? cpuCores = default(long?), long? cpuSockets = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineDisk> disks = null, string generation = null, string hardwareVersion = null, long? memoryCapacityGB = default(long?), string model = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface> networkInterfaces = null, long? totalThreads = default(long?), string vendor = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment NetworkAttachment(string attachedNetworkId = null, Azure.ResourceManager.NetworkCloud.Models.DefaultGateway? defaultGateway = default(Azure.ResourceManager.NetworkCloud.Models.DefaultGateway?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod ipAllocationMethod = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod), string ipv4Address = null, string ipv6Address = null, string macAddress = null, string networkAttachmentName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData NetworkCloudAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration agentOptions = null, Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration attachedNetworkConfiguration = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, long count = (long)0, Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus?), string detailedStatusMessage = null, string kubernetesVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode = default(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode), Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints = null, string upgradeMaxSurge = null, string vmSkuName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData NetworkCloudBareMetalMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, string bmcConnectionString = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? cordonStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.HardwareInventory hardwareInventory = null, Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus hardwareValidationStatus = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, string kubernetesNodeName = null, string kubernetesVersion = null, string machineDetails = null, string machineName = null, string machineSkuId = null, System.Net.IPAddress oamIPv4Address = null, string oamIPv6Address = null, string osImage = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState?), Azure.Core.ResourceIdentifier rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? readyState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState?), string serialNumber = null, string serviceTag = null, System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<System.Net.IPAddress> jumpHostsAllowed = null, System.DateTimeOffset? lastValidatedOn = default(System.DateTimeOffset?), string osGroupName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData NetworkCloudBmcKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset), System.DateTimeOffset? lastValidatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> additionalEgressEndpoints = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> enabledEgressEndpoints = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData NetworkCloudClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition = null, Azure.Core.ResourceIdentifier analyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> availableUpgradeVersions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity clusterCapacity = null, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? clusterConnectionStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation clusterExtendedLocation = null, string clusterLocation = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? clusterManagerConnectionStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus?), Azure.Core.ResourceIdentifier clusterManagerId = null, Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation clusterServicePrincipal = null, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType = default(Azure.ResourceManager.NetworkCloud.Models.ClusterType), string clusterVersion = null, Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold computeDeploymentThreshold = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> computeRackDefinitions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation hybridAksExtendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, long? manualActionCount = default(long?), Azure.Core.ResourceIdentifier networkFabricId = null, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState?), System.DateTimeOffset? supportExpireOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workloadResourceIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData NetworkCloudClusterManagerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier analyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> clusterVersions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus?), string detailedStatusMessage = null, Azure.Core.ResourceIdentifier fabricControllerId = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation managerExtendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState?), string vmSize = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData NetworkCloudClusterMetricsConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, long collectionInterval = (long)0, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<string> disabledMetrics = null, System.Collections.Generic.IEnumerable<string> enabledMetrics = null, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData NetworkCloudKubernetesClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> aadAdminGroupObjectIds = null, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> attachedNetworkIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade> availableUpgrades = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.Core.ResourceIdentifier connectedClusterId = null, string controlPlaneKubernetesVersion = null, Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration controlPlaneNodeConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus> featureStatuses = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration> initialAgentPoolConfigurations = null, string kubernetesVersion = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration networkConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode> nodes = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData NetworkCloudL2NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, Azure.Core.ResourceIdentifier l2IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData NetworkCloudL3NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled? hybridAksIpamEnabled = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled?), Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? ipAllocationType = default(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType?), string ipv4ConnectedPrefix = null, string ipv6ConnectedPrefix = null, Azure.Core.ResourceIdentifier l3IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null, long vlan = (long)0) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface NetworkCloudNetworkInterface(string address = null, Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType? deviceConnectionType = default(Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType?), string model = null, long? physicalSlot = default(long?), long? portCount = default(long?), long? portSpeed = default(long?), string vendor = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic NetworkCloudNic(Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor lldpNeighbor = null, string macAddress = null, string name = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult NetworkCloudOperationStatusResult(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier resourceId = null, string name = null, string status = null, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> operations = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackData NetworkCloudRackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string availabilityZone = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState?), string rackLocation = null, string rackSerialNumber = null, Azure.Core.ResourceIdentifier rackSkuId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData NetworkCloudRackSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> computeMachines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> controllerMachines = null, string description = null, long? maxClusterSlots = default(long?), Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState?), Azure.ResourceManager.NetworkCloud.Models.RackSkuType? rackType = default(Azure.ResourceManager.NetworkCloud.Models.RackSkuType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot> storageAppliances = null, System.Collections.Generic.IEnumerable<string> supportedRackSkuIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData NetworkCloudStorageApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials = null, long? capacity = default(long?), long? capacityUsed = default(long?), Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus?), string detailedStatusMessage = null, System.Net.IPAddress managementIPv4Address = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState?), Azure.Core.ResourceIdentifier rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? remoteVendorManagementFeature = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature?), Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? remoteVendorManagementStatus = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus?), string serialNumber = null, string storageApplianceSkuId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData NetworkCloudTrunkedNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> isolationDomainIds = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null, System.Collections.Generic.IEnumerable<long> vlans = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData NetworkCloudVirtualMachineConsoleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier privateLinkServiceId = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState?), string keyData = null, System.Guid? virtualMachineAccessId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string adminUsername = null, string availabilityZone = null, Azure.Core.ResourceIdentifier bareMetalMachineId = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? bootMethod = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod?), Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment = null, Azure.Core.ResourceIdentifier clusterId = null, long cpuCores = (long)0, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? isolateEmulatorThread = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread?), long memorySizeInGB = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments = null, string networkData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> placementHints = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> sshPublicKeys = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile storageProfile = null, string userData = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? virtioInterface = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? vmDeviceModel = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType?), string vmImage = null, Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials vmImageRepositoryCredentials = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> volumes = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData NetworkCloudVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> attachedTo = null, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState?), string serialNumber = null, long sizeInMiB = (long)0) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot StorageApplianceSkuSlot(long? rackSlot = default(long?), long? capacityGB = default(long?), string model = null) { throw null; }
    }
    public partial class AttachedNetworkConfiguration
    {
        public AttachedNetworkConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration> L2Networks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration> L3Networks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration> TrunkedNetworks { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityLifecycle : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityLifecycle(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle GenerallyAvailable { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle Preview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle left, Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle left, Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableUpgrade
    {
        internal AvailableUpgrade() { }
        public Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle? AvailabilityLifecycle { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class BareMetalMachineCommandSpecification
    {
        public BareMetalMachineCommandSpecification(string command) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
    }
    public partial class BareMetalMachineConfiguration
    {
        public BareMetalMachineConfiguration(Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, long rackSlot, string serialNumber) { }
        public string BmcConnectionString { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials BmcCredentials { get { throw null; } set { } }
        public string BmcMacAddress { get { throw null; } set { } }
        public string BootMacAddress { get { throw null; } set { } }
        public string MachineDetails { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
    }
    public partial class BareMetalMachineCordonContent
    {
        public BareMetalMachineCordonContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate? Evacuate { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineCordonStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineCordonStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus Cordoned { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus Uncordoned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus Deprovisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus Preparing { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus Provisioned { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineEvacuate : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineEvacuate(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineHardwareValidationResult : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineHardwareValidationResult(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult Fail { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult Pass { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineKeySetDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineKeySetDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus AllActive { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus AllInvalid { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus SomeInvalid { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineKeySetPrivilegeLevel : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineKeySetPrivilegeLevel(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel Standard { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel Superuser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineKeySetProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineKeySetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineKeySetUserSetupStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineKeySetUserSetupStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BareMetalMachinePowerOffContent
    {
        public BareMetalMachinePowerOffContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown? SkipShutdown { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachinePowerState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachinePowerState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState Off { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineReadyState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineReadyState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BareMetalMachineReplaceContent
    {
        public BareMetalMachineReplaceContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials BmcCredentials { get { throw null; } set { } }
        public string BmcMacAddress { get { throw null; } set { } }
        public string BootMacAddress { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
    }
    public partial class BareMetalMachineRunCommandContent
    {
        public BareMetalMachineRunCommandContent(long limitTimeSeconds, string script) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
        public string Script { get { throw null; } }
    }
    public partial class BareMetalMachineRunDataExtractsContent
    {
        public BareMetalMachineRunDataExtractsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> commands, long limitTimeSeconds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> Commands { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
    }
    public partial class BareMetalMachineRunReadCommandsContent
    {
        public BareMetalMachineRunReadCommandsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> commands, long limitTimeSeconds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> Commands { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineSkipShutdown : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineSkipShutdown(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BfdEnabled : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BfdEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BfdEnabled(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BfdEnabled False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BfdEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BfdEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BfdEnabled left, Azure.ResourceManager.NetworkCloud.Models.BfdEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BfdEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BfdEnabled left, Azure.ResourceManager.NetworkCloud.Models.BfdEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BgpAdvertisement
    {
        public BgpAdvertisement(System.Collections.Generic.IEnumerable<string> ipAddressPools) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric? AdvertiseToFabric { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Communities { get { throw null; } }
        public System.Collections.Generic.IList<string> IPAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<string> Peers { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BgpMultiHop : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BgpMultiHop(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop left, Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop left, Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BgpServiceLoadBalancerConfiguration
    {
        public BgpServiceLoadBalancerConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement> BgpAdvertisements { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer> BgpPeers { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled? FabricPeeringEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool> IPAddressPools { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BmcKeySetDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BmcKeySetDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus AllActive { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus AllInvalid { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus SomeInvalid { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BmcKeySetPrivilegeLevel : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BmcKeySetPrivilegeLevel(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel Administrator { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel ReadOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel left, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel left, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BmcKeySetProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BmcKeySetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BootstrapProtocol : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BootstrapProtocol(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol Pxe { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol left, Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol left, Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudServicesNetworkDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudServicesNetworkDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudServicesNetworkEnableDefaultEgressEndpoint : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudServicesNetworkEnableDefaultEgressEndpoint(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudServicesNetworkProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudServicesNetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterAvailableUpgradeVersion
    {
        internal ClusterAvailableUpgradeVersion() { }
        public Azure.ResourceManager.NetworkCloud.Models.ControlImpact? ControlImpact { get { throw null; } }
        public string ExpectedDuration { get { throw null; } }
        public string ImpactDescription { get { throw null; } }
        public System.DateTimeOffset? SupportExpireOn { get { throw null; } }
        public string TargetClusterVersion { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact? WorkloadImpact { get { throw null; } }
    }
    public partial class ClusterAvailableVersion
    {
        internal ClusterAvailableVersion() { }
        public string SupportExpiryDate { get { throw null; } }
        public string TargetClusterVersion { get { throw null; } }
    }
    public partial class ClusterCapacity
    {
        internal ClusterCapacity() { }
        public long? AvailableApplianceStorageGB { get { throw null; } }
        public long? AvailableCoreCount { get { throw null; } }
        public long? AvailableHostStorageGB { get { throw null; } }
        public long? AvailableMemoryGB { get { throw null; } }
        public long? TotalApplianceStorageGB { get { throw null; } }
        public long? TotalCoreCount { get { throw null; } }
        public long? TotalHostStorageGB { get { throw null; } }
        public long? TotalMemoryGB { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterConnectionStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus Timeout { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus Undefined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterDeployContent
    {
        public ClusterDeployContent() { }
        public System.Collections.Generic.IList<string> SkipValidationsForMachines { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus Degraded { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus Deploying { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus PendingDeployment { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus Running { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterManagerConnectionStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterManagerConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus Unreachable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterManagerDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterManagerDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus ProvisioningFailed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus UpdateFailed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterManagerProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterManagerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterMetricsConfigurationDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterMetricsConfigurationDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus Applied { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus Processing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterMetricsConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterMetricsConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState Validating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterType MultiRack { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterType SingleRack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterType left, Azure.ResourceManager.NetworkCloud.Models.ClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterType left, Azure.ResourceManager.NetworkCloud.Models.ClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterUpdateVersionContent
    {
        public ClusterUpdateVersionContent(string targetClusterVersion) { }
        public string TargetClusterVersion { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsoleDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsoleDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsoleEnabled : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsoleEnabled(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled left, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled left, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConsoleProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConsoleProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ControlImpact : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ControlImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ControlImpact(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ControlImpact False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ControlImpact True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ControlImpact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ControlImpact left, Azure.ResourceManager.NetworkCloud.Models.ControlImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ControlImpact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ControlImpact left, Azure.ResourceManager.NetworkCloud.Models.ControlImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ControlPlaneNodeConfiguration
    {
        public ControlPlaneNodeConfiguration(long count, string vmSkuName) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration AdministratorConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public long Count { get { throw null; } set { } }
        public string VmSkuName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultGateway : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.DefaultGateway>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultGateway(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultGateway False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultGateway True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.DefaultGateway other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.DefaultGateway left, Azure.ResourceManager.NetworkCloud.Models.DefaultGateway right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.DefaultGateway (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.DefaultGateway left, Azure.ResourceManager.NetworkCloud.Models.DefaultGateway right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceConnectionType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType PCI { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType left, Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType left, Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.DiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.DiskType HDD { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DiskType SSD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.DiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.DiskType left, Azure.ResourceManager.NetworkCloud.Models.DiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.DiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.DiskType left, Azure.ResourceManager.NetworkCloud.Models.DiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressEndpoint
    {
        public EgressEndpoint(string category, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency> endpoints) { }
        public string Category { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency> Endpoints { get { throw null; } }
    }
    public partial class EndpointDependency
    {
        public EndpointDependency(string domainName) { }
        public string DomainName { get { throw null; } set { } }
        public long? Port { get { throw null; } set { } }
    }
    public partial class ExtendedLocation
    {
        public ExtendedLocation(string name, string extendedLocationType) { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricPeeringEnabled : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricPeeringEnabled(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled left, Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled left, Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus Running { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FeatureStatus
    {
        internal FeatureStatus() { }
        public Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class HardwareInventory
    {
        internal HardwareInventory() { }
        public string AdditionalHostInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface> Interfaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic> Nics { get { throw null; } }
    }
    public partial class HardwareInventoryNetworkInterface
    {
        internal HardwareInventoryNetworkInterface() { }
        public string LinkStatus { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } }
        public string NetworkInterfaceId { get { throw null; } }
    }
    public partial class HardwareValidationStatus
    {
        internal HardwareValidationStatus() { }
        public System.DateTimeOffset? LastValidationOn { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult? Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HugepagesSize : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.HugepagesSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HugepagesSize(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HugepagesSize OneG { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HugepagesSize TwoM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.HugepagesSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.HugepagesSize left, Azure.ResourceManager.NetworkCloud.Models.HugepagesSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.HugepagesSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.HugepagesSize left, Azure.ResourceManager.NetworkCloud.Models.HugepagesSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridAksIpamEnabled : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridAksIpamEnabled(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled left, Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled left, Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridAksPluginType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridAksPluginType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType Dpdk { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType OSDevice { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType Sriov { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType left, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType left, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageRepositoryCredentials
    {
        public ImageRepositoryCredentials(string registryUriString, string username) { }
        public string Password { get { throw null; } set { } }
        public string RegistryUriString { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class InitialAgentPoolConfiguration
    {
        public InitialAgentPoolConfiguration(long count, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode, string name, string vmSkuName) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration AdministratorConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration AgentOptions { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration AttachedNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public long Count { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Labels { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode Mode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Taints { get { throw null; } }
        public string UpgradeMaxSurge { get { throw null; } set { } }
        public string VmSkuName { get { throw null; } set { } }
    }
    public partial class IPAddressPool
    {
        public IPAddressPool(System.Collections.Generic.IEnumerable<string> addresses, string name) { }
        public System.Collections.Generic.IList<string> Addresses { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BfdEnabled? AutoAssign { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BfdEnabled? OnlyUseHostIPs { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAllocationType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.IPAllocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAllocationType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.IPAllocationType DualStack { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.IPAllocationType IPV4 { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.IPAllocationType IPV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType left, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.IPAllocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType left, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeySetUser
    {
        public KeySetUser(string azureUserName, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey sshPublicKey) { }
        public string AzureUserName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
    }
    public partial class KeySetUserStatus
    {
        internal KeySetUserStatus() { }
        public string AzureUserName { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesClusterNetworkConfiguration
    {
        public KubernetesClusterNetworkConfiguration(Azure.Core.ResourceIdentifier cloudServicesNetworkId, Azure.Core.ResourceIdentifier cniNetworkId) { }
        public Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration AttachedNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration BgpServiceLoadBalancerConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CloudServicesNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CniNetworkId { get { throw null; } set { } }
        public System.Net.IPAddress DnsServiceIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PodCidrs { get { throw null; } }
        public System.Collections.Generic.IList<string> ServiceCidrs { get { throw null; } }
    }
    public partial class KubernetesClusterNode
    {
        internal KubernetesClusterNode() { }
        public string AgentPoolId { get { throw null; } }
        public string AvailabilityZone { get { throw null; } }
        public string BareMetalMachineId { get { throw null; } }
        public long? CpuCores { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public long? DiskSizeGB { get { throw null; } }
        public string Image { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Labels { get { throw null; } }
        public long? MemorySizeGB { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode? Mode { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> NetworkAttachments { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole? Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Taints { get { throw null; } }
        public string VmSkuName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterNodeDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterNodeDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Running { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Scheduling { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Terminating { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesClusterRestartNodeContent
    {
        public KubernetesClusterRestartNodeContent(string nodeName) { }
        public string NodeName { get { throw null; } }
    }
    public partial class KubernetesLabel
    {
        public KubernetesLabel(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesNodePowerState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesNodePowerState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState Off { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState On { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState left, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState left, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesNodeRole : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesNodeRole(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole ControlPlane { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole Worker { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole left, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole left, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesPluginType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesPluginType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType Dpdk { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType Ipvlan { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType Macvlan { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType OSDevice { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType Sriov { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType left, Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType left, Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class L2NetworkAttachmentConfiguration
    {
        public L2NetworkAttachmentConfiguration(Azure.Core.ResourceIdentifier networkId) { }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType? PluginType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct L2NetworkDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public L2NetworkDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct L2NetworkProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public L2NetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class L3NetworkAttachmentConfiguration
    {
        public L3NetworkAttachmentConfiguration(Azure.Core.ResourceIdentifier networkId) { }
        public Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled? IpamEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType? PluginType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct L3NetworkConfigurationIpamEnabled : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public L3NetworkConfigurationIpamEnabled(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled left, Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled left, Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct L3NetworkDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public L3NetworkDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct L3NetworkProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public L3NetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LldpNeighbor
    {
        internal LldpNeighbor() { }
        public string PortDescription { get { throw null; } }
        public string PortName { get { throw null; } }
        public string SystemDescription { get { throw null; } }
        public string SystemName { get { throw null; } }
    }
    public partial class MachineDisk
    {
        internal MachineDisk() { }
        public long? CapacityGB { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType? Connection { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.DiskType? DiskType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineSkuDiskConnectionType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineSkuDiskConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType Pcie { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType Raid { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType SAS { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType Sata { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType left, Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType left, Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineSkuSlot
    {
        internal MachineSkuSlot() { }
        public Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol? BootstrapProtocol { get { throw null; } }
        public long? CpuCores { get { throw null; } }
        public long? CpuSockets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.MachineDisk> Disks { get { throw null; } }
        public string Generation { get { throw null; } }
        public string HardwareVersion { get { throw null; } }
        public long? MemoryCapacityGB { get { throw null; } }
        public string Model { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface> NetworkInterfaces { get { throw null; } }
        public long? RackSlot { get { throw null; } }
        public long? TotalThreads { get { throw null; } }
        public string Vendor { get { throw null; } }
    }
    public partial class ManagedResourceGroupConfiguration
    {
        public ManagedResourceGroupConfiguration() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class NetworkAttachment
    {
        public NetworkAttachment(string attachedNetworkId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod ipAllocationMethod) { }
        public string AttachedNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.DefaultGateway? DefaultGateway { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod IPAllocationMethod { get { throw null; } set { } }
        public string IPv4Address { get { throw null; } set { } }
        public string IPv6Address { get { throw null; } set { } }
        public string MacAddress { get { throw null; } }
        public string NetworkAttachmentName { get { throw null; } set { } }
    }
    public partial class NetworkCloudAgentConfiguration
    {
        public NetworkCloudAgentConfiguration(long hugepagesCount) { }
        public long HugepagesCount { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.HugepagesSize? HugepagesSize { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkCloudAgentPoolMode : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkCloudAgentPoolMode(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode System { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode left, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode left, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkCloudAgentPoolPatch
    {
        public NetworkCloudAgentPoolPatch() { }
        public long? Count { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string UpgradeMaxSurge { get { throw null; } set { } }
    }
    public partial class NetworkCloudBareMetalMachineKeySetPatch
    {
        public NetworkCloudBareMetalMachineKeySetPatch() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> JumpHostsAllowed { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
    }
    public partial class NetworkCloudBareMetalMachinePatch
    {
        public NetworkCloudBareMetalMachinePatch() { }
        public string MachineDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudBmcKeySetPatch
    {
        public NetworkCloudBmcKeySetPatch() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
    }
    public partial class NetworkCloudCloudServicesNetworkPatch
    {
        public NetworkCloudCloudServicesNetworkPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> AdditionalEgressEndpoints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? EnableDefaultEgressEndpoints { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudClusterManagerPatch
    {
        public NetworkCloudClusterManagerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudClusterMetricsConfigurationPatch
    {
        public NetworkCloudClusterMetricsConfigurationPatch() { }
        public long? CollectionInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnabledMetrics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudClusterPatch
    {
        public NetworkCloudClusterPatch() { }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition AggregatorOrSingleRackDefinition { get { throw null; } set { } }
        public string ClusterLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation ClusterServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold ComputeDeploymentThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> ComputeRackDefinitions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudKubernetesClusterPatch
    {
        public NetworkCloudKubernetesClusterPatch() { }
        public long? ControlPlaneNodeCount { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudL2NetworkPatch
    {
        public NetworkCloudL2NetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudL3NetworkPatch
    {
        public NetworkCloudL3NetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudNetworkInterface
    {
        internal NetworkCloudNetworkInterface() { }
        public string Address { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType? DeviceConnectionType { get { throw null; } }
        public string Model { get { throw null; } }
        public long? PhysicalSlot { get { throw null; } }
        public long? PortCount { get { throw null; } }
        public long? PortSpeed { get { throw null; } }
        public string Vendor { get { throw null; } }
    }
    public partial class NetworkCloudNic
    {
        internal NetworkCloudNic() { }
        public Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor LldpNeighbor { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class NetworkCloudOperationStatusResult
    {
        internal NetworkCloudOperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Operations { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class NetworkCloudOSDisk
    {
        public NetworkCloudOSDisk(long diskSizeInGB) { }
        public Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption? CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption? DeleteOption { get { throw null; } set { } }
        public long DiskSizeInGB { get { throw null; } set { } }
    }
    public partial class NetworkCloudRackDefinition
    {
        public NetworkCloudRackDefinition(Azure.Core.ResourceIdentifier networkRackId, string rackSerialNumber, Azure.Core.ResourceIdentifier rackSkuId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration> BareMetalMachineConfigurationData { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkRackId { get { throw null; } set { } }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RackSkuId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration> StorageApplianceConfigurationData { get { throw null; } }
    }
    public partial class NetworkCloudRackPatch
    {
        public NetworkCloudRackPatch() { }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudSshPublicKey
    {
        public NetworkCloudSshPublicKey(string keyData) { }
        public string KeyData { get { throw null; } set { } }
    }
    public partial class NetworkCloudStorageAppliancePatch
    {
        public NetworkCloudStorageAppliancePatch() { }
        public string SerialNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudStorageProfile
    {
        public NetworkCloudStorageProfile(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk osDisk) { }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk OSDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VolumeAttachments { get { throw null; } }
    }
    public partial class NetworkCloudTrunkedNetworkPatch
    {
        public NetworkCloudTrunkedNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudVirtualMachineConsolePatch
    {
        public NetworkCloudVirtualMachineConsolePatch() { }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class NetworkCloudVirtualMachinePatch
    {
        public NetworkCloudVirtualMachinePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
    }
    public partial class NetworkCloudVolumePatch
    {
        public NetworkCloudVolumePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSDiskCreateOption : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSDiskCreateOption(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption Ephemeral { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption left, Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption left, Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSDiskDeleteOption : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSDiskDeleteOption(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption Delete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption left, Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption left, Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RackDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RackDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RackProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RackProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RackSkuProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RackSkuProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RackSkuType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RackSkuType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RackSkuType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RackSkuType Aggregator { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackSkuType Compute { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackSkuType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RackSkuType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RackSkuType left, Azure.ResourceManager.NetworkCloud.Models.RackSkuType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RackSkuType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RackSkuType left, Azure.ResourceManager.NetworkCloud.Models.RackSkuType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteVendorManagementFeature : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteVendorManagementFeature(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature Supported { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature Unsupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature left, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature left, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteVendorManagementStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteVendorManagementStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus Unsupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus left, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus left, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceLoadBalancerBgpPeer
    {
        public ServiceLoadBalancerBgpPeer(string name, string peerAddress, long peerAsn) { }
        public Azure.ResourceManager.NetworkCloud.Models.BfdEnabled? BfdEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BgpMultiHop? BgpMultiHop { get { throw null; } set { } }
        public string HoldTime { get { throw null; } set { } }
        public string KeepAliveTime { get { throw null; } set { } }
        public long? MyAsn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PeerAddress { get { throw null; } set { } }
        public long PeerAsn { get { throw null; } set { } }
        public long? PeerPort { get { throw null; } set { } }
    }
    public partial class ServicePrincipalInformation
    {
        public ServicePrincipalInformation(string applicationId, string principalId, string tenantId) { }
        public string ApplicationId { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkipShutdown : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.SkipShutdown>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkipShutdown(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.SkipShutdown False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.SkipShutdown True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.SkipShutdown other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.SkipShutdown left, Azure.ResourceManager.NetworkCloud.Models.SkipShutdown right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.SkipShutdown (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.SkipShutdown left, Azure.ResourceManager.NetworkCloud.Models.SkipShutdown right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageApplianceConfiguration
    {
        public StorageApplianceConfiguration(Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials adminCredentials, long rackSlot, string serialNumber) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials AdminCredentials { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string StorageApplianceName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageApplianceDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageApplianceDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageApplianceEnableRemoteVendorManagementContent
    {
        public StorageApplianceEnableRemoteVendorManagementContent() { }
        public System.Collections.Generic.IList<string> SupportEndpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageApplianceProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageApplianceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageApplianceSkuSlot
    {
        internal StorageApplianceSkuSlot() { }
        public long? CapacityGB { get { throw null; } }
        public string Model { get { throw null; } }
        public long? RackSlot { get { throw null; } }
    }
    public partial class TrunkedNetworkAttachmentConfiguration
    {
        public TrunkedNetworkAttachmentConfiguration(Azure.Core.ResourceIdentifier networkId) { }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType? PluginType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrunkedNetworkDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrunkedNetworkDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrunkedNetworkProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrunkedNetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationThreshold
    {
        public ValidationThreshold(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping grouping, Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType thresholdType, long value) { }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping Grouping { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType ThresholdType { get { throw null; } set { } }
        public long Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationThresholdGrouping : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationThresholdGrouping(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping PerCluster { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping PerRack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping left, Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping left, Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationThresholdType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationThresholdType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType CountSuccess { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType PercentSuccess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType left, Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType left, Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineBootMethod : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineBootMethod(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod Bios { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod Uefi { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Running { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Scheduling { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Terminating { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineDeviceModelType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineDeviceModelType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType T1 { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType T2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineIPAllocationMethod : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineIsolateEmulatorThread : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineIsolateEmulatorThread(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachinePlacementHint
    {
        public VirtualMachinePlacementHint(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType hintType, Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution schedulingExecution, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope scope) { }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType HintType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution SchedulingExecution { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope Scope { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePlacementHintPodAffinityScope : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePlacementHintPodAffinityScope(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope Machine { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope Rack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePlacementHintType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePlacementHintType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType Affinity { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType AntiAffinity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualMachinePowerOffContent
    {
        public VirtualMachinePowerOffContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.SkipShutdown? SkipShutdown { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachinePowerState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachinePowerState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState Off { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState On { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineSchedulingExecution : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineSchedulingExecution(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution Hard { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution Soft { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineVirtioInterfaceType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineVirtioInterfaceType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType Modern { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType Transitional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType left, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadImpact : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadImpact(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact left, Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact left, Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
}
