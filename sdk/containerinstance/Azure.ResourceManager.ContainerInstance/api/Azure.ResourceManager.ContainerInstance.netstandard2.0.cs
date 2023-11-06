namespace Azure.ResourceManager.ContainerInstance
{
    public partial class ContainerGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>, System.Collections.IEnumerable
    {
        protected ContainerGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string containerGroupName, Azure.ResourceManager.ContainerInstance.ContainerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string containerGroupName, Azure.ResourceManager.ContainerInstance.ContainerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Get(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetIfExists(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetIfExistsAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContainerGroupData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType osType) { }
        public string ConfidentialComputeCcePolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> Containers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics DiagnosticsLogAnalytics { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration DnsConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec> Extensions { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential> ImageRegistryCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> InitContainers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress IPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType OSType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority? Priority { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId> SubnetIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume> Volumes { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ContainerGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerGroupResource() { }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult> AttachContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult>> AttachContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string containerGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult> ExecuteContainerCommand(string containerName, Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>> ExecuteContainerCommandAsync(string containerName, Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs> GetContainerLogs(string containerName, int? tail = default(int?), bool? timestamps = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>> GetContainerLogsAsync(string containerName, int? tail = default(int?), bool? timestamps = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Update(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> UpdateAsync(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ContainerInstanceExtensions
    {
        public static Azure.ResourceManager.ArmOperation DeleteSubnetServiceAssociationLink(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteSubnetServiceAssociationLinkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetContainerGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupResource GetContainerGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupCollection GetContainerGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerInstanceArmClient() { }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupResource GetContainerGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerInstanceResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerInstanceResourceGroupResource() { }
        public virtual Azure.ResourceManager.ArmOperation DeleteSubnetServiceAssociationLink(Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteSubnetServiceAssociationLinkAsync(Azure.WaitUntil waitUntil, string virtualNetworkName, string subnetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroup(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetContainerGroupAsync(string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerInstance.ContainerGroupCollection GetContainerGroups() { throw null; }
    }
    public partial class MockableContainerInstanceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerInstanceSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities> GetCapabilitiesWithLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsagesWithLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerInstance.Models
{
    public static partial class ArmContainerInstanceModelFactory
    {
        public static Azure.ResourceManager.ContainerInstance.Models.CachedImages CachedImages(string osType = null, string image = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerAttachResult ContainerAttachResult(System.Uri webSocketUri = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerCapabilities ContainerCapabilities(string resourceType = null, string osType = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string ipAddressType = null, string gpu = null, Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities capabilities = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerEvent ContainerEvent(int? count = default(int?), System.DateTimeOffset? firstTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastTimestamp = default(System.DateTimeOffset?), string name = null, string message = null, string eventType = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult ContainerExecResult(System.Uri webSocketUri = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupData ContainerGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupImageRegistryCredential> imageRegistryCredentials = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? restartPolicy = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy?), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress ipAddress = null, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType osType = default(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolume> volumes = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView instanceView = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalytics diagnosticsLogAnalytics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId> subnetIds = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupDnsConfiguration dnsConfig = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? sku = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku?), Azure.ResourceManager.ContainerInstance.Models.ContainerGroupEncryptionProperties encryptionProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> initContainers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.DeploymentExtensionSpec> extensions = null, string confidentialComputeCcePolicy = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority? priority = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority?)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupInstanceView ContainerGroupInstanceView(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> events = null, string state = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddress ContainerGroupIPAddress(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort> ports = null, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType addressType = default(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType), System.Net.IPAddress ip = null, string dnsNameLabel = null, Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy?), string fqdn = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPatch ContainerGroupPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer ContainerInstanceContainer(string name = null, string image = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerPort> ports = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> environmentVariables = null, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView instanceView = null, Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> volumeMounts = null, Azure.ResourceManager.ContainerInstance.Models.ContainerProbe livenessProbe = null, Azure.ResourceManager.ContainerInstance.Models.ContainerProbe readinessProbe = null, Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition securityContext = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage ContainerInstanceUsage(string id = null, string unit = null, int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName name = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName ContainerInstanceUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView ContainerInstanceView(int? restartCount = default(int?), Azure.ResourceManager.ContainerInstance.Models.ContainerState currentState = null, Azure.ResourceManager.ContainerInstance.Models.ContainerState previousState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> events = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerLogs ContainerLogs(string content = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerState ContainerState(string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), int? exitCode = default(int?), System.DateTimeOffset? finishOn = default(System.DateTimeOffset?), string detailStatus = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities ContainerSupportedCapabilities(float? maxMemoryInGB = default(float?), float? maxCpu = default(float?), float? maxGpuCount = default(float?)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent InitContainerDefinitionContent(string name = null, string image = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> environmentVariables = null, Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView instanceView = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> volumeMounts = null, Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition securityContext = null) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView InitContainerPropertiesDefinitionInstanceView(int? restartCount = default(int?), Azure.ResourceManager.ContainerInstance.Models.ContainerState currentState = null, Azure.ResourceManager.ContainerInstance.Models.ContainerState previousState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> events = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope Unsecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CachedImages
    {
        internal CachedImages() { }
        public string Image { get { throw null; } }
        public string OSType { get { throw null; } }
    }
    public partial class ContainerAttachResult
    {
        internal ContainerAttachResult() { }
        public string Password { get { throw null; } }
        public System.Uri WebSocketUri { get { throw null; } }
    }
    public partial class ContainerCapabilities
    {
        internal ContainerCapabilities() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSupportedCapabilities Capabilities { get { throw null; } }
        public string Gpu { get { throw null; } }
        public string IPAddressType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string OSType { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ContainerEnvironmentVariable
    {
        public ContainerEnvironmentVariable(string name) { }
        public string Name { get { throw null; } set { } }
        public string SecureValue { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ContainerEvent
    {
        internal ContainerEvent() { }
        public int? Count { get { throw null; } }
        public string EventType { get { throw null; } }
        public System.DateTimeOffset? FirstTimestamp { get { throw null; } }
        public System.DateTimeOffset? LastTimestamp { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ContainerExecContent
    {
        public ContainerExecContent() { }
        public string Command { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerExecRequestTerminalSize TerminalSize { get { throw null; } set { } }
    }
    public partial class ContainerExecRequestTerminalSize
    {
        public ContainerExecRequestTerminalSize() { }
        public int? Cols { get { throw null; } set { } }
        public int? Rows { get { throw null; } set { } }
    }
    public partial class ContainerExecResult
    {
        internal ContainerExecResult() { }
        public string Password { get { throw null; } }
        public System.Uri WebSocketUri { get { throw null; } }
    }
    public partial class ContainerGpuResourceInfo
    {
        public ContainerGpuResourceInfo(int count, Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku sku) { }
        public int Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku Sku { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGpuSku : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGpuSku(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku K80 { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku P100 { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku V100 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGpuSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupDnsConfiguration
    {
        public ContainerGroupDnsConfiguration(System.Collections.Generic.IEnumerable<string> nameServers) { }
        public System.Collections.Generic.IList<string> NameServers { get { throw null; } }
        public string Options { get { throw null; } set { } }
        public string SearchDomains { get { throw null; } set { } }
    }
    public partial class ContainerGroupEncryptionProperties
    {
        public ContainerGroupEncryptionProperties(System.Uri vaultBaseUri, string keyName, string keyVersion) { }
        public string Identity { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.Uri VaultBaseUri { get { throw null; } set { } }
    }
    public partial class ContainerGroupImageRegistryCredential
    {
        public ContainerGroupImageRegistryCredential(string server) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release.", false)]
        public ContainerGroupImageRegistryCredential(string server, string username) { }
        public string Identity { get { throw null; } set { } }
        public System.Uri IdentityUri { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class ContainerGroupInstanceView
    {
        internal ContainerGroupInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class ContainerGroupIPAddress
    {
        public ContainerGroupIPAddress(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort> ports, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType addressType) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType AddressType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string DnsNameLabel { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("DnsNameLabelReusePolicy is deprecated, use AutoGeneratedDnsNameLabelScope instead", false)]
        public Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope? DnsNameLabelReusePolicy { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public System.Net.IPAddress IP { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPort> Ports { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupIPAddressType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupIPAddressType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType Private { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupLogAnalytics
    {
        public ContainerGroupLogAnalytics(string workspaceId, string workspaceKey) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType? LogType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string WorkspaceId { get { throw null; } set { } }
        public string WorkspaceKey { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupLogAnalyticsLogType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupLogAnalyticsLogType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType ContainerInsights { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType ContainerInstanceLogs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupLogAnalyticsLogType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupNetworkProtocol : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupNetworkProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContainerGroupPatch(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ContainerGroupPort
    {
        public ContainerGroupPort(int port) { }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol? Protocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupPriority : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupPriority(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority Regular { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupRestartPolicy : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupRestartPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy Always { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy Never { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy OnFailure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerGroupSku : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerGroupSku(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku Confidential { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku Dedicated { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku left, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerGroupSubnetId
    {
        public ContainerGroupSubnetId(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ContainerHttpGet
    {
        public ContainerHttpGet(int port) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpHeader> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme? Scheme { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerHttpGetScheme : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerHttpGetScheme(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme Http { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme left, Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme left, Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGetScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerHttpHeader
    {
        public ContainerHttpHeader() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ContainerInstanceAzureFileVolume
    {
        public ContainerInstanceAzureFileVolume(string shareName, string storageAccountName) { }
        public bool? IsReadOnly { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
    }
    public partial class ContainerInstanceContainer
    {
        public ContainerInstanceContainer(string name, string image, Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements resources) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerPort> Ports { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequirements Resources { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> VolumeMounts { get { throw null; } }
    }
    public partial class ContainerInstanceGitRepoVolume
    {
        public ContainerInstanceGitRepoVolume(string repository) { }
        public string Directory { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
        public string Revision { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerInstanceOperatingSystemType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerInstanceOperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType left, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType left, Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceOperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerInstanceUsage
    {
        internal ContainerInstanceUsage() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ContainerInstanceUsageName
    {
        internal ContainerInstanceUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ContainerInstanceView
    {
        internal ContainerInstanceView() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState CurrentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState PreviousState { get { throw null; } }
        public int? RestartCount { get { throw null; } }
    }
    public partial class ContainerLogs
    {
        internal ContainerLogs() { }
        public string Content { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerNetworkProtocol : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerNetworkProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol left, Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerPort
    {
        public ContainerPort(int port) { }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerNetworkProtocol? Protocol { get { throw null; } set { } }
    }
    public partial class ContainerProbe
    {
        public ContainerProbe() { }
        public System.Collections.Generic.IList<string> ExecCommand { get { throw null; } }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerHttpGet HttpGet { get { throw null; } set { } }
        public int? InitialDelayInSeconds { get { throw null; } set { } }
        public int? PeriodInSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class ContainerResourceLimits
    {
        public ContainerResourceLimits() { }
        public double? Cpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo Gpu { get { throw null; } set { } }
        public double? MemoryInGB { get { throw null; } set { } }
    }
    public partial class ContainerResourceRequestsContent
    {
        public ContainerResourceRequestsContent(double memoryInGB, double cpu) { }
        public double Cpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGpuResourceInfo Gpu { get { throw null; } set { } }
        public double MemoryInGB { get { throw null; } set { } }
    }
    public partial class ContainerResourceRequirements
    {
        public ContainerResourceRequirements(Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent requests) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerResourceLimits Limits { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerResourceRequestsContent Requests { get { throw null; } set { } }
    }
    public partial class ContainerSecurityContextCapabilitiesDefinition
    {
        public ContainerSecurityContextCapabilitiesDefinition() { }
        public System.Collections.Generic.IList<string> Add { get { throw null; } }
        public System.Collections.Generic.IList<string> Drop { get { throw null; } }
    }
    public partial class ContainerSecurityContextDefinition
    {
        public ContainerSecurityContextDefinition() { }
        public bool? AllowPrivilegeEscalation { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextCapabilitiesDefinition Capabilities { get { throw null; } set { } }
        public bool? IsPrivileged { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public string SeccompProfile { get { throw null; } set { } }
    }
    public partial class ContainerState
    {
        internal ContainerState() { }
        public string DetailStatus { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public System.DateTimeOffset? FinishOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class ContainerSupportedCapabilities
    {
        internal ContainerSupportedCapabilities() { }
        public float? MaxCpu { get { throw null; } }
        public float? MaxGpuCount { get { throw null; } }
        public float? MaxMemoryInGB { get { throw null; } }
    }
    public partial class ContainerVolume
    {
        public ContainerVolume(string name) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceAzureFileVolume AzureFile { get { throw null; } set { } }
        public System.BinaryData EmptyDir { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceGitRepoVolume GitRepo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Secret { get { throw null; } }
    }
    public partial class ContainerVolumeMount
    {
        public ContainerVolumeMount(string name, string mountPath) { }
        public bool? IsReadOnly { get { throw null; } set { } }
        public string MountPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class DeploymentExtensionSpec
    {
        public DeploymentExtensionSpec(string name) { }
        public string ExtensionType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData ProtectedSettings { get { throw null; } set { } }
        public System.BinaryData Settings { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsNameLabelReusePolicy : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsNameLabelReusePolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy TenantReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy Unsecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy left, Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy left, Azure.ResourceManager.ContainerInstance.Models.DnsNameLabelReusePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InitContainerDefinitionContent
    {
        public InitContainerDefinitionContent(string name) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerEnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView InstanceView { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerSecurityContextDefinition SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerVolumeMount> VolumeMounts { get { throw null; } }
    }
    public partial class InitContainerPropertiesDefinitionInstanceView
    {
        internal InitContainerPropertiesDefinitionInstanceView() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState CurrentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState PreviousState { get { throw null; } }
        public int? RestartCount { get { throw null; } }
    }
}
