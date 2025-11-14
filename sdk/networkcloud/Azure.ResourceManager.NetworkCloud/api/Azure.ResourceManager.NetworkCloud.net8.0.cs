namespace Azure.ResourceManager.NetworkCloud
{
    public partial class AzureResourceManagerNetworkCloudContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNetworkCloudContext() { }
        public static Azure.ResourceManager.NetworkCloud.AzureResourceManagerNetworkCloudContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NetworkCloudAgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudAgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetIfExists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetIfExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudAgentPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>
    {
        public NetworkCloudAgentPoolData(Azure.Core.AzureLocation location, long count, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode, string vmSkuName) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration AdministratorConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration AgentOptions { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration AttachedNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public long Count { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Labels { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode Mode { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> Taints { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string UpgradeMaxSurge { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public string VmSkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudAgentPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudAgentPoolResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string kubernetesClusterName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudBareMetalMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> Get(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> GetAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetIfExists(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> GetIfExistsAsync(string bareMetalMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>
    {
        public NetworkCloudBareMetalMachineData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string bmcConnectionString, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, string machineDetails, string machineName, string machineSkuId, Azure.Core.ResourceIdentifier rackId, long rackSlot, string serialNumber) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.ActionState> ActionStates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public string BmcConnectionString { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials BmcCredentials { get { throw null; } set { } }
        public string BmcMacAddress { get { throw null; } set { } }
        public string BootMacAddress { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.CertificateInfo CaCertificate { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? CordonStatus { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.HardwareInventory HardwareInventory { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus HardwareValidationStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> HybridAksClustersAssociatedIds { get { throw null; } }
        public string KubernetesNodeName { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public string MachineClusterVersion { get { throw null; } set { } }
        public string MachineDetails { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> MachineRoles { get { throw null; } }
        public string MachineSkuId { get { throw null; } set { } }
        public System.Net.IPAddress OamIPv4Address { get { throw null; } }
        public string OamIPv6Address { get { throw null; } }
        public string OSImage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier RackId { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? ReadyState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus RuntimeProtectionStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> SecretRotationStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string ServiceTag { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualMachinesAssociatedIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineKeySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudBareMetalMachineKeySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bareMetalMachineKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> Get(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> GetAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> GetIfExists(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> GetIfExistsAsync(string bareMetalMachineKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineKeySetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>
    {
        public NetworkCloudBareMetalMachineKeySetData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, System.DateTimeOffset expireOn, System.Collections.Generic.IEnumerable<System.Net.IPAddress> jumpHostsAllowed, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList) { }
        public string AzureGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> JumpHostsAllowed { get { throw null; } }
        public System.DateTimeOffset? LastValidatedOn { get { throw null; } }
        public string OSGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel PrivilegeLevel { get { throw null; } set { } }
        public string PrivilegeLevelName { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> UserListStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineKeySetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudBareMetalMachineKeySetResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string bareMetalMachineKeySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RunDataExtracts(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters bareMetalMachineRunDataExtractsParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunDataExtractsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunDataExtractsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters bareMetalMachineRunDataExtractsParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RunDataExtractsRestricted(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters bareMetalMachineRunDataExtractsRestrictedParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunDataExtractsRestrictedAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters bareMetalMachineRunDataExtractsRestrictedParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RunReadCommands(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunReadCommandsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Uncordon(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> UncordonAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudBmcKeySetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudBmcKeySetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bmcKeySetName, Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> Get(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> GetAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> GetIfExists(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> GetIfExistsAsync(string bmcKeySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudBmcKeySetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>
    {
        public NetworkCloudBmcKeySetData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, System.DateTimeOffset expireOn, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList) { }
        public string AzureGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.DateTimeOffset ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.DateTimeOffset? LastValidatedOn { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel PrivilegeLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> UserListStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudBmcKeySetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudBmcKeySetResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string bmcKeySetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudCloudServicesNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudCloudServicesNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudServicesNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> Get(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetIfExists(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetIfExistsAsync(string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudCloudServicesNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>
    {
        public NetworkCloudCloudServicesNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> AdditionalEgressEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? EnableDefaultEgressEndpoints { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> EnabledEgressEndpoints { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> HybridAksClustersAssociatedIds { get { throw null; } }
        public string InterfaceName { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions StorageOptions { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus StorageStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VirtualMachinesAssociatedIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudCloudServicesNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudCloudServicesNetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudServicesNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>
    {
        public NetworkCloudClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType, string clusterVersion, Azure.Core.ResourceIdentifier networkFabricId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.ActionState> ActionStates { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition AggregatorOrSingleRackDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings AnalyticsOutputSettings { get { throw null; } set { } }
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
        public Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings CommandOutputSettings { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold ComputeDeploymentThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> ComputeRackDefinitions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation HybridAksExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public long? ManualActionCount { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkFabricId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel? RuntimeProtectionEnforcementLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive SecretArchive { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings SecretArchiveSettings { get { throw null; } set { } }
        public System.DateTimeOffset? SupportExpireOn { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy UpdateStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan? VulnerabilityScanningContainerScan { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> WorkloadResourceIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudClusterManagerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudClusterManagerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterManagerName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> Get(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetIfExists(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetIfExistsAsync(string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudClusterManagerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>
    {
        public NetworkCloudClusterManagerData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier fabricControllerId) { }
        public Azure.Core.ResourceIdentifier AnalyticsWorkspaceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> ClusterVersions { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricControllerId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ManagerExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? ProvisioningState { get { throw null; } }
        public string VmSize { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudClusterManagerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudClusterManagerResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterManagerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudClusterMetricsConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudClusterMetricsConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string metricsConfigurationName, Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> Get(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> GetAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> GetIfExists(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> GetIfExistsAsync(string metricsConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudClusterMetricsConfigurationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>
    {
        public NetworkCloudClusterMetricsConfigurationData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, long collectionInterval) { }
        public long CollectionInterval { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DisabledMetrics { get { throw null; } }
        public System.Collections.Generic.IList<string> EnabledMetrics { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudClusterMetricsConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudClusterMetricsConfigurationResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string metricsConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudClusterResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> ContinueUpdateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> ContinueUpdateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> ScanRuntime(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> ScanRuntimeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetResource GetNetworkCloudBmcKeySetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource>> GetNetworkCloudCloudServicesNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudServicesNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource GetNetworkCloudCloudServicesNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkCollection GetNetworkCloudCloudServicesNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource>> GetNetworkCloudClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManager(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource>> GetNetworkCloudClusterManagerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterManagerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource GetNetworkCloudClusterManagerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerCollection GetNetworkCloudClusterManagers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationResource GetNetworkCloudClusterMetricsConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource GetNetworkCloudClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterCollection GetNetworkCloudClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetNetworkCloudKubernetesClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource GetNetworkCloudKubernetesClusterFeatureResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource GetNetworkCloudKubernetesClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterCollection GetNetworkCloudKubernetesClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Network(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetNetworkCloudL2NetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource GetNetworkCloudL2NetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkCollection GetNetworkCloudL2Networks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Network(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetNetworkCloudL3NetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource GetNetworkCloudL3NetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkCollection GetNetworkCloudL3Networks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Networks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3NetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetNetworkCloudRackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource GetNetworkCloudRackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackCollection GetNetworkCloudRacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> GetNetworkCloudRackSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetNetworkCloudRackSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource GetNetworkCloudRackSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuCollection GetNetworkCloudRackSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetNetworkCloudStorageApplianceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource GetNetworkCloudStorageApplianceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceCollection GetNetworkCloudStorageAppliances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetwork(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetNetworkCloudTrunkedNetworkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource GetNetworkCloudTrunkedNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkCollection GetNetworkCloudTrunkedNetworks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> GetNetworkCloudVirtualMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource GetNetworkCloudVirtualMachineConsoleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource GetNetworkCloudVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineCollection GetNetworkCloudVirtualMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolume(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetNetworkCloudVolumeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource GetNetworkCloudVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeCollection GetNetworkCloudVolumes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudKubernetesClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kubernetesClusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kubernetesClusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kubernetesClusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kubernetesClusterName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> Get(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetAsync(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetIfExists(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetIfExistsAsync(string kubernetesClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus> FeatureStatuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration> InitialAgentPoolConfigurations { get { throw null; } }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration ManagedResourceGroupConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode> Nodes { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterFeatureCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudKubernetesClusterFeatureCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string featureName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string featureName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string featureName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string featureName, Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> Get(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> GetAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> GetIfExists(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> GetIfExistsAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterFeatureData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>
    {
        public NetworkCloudKubernetesClusterFeatureData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle? AvailabilityLifecycle { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair> Options { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired? Required { get { throw null; } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterFeatureResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudKubernetesClusterFeatureResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string kubernetesClusterName, string featureName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudKubernetesClusterResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string kubernetesClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource> GetNetworkCloudAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolResource>> GetNetworkCloudAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolCollection GetNetworkCloudAgentPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource> GetNetworkCloudKubernetesClusterFeature(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource>> GetNetworkCloudKubernetesClusterFeatureAsync(string featureName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureCollection GetNetworkCloudKubernetesClusterFeatures() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RestartNode(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RestartNodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudL2NetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudL2NetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l2NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> Get(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetIfExists(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetIfExistsAsync(string l2NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudL2NetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>
    {
        public NetworkCloudL2NetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.Core.ResourceIdentifier l2IsolationDomainId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier L2IsolationDomainId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VirtualMachinesAssociatedIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudL2NetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudL2NetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l2NetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudL3NetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudL3NetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string l3NetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> Get(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetIfExists(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetIfExistsAsync(string l3NetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudL3NetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>
    {
        public NetworkCloudL3NetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.Core.ResourceIdentifier l3IsolationDomainId, long vlan) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudL3NetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudL3NetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string l3NetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudRackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudRackCollection() { }
        public virtual Azure.Response<bool> Exists(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> Get(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetIfExists(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> GetIfExistsAsync(string rackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudRackData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>
    {
        public NetworkCloudRackData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string availabilityZone, string rackLocation, string rackSerialNumber, Azure.Core.ResourceIdentifier rackSkuId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? ProvisioningState { get { throw null; } }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RackSkuId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudRackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>
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
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
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
    public partial class NetworkCloudRackSkuData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudRackSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudRackSkuResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string rackSkuName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudStorageApplianceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudStorageApplianceCollection() { }
        public virtual Azure.Response<bool> Exists(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> Get(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetIfExists(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> GetIfExistsAsync(string storageApplianceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudStorageApplianceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>
    {
        public NetworkCloudStorageApplianceData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials, Azure.Core.ResourceIdentifier rackId, long rackSlot, string serialNumber, string storageApplianceSkuId) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials AdministratorCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.CertificateInfo CaCertificate { get { throw null; } }
        public long? Capacity { get { throw null; } }
        public long? CapacityUsed { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Net.IPAddress ManagementIPv4Address { get { throw null; } }
        public string Manufacturer { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier RackId { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? RemoteVendorManagementFeature { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? RemoteVendorManagementStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> SecretRotationStatus { get { throw null; } }
        public string SerialNumber { get { throw null; } set { } }
        public string StorageApplianceSkuId { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudStorageApplianceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> RunReadCommands(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> RunReadCommandsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudTrunkedNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudTrunkedNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trunkedNetworkName, Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> Get(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetIfExists(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetIfExistsAsync(string trunkedNetworkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudTrunkedNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>
    {
        public NetworkCloudTrunkedNetworkData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> isolationDomainIds, System.Collections.Generic.IEnumerable<long> vlans) { }
        public System.Collections.Generic.IReadOnlyList<string> AssociatedResourceIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> HybridAksClustersAssociatedIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? HybridAksPluginType { get { throw null; } set { } }
        public string InterfaceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> IsolationDomainIds { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VirtualMachinesAssociatedIds { get { throw null; } }
        public System.Collections.Generic.IList<long> Vlans { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudTrunkedNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudTrunkedNetworkResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trunkedNetworkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudVirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualMachineName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> Get(string virtualMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consoleName, Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> Get(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> GetAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> GetIfExists(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> GetIfExistsAsync(string consoleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudVirtualMachineConsoleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>
    {
        public NetworkCloudVirtualMachineConsoleData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey sshPublicKey) { }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled Enabled { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkServiceId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? VirtualMachineAccessId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudVirtualMachineConsoleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudVirtualMachineConsoleResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName, string consoleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudVirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>
    {
        public NetworkCloudVirtualMachineData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string adminUsername, Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment, long cpuCores, long memorySizeInGB, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile storageProfile, string vmImage) { }
        public string AdminUsername { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } }
        public Azure.Core.ResourceIdentifier BareMetalMachineId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? BootMethod { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment CloudServicesNetworkAttachment { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ConsoleExtendedLocation { get { throw null; } set { } }
        public long CpuCores { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? IsolateEmulatorThread { get { throw null; } set { } }
        public long MemorySizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> NetworkAttachments { get { throw null; } }
        public string NetworkData { get { throw null; } set { } }
        public string NetworkDataContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> PlacementHints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> SshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile StorageProfile { get { throw null; } set { } }
        public string UserData { get { throw null; } set { } }
        public string UserDataContent { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? VirtioInterface { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? VmDeviceModel { get { throw null; } set { } }
        public string VmImage { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> Volumes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudVirtualMachineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudVirtualMachineResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> AssignRelay(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> AssignRelayAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class NetworkCloudVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>, System.Collections.IEnumerable
    {
        protected NetworkCloudVolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetIfExists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetIfExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkCloudVolumeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>
    {
        public NetworkCloudVolumeData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, long sizeInMiB) { }
        public long? AllocatedSizeMiB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AttachedTo { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? ProvisioningState { get { throw null; } }
        public string SerialNumber { get { throw null; } }
        public long SizeInMiB { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageApplianceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkCloudVolumeResource() { }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Delete(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> DeleteWithResponse(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>> DeleteWithResponseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> Update(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch patch, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource>> UpdateAsync(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch patch, System.Threading.CancellationToken cancellationToken) { throw null; }
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
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureResource GetNetworkCloudKubernetesClusterFeatureResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachines(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineResource> GetNetworkCloudBareMetalMachinesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineCollection GetNetworkCloudBareMetalMachinesClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworks(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworks(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworksAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkResource> GetNetworkCloudCloudServicesNetworksAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkCollection GetNetworkCloudCloudServicesNetworksClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagers(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagers(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagersAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerResource> GetNetworkCloudClusterManagersAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerCollection GetNetworkCloudClusterManagersClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClusters(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClusters(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClustersAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudClusterResource> GetNetworkCloudClustersAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudClusterCollection GetNetworkCloudClustersClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClusters(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClusters(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClustersAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterResource> GetNetworkCloudKubernetesClustersAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterCollection GetNetworkCloudKubernetesClustersClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Networks(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2Networks(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2NetworksAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkResource> GetNetworkCloudL2NetworksAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkCollection GetNetworkCloudL2NetworksClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Networks(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3Networks(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3NetworksAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkResource> GetNetworkCloudL3NetworksAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkCollection GetNetworkCloudL3NetworksClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacks(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacks(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacksAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudRackResource> GetNetworkCloudRacksAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackCollection GetNetworkCloudRacksClient() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource> GetNetworkCloudRackSku(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuResource>> GetNetworkCloudRackSkuAsync(string rackSkuName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuCollection GetNetworkCloudRackSkus() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliances(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliances(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliancesAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceResource> GetNetworkCloudStorageAppliancesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceCollection GetNetworkCloudStorageAppliancesClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworks(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworks(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworksAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkResource> GetNetworkCloudTrunkedNetworksAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkCollection GetNetworkCloudTrunkedNetworksClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachines(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachines(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachinesAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineResource> GetNetworkCloudVirtualMachinesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineCollection GetNetworkCloudVirtualMachinesClient() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumes(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumes(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumesAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeResource> GetNetworkCloudVolumesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeCollection GetNetworkCloudVolumesClient() { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class ActionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ActionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ActionState>
    {
        internal ActionState() { }
        public string ActionType { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string EndTime { get { throw null; } }
        public string Message { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.StepState> StepStates { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ActionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ActionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ActionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ActionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ActionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ActionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ActionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionStateStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus InProgress { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus left, Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus left, Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdministrativeCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials>
    {
        public AdministrativeCredentials(string username) { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdministratorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration>
    {
        public AdministratorConfiguration() { }
        public string AdminUsername { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> SshPublicKeys { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AgentPoolUpgradeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings>
    {
        public AgentPoolUpgradeSettings() { }
        public long? DrainTimeout { get { throw null; } set { } }
        public string MaxSurge { get { throw null; } set { } }
        public string MaxUnavailable { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyticsOutputSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings>
    {
        public AnalyticsOutputSettings() { }
        public Azure.Core.ResourceIdentifier AnalyticsWorkspaceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector AssociatedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmNetworkCloudModelFactory
    {
        public static Azure.ResourceManager.NetworkCloud.Models.ActionState ActionState(string actionType = null, string correlationId = null, string endTime = null, string message = null, string startTime = null, Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus? status = default(Azure.ResourceManager.NetworkCloud.Models.ActionStateStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StepState> stepStates = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade AvailableUpgrade(Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle? availabilityLifecycle = default(Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle?), string version = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification BareMetalMachineCommandSpecification(System.Collections.Generic.IEnumerable<string> arguments = null, string command = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration BareMetalMachineConfiguration(string bmcConnectionString = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, string machineDetails = null, string machineName = null, long rackSlot = (long)0, string serialNumber = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent BareMetalMachineRunCommandContent(System.Collections.Generic.IEnumerable<string> arguments = null, long limitTimeSeconds = (long)0, string script = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CertificateInfo CertificateInfo(string hash = null, string value = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus CloudServicesNetworkStorageStatus(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode? mode = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode?), long? sizeMiB = default(long?), Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus? status = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus?), string statusMessage = null, Azure.Core.ResourceIdentifier volumeId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion ClusterAvailableUpgradeVersion(Azure.ResourceManager.NetworkCloud.Models.ControlImpact? controlImpact = default(Azure.ResourceManager.NetworkCloud.Models.ControlImpact?), string expectedDuration = null, string impactDescription = null, System.DateTimeOffset? supportExpireOn = default(System.DateTimeOffset?), string targetClusterVersion = null, Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact? workloadImpact = default(Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion ClusterAvailableVersion(string supportExpiryDate = null, string targetClusterVersion = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity ClusterCapacity(long? availableApplianceStorageGB = default(long?), long? availableCoreCount = default(long?), long? availableHostStorageGB = default(long?), long? availableMemoryGB = default(long?), long? totalApplianceStorageGB = default(long?), long? totalCoreCount = default(long?), long? totalHostStorageGB = default(long?), long? totalMemoryGB = default(long?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.FeatureStatus FeatureStatus(Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus?), string detailedStatusMessage = null, string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareInventory HardwareInventory(string additionalHostInformation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface> interfaces = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic> nics = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface HardwareInventoryNetworkInterface(string linkStatus = null, string macAddress = null, string name = null, string networkInterfaceId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus HardwareValidationStatus(System.DateTimeOffset? lastValidationOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult? result = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus KeySetUserStatus(string azureUserName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus? status = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus?), string statusMessage = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode KubernetesClusterNode(Azure.Core.ResourceIdentifier agentPoolArmId = null, string availabilityZone = null, Azure.Core.ResourceIdentifier bareMetalMachineArmId = null, long? cpuCores = default(long?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus?), string detailedStatusMessage = null, long? diskSizeGB = default(long?), string image = null, string kubernetesVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels = null, long? memorySizeGB = default(long?), Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode? mode = default(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode?), string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState?), Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole? role = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints = null, string vmSkuName = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode KubernetesClusterNode(string agentPoolId, string availabilityZone, string bareMetalMachineId, long? cpuCores, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNodeDetailedStatus? detailedStatus, string detailedStatusMessage, long? diskSizeGB, string image, string kubernetesVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels, long? memorySizeGB, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode? mode, string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodePowerState? powerState, Azure.ResourceManager.NetworkCloud.Models.KubernetesNodeRole? role, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints, string vmSkuName) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor LldpNeighbor(string portDescription = null, string portName = null, string systemDescription = null, string systemName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineDisk MachineDisk(long? capacityGB = default(long?), Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType? connection = default(Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType?), Azure.ResourceManager.NetworkCloud.Models.DiskType? diskType = default(Azure.ResourceManager.NetworkCloud.Models.DiskType?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot MachineSkuSlot(long? rackSlot = default(long?), Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol? bootstrapProtocol = default(Azure.ResourceManager.NetworkCloud.Models.BootstrapProtocol?), long? cpuCores = default(long?), long? cpuSockets = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineDisk> disks = null, string generation = null, string hardwareVersion = null, long? memoryCapacityGB = default(long?), string model = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface> networkInterfaces = null, long? totalThreads = default(long?), string vendor = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment NetworkAttachment(Azure.Core.ResourceIdentifier attachedNetworkArmId = null, Azure.ResourceManager.NetworkCloud.Models.DefaultGateway? defaultGateway = default(Azure.ResourceManager.NetworkCloud.Models.DefaultGateway?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod ipAllocationMethod = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod), string ipv4Address = null, string ipv6Address = null, string macAddress = null, string networkAttachmentName = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment NetworkAttachment(string attachedNetworkId, Azure.ResourceManager.NetworkCloud.Models.DefaultGateway? defaultGateway, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod ipAllocationMethod, string ipv4Address, string ipv6Address, string macAddress, string networkAttachmentName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData NetworkCloudAgentPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration agentOptions, Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration attachedNetworkConfiguration, System.Collections.Generic.IEnumerable<string> availabilityZones, long count, Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus? detailedStatus, string detailedStatusMessage, string kubernetesVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode, Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints, Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings upgradeSettings, string vmSkuName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData NetworkCloudAgentPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration agentOptions, Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration attachedNetworkConfiguration, System.Collections.Generic.IEnumerable<string> availabilityZones, long count, Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus? detailedStatus, string detailedStatusMessage, string kubernetesVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode, Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints, string upgradeMaxSurge, string vmSkuName) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudAgentPoolData NetworkCloudAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration agentOptions = null, Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration attachedNetworkConfiguration = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, long count = (long)0, Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.AgentPoolDetailedStatus?), string detailedStatusMessage = null, string kubernetesVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> labels = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode mode = default(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolMode), Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.AgentPoolProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel> taints = null, Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings upgradeSettings = null, string vmSkuName = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData NetworkCloudBareMetalMachineData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds, string bmcConnectionString, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? cordonStatus, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.HardwareInventory hardwareInventory, Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus hardwareValidationStatus, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds, string kubernetesNodeName, string kubernetesVersion, string machineClusterVersion, string machineDetails, string machineName, System.Collections.Generic.IEnumerable<string> machineRoles, string machineSkuId, System.Net.IPAddress oamIPv4Address, string oamIPv6Address, string osImage, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? powerState, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? provisioningState, Azure.Core.ResourceIdentifier rackId, long rackSlot, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? readyState, Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus runtimeProtectionStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus, string serialNumber, string serviceTag, System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData NetworkCloudBareMetalMachineData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds, string bmcConnectionString, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? cordonStatus, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.HardwareInventory hardwareInventory, Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus hardwareValidationStatus, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds, string kubernetesNodeName, string kubernetesVersion, string machineDetails, string machineName, string machineSkuId, System.Net.IPAddress oamIPv4Address, string oamIPv6Address, string osImage, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? powerState, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? provisioningState, Azure.Core.ResourceIdentifier rackId, long rackSlot, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? readyState, string serialNumber, string serviceTag, System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData NetworkCloudBareMetalMachineData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds, string bmcConnectionString, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? cordonStatus, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.HardwareInventory hardwareInventory, Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus hardwareValidationStatus, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds, string kubernetesNodeName, string kubernetesVersion, string machineClusterVersion, string machineDetails, string machineName, System.Collections.Generic.IEnumerable<string> machineRoles, string machineSkuId, System.Net.IPAddress oamIPv4Address, string oamIPv6Address, string osImage, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? powerState, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? provisioningState, Azure.Core.ResourceIdentifier rackId, long rackSlot, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? readyState, Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus runtimeProtectionStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus, string serialNumber, string serviceTag, System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineData NetworkCloudBareMetalMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ActionState> actionStates = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, string bmcConnectionString = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials bmcCredentials = null, string bmcMacAddress = null, string bootMacAddress = null, Azure.ResourceManager.NetworkCloud.Models.CertificateInfo caCertificate = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus? cordonStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonStatus?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.HardwareInventory hardwareInventory = null, Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus hardwareValidationStatus = null, System.Collections.Generic.IEnumerable<string> hybridAksClustersAssociatedIds = null, string kubernetesNodeName = null, string kubernetesVersion = null, string machineClusterVersion = null, string machineDetails = null, string machineName = null, System.Collections.Generic.IEnumerable<string> machineRoles = null, string machineSkuId = null, System.Net.IPAddress oamIPv4Address = null, string oamIPv6Address = null, string osImage = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineProvisioningState?), Azure.Core.ResourceIdentifier rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState? readyState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReadyState?), Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus runtimeProtectionStatus = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus = null, string serialNumber = null, string serviceTag = null, System.Collections.Generic.IEnumerable<string> virtualMachinesAssociatedIds = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, System.DateTimeOffset expireOn, System.Collections.Generic.IEnumerable<System.Net.IPAddress> jumpHostsAllowed, System.DateTimeOffset? lastValidatedOn, string osGroupName, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, System.DateTimeOffset expireOn, System.Collections.Generic.IEnumerable<System.Net.IPAddress> jumpHostsAllowed, System.DateTimeOffset? lastValidatedOn, string osGroupName, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBareMetalMachineKeySetData NetworkCloudBareMetalMachineKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<System.Net.IPAddress> jumpHostsAllowed = null, System.DateTimeOffset? lastValidatedOn = default(System.DateTimeOffset?), string osGroupName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel), string privilegeLevelName = null, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData NetworkCloudBmcKeySetData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string azureGroupId, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? detailedStatus, string detailedStatusMessage, System.DateTimeOffset expireOn, System.DateTimeOffset? lastValidatedOn, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudBmcKeySetData NetworkCloudBmcKeySetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string azureGroupId = null, Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetDetailedStatus?), string detailedStatusMessage = null, System.DateTimeOffset expireOn = default(System.DateTimeOffset), System.DateTimeOffset? lastValidatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel privilegeLevel = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetPrivilegeLevel), Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.BmcKeySetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> userList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus> userListStatus = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> additionalEgressEndpoints, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> enabledEgressEndpoints, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds, string interfaceName, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> additionalEgressEndpoints = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> enabledEgressEndpoints = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState?), Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions storageOptions = null, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus storageStatus = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudCloudServicesNetworkData NetworkCloudCloudServicesNetworkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> additionalEgressEndpoints, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? enableDefaultEgressEndpoints, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> enabledEgressEndpoints, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds, string interfaceName, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData NetworkCloudClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, Azure.Core.ResourceIdentifier analyticsWorkspaceId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> availableUpgradeVersions, Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity clusterCapacity, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? clusterConnectionStatus, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation clusterExtendedLocation, string clusterLocation, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? clusterManagerConnectionStatus, Azure.Core.ResourceIdentifier clusterManagerId, Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation clusterServicePrincipal, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType, string clusterVersion, Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings commandOutputSettings, Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold computeDeploymentThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> computeRackDefinitions, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation hybridAksExtendedLocation, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration, long? manualActionCount, Azure.Core.ResourceIdentifier networkFabricId, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? provisioningState, Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel? runtimeProtectionEnforcementLevel, Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive secretArchive, System.DateTimeOffset? supportExpireOn, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy updateStrategy, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workloadResourceIds) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData NetworkCloudClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, Azure.Core.ResourceIdentifier analyticsWorkspaceId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> availableUpgradeVersions, Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity clusterCapacity, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? clusterConnectionStatus, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation clusterExtendedLocation, string clusterLocation, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? clusterManagerConnectionStatus, Azure.Core.ResourceIdentifier clusterManagerId, Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation clusterServicePrincipal, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType, string clusterVersion, Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold computeDeploymentThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> computeRackDefinitions, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation hybridAksExtendedLocation, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration, long? manualActionCount, Azure.Core.ResourceIdentifier networkFabricId, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? provisioningState, System.DateTimeOffset? supportExpireOn, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workloadResourceIds) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData NetworkCloudClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition, Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings analyticsOutputSettings, Azure.Core.ResourceIdentifier analyticsWorkspaceId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> availableUpgradeVersions, Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity clusterCapacity, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? clusterConnectionStatus, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation clusterExtendedLocation, string clusterLocation, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? clusterManagerConnectionStatus, Azure.Core.ResourceIdentifier clusterManagerId, Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation clusterServicePrincipal, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType, string clusterVersion, Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings commandOutputSettings, Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold computeDeploymentThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> computeRackDefinitions, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation hybridAksExtendedLocation, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration, long? manualActionCount, Azure.Core.ResourceIdentifier networkFabricId, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? provisioningState, Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel? runtimeProtectionEnforcementLevel, Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive secretArchive, Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings secretArchiveSettings, System.DateTimeOffset? supportExpireOn, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy updateStrategy, Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan? vulnerabilityScanningContainerScan, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workloadResourceIds) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterData NetworkCloudClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ActionState> actionStates = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition aggregatorOrSingleRackDefinition = null, Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings analyticsOutputSettings = null, Azure.Core.ResourceIdentifier analyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion> availableUpgradeVersions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity clusterCapacity = null, Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus? clusterConnectionStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation clusterExtendedLocation = null, string clusterLocation = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus? clusterManagerConnectionStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerConnectionStatus?), Azure.Core.ResourceIdentifier clusterManagerId = null, Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation clusterServicePrincipal = null, Azure.ResourceManager.NetworkCloud.Models.ClusterType clusterType = default(Azure.ResourceManager.NetworkCloud.Models.ClusterType), string clusterVersion = null, Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings commandOutputSettings = null, Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold computeDeploymentThreshold = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> computeRackDefinitions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation hybridAksExtendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, long? manualActionCount = default(long?), Azure.Core.ResourceIdentifier networkFabricId = null, Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterProvisioningState?), Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel? runtimeProtectionEnforcementLevel = default(Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel?), Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive secretArchive = null, Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings secretArchiveSettings = null, System.DateTimeOffset? supportExpireOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy updateStrategy = null, Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan? vulnerabilityScanningContainerScan = default(Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> workloadResourceIds = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData NetworkCloudClusterManagerData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier analyticsWorkspaceId, System.Collections.Generic.IEnumerable<string> availabilityZones, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> clusterVersions, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.Core.ResourceIdentifier fabricControllerId, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation managerExtendedLocation, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? provisioningState, string vmSize) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData NetworkCloudClusterManagerData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.Core.ResourceIdentifier analyticsWorkspaceId, System.Collections.Generic.IEnumerable<string> availabilityZones, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> clusterVersions, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.Core.ResourceIdentifier fabricControllerId, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation managerExtendedLocation, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? provisioningState, string vmSize) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterManagerData NetworkCloudClusterManagerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier analyticsWorkspaceId = null, System.Collections.Generic.IEnumerable<string> availabilityZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion> clusterVersions = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerDetailedStatus?), string detailedStatusMessage = null, Azure.Core.ResourceIdentifier fabricControllerId = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation managerExtendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterManagerProvisioningState?), string vmSize = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData NetworkCloudClusterMetricsConfigurationData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, long collectionInterval, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? detailedStatus, string detailedStatusMessage, System.Collections.Generic.IEnumerable<string> disabledMetrics, System.Collections.Generic.IEnumerable<string> enabledMetrics, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudClusterMetricsConfigurationData NetworkCloudClusterMetricsConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, long collectionInterval = (long)0, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<string> disabledMetrics = null, System.Collections.Generic.IEnumerable<string> enabledMetrics = null, Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ClusterMetricsConfigurationProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData NetworkCloudKubernetesClusterData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> aadAdminGroupObjectIds, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> attachedNetworkIds, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade> availableUpgrades, Azure.Core.ResourceIdentifier clusterId, Azure.Core.ResourceIdentifier connectedClusterId, string controlPlaneKubernetesVersion, Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration controlPlaneNodeConfiguration, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus? detailedStatus, string detailedStatusMessage, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus> featureStatuses, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration> initialAgentPoolConfigurations, string kubernetesVersion, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration networkConfiguration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode> nodes, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterData NetworkCloudKubernetesClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> aadAdminGroupObjectIds = null, Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration administratorConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> attachedNetworkIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade> availableUpgrades = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.Core.ResourceIdentifier connectedClusterId = null, string controlPlaneKubernetesVersion = null, Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration controlPlaneNodeConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus> featureStatuses = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration> initialAgentPoolConfigurations = null, string kubernetesVersion = null, Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration managedResourceGroupConfiguration = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration networkConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode> nodes = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData NetworkCloudKubernetesClusterFeatureData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle? availabilityLifecycle = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair> options = null, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState?), Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired? required = default(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired?), string version = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudKubernetesClusterFeatureData NetworkCloudKubernetesClusterFeatureData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle? availabilityLifecycle, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus? detailedStatus, string detailedStatusMessage, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair> options, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState? provisioningState, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired? required, string version) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData NetworkCloudL2NetworkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? detailedStatus, string detailedStatusMessage, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType, string interfaceName, Azure.Core.ResourceIdentifier l2IsolationDomainId, Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL2NetworkData NetworkCloudL2NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, Azure.Core.ResourceIdentifier l2IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L2NetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData NetworkCloudL3NetworkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? detailedStatus, string detailedStatusMessage, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds, Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled? hybridAksIpamEnabled, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType, string interfaceName, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? ipAllocationType, string ipv4ConnectedPrefix, string ipv6ConnectedPrefix, Azure.Core.ResourceIdentifier l3IsolationDomainId, Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds, long vlan) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudL3NetworkData NetworkCloudL3NetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled? hybridAksIpamEnabled = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksIpamEnabled?), Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, Azure.ResourceManager.NetworkCloud.Models.IPAllocationType? ipAllocationType = default(Azure.ResourceManager.NetworkCloud.Models.IPAllocationType?), string ipv4ConnectedPrefix = null, string ipv6ConnectedPrefix = null, Azure.Core.ResourceIdentifier l3IsolationDomainId = null, Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.L3NetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null, long vlan = (long)0) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface NetworkCloudNetworkInterface(string address = null, Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType? deviceConnectionType = default(Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType?), string model = null, long? physicalSlot = default(long?), long? portCount = default(long?), long? portSpeed = default(long?), string vendor = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic NetworkCloudNic(Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor lldpNeighbor = null, string macAddress = null, string name = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult NetworkCloudOperationStatusResult(Azure.Core.ResourceIdentifier id, Azure.Core.ResourceIdentifier resourceId, string name, string status, float? percentComplete, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> operations, Azure.ResponseError error) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult NetworkCloudOperationStatusResult(System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResponseError error = null, Azure.Core.ResourceIdentifier id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> operations = null, float? percentComplete = default(float?), Azure.Core.ResourceIdentifier resourceId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string status = null, string exitCode = null, string outputHead = null, System.Uri resultRef = null, System.Uri resultUri = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackData NetworkCloudRackData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string availabilityZone, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? provisioningState, string rackLocation, string rackSerialNumber, Azure.Core.ResourceIdentifier rackSkuId) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackData NetworkCloudRackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, string availabilityZone = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.RackDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.RackProvisioningState?), string rackLocation = null, string rackSerialNumber = null, Azure.Core.ResourceIdentifier rackSkuId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudRackSkuData NetworkCloudRackSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> computeMachines = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot> controllerMachines = null, string description = null, long? maxClusterSlots = default(long?), Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState?), Azure.ResourceManager.NetworkCloud.Models.RackSkuType? rackType = default(Azure.ResourceManager.NetworkCloud.Models.RackSkuType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot> storageAppliances = null, System.Collections.Generic.IEnumerable<string> supportedRackSkuIds = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData NetworkCloudStorageApplianceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials, long? capacity, long? capacityUsed, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? detailedStatus, string detailedStatusMessage, System.Net.IPAddress managementIPv4Address, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? provisioningState, Azure.Core.ResourceIdentifier rackId, long rackSlot, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? remoteVendorManagementFeature, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? remoteVendorManagementStatus, string serialNumber, string storageApplianceSkuId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData NetworkCloudStorageApplianceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials, long? capacity, long? capacityUsed, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? detailedStatus, string detailedStatusMessage, System.Net.IPAddress managementIPv4Address, string manufacturer, string model, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? provisioningState, Azure.Core.ResourceIdentifier rackId, long rackSlot, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? remoteVendorManagementFeature, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? remoteVendorManagementStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus, string serialNumber, string storageApplianceSkuId, string version) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData NetworkCloudStorageApplianceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials = null, Azure.ResourceManager.NetworkCloud.Models.CertificateInfo caCertificate = null, long? capacity = default(long?), long? capacityUsed = default(long?), Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus?), string detailedStatusMessage = null, System.Net.IPAddress managementIPv4Address = null, string manufacturer = null, string model = null, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState?), Azure.Core.ResourceIdentifier rackId = null, long rackSlot = (long)0, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? remoteVendorManagementFeature = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature?), Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? remoteVendorManagementStatus = default(Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus = null, string serialNumber = null, string storageApplianceSkuId = null, string version = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudStorageApplianceData NetworkCloudStorageApplianceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials administratorCredentials, long? capacity, long? capacityUsed, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus? detailedStatus, string detailedStatusMessage, System.Net.IPAddress managementIPv4Address, string manufacturer, string model, Azure.ResourceManager.NetworkCloud.Models.StorageApplianceProvisioningState? provisioningState, Azure.Core.ResourceIdentifier rackId, long rackSlot, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementFeature? remoteVendorManagementFeature, Azure.ResourceManager.NetworkCloud.Models.RemoteVendorManagementStatus? remoteVendorManagementStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus> secretRotationStatus, string serialNumber, string storageApplianceSkuId, string version) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData NetworkCloudTrunkedNetworkData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> associatedResourceIds, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? detailedStatus, string detailedStatusMessage, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType, string interfaceName, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> isolationDomainIds, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds, System.Collections.Generic.IEnumerable<long> vlans) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudTrunkedNetworkData NetworkCloudTrunkedNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<string> associatedResourceIds = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkDetailedStatus?), string detailedStatusMessage = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hybridAksClustersAssociatedIds = null, Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType? hybridAksPluginType = default(Azure.ResourceManager.NetworkCloud.Models.HybridAksPluginType?), string interfaceName = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> isolationDomainIds = null, Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualMachinesAssociatedIds = null, System.Collections.Generic.IEnumerable<long> vlans = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData NetworkCloudVirtualMachineConsoleData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled, System.DateTimeOffset? expireOn, Azure.Core.ResourceIdentifier privateLinkServiceId, Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? provisioningState, string keyData, System.Guid? virtualMachineAccessId) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineConsoleData NetworkCloudVirtualMachineConsoleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled enabled = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier privateLinkServiceId = null, Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.ConsoleProvisioningState?), string keyData = null, System.Guid? virtualMachineAccessId = default(System.Guid?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string adminUsername, string availabilityZone, Azure.Core.ResourceIdentifier bareMetalMachineId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? bootMethod, Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment, Azure.Core.ResourceIdentifier clusterId, long cpuCores, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? isolateEmulatorThread, long memorySizeInGB, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments, string networkData, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> placementHints, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? powerState, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> sshPublicKeys, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile storageProfile, string userData, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? virtioInterface, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? vmDeviceModel, string vmImage, Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials vmImageRepositoryCredentials, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> volumes) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string adminUsername = null, string availabilityZone = null, Azure.Core.ResourceIdentifier bareMetalMachineId = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? bootMethod = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod?), Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation consoleExtendedLocation = null, long cpuCores = (long)0, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? isolateEmulatorThread = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread?), long memorySizeInGB = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments = null, string networkData = null, string networkDataContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> placementHints = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? powerState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> sshPublicKeys = null, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile storageProfile = null, string userData = null, string userDataContent = null, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? virtioInterface = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType?), Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? vmDeviceModel = default(Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType?), string vmImage = null, Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials vmImageRepositoryCredentials = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> volumes = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVirtualMachineData NetworkCloudVirtualMachineData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, string adminUsername, string availabilityZone, Azure.Core.ResourceIdentifier bareMetalMachineId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineBootMethod? bootMethod, Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment cloudServicesNetworkAttachment, Azure.Core.ResourceIdentifier clusterId, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation consoleExtendedLocation, long cpuCores, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIsolateEmulatorThread? isolateEmulatorThread, long memorySizeInGB, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment> networkAttachments, string networkData, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint> placementHints, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerState? powerState, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> sshPublicKeys, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile storageProfile, string userData, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineVirtioInterfaceType? virtioInterface, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType? vmDeviceModel, string vmImage, Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials vmImageRepositoryCredentials, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> volumes) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData NetworkCloudVolumeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> attachedTo, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? provisioningState, string serialNumber, long sizeInMiB) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData NetworkCloudVolumeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation, System.Collections.Generic.IEnumerable<string> attachedTo, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? detailedStatus, string detailedStatusMessage, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? provisioningState, string serialNumber, long sizeInMiB) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.NetworkCloudVolumeData NetworkCloudVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation extendedLocation = null, long? allocatedSizeMiB = default(long?), System.Collections.Generic.IEnumerable<string> attachedTo = null, Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus? detailedStatus = default(Azure.ResourceManager.NetworkCloud.Models.VolumeDetailedStatus?), string detailedStatusMessage = null, Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkCloud.Models.VolumeProvisioningState?), string serialNumber = null, long sizeInMiB = (long)0, Azure.Core.ResourceIdentifier storageApplianceId = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus RuntimeProtectionStatus(System.DateTimeOffset? definitionsLastUpdated = default(System.DateTimeOffset?), string definitionsVersion = null, System.DateTimeOffset? scanCompletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scanScheduledOn = default(System.DateTimeOffset?), System.DateTimeOffset? scanStartedOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference SecretArchiveReference(Azure.Core.ResourceIdentifier keyVaultId, string secretName, string secretVersion) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference SecretArchiveReference(Azure.Core.ResourceIdentifier keyVaultId = null, System.Uri keyVaultUri = null, string secretName = null, string secretVersion = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus SecretRotationStatus(long? expirePeriodDays = default(long?), System.DateTimeOffset? lastRotationOn = default(System.DateTimeOffset?), long? rotationPeriodDays = default(long?), Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference secretArchiveReference = null, string secretType = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StepState StepState(string endTime = null, string message = null, string startTime = null, Azure.ResourceManager.NetworkCloud.Models.StepStateStatus? status = default(Azure.ResourceManager.NetworkCloud.Models.StepStateStatus?), string stepName = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification StorageApplianceCommandSpecification(System.Collections.Generic.IEnumerable<string> arguments = null, string command = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot StorageApplianceSkuSlot(long? rackSlot = default(long?), long? capacityGB = default(long?), string model = null) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent VirtualMachineAssignRelayContent(Azure.Core.ResourceIdentifier machineId = null, Azure.ResourceManager.NetworkCloud.Models.RelayType? relayType = default(Azure.ResourceManager.NetworkCloud.Models.RelayType?)) { throw null; }
    }
    public partial class AttachedNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration>
    {
        public AttachedNetworkConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration> L2Networks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration> L3Networks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration> TrunkedNetworks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AvailableUpgrade : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>
    {
        internal AvailableUpgrade() { }
        public Azure.ResourceManager.NetworkCloud.Models.AvailabilityLifecycle? AvailabilityLifecycle { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.AvailableUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BareMetalMachineCommandSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification>
    {
        public BareMetalMachineCommandSpecification(string command) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BareMetalMachineConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BareMetalMachineCordonContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent>
    {
        public BareMetalMachineCordonContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineEvacuate? Evacuate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCordonContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetPrivilegeLevel Other { get { throw null; } }
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
    public partial class BareMetalMachinePowerOffContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent>
    {
        public BareMetalMachinePowerOffContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineSkipShutdown? SkipShutdown { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachinePowerOffContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BareMetalMachineReplaceContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent>
    {
        public BareMetalMachineReplaceContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials BmcCredentials { get { throw null; } set { } }
        public string BmcMacAddress { get { throw null; } set { } }
        public string BootMacAddress { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode? SafeguardMode { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy? StoragePolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineReplaceSafeguardMode : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineReplaceSafeguardMode(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode All { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceSafeguardMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BareMetalMachineReplaceStoragePolicy : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BareMetalMachineReplaceStoragePolicy(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy DiscardAll { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy Preserve { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy left, Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineReplaceStoragePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BareMetalMachineRunCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent>
    {
        public BareMetalMachineRunCommandContent(long limitTimeSeconds, string script) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
        public string Script { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BareMetalMachineRunDataExtractsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent>
    {
        public BareMetalMachineRunDataExtractsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> commands, long limitTimeSeconds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> Commands { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BareMetalMachineRunDataExtractsParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters>
    {
        public BareMetalMachineRunDataExtractsParameters(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> commands, long limitTimeSeconds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> Commands { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunDataExtractsParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BareMetalMachineRunReadCommandsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent>
    {
        public BareMetalMachineRunReadCommandsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> commands, long limitTimeSeconds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineCommandSpecification> Commands { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineRunReadCommandsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BgpAdvertisement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement>
    {
        public BgpAdvertisement(System.Collections.Generic.IEnumerable<string> ipAddressPools) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdvertiseToFabric? AdvertiseToFabric { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Communities { get { throw null; } }
        public System.Collections.Generic.IList<string> IPAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<string> Peers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BgpServiceLoadBalancerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration>
    {
        public BgpServiceLoadBalancerConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BgpAdvertisement> BgpAdvertisements { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer> BgpPeers { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.FabricPeeringEnabled? FabricPeeringEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool> IPAddressPools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CertificateInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CertificateInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CertificateInfo>
    {
        internal CertificateInfo() { }
        public string Hash { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CertificateInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CertificateInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CertificateInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CertificateInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CertificateInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CertificateInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CertificateInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudServicesNetworkStorageMode : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudServicesNetworkStorageMode(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode None { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudServicesNetworkStorageOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions>
    {
        public CloudServicesNetworkStorageOptions() { }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode? Mode { get { throw null; } set { } }
        public long? SizeMiB { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageApplianceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudServicesNetworkStorageOptionsPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch>
    {
        public CloudServicesNetworkStorageOptionsPatch() { }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode? Mode { get { throw null; } set { } }
        public long? SizeMiB { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageApplianceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudServicesNetworkStorageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus>
    {
        internal CloudServicesNetworkStorageStatus() { }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageMode? Mode { get { throw null; } }
        public long? SizeMiB { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public Azure.Core.ResourceIdentifier VolumeId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudServicesNetworkStorageStatusStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudServicesNetworkStorageStatusStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus ExpandingVolume { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus ExpansionFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus left, Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageStatusStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterAvailableUpgradeVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>
    {
        internal ClusterAvailableUpgradeVersion() { }
        public Azure.ResourceManager.NetworkCloud.Models.ControlImpact? ControlImpact { get { throw null; } }
        public string ExpectedDuration { get { throw null; } }
        public string ImpactDescription { get { throw null; } }
        public System.DateTimeOffset? SupportExpireOn { get { throw null; } }
        public string TargetClusterVersion { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.WorkloadImpact? WorkloadImpact { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableUpgradeVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAvailableVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>
    {
        internal ClusterAvailableVersion() { }
        public string SupportExpiryDate { get { throw null; } }
        public string TargetClusterVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterAvailableVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterConnectionStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus Connected { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterConnectionStatus Disconnected { get { throw null; } }
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
    public partial class ClusterContinueUpdateVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent>
    {
        public ClusterContinueUpdateVersionContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode? MachineGroupTargetingMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterContinueUpdateVersionMachineGroupTargetingMode : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterContinueUpdateVersionMachineGroupTargetingMode(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode AlphaByRack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode left, Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode left, Azure.ResourceManager.NetworkCloud.Models.ClusterContinueUpdateVersionMachineGroupTargetingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterDeployContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent>
    {
        public ClusterDeployContent() { }
        public System.Collections.Generic.IList<string> SkipValidationsForMachines { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterDeployContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterDetailedStatus UpdatePaused { get { throw null; } }
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
    public partial class ClusterScanRuntimeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent>
    {
        public ClusterScanRuntimeContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity? ScanActivity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterScanRuntimeParametersScanActivity : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterScanRuntimeParametersScanActivity(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity Scan { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity Skip { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity left, Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity left, Azure.ResourceManager.NetworkCloud.Models.ClusterScanRuntimeParametersScanActivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterSecretArchive : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive>
    {
        public ClusterSecretArchive(Azure.Core.ResourceIdentifier keyVaultId) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled? UseKeyVault { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterSecretArchiveEnabled : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterSecretArchiveEnabled(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled left, Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled left, Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchiveEnabled right) { throw null; }
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
    public partial class ClusterUpdateStrategy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy>
    {
        public ClusterUpdateStrategy(Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType strategyType, Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType thresholdType, long thresholdValue) { }
        public long? MaxUnavailable { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType StrategyType { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType ThresholdType { get { throw null; } set { } }
        public long ThresholdValue { get { throw null; } set { } }
        public long? WaitTimeMinutes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterUpdateStrategyType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterUpdateStrategyType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType PauseAfterRack { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType Rack { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType left, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType left, Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterUpdateVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent>
    {
        public ClusterUpdateVersionContent(string targetClusterVersion) { }
        public string TargetClusterVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommandOutputOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride>
    {
        public CommandOutputOverride() { }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector AssociatedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.CommandOutputType? CommandOutputType { get { throw null; } set { } }
        public System.Uri ContainerUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommandOutputSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings>
    {
        public CommandOutputSettings() { }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector AssociatedIdentity { get { throw null; } set { } }
        public System.Uri ContainerUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.CommandOutputOverride> Overrides { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommandOutputType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.CommandOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommandOutputType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.CommandOutputType BareMetalMachineRunCommand { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CommandOutputType BareMetalMachineRunDataExtracts { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CommandOutputType BareMetalMachineRunReadCommands { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.CommandOutputType StorageRunReadCommands { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.CommandOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.CommandOutputType left, Azure.ResourceManager.NetworkCloud.Models.CommandOutputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.CommandOutputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.CommandOutputType left, Azure.ResourceManager.NetworkCloud.Models.CommandOutputType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ControlPlaneNodeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration>
    {
        public ControlPlaneNodeConfiguration(long count, string vmSkuName) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministratorConfiguration AdministratorConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvailabilityZones { get { throw null; } }
        public long Count { get { throw null; } set { } }
        public string VmSkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ControlPlaneNodePatchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration>
    {
        public ControlPlaneNodePatchConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> AdministratorSshPublicKeys { get { throw null; } }
        public long? Count { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EgressEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>
    {
        public EgressEndpoint(string category, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency> endpoints) { }
        public string Category { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency> Endpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency>
    {
        public EndpointDependency(string domainName) { }
        public string DomainName { get { throw null; } set { } }
        public long? Port { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.EndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.EndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.EndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation>
    {
        public ExtendedLocation(string name, string extendedLocationType) { }
        public string ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class FeatureStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>
    {
        internal FeatureStatus() { }
        public Azure.ResourceManager.NetworkCloud.Models.FeatureDetailedStatus? DetailedStatus { get { throw null; } }
        public string DetailedStatusMessage { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.FeatureStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.FeatureStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.FeatureStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareInventory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventory>
    {
        internal HardwareInventory() { }
        public string AdditionalHostInformation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface> Interfaces { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic> Nics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.HardwareInventory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.HardwareInventory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareInventoryNetworkInterface : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface>
    {
        internal HardwareInventoryNetworkInterface() { }
        public string LinkStatus { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } }
        public string NetworkInterfaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareInventoryNetworkInterface>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareValidationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus>
    {
        internal HardwareValidationStatus() { }
        public System.DateTimeOffset? LastValidationOn { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineHardwareValidationResult? Result { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.HardwareValidationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ImageRepositoryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials>
    {
        public ImageRepositoryCredentials(string registryUriString, string username) { }
        public string Password { get { throw null; } set { } }
        public string RegistryUriString { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InitialAgentPoolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string UpgradeMaxSurge { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        public string VmSkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.InitialAgentPoolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IPAddressPool : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool>
    {
        public IPAddressPool(System.Collections.Generic.IEnumerable<string> addresses, string name) { }
        public System.Collections.Generic.IList<string> Addresses { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BfdEnabled? AutoAssign { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BfdEnabled? OnlyUseHostIPs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.IPAddressPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.IPAddressPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class KeySetUser : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>
    {
        public KeySetUser(string azureUserName, Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey sshPublicKey) { }
        public string AzureUserName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KeySetUser System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KeySetUser System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeySetUserStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>
    {
        internal KeySetUserStatus() { }
        public string AzureUserName { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineKeySetUserSetupStatus? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KeySetUserStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterFeatureAvailabilityLifecycle : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterFeatureAvailabilityLifecycle(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle GenerallyAvailable { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle Preview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureAvailabilityLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterFeatureDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterFeatureDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus Installed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus Provisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureDetailedStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterFeatureProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterFeatureProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterFeatureRequired : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterFeatureRequired(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired False { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired left, Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterFeatureRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesClusterNetworkConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration>
    {
        public KubernetesClusterNetworkConfiguration(Azure.Core.ResourceIdentifier cloudServicesNetworkId, Azure.Core.ResourceIdentifier cniNetworkId) { }
        public Azure.ResourceManager.NetworkCloud.Models.AttachedNetworkConfiguration AttachedNetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration BgpServiceLoadBalancerConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CloudServicesNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CniNetworkId { get { throw null; } set { } }
        public System.Net.IPAddress DnsServiceIP { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.IPAddressPool> L2ServiceLoadBalancerIPAddressPools { get { throw null; } }
        public System.Collections.Generic.IList<string> PodCidrs { get { throw null; } }
        public System.Collections.Generic.IList<string> ServiceCidrs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNetworkConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterNode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>
    {
        internal KubernetesClusterNode() { }
        public Azure.Core.ResourceIdentifier AgentPoolArmId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string AgentPoolId { get { throw null; } }
        public string AvailabilityZone { get { throw null; } }
        public Azure.Core.ResourceIdentifier BareMetalMachineArmId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterNode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class KubernetesClusterRestartNodeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent>
    {
        public KubernetesClusterRestartNodeContent(string nodeName) { }
        public string NodeName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesClusterRestartNodeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesLabel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>
    {
        public KubernetesLabel(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.KubernetesLabel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class L2NetworkAttachmentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration>
    {
        public L2NetworkAttachmentConfiguration(Azure.Core.ResourceIdentifier networkId) { }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType? PluginType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L2NetworkAttachmentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class L3NetworkAttachmentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration>
    {
        public L3NetworkAttachmentConfiguration(Azure.Core.ResourceIdentifier networkId) { }
        public Azure.ResourceManager.NetworkCloud.Models.L3NetworkConfigurationIpamEnabled? IpamEnabled { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType? PluginType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.L3NetworkAttachmentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LldpNeighbor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor>
    {
        internal LldpNeighbor() { }
        public string PortDescription { get { throw null; } }
        public string PortName { get { throw null; } }
        public string SystemDescription { get { throw null; } }
        public string SystemName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.MachineDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineDisk>
    {
        internal MachineDisk() { }
        public long? CapacityGB { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.MachineSkuDiskConnectionType? Connection { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.DiskType? DiskType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.MachineDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.MachineDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.MachineDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.MachineDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MachineSkuSlot : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.MachineSkuSlot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedResourceGroupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration>
    {
        public ManagedResourceGroupConfiguration() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedResourceGroupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedServiceIdentitySelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector>
    {
        public ManagedServiceIdentitySelector() { }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentitySelectorType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentitySelectorType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType left, Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType left, Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelectorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkAttachment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>
    {
        public NetworkAttachment(Azure.Core.ResourceIdentifier attachedNetworkArmId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod ipAllocationMethod) { }
        public NetworkAttachment(string attachedNetworkId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod ipAllocationMethod) { }
        public Azure.Core.ResourceIdentifier AttachedNetworkArmId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string AttachedNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.DefaultGateway? DefaultGateway { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineIPAllocationMethod IPAllocationMethod { get { throw null; } set { } }
        public string IPv4Address { get { throw null; } set { } }
        public string IPv6Address { get { throw null; } set { } }
        public string MacAddress { get { throw null; } }
        public string NetworkAttachmentName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudAgentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration>
    {
        public NetworkCloudAgentConfiguration(long hugepagesCount) { }
        public long HugepagesCount { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.HugepagesSize? HugepagesSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class NetworkCloudAgentPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch>
    {
        public NetworkCloudAgentPoolPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> AdministratorSshPublicKeys { get { throw null; } }
        public long? Count { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string UpgradeMaxSurge { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AgentPoolUpgradeSettings UpgradeSettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudAgentPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachineKeySetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch>
    {
        public NetworkCloudBareMetalMachineKeySetPatch() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Net.IPAddress> JumpHostsAllowed { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachineKeySetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudBareMetalMachinePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch>
    {
        public NetworkCloudBareMetalMachinePatch() { }
        public string MachineDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBareMetalMachinePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudBmcKeySetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch>
    {
        public NetworkCloudBmcKeySetPatch() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.KeySetUser> UserList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudBmcKeySetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudCloudServicesNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch>
    {
        public NetworkCloudCloudServicesNetworkPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.EgressEndpoint> AdditionalEgressEndpoints { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkEnableDefaultEgressEndpoint? EnableDefaultEgressEndpoints { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.CloudServicesNetworkStorageOptionsPatch StorageOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudCloudServicesNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudClusterManagerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch>
    {
        public NetworkCloudClusterManagerPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterManagerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudClusterMetricsConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch>
    {
        public NetworkCloudClusterMetricsConfigurationPatch() { }
        public long? CollectionInterval { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnabledMetrics { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterMetricsConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch>
    {
        public NetworkCloudClusterPatch() { }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition AggregatorOrSingleRackDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.AnalyticsOutputSettings AnalyticsOutputSettings { get { throw null; } set { } }
        public string ClusterLocation { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation ClusterServicePrincipal { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.CommandOutputSettings CommandOutputSettings { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold ComputeDeploymentThreshold { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition> ComputeRackDefinitions { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel? RuntimeProtectionEnforcementLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterSecretArchive SecretArchive { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings SecretArchiveSettings { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ClusterUpdateStrategy UpdateStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan? VulnerabilityScanningContainerScan { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterFeaturePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch>
    {
        public NetworkCloudKubernetesClusterFeaturePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair> Options { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterFeaturePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudKubernetesClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch>
    {
        public NetworkCloudKubernetesClusterPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey> AdministratorSshPublicKeys { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ControlPlaneNodePatchConfiguration ControlPlaneNodeConfiguration { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? ControlPlaneNodeCount { get { throw null; } set { } }
        public string KubernetesVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudKubernetesClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudL2NetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch>
    {
        public NetworkCloudL2NetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL2NetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudL3NetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch>
    {
        public NetworkCloudL3NetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudL3NetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudNetworkInterface : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface>
    {
        internal NetworkCloudNetworkInterface() { }
        public string Address { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.DeviceConnectionType? DeviceConnectionType { get { throw null; } }
        public string Model { get { throw null; } }
        public long? PhysicalSlot { get { throw null; } }
        public long? PortCount { get { throw null; } }
        public long? PortSpeed { get { throw null; } }
        public string Vendor { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNetworkInterface>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudNic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic>
    {
        internal NetworkCloudNic() { }
        public Azure.ResourceManager.NetworkCloud.Models.LldpNeighbor LldpNeighbor { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudNic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudOperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>
    {
        internal NetworkCloudOperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string ExitCode { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult> Operations { get { throw null; } }
        public string OutputHead { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.Uri ResultRef { get { throw null; } }
        public System.Uri ResultUri { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudOSDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk>
    {
        public NetworkCloudOSDisk(long diskSizeInGB) { }
        public Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption? CreateOption { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.OSDiskDeleteOption? DeleteOption { get { throw null; } set { } }
        public long DiskSizeInGB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudRackDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>
    {
        public NetworkCloudRackDefinition(Azure.Core.ResourceIdentifier networkRackId, string rackSerialNumber, Azure.Core.ResourceIdentifier rackSkuId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.BareMetalMachineConfiguration> BareMetalMachineConfigurationData { get { throw null; } }
        public Azure.Core.ResourceIdentifier NetworkRackId { get { throw null; } set { } }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RackSkuId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration> StorageApplianceConfigurationData { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudRackPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch>
    {
        public NetworkCloudRackPatch() { }
        public string RackLocation { get { throw null; } set { } }
        public string RackSerialNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudRackPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudSshPublicKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>
    {
        public NetworkCloudSshPublicKey(string keyData) { }
        public string KeyData { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudSshPublicKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudStorageAppliancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch>
    {
        public NetworkCloudStorageAppliancePatch() { }
        public string SerialNumber { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageAppliancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile>
    {
        public NetworkCloudStorageProfile(Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk osDisk) { }
        public Azure.ResourceManager.NetworkCloud.Models.NetworkCloudOSDisk OSDisk { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VolumeAttachments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudTrunkedNetworkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch>
    {
        public NetworkCloudTrunkedNetworkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudTrunkedNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudVirtualMachineConsolePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch>
    {
        public NetworkCloudVirtualMachineConsolePatch() { }
        public Azure.ResourceManager.NetworkCloud.Models.ConsoleEnabled? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string KeyData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachineConsolePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudVirtualMachinePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch>
    {
        public NetworkCloudVirtualMachinePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.ImageRepositoryCredentials VmImageRepositoryCredentials { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVirtualMachinePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkCloudVolumePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch>
    {
        public NetworkCloudVolumePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.NetworkCloudVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSDiskCreateOption : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSDiskCreateOption(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption Ephemeral { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.OSDiskCreateOption Persistent { get { throw null; } }
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
        public static Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RackSkuProvisioningState Failed { get { throw null; } }
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
    public readonly partial struct RelayType : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RelayType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RelayType Platform { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RelayType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RelayType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RelayType left, Azure.ResourceManager.NetworkCloud.Models.RelayType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RelayType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RelayType left, Azure.ResourceManager.NetworkCloud.Models.RelayType right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuntimeProtectionEnforcementLevel : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuntimeProtectionEnforcementLevel(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel Audit { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel OnDemand { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel Passive { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel RealTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel left, Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel left, Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionEnforcementLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuntimeProtectionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus>
    {
        internal RuntimeProtectionStatus() { }
        public System.DateTimeOffset? DefinitionsLastUpdated { get { throw null; } }
        public string DefinitionsVersion { get { throw null; } }
        public System.DateTimeOffset? ScanCompletedOn { get { throw null; } }
        public System.DateTimeOffset? ScanScheduledOn { get { throw null; } }
        public System.DateTimeOffset? ScanStartedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.RuntimeProtectionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretArchiveReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference>
    {
        internal SecretArchiveReference() { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } }
        public System.Uri KeyVaultUri { get { throw null; } }
        public string SecretName { get { throw null; } }
        public string SecretVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretArchiveSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings>
    {
        public SecretArchiveSettings() { }
        public Azure.ResourceManager.NetworkCloud.Models.ManagedServiceIdentitySelector AssociatedIdentity { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretArchiveSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretRotationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>
    {
        internal SecretRotationStatus() { }
        public long? ExpirePeriodDays { get { throw null; } }
        public System.DateTimeOffset? LastRotationOn { get { throw null; } }
        public long? RotationPeriodDays { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.SecretArchiveReference SecretArchiveReference { get { throw null; } }
        public string SecretType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceLoadBalancerBgpPeer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServiceLoadBalancerBgpPeer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServicePrincipalInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation>
    {
        public ServicePrincipalInformation(string applicationId, string principalId, string tenantId) { }
        public string ApplicationId { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ServicePrincipalInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StepState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StepState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StepState>
    {
        internal StepState() { }
        public string EndTime { get { throw null; } }
        public string Message { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.StepStateStatus? Status { get { throw null; } }
        public string StepName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StepState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StepState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StepState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StepState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StepState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StepState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StepState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StepStateStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.StepStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StepStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StepStateStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StepStateStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StepStateStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StepStateStatus NotStarted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.StepStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.StepStateStatus left, Azure.ResourceManager.NetworkCloud.Models.StepStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.StepStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.StepStateStatus left, Azure.ResourceManager.NetworkCloud.Models.StepStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageApplianceCommandSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification>
    {
        public StorageApplianceCommandSpecification(string command) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageApplianceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration>
    {
        public StorageApplianceConfiguration(Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials adminCredentials, long rackSlot, string serialNumber) { }
        public Azure.ResourceManager.NetworkCloud.Models.AdministrativeCredentials AdminCredentials { get { throw null; } set { } }
        public long RackSlot { get { throw null; } set { } }
        public string SerialNumber { get { throw null; } set { } }
        public string StorageApplianceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageApplianceDetailedStatus : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageApplianceDetailedStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus Available { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.StorageApplianceDetailedStatus Degraded { get { throw null; } }
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
    public partial class StorageApplianceEnableRemoteVendorManagementContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent>
    {
        public StorageApplianceEnableRemoteVendorManagementContent() { }
        public System.Collections.Generic.IList<string> SupportEndpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceEnableRemoteVendorManagementContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StorageApplianceRunReadCommandsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent>
    {
        public StorageApplianceRunReadCommandsContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification> commands, long limitTimeSeconds) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceCommandSpecification> Commands { get { throw null; } }
        public long LimitTimeSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceRunReadCommandsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageApplianceSkuSlot : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot>
    {
        internal StorageApplianceSkuSlot() { }
        public long? CapacityGB { get { throw null; } }
        public string Model { get { throw null; } }
        public long? RackSlot { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StorageApplianceSkuSlot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringKeyValuePair : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>
    {
        public StringKeyValuePair(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.StringKeyValuePair>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrunkedNetworkAttachmentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration>
    {
        public TrunkedNetworkAttachmentConfiguration(Azure.Core.ResourceIdentifier networkId) { }
        public Azure.Core.ResourceIdentifier NetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.KubernetesPluginType? PluginType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.TrunkedNetworkAttachmentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ValidationThreshold : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold>
    {
        public ValidationThreshold(Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping grouping, Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType thresholdType, long value) { }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdGrouping Grouping { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.ValidationThresholdType ThresholdType { get { throw null; } set { } }
        public long Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.ValidationThreshold>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VirtualMachineAssignRelayContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent>
    {
        public VirtualMachineAssignRelayContent(Azure.Core.ResourceIdentifier machineId) { }
        public Azure.Core.ResourceIdentifier MachineId { get { throw null; } }
        public Azure.ResourceManager.NetworkCloud.Models.RelayType? RelayType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachineAssignRelayContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.NetworkCloud.Models.VirtualMachineDeviceModelType T3 { get { throw null; } }
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
    public partial class VirtualMachinePlacementHint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>
    {
        public VirtualMachinePlacementHint(Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType hintType, Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution schedulingExecution, Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope scope) { }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintType HintType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachineSchedulingExecution SchedulingExecution { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHintPodAffinityScope Scope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePlacementHint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VirtualMachinePowerOffContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent>
    {
        public VirtualMachinePowerOffContent() { }
        public Azure.ResourceManager.NetworkCloud.Models.SkipShutdown? SkipShutdown { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkCloud.Models.VirtualMachinePowerOffContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct VulnerabilityScanningSettingsContainerScan : System.IEquatable<Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityScanningSettingsContainerScan(string value) { throw null; }
        public static Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan left, Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan left, Azure.ResourceManager.NetworkCloud.Models.VulnerabilityScanningSettingsContainerScan right) { throw null; }
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
