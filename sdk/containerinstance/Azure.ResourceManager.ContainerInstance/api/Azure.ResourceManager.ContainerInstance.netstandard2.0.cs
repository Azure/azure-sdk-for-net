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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerGroupData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ContainerGroupData(Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> containers, Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType osType) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceContainer> Containers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.LogAnalytics DiagnosticsLogAnalytics { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.DnsConfiguration DnsConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.EncryptionProperties EncryptionProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ImageRegistryCredential> ImageRegistryCredentials { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.InitContainerDefinitionContent> InitContainers { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupPropertiesInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.IPAddress IPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType OSType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSku? Sku { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerGroupSubnetId> SubnetIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceVolume> Volumes { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult> ExecuteCommandContainer(string containerName, Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerExecResult>> ExecuteCommandContainerAsync(string containerName, Azure.ResourceManager.ContainerInstance.Models.ContainerExecContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs> GetLogsContainer(string containerName, int? tail = default(int?), bool? timestamps = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.Models.ContainerLogs>> GetLogsContainerAsync(string containerName, int? tail = default(int?), bool? timestamps = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.CachedImages> GetCachedImagesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceCapabilities> GetCapabilitiesWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceCapabilities> GetCapabilitiesWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerInstance.ContainerGroupResource>> GetContainerGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string containerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupResource GetContainerGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.ContainerGroupCollection GetContainerGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.ContainerGroupResource> GetContainerGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsageWithLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerInstance.Models.ContainerInstanceUsage> GetUsageWithLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerInstance.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope Noreuse { get { throw null; } }
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
    public partial class AzureFileVolume
    {
        public AzureFileVolume(string shareName, string storageAccountName) { }
        public bool? ReadOnly { get { throw null; } set { } }
        public string ShareName { get { throw null; } set { } }
        public string StorageAccountKey { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
    }
    public partial class CachedImages
    {
        internal CachedImages() { }
        public string Image { get { throw null; } }
        public string OSType { get { throw null; } }
    }
    public partial class Capabilities
    {
        internal Capabilities() { }
        public float? MaxCpu { get { throw null; } }
        public float? MaxGpuCount { get { throw null; } }
        public float? MaxMemoryInGB { get { throw null; } }
    }
    public partial class ContainerAttachResult
    {
        internal ContainerAttachResult() { }
        public string Password { get { throw null; } }
        public System.Uri WebSocketUri { get { throw null; } }
    }
    public partial class ContainerEvent
    {
        internal ContainerEvent() { }
        public string ContainerEventType { get { throw null; } }
        public int? Count { get { throw null; } }
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
        public ContainerGroupPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ContainerGroupPropertiesInstanceView
    {
        internal ContainerGroupPropertiesInstanceView() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public string State { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.HttpHeader> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.Scheme? Scheme { get { throw null; } set { } }
    }
    public partial class ContainerInstanceCapabilities
    {
        internal ContainerInstanceCapabilities() { }
        public Azure.ResourceManager.ContainerInstance.Models.Capabilities Capabilities { get { throw null; } }
        public string Gpu { get { throw null; } }
        public string IPAddressType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string OSType { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ContainerInstanceContainer
    {
        public ContainerInstanceContainer(string name, string image, Azure.ResourceManager.ContainerInstance.Models.ResourceRequirements resources) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerPropertiesInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.ContainerPort> Ports { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ResourceRequirements Resources { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.VolumeMount> VolumeMounts { get { throw null; } }
    }
    public partial class ContainerInstanceUsage
    {
        internal ContainerInstanceUsage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.UsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class ContainerInstanceVolume
    {
        public ContainerInstanceVolume(string name) { }
        public Azure.ResourceManager.ContainerInstance.Models.AzureFileVolume AzureFile { get { throw null; } set { } }
        public System.BinaryData EmptyDir { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.GitRepoVolume GitRepo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Secret { get { throw null; } }
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
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
    }
    public partial class ContainerPropertiesInstanceView
    {
        internal ContainerPropertiesInstanceView() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState CurrentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState PreviousState { get { throw null; } }
        public int? RestartCount { get { throw null; } }
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
    public partial class DnsConfiguration
    {
        public DnsConfiguration(System.Collections.Generic.IEnumerable<string> nameServers) { }
        public System.Collections.Generic.IList<string> NameServers { get { throw null; } }
        public string Options { get { throw null; } set { } }
        public string SearchDomains { get { throw null; } set { } }
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties(System.Uri vaultBaseUri, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.Uri VaultBaseUri { get { throw null; } set { } }
    }
    public partial class EnvironmentVariable
    {
        public EnvironmentVariable(string name) { }
        public string Name { get { throw null; } set { } }
        public string SecureValue { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class GitRepoVolume
    {
        public GitRepoVolume(string repository) { }
        public string Directory { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
        public string Revision { get { throw null; } set { } }
    }
    public partial class GpuResource
    {
        public GpuResource(int count, Azure.ResourceManager.ContainerInstance.Models.GpuSku sku) { }
        public int Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.GpuSku Sku { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GpuSku : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.GpuSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GpuSku(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.GpuSku K80 { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.GpuSku P100 { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.GpuSku V100 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.GpuSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.GpuSku left, Azure.ResourceManager.ContainerInstance.Models.GpuSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.GpuSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.GpuSku left, Azure.ResourceManager.ContainerInstance.Models.GpuSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HttpHeader
    {
        public HttpHeader() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ImageRegistryCredential
    {
        public ImageRegistryCredential(string server, string username) { }
        public string Identity { get { throw null; } set { } }
        public System.Uri IdentityUri { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class InitContainerDefinitionContent
    {
        public InitContainerDefinitionContent(string name) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.EnvironmentVariable> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.InitContainerPropertiesDefinitionInstanceView InstanceView { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.VolumeMount> VolumeMounts { get { throw null; } }
    }
    public partial class InitContainerPropertiesDefinitionInstanceView
    {
        internal InitContainerPropertiesDefinitionInstanceView() { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState CurrentState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerInstance.Models.ContainerEvent> Events { get { throw null; } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerState PreviousState { get { throw null; } }
        public int? RestartCount { get { throw null; } }
    }
    public partial class IPAddress
    {
        public IPAddress(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerInstance.Models.Port> ports, Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType containerGroupIPAddressType) { }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupIPAddressType ContainerGroupIPAddressType { get { throw null; } set { } }
        public string DnsNameLabel { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.AutoGeneratedDomainNameLabelScope? DnsNameLabelReusePolicy { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string IP { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerInstance.Models.Port> Ports { get { throw null; } }
    }
    public partial class LogAnalytics
    {
        public LogAnalytics(Azure.Core.ResourceIdentifier workspaceId, string workspaceKey) { }
        public Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType? LogType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } set { } }
        public string WorkspaceKey { get { throw null; } set { } }
        public string WorkspaceResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogAnalyticsLogType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogAnalyticsLogType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType ContainerInsights { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType ContainerInstanceLogs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType left, Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType left, Azure.ResourceManager.ContainerInstance.Models.LogAnalyticsLogType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatingSystemType : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatingSystemType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType left, Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType left, Azure.ResourceManager.ContainerInstance.Models.OperatingSystemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Port
    {
        public Port(int portValue) { }
        public int PortValue { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ContainerGroupNetworkProtocol? Protocol { get { throw null; } set { } }
    }
    public partial class ResourceLimits
    {
        public ResourceLimits() { }
        public double? Cpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.GpuResource Gpu { get { throw null; } set { } }
        public double? MemoryInGB { get { throw null; } set { } }
    }
    public partial class ResourceRequests
    {
        public ResourceRequests(double memoryInGB, double cpu) { }
        public double Cpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.GpuResource Gpu { get { throw null; } set { } }
        public double MemoryInGB { get { throw null; } set { } }
    }
    public partial class ResourceRequirements
    {
        public ResourceRequirements(Azure.ResourceManager.ContainerInstance.Models.ResourceRequests requests) { }
        public Azure.ResourceManager.ContainerInstance.Models.ResourceLimits Limits { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerInstance.Models.ResourceRequests Requests { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Scheme : System.IEquatable<Azure.ResourceManager.ContainerInstance.Models.Scheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Scheme(string value) { throw null; }
        public static Azure.ResourceManager.ContainerInstance.Models.Scheme Http { get { throw null; } }
        public static Azure.ResourceManager.ContainerInstance.Models.Scheme Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerInstance.Models.Scheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerInstance.Models.Scheme left, Azure.ResourceManager.ContainerInstance.Models.Scheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerInstance.Models.Scheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerInstance.Models.Scheme left, Azure.ResourceManager.ContainerInstance.Models.Scheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class VolumeMount
    {
        public VolumeMount(string name, string mountPath) { }
        public string MountPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
    }
}
