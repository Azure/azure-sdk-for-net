namespace Azure.ResourceManager.NetworkCloud
{
    public partial class BareMetalMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>, System.Collections.IEnumerable
    {
        protected BareMetalMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> Get(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>> GetAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BareMetalMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BareMetalMachineData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string bmcConnectionString, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, string machineDetails, string machineName, string machineSkuId, string rackId, long rackSlot, string serialNumber) : base (default(Azure.Core.AzureLocation)) { }
        public string BmcConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials BmcCredentials { get { throw null; } set { } }
        public string BmcMacAddress { get { throw null; } set { } }
        public string BootMacAddress { get { throw null; } set { } }
        public string ClusterId { get { throw null; } }
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
        public string OamIPv4Address { get { throw null; } }
        public string OamIPv6Address { get { throw null; } }
        public string OSImage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? ProvisioningState { get { throw null; } }
        public string RackId { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? ReadyState { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string ServiceTag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualMachinesAssociatedIds { get { throw null; } }
    }
    public partial class BareMetalMachineKeySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>, System.Collections.IEnumerable
    {
        protected BareMetalMachineKeySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> Get(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> GetAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BareMetalMachineKeySetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BareMetalMachineKeySetData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, System.DateTimeOffset expiration, System.Collections.Generic.IEnumerable<string> jumpHostsAllowed, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList) : base (default(Azure.Core.AzureLocation)) { }
        public string AzureGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public System.DateTimeOffset Expiration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> JumpHostsAllowed { get { throw null; } }
        public System.DateTimeOffset? LastValidation { get { throw null; } }
        public string OSGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel PrivilegeLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> UserListStatus { get { throw null; } }
    }
    public partial class BareMetalMachineKeySetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BareMetalMachineKeySetResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string bareMetalMachineKeySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BareMetalMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BareMetalMachineResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.BareMetalMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Cordon(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CordonAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string bareMetalMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Replace(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReplaceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunCommand(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunCommandAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunDataExtracts(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunDataExtractsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunReadCommands(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunReadCommandsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Uncordon(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UncordonAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ValidateHardware(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineValidateHardwareContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ValidateHardwareAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineValidateHardwareContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BmcKeySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>, System.Collections.IEnumerable
    {
        protected BmcKeySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.BmcKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.BmcKeySetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> Get(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> GetAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BmcKeySetData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BmcKeySetData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, System.DateTimeOffset expiration, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList) : base (default(Azure.Core.AzureLocation)) { }
        public string AzureGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public System.DateTimeOffset Expiration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.DateTimeOffset? LastValidation { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel PrivilegeLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> UserListStatus { get { throw null; } }
    }
    public partial class BmcKeySetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BmcKeySetResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.BmcKeySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string bmcKeySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudServicesNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>, System.Collections.IEnumerable
    {
        protected CloudServicesNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.CloudServicesNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.CloudServicesNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> Get(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> GetAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudServicesNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CloudServicesNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> AdditionalEgressEndpoints { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? EnableDefaultEgressEndpoints { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> EnabledEgressEndpoints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HybridAksClustersAssociatedIds { get { throw null; } }
        public string InterfaceName { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualMachinesAssociatedIds { get { throw null; } }
    }
    public partial class CloudServicesNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudServicesNetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.CloudServicesNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServicesNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.ClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.RackDefinition aggregatorOrSingleRackDefinition, string analyticsWorkspaceId, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType, string clusterVersion, string networkFabricId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetworkCloud.Models.RackDefinition AggregatorOrSingleRackDefinition { get { throw null; } set { } }
        public string AnalyticsWorkspaceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> AvailableUpgradeVersions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity ClusterCapacity { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? ClusterConnectionStatus { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ClusterExtendedLocation { get { throw null; } }
        public string ClusterLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? ClusterManagerConnectionStatus { get { throw null; } }
        public string ClusterManagerId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation ClusterServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterType ClusterType { get { throw null; } set { } }
        public string ClusterVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold ComputeDeploymentThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.RackDefinition> ComputeRackDefinitions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation HybridAksExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public long? ManualActionCount { get { throw null; } }
        public string NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string SupportExpiryDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> WorkloadResourceIds { get { throw null; } }
    }
    public partial class ClusterManagerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>, System.Collections.IEnumerable
    {
        protected ClusterManagerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.ClusterManagerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.ClusterManagerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> Get(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> GetAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterManagerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterManagerData(Azure.Core.AzureLocation location, string fabricControllerId) : base (default(Azure.Core.AzureLocation)) { }
        public string AnalyticsWorkspaceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> ClusterVersions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public string FabricControllerId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ManagerExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? ProvisioningState { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
    }
    public partial class ClusterManagerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterManagerResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.ClusterManagerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterManagerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> Update(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterMetricsConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>, System.Collections.IEnumerable
    {
        protected ClusterMetricsConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> Get(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> GetAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterMetricsConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterMetricsConfigurationData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, long collectionInterval) : base (default(Azure.Core.AzureLocation)) { }
        public long CollectionInterval { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DisabledMetrics { get { throw null; } }
        public System.Collections.Generic.IList<string> EnabledMetrics { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ClusterMetricsConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterMetricsConfigurationResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string metricsConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deploy(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeployAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource> GetBareMetalMachineKeySet(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource>> GetBareMetalMachineKeySetAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetCollection GetBareMetalMachineKeySets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource> GetBmcKeySet(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BmcKeySetResource>> GetBmcKeySetAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.BmcKeySetCollection GetBmcKeySets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource> GetClusterMetricsConfiguration(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource>> GetClusterMetricsConfigurationAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationCollection GetClusterMetricsConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpdateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsoleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ConsoleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ConsoleResource>, System.Collections.IEnumerable
    {
        protected ConsoleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ConsoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.ConsoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ConsoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.ConsoleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource> Get(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.ConsoleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.ConsoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource>> GetAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.ConsoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.ConsoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.ConsoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.ConsoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConsoleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ConsoleData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled, Azure.ResourceManager.NetworkCloud.Models.SshPublicKey sshPublicKey) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? Expiration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
        public string PrivateLinkServiceId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? ProvisioningState { get { throw null; } }
        public string VirtualMachineAccessId { get { throw null; } }
    }
    public partial class ConsoleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConsoleResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.ConsoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string consoleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ConsoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ConsolePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.ConsoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ConsolePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultCniNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>, System.Collections.IEnumerable
    {
        protected DefaultCniNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string defaultCniNetworkName, Azure.ResourceManager.NetworkCloud.DefaultCniNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string defaultCniNetworkName, Azure.ResourceManager.NetworkCloud.DefaultCniNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string defaultCniNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string defaultCniNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> Get(string defaultCniNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> GetAsync(string defaultCniNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DefaultCniNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DefaultCniNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string l3IsolationDomainId, long vlan) : base (default(Azure.Core.AzureLocation)) { }
        public string ClusterId { get { throw null; } }
        public long? CniAsNumber { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CniBgpConfiguration CniBgpConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.BgpPeer> FabricBgpPeers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HybridAksClustersAssociatedIds { get { throw null; } }
        public string InterfaceName { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? IPAllocationType { get { throw null; } set { } }
        public string IPv4ConnectedPrefix { get { throw null; } set { } }
        public string IPv6ConnectedPrefix { get { throw null; } set { } }
        public string L3IsolationDomainId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public long Vlan { get { throw null; } set { } }
    }
    public partial class DefaultCniNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DefaultCniNetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.DefaultCniNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string defaultCniNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridAksClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>, System.Collections.IEnumerable
    {
        protected HybridAksClusterCollection() { }
        public virtual Azure.Response<bool> Exists(string hybridAksClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hybridAksClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> Get(string hybridAksClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>> GetAsync(string hybridAksClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridAksClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridAksClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> associatedNetworkIds, long controlPlaneCount, string hybridAksProvisionedClusterId, long workerCount) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> AssociatedNetworkIds { get { throw null; } }
        public string CloudServicesNetworkId { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public long ControlPlaneCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NodeConfiguration> ControlPlaneNodes { get { throw null; } }
        public string DefaultCniNetworkId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string HybridAksProvisionedClusterId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Volumes { get { throw null; } }
        public long WorkerCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NodeConfiguration> WorkerNodes { get { throw null; } }
    }
    public partial class HybridAksClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridAksClusterResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.HybridAksClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hybridAksClusterName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestartNode(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterRestartNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartNodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterRestartNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> Update(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class L2NetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.L2NetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.L2NetworkResource>, System.Collections.IEnumerable
    {
        protected L2NetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.L2NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.L2NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.L2NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource> Get(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.L2NetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.L2NetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> GetAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.L2NetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.L2NetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.L2NetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.L2NetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class L2NetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public L2NetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string l2IsolationDomainId) : base (default(Azure.Core.AzureLocation)) { }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public string L2IsolationDomainId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualMachinesAssociatedIds { get { throw null; } }
    }
    public partial class L2NetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected L2NetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.L2NetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l2NetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.L2NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.L2NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class L3NetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.L3NetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.L3NetworkResource>, System.Collections.IEnumerable
    {
        protected L3NetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.L3NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.L3NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.L3NetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource> Get(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.L3NetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.L3NetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> GetAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.L3NetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.L3NetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.L3NetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.L3NetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class L3NetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public L3NetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string l3IsolationDomainId, long vlan) : base (default(Azure.Core.AzureLocation)) { }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled? HybridAksIpamEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? IPAllocationType { get { throw null; } set { } }
        public string IPv4ConnectedPrefix { get { throw null; } set { } }
        public string IPv6ConnectedPrefix { get { throw null; } set { } }
        public string L3IsolationDomainId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualMachinesAssociatedIds { get { throw null; } }
        public long Vlan { get { throw null; } set { } }
    }
    public partial class L3NetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected L3NetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.L3NetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3NetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.L3NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.L3NetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetworkCloudExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> GetBareMetalMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource>> GetBareMetalMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetResource GetBareMetalMachineKeySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.BareMetalMachineResource GetBareMetalMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.BareMetalMachineCollection GetBareMetalMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> GetBareMetalMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.BareMetalMachineResource> GetBareMetalMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.BmcKeySetResource GetBmcKeySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> GetCloudServicesNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource>> GetCloudServicesNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource GetCloudServicesNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.CloudServicesNetworkCollection GetCloudServicesNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> GetCloudServicesNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.CloudServicesNetworkResource> GetCloudServicesNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> GetClusterManager(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ClusterManagerResource>> GetClusterManagerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterManagerResource GetClusterManagerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterManagerCollection GetClusterManagers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> GetClusterManagers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.ClusterManagerResource> GetClusterManagersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationResource GetClusterMetricsConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ConsoleResource GetConsoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> GetDefaultCniNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string defaultCniNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource>> GetDefaultCniNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string defaultCniNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource GetDefaultCniNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.DefaultCniNetworkCollection GetDefaultCniNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> GetDefaultCniNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.DefaultCniNetworkResource> GetDefaultCniNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> GetHybridAksCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hybridAksClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource>> GetHybridAksClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hybridAksClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.HybridAksClusterResource GetHybridAksClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.HybridAksClusterCollection GetHybridAksClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> GetHybridAksClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.HybridAksClusterResource> GetHybridAksClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource> GetL2Network(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L2NetworkResource>> GetL2NetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.L2NetworkResource GetL2NetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.L2NetworkCollection GetL2Networks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.L2NetworkResource> GetL2Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.L2NetworkResource> GetL2NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource> GetL3Network(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.L3NetworkResource>> GetL3NetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.L3NetworkResource GetL3NetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.L3NetworkCollection GetL3Networks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.L3NetworkResource> GetL3Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.L3NetworkResource> GetL3NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource> GetRack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource>> GetRackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.RackResource GetRackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.RackCollection GetRacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.RackResource> GetRacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.RackResource> GetRacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.RackSkuResource> GetRackSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackSkuResource>> GetRackSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.RackSkuResource GetRackSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.RackSkuCollection GetRackSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> GetStorageAppliance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>> GetStorageApplianceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.StorageApplianceResource GetStorageApplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.StorageApplianceCollection GetStorageAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> GetStorageAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> GetStorageAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> GetTrunkedNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> GetTrunkedNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource GetTrunkedNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.TrunkedNetworkCollection GetTrunkedNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> GetTrunkedNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> GetTrunkedNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> GetVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> GetVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.VirtualMachineResource GetVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.VirtualMachineCollection GetVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> GetVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> GetVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource> GetVolume(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource>> GetVolumeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.VolumeResource GetVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.VolumeCollection GetVolumes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.VolumeResource> GetVolumes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.VolumeResource> GetVolumesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.RackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.RackResource>, System.Collections.IEnumerable
    {
        protected RackCollection() { }
        public virtual Azure.Response<bool> Exists(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource> Get(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.RackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.RackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource>> GetAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.RackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.RackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.RackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.RackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RackData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RackData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string availabilityZone, string rackLocation, string rackSerialNumber, string rackSkuId) : base (default(Azure.Core.AzureLocation)) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? ProvisioningState { get { throw null; } }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public string RackSkuId { get { throw null; } set { } }
    }
    public partial class RackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RackResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.RackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rackName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.RackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.RackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.RackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.RackPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RackSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.RackSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.RackSkuResource>, System.Collections.IEnumerable
    {
        protected RackSkuCollection() { }
        public virtual Azure.Response<bool> Exists(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.RackSkuResource> Get(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.RackSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.RackSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackSkuResource>> GetAsync(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.RackSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.RackSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.RackSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.RackSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RackSkuData : Azure.ResourceManager.Models.ResourceData
    {
        public RackSkuData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> ComputeMachines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> ControllerMachines { get { throw null; } }
        public string Description { get { throw null; } }
        public long? MaxClusterSlots { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RackSkuType? RackType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot> StorageAppliances { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedRackSkuIds { get { throw null; } }
    }
    public partial class RackSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RackSkuResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.RackSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string rackSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.RackSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.RackSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageApplianceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>, System.Collections.IEnumerable
    {
        protected StorageApplianceCollection() { }
        public virtual Azure.Response<bool> Exists(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> Get(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>> GetAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageApplianceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public StorageApplianceData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials, string rackId, long rackSlot, string serialNumber, string storageApplianceSkuId) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials AdministratorCredentials { get { throw null; } set { } }
        public long? Capacity { get { throw null; } }
        public long? CapacityUsed { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string ManagementIPv4Address { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? ProvisioningState { get { throw null; } }
        public string RackId { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? RemoteVendorManagementFeature { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? RemoteVendorManagementStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string StorageApplianceSkuId { get { throw null; } set { } }
    }
    public partial class StorageApplianceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageApplianceResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.StorageApplianceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageApplianceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableRemoteVendorManagement(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableRemoteVendorManagementAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableRemoteVendorManagement(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableRemoteVendorManagementAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RunReadCommands(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RunReadCommandsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.StorageApplianceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.StorageApplianceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageAppliancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ValidateHardware(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceValidateHardwareContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ValidateHardwareAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceValidateHardwareContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrunkedNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>, System.Collections.IEnumerable
    {
        protected TrunkedNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.TrunkedNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.TrunkedNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> Get(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> GetAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrunkedNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public TrunkedNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> isolationDomainIds, System.Collections.Generic.IEnumerable<long> vlans) : base (default(Azure.Core.AzureLocation)) { }
        public string ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> IsolationDomainIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualMachinesAssociatedIds { get { throw null; } }
        public System.Collections.Generic.IList<long> Vlans { get { throw null; } }
    }
    public partial class TrunkedNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrunkedNetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.TrunkedNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trunkedNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.TrunkedNetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>, System.Collections.IEnumerable
    {
        protected VirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.VirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.VirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> GetAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualMachineData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string adminUsername, Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment, long cpuCores, long memorySizeGB, Azure.ResourceManager.NetworkCloud.Models.StorageProfile storageProfile, string vmImage) : base (default(Azure.Core.AzureLocation)) { }
        public string AdminUsername { get { throw null; } set { } }
        public string BareMetalMachineId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? BootMethod { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment CloudServicesNetworkAttachment { get { throw null; } set { } }
        public string ClusterId { get { throw null; } }
        public long CpuCores { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? IsolateEmulatorThread { get { throw null; } set { } }
        public long MemorySizeGB { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> NetworkAttachments { get { throw null; } }
        public string NetworkData { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> PlacementHints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.SshPublicKey> SshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? VirtioInterface { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? VmDeviceModel { get { throw null; } set { } }
        public string VmImage { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> Volumes { get { throw null; } }
    }
    public partial class VirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualMachineResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.VirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation AttachVolume(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVolumeParameters virtualMachineAttachVolumeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AttachVolumeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVolumeParameters virtualMachineAttachVolumeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachVolume(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVolumeParameters virtualMachineDetachVolumeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachVolumeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVolumeParameters virtualMachineDetachVolumeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource> GetConsole(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.ConsoleResource>> GetConsoleAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.ConsoleCollection GetConsoles() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PowerOff(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PowerOffAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Reimage(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReimageAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.VirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.VirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.VolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.VolumeResource>, System.Collections.IEnumerable
    {
        protected VolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.VolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.VolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.VolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.VolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.VolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.VolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.VolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.VolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.VolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.VolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VolumeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VolumeData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, long sizeMiB) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<string> AttachedTo { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public long SizeMiB { get { throw null; } set { } }
    }
    public partial class VolumeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VolumeResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.VolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource> Update(Azure.ResourceManager.NetworkCloud.Models.VolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.VolumeResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.VolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ArmNetworkCloudModelFactory
    {
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfigurationData BareMetalMachineConfigurationData(string bmcConnectionString = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, string machineDetails = null, string machineName = null, long rackSlot = (long)0, string serialNumber = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.BareMetalMachineData BareMetalMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string bmcConnectionString = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, string clusterId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? cordonStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.HardwareInventory hardwareInventory = null, Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus hardwareValidationStatus = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, string kubernetesNodeName = null, string kubernetesVersion = null, string machineDetails = null, string machineName = null, string machineSkuId = null, string oamIPv4Address = null, string oamIPv6Address = null, string osImage = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState?), string rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? readyState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState?), string serialNumber = null, string serviceTag = null, System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.BareMetalMachineKeySetData BareMetalMachineKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expiration = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<string> jumpHostsAllowed = null, System.DateTimeOffset? lastValidation = default(System.DateTimeOffset?), string osGroupName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.BmcKeySetData BmcKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expiration = default(System.DateTimeOffset), System.DateTimeOffset? lastValidation = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.CloudServicesNetworkData CloudServicesNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> additionalEgressEndpoints = null, string clusterId = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> enabledEgressEndpoints = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState?), System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion ClusterAvailableUpgradeVersion(Azure.ResourceManager.NetworkCloud.Models.ControlImpact? controlImpact = default(Azure.ResourceManager.NetworkCloud.Models.ControlImpact?), string expectedDuration = null, string impactDescription = null, string supportExpiryDate = null, string targetClusterVersion = null, Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact? workloadImpact = default(Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion ClusterAvailableVersion(string supportExpiryDate = null, string targetClusterVersion = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity ClusterCapacity(long? availableApplianceStorageGB = default(long?), long? availableCoreCount = default(long?), long? availableHostStorageGB = default(long?), long? availableMemoryGB = default(long?), long? totalApplianceStorageGB = default(long?), long? totalCoreCount = default(long?), long? totalHostStorageGB = default(long?), long? totalMemoryGB = default(long?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterData ClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.RackDefinition aggregatorOrSingleRackDefinition = null, string analyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> availableUpgradeVersions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity clusterCapacity = null, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? clusterConnectionStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation clusterExtendedLocation = null, string clusterLocation = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? clusterManagerConnectionStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus?), string clusterManagerId = null, Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation clusterServicePrincipal = null, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType = default(Azure.ResourceManager.NetworkCloud.Models.ClusterType), string clusterVersion = null, Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold computeDeploymentThreshold = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.RackDefinition> computeRackDefinitions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation hybridAksExtendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, long? manualActionCount = default(long?), string networkFabricId = null, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState?), string supportExpiryDate = null, System.Collections.Generic.IEnumerable<string> workloadResourceIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterManagerData ClusterManagerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string analyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> clusterVersions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus?), string detailedStatusMessage = null, string fabricControllerId = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation managerExtendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState?), string vmSize = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ClusterMetricsConfigurationData ClusterMetricsConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, long collectionInterval = (long)0, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<string> disabledMetrics = null, System.Collections.Generic.IEnumerable<string> enabledMetrics = null, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.ConsoleData ConsoleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled), System.DateTimeOffset? expiration = default(System.DateTimeOffset?), string privateLinkServiceId = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState?), string keyData = null, string virtualMachineAccessId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.DefaultCniNetworkData DefaultCniNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string clusterId = null, long? cniAsNumber = default(long?), Azure.ResourceManager.NetworkCloud.Models.CniBgpConfiguration cniBgpConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.BgpPeer> fabricBgpPeers = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? ipAllocationType = default(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType?), string ipv4ConnectedPrefix = null, string ipv6ConnectedPrefix = null, string l3IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState?), long vlan = (long)0) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareInventory HardwareInventory(string additionalHostInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface> interfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.Nic> nics = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface HardwareInventoryNetworkInterface(string linkStatus = null, string macAddress = null, string name = null, string networkInterfaceId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus HardwareValidationStatus(System.DateTimeOffset? lastValidationOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult? result = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.HybridAksClusterData HybridAksClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> associatedNetworkIds = null, string cloudServicesNetworkId = null, string clusterId = null, long controlPlaneCount = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NodeConfiguration> controlPlaneNodes = null, string defaultCniNetworkId = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus?), string detailedStatusMessage = null, string hybridAksProvisionedClusterId = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState?), System.Collections.Generic.IEnumerable<string> volumes = null, long workerCount = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NodeConfiguration> workerNodes = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus KeySetUserStatus(string azureUserName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus? status = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus?), string statusMessage = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.L2NetworkData L2NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, string l2IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState?), System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.L3NetworkData L3NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled? hybridAksIpamEnabled = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled?), Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? ipAllocationType = default(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType?), string ipv4ConnectedPrefix = null, string ipv6ConnectedPrefix = null, string l3IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState?), System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null, long vlan = (long)0) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor LldpNeighbor(string portDescription = null, string portName = null, string systemDescription = null, string systemName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineDisk MachineDisk(long? capacityGB = default(long?), Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType? connection = default(Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType?), Azure.ResourceManager.NetworkCloud.Models.DiskType? diskType = default(Azure.ResourceManager.NetworkCloud.Models.DiskType?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot MachineSkuSlot(long? rackSlot = default(long?), Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol? bootstrapProtocol = default(Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol?), long? cpuCores = default(long?), long? cpuSockets = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineDisk> disks = null, string generation = null, string hardwareVersion = null, long? memoryCapacityGB = default(long?), string model = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkInterface> networkInterfaces = null, long? totalThreads = default(long?), string vendor = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment NetworkAttachment(string attachedNetworkId = null, Azure.ResourceManager.NetworkCloud.Models.DefaultGateway? defaultGateway = default(Azure.ResourceManager.NetworkCloud.Models.DefaultGateway?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod ipAllocationMethod = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod), string ipv4Address = null, string ipv6Address = null, string macAddress = null, string networkAttachmentName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkInterface NetworkInterface(string address = null, Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType? deviceConnectionType = default(Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType?), string model = null, long? physicalSlot = default(long?), long? portCount = default(long?), long? portSpeed = default(long?), string vendor = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.Nic Nic(Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor lldpNeighbor = null, string macAddress = null, string name = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.Node Node(string bareMetalMachineId = null, string imageId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments = null, string nodeName = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NodeConfiguration NodeConfiguration(string agentPoolId = null, string agentPoolName = null, long? cpuCores = default(long?), long? diskSizeGB = default(long?), long? memorySizeGB = default(long?), string nodePoolName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.Node> nodes = null, long? vmCount = default(long?), string vmSize = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.RackData RackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string availabilityZone = null, string clusterId = null, Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState?), string rackLocation = null, string rackSerialNumber = null, string rackSkuId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.RackSkuData RackSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> computeMachines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> controllerMachines = null, string description = null, long? maxClusterSlots = default(long?), Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState?), Azure.ResourceManager.NetworkCloud.Models.RackSkuType? rackType = default(Azure.ResourceManager.NetworkCloud.Models.RackSkuType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot> storageAppliances = null, System.Collections.Generic.IEnumerable<string> supportedRackSkuIds = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.StorageApplianceData StorageApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials = null, long? capacity = default(long?), long? capacityUsed = default(long?), string clusterId = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus?), string detailedStatusMessage = null, string managementIPv4Address = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState?), string rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? remoteVendorManagementFeature = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature?), Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? remoteVendorManagementStatus = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus?), string serialNumber = null, string storageApplianceSkuId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot StorageApplianceSkuSlot(long? rackSlot = default(long?), long? capacityGB = default(long?), string model = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.TrunkedNetworkData TrunkedNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string clusterId = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, System.Collections.Generic.IEnumerable<string> isolationDomainIds = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState?), System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null, System.Collections.Generic.IEnumerable<long> vlans = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.VirtualMachineData VirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string adminUsername = null, string bareMetalMachineId = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? bootMethod = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod?), Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment = null, string clusterId = null, long cpuCores = (long)0, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? isolateEmulatorThread = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread?), long memorySizeGB = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments = null, string networkData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> placementHints = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SshPublicKey> sshPublicKeys = null, Azure.ResourceManager.NetworkCloud.Models.StorageProfile storageProfile = null, string userData = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? virtioInterface = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? vmDeviceModel = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType?), string vmImage = null, Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials vmImageRepositoryCredentials = null, System.Collections.Generic.IEnumerable<string> volumes = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.VolumeData VolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> attachedTo = null, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState?), string serialNumber = null, long sizeMiB = (long)0) { throw null; }
    }
    public partial class BareMetalMachineCommandSpecification
    {
        public BareMetalMachineCommandSpecification(string command) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
    }
    public partial class BareMetalMachineConfigurationData
    {
        public BareMetalMachineConfigurationData(Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, long rackSlot, string serialNumber) { }
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
    public readonly partial struct BareMetalMachineHardwareValidationCategory : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineHardwareValidationCategory(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory BasicValidation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory right) { throw null; }
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
    public partial class BareMetalMachineKeySetPatch
    {
        public BareMetalMachineKeySetPatch() { }
        public System.DateTimeOffset? Expiration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> JumpHostsAllowed { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
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
    public partial class BareMetalMachinePatch
    {
        public BareMetalMachinePatch() { }
        public string MachineDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class BareMetalMachineValidateHardwareContent
    {
        public BareMetalMachineValidateHardwareContent(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory validationCategory) { }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationCategory ValidationCategory { get { throw null; } }
    }
    public partial class BgpPeer
    {
        public BgpPeer(long asNumber, string peerIP) { }
        public long AsNumber { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PeerIP { get { throw null; } set { } }
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
    public partial class BmcKeySetPatch
    {
        public BmcKeySetPatch() { }
        public System.DateTimeOffset? Expiration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
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
        public static Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol PXE { get { throw null; } }
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
    public partial class CloudServicesNetworkPatch
    {
        public CloudServicesNetworkPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> AdditionalEgressEndpoints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? EnableDefaultEgressEndpoints { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public string SupportExpiryDate { get { throw null; } }
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
    public partial class ClusterManagerPatch
    {
        public ClusterManagerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class ClusterMetricsConfigurationPatch
    {
        public ClusterMetricsConfigurationPatch() { }
        public long? CollectionInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnabledMetrics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class ClusterPatch
    {
        public ClusterPatch() { }
        public Azure.ResourceManager.NetworkCloud.Models.RackDefinition AggregatorOrSingleRackDefinition { get { throw null; } set { } }
        public string ClusterLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation ClusterServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold ComputeDeploymentThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.RackDefinition> ComputeRackDefinitions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class CniBgpConfiguration
    {
        public CniBgpConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BgpPeer> BgpPeers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.CommunityAdvertisement> CommunityAdvertisements { get { throw null; } }
        public string NodeMeshPassword { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServiceExternalPrefixes { get { throw null; } }
        public System.Collections.Generic.IList<string> ServiceLoadBalancerPrefixes { get { throw null; } }
    }
    public partial class CommunityAdvertisement
    {
        public CommunityAdvertisement(System.Collections.Generic.IEnumerable<string> communities, string subnetPrefix) { }
        public System.Collections.Generic.IList<string> Communities { get { throw null; } }
        public string SubnetPrefix { get { throw null; } set { } }
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
    public partial class ConsolePatch
    {
        public ConsolePatch() { }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? Expiration { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultCniNetworkDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultCniNetworkDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DefaultCniNetworkPatch
    {
        public DefaultCniNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultCniNetworkProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultCniNetworkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.DefaultCniNetworkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class HardwareInventory
    {
        internal HardwareInventory() { }
        public string AdditionalHostInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface> Interfaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.Nic> Nics { get { throw null; } }
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
    public readonly partial struct HybridAksClusterDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridAksClusterDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridAksClusterMachinePowerState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridAksClusterMachinePowerState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState Off { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState left, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState left, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridAksClusterPatch
    {
        public HybridAksClusterPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridAksClusterProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridAksClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridAksClusterRestartNodeContent
    {
        public HybridAksClusterRestartNodeContent(string nodeName) { }
        public string NodeName { get { throw null; } }
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
        public KeySetUser(string azureUserName, Azure.ResourceManager.NetworkCloud.Models.SshPublicKey sshPublicKey) { }
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
    public partial class L2NetworkPatch
    {
        public L2NetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class L3NetworkPatch
    {
        public L3NetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
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
    public partial class NetworkInterface
    {
        internal NetworkInterface() { }
        public string Address { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType? DeviceConnectionType { get { throw null; } }
        public string Model { get { throw null; } }
        public long? PhysicalSlot { get { throw null; } }
        public long? PortCount { get { throw null; } }
        public long? PortSpeed { get { throw null; } }
        public string Vendor { get { throw null; } }
    }
    public partial class Nic
    {
        internal Nic() { }
        public Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor LldpNeighbor { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class Node
    {
        internal Node() { }
        public string BareMetalMachineId { get { throw null; } }
        public string ImageId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> NetworkAttachments { get { throw null; } }
        public string NodeName { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksClusterMachinePowerState? PowerState { get { throw null; } }
    }
    public partial class NodeConfiguration
    {
        internal NodeConfiguration() { }
        public string AgentPoolId { get { throw null; } }
        public string AgentPoolName { get { throw null; } }
        public long? CpuCores { get { throw null; } }
        public long? DiskSizeGB { get { throw null; } }
        public long? MemorySizeGB { get { throw null; } }
        public string NodePoolName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.Node> Nodes { get { throw null; } }
        public long? VmCount { get { throw null; } }
        public string VmSize { get { throw null; } }
    }
    public partial class OSDisk
    {
        public OSDisk(long diskSizeGB) { }
        public Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption? CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption? DeleteOption { get { throw null; } set { } }
        public long DiskSizeGB { get { throw null; } set { } }
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
    public partial class RackDefinition
    {
        public RackDefinition(string networkRackId, string rackSerialNumber, string rackSkuId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfigurationData> BareMetalMachineConfigurationData { get { throw null; } }
        public string NetworkRackId { get { throw null; } set { } }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public string RackSkuId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfigurationData> StorageApplianceConfigurationData { get { throw null; } }
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
    public partial class RackPatch
    {
        public RackPatch() { }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class ServicePrincipalInformation
    {
        public ServicePrincipalInformation(string applicationId, string principalId, System.Guid tenantId) { }
        public string ApplicationId { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
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
    public partial class SshPublicKey
    {
        public SshPublicKey(string keyData) { }
        public string KeyData { get { throw null; } set { } }
    }
    public partial class StorageApplianceCommandSpecification
    {
        public StorageApplianceCommandSpecification(string command) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
    }
    public partial class StorageApplianceConfigurationData
    {
        public StorageApplianceConfigurationData(Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials adminCredentials, long rackSlot, string serialNumber) { }
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
    public readonly partial struct StorageApplianceHardwareValidationCategory : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageApplianceHardwareValidationCategory(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory BasicValidation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory left, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory left, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAppliancePatch
    {
        public StorageAppliancePatch() { }
        public string SerialNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class StorageApplianceRunReadCommandsContent
    {
        public StorageApplianceRunReadCommandsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification> commands, long limitTimeSeconds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification> Commands { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
    }
    public partial class StorageApplianceSkuSlot
    {
        internal StorageApplianceSkuSlot() { }
        public long? CapacityGB { get { throw null; } }
        public string Model { get { throw null; } }
        public long? RackSlot { get { throw null; } }
    }
    public partial class StorageApplianceValidateHardwareContent
    {
        public StorageApplianceValidateHardwareContent(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory validationCategory) { }
        public Azure.ResourceManager.NetworkCloud.Models.StorageApplianceHardwareValidationCategory ValidationCategory { get { throw null; } }
    }
    public partial class StorageProfile
    {
        public StorageProfile(Azure.ResourceManager.NetworkCloud.Models.OSDisk osDisk) { }
        public Azure.ResourceManager.NetworkCloud.Models.OSDisk OSDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VolumeAttachments { get { throw null; } }
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
    public partial class TrunkedNetworkPatch
    {
        public TrunkedNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class VirtualMachinePatch
    {
        public VirtualMachinePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
    }
    public partial class VirtualMachinePlacementHint
    {
        public VirtualMachinePlacementHint(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType hintType, string resourceId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution schedulingExecution, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope scope) { }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType HintType { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
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
    public partial class VirtualMachineVolumeParameters
    {
        public VirtualMachineVolumeParameters(string volumeId) { }
        public string VolumeId { get { throw null; } }
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
    public partial class VolumePatch
    {
        public VolumePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
