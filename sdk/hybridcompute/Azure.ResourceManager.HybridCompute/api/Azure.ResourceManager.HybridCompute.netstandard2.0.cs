namespace Azure.ResourceManager.HybridCompute
{
    public partial class ExtensionValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.ExtensionValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.ExtensionValueResource>, System.Collections.IEnumerable
    {
        protected ExtensionValueCollection() { }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.ExtensionValueResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.ExtensionValueResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.ExtensionValueResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.ExtensionValueResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.ExtensionValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.ExtensionValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.ExtensionValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.ExtensionValueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtensionValueData : Azure.ResourceManager.Models.ResourceData
    {
        public ExtensionValueData() { }
        public string ExtensionType { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ExtensionValueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtensionValueResource() { }
        public virtual Azure.ResourceManager.HybridCompute.ExtensionValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publisher, string extensionType, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HybridComputeExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource> GetExtensionValue(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource>> GetExtensionValueAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.ExtensionValueResource GetExtensionValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.ExtensionValueCollection GetExtensionValues(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisher, string extensionType) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetHybridComputeMachineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource GetHybridComputeMachineExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineResource GetHybridComputeMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineCollection GetHybridComputeMachines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachines(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachinesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource GetHybridComputePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource GetHybridComputePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScope(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetHybridComputePrivateLinkScopeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource GetHybridComputePrivateLinkScopeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeCollection GetHybridComputePrivateLinkScopes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScopes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScopesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.MachineRunCommandResource GetMachineRunCommandResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails> GetValidationDetailsPrivateLinkScope(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string privateLinkScopeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>> GetValidationDetailsPrivateLinkScopeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string privateLinkScopeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputeMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>, System.Collections.IEnumerable
    {
        protected HybridComputeMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> Get(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetAsync(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetIfExists(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetIfExistsAsync(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputeMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridComputeMachineData(Azure.Core.AzureLocation location) { }
        public string AdFqdn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.AgentConfiguration AgentConfiguration { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.AgentUpgrade AgentUpgrade { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } }
        public string ClientPublicKey { get { throw null; } set { } }
        public string CloudMetadataProvider { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DetectedProperties { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string DnsFqdn { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResponseError> ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView> Extensions { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.ArcKindEnum? Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastStatusChange { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView LicenseProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LocationData LocationData { get { throw null; } set { } }
        public string MachineFqdn { get { throw null; } }
        public string MssqlDiscovered { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public string OSEdition { get { throw null; } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public string OSSku { get { throw null; } }
        public string OSType { get { throw null; } set { } }
        public string OSVersion { get { throw null; } }
        public Azure.Core.ResourceIdentifier ParentClusterResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkScopeResourceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData> Resources { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses ServiceStatuses { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType? Status { get { throw null; } }
        public System.Guid? VmId { get { throw null; } set { } }
        public System.Guid? VmUuid { get { throw null; } }
    }
    public partial class HybridComputeMachineExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>, System.Collections.IEnumerable
    {
        protected HybridComputeMachineExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputeMachineExtensionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridComputeMachineExtensionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputeMachineExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputeMachineExtensionResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputeMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputeMachineResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult> AssessPatches(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>> AssessPatchesAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource> GetHybridComputeMachineExtension(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource>> GetHybridComputeMachineExtensionAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionCollection GetHybridComputeMachineExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> GetMachineRunCommand(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> GetMachineRunCommandAsync(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.MachineRunCommandCollection GetMachineRunCommands() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.Models.NetworkProfile> GetNetworkProfile(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.Models.NetworkProfile>> GetNetworkProfileAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails> GetValidationDetailsForMachinePrivateLinkScope(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>> GetValidationDetailsForMachinePrivateLinkScopeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult> InstallPatches(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>> InstallPatchesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> Update(Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> UpdateAsync(Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade extensionUpgradeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade extensionUpgradeParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HybridComputePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridComputePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputePrivateLinkResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridComputePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HybridComputePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridComputePrivateLinkResourceData() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateLinkScopeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>, System.Collections.IEnumerable
    {
        protected HybridComputePrivateLinkScopeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopeName, Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> Get(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetIfExists(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetIfExistsAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputePrivateLinkScopeData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HybridComputePrivateLinkScopeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties Properties { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateLinkScopeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputePrivateLinkScopeResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scopeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource> GetHybridComputePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource>> GetHybridComputePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionCollection GetHybridComputePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource> GetHybridComputePrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource>> GetHybridComputePrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceCollection GetHybridComputePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> Update(Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> UpdateAsync(Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineRunCommandCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>, System.Collections.IEnumerable
    {
        protected MachineRunCommandCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.HybridCompute.MachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string runCommandName, Azure.ResourceManager.HybridCompute.MachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> Get(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> GetAll(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> GetAllAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> GetAsync(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> GetIfExists(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> GetIfExistsAsync(string runCommandName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineRunCommandData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MachineRunCommandData(Azure.Core.AzureLocation location) { }
        public bool? AsyncExecution { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity ErrorBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri ErrorBlobUri { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView InstanceView { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity OutputBlobManagedIdentity { get { throw null; } set { } }
        public System.Uri OutputBlobUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter> ProtectedParameters { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string RunAsPassword { get { throw null; } set { } }
        public string RunAsUser { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource Source { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
    }
    public partial class MachineRunCommandResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineRunCommandResource() { }
        public virtual Azure.ResourceManager.HybridCompute.MachineRunCommandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string machineName, string runCommandName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.MachineRunCommandResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.MachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridCompute.MachineRunCommandResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HybridCompute.MachineRunCommandData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridCompute.Mocking
{
    public partial class MockableHybridComputeArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridComputeArmClient() { }
        public virtual Azure.ResourceManager.HybridCompute.ExtensionValueResource GetExtensionValueResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionResource GetHybridComputeMachineExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineResource GetHybridComputeMachineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionResource GetHybridComputePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResource GetHybridComputePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource GetHybridComputePrivateLinkScopeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.MachineRunCommandResource GetMachineRunCommandResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHybridComputeResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridComputeResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachine(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource>> GetHybridComputeMachineAsync(string machineName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeMachineCollection GetHybridComputeMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScope(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource>> GetHybridComputePrivateLinkScopeAsync(string scopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeCollection GetHybridComputePrivateLinkScopes() { throw null; }
    }
    public partial class MockableHybridComputeSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridComputeSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource> GetExtensionValue(Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.ExtensionValueResource>> GetExtensionValueAsync(Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.ExtensionValueCollection GetExtensionValues(Azure.Core.AzureLocation location, string publisher, string extensionType) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachines(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeMachineResource> GetHybridComputeMachinesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScopes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeResource> GetHybridComputePrivateLinkScopesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails> GetValidationDetailsPrivateLinkScope(Azure.Core.AzureLocation location, string privateLinkScopeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>> GetValidationDetailsPrivateLinkScopeAsync(Azure.Core.AzureLocation location, string privateLinkScopeId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridCompute.Models
{
    public partial class AgentConfiguration
    {
        internal AgentConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode? ConfigMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> ExtensionsAllowList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> ExtensionsBlockList { get { throw null; } }
        public string ExtensionsEnabled { get { throw null; } }
        public string GuestConfigurationEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IncomingConnectionsPorts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProxyBypass { get { throw null; } }
        public System.Uri ProxyUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentConfigurationMode : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentConfigurationMode(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode Full { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode Monitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode left, Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode left, Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentUpgrade
    {
        public AgentUpgrade() { }
        public System.Guid? CorrelationId { get { throw null; } set { } }
        public string DesiredVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string LastAttemptDesiredVersion { get { throw null; } }
        public string LastAttemptMessage { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum? LastAttemptStatus { get { throw null; } }
        public System.DateTimeOffset? LastAttemptTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcKindEnum : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.ArcKindEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcKindEnum(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum AVS { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum AWS { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum EPS { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum GCP { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum HCI { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum Scvmm { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum VMware { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.ArcKindEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.ArcKindEnum left, Azure.ResourceManager.HybridCompute.Models.ArcKindEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.ArcKindEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.ArcKindEnum left, Azure.ResourceManager.HybridCompute.Models.ArcKindEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmHybridComputeModelFactory
    {
        public static Azure.ResourceManager.HybridCompute.Models.AgentConfiguration AgentConfiguration(System.Uri proxyUri = null, System.Collections.Generic.IEnumerable<string> incomingConnectionsPorts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> extensionsAllowList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension> extensionsBlockList = null, System.Collections.Generic.IEnumerable<string> proxyBypass = null, string extensionsEnabled = null, string guestConfigurationEnabled = null, Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode? configMode = default(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AgentUpgrade AgentUpgrade(string desiredVersion = null, System.Guid? correlationId = default(System.Guid?), bool? enableAutomaticUpgrade = default(bool?), string lastAttemptDesiredVersion = null, System.DateTimeOffset? lastAttemptTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum? lastAttemptStatus = default(Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum?), string lastAttemptMessage = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification AvailablePatchCountByClassification(int? security = default(int?), int? critical = default(int?), int? definition = default(int?), int? updateRollup = default(int?), int? featurePack = default(int?), int? servicePack = default(int?), int? tools = default(int?), int? updates = default(int?), int? other = default(int?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ConfigurationExtension ConfigurationExtension(string publisher = null, string configurationExtensionType = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ConnectionDetail ConnectionDetail(string id = null, string privateIPAddress = null, string linkIdentifier = null, string groupId = null, string memberName = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.EsuKey EsuKey(string sku = null, string licenseStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus ExtensionsResourceStatus(string code = null, Azure.ResourceManager.HybridCompute.Models.ExtensionsStatusLevelType? level = default(Azure.ResourceManager.HybridCompute.Models.ExtensionsStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.ExtensionValueData ExtensionValueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string version = null, string extensionType = null, string publisher = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineData HybridComputeMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData> resources = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HybridCompute.Models.ArcKindEnum? kind = default(Azure.ResourceManager.HybridCompute.Models.ArcKindEnum?), Azure.ResourceManager.HybridCompute.Models.LocationData locationData = null, Azure.ResourceManager.HybridCompute.Models.AgentConfiguration agentConfiguration = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses serviceStatuses = null, string cloudMetadataProvider = null, Azure.ResourceManager.HybridCompute.Models.AgentUpgrade agentUpgrade = null, Azure.ResourceManager.HybridCompute.Models.OSProfile osProfile = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView licenseProfile = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType? status = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType?), System.DateTimeOffset? lastStatusChange = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null, string agentVersion = null, System.Guid? vmId = default(System.Guid?), string displayName = null, string machineFqdn = null, string clientPublicKey = null, string osName = null, string osVersion = null, string osType = null, System.Guid? vmUuid = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView> extensions = null, string osSku = null, string osEdition = null, string domainName = null, string adFqdn = null, string dnsFqdn = null, Azure.Core.ResourceIdentifier privateLinkScopeResourceId = null, Azure.Core.ResourceIdentifier parentClusterResourceId = null, string mssqlDiscovered = null, System.Collections.Generic.IReadOnlyDictionary<string, string> detectedProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.NetworkInterface> networkInterfaces = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData HybridComputeMachineExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData HybridComputePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData HybridComputePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties HybridComputePrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData HybridComputePrivateLinkScopeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties HybridComputePrivateLinkScopeProperties(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType?), string provisioningState = null, string privateLinkScopeId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty HybridComputePrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.IPAddress IPAddress(string address = null, string ipAddressVersion = null, string subnetAddressPrefix = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.License License(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HybridCompute.Models.ProvisioningState?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.HybridCompute.Models.LicenseType? licenseType = default(Azure.ResourceManager.HybridCompute.Models.LicenseType?), Azure.ResourceManager.HybridCompute.Models.LicenseDetails licenseDetails = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseDetails LicenseDetails(Azure.ResourceManager.HybridCompute.Models.LicenseState? state = default(Azure.ResourceManager.HybridCompute.Models.LicenseState?), Azure.ResourceManager.HybridCompute.Models.LicenseTarget? target = default(Azure.ResourceManager.HybridCompute.Models.LicenseTarget?), Azure.ResourceManager.HybridCompute.Models.LicenseEdition? edition = default(Azure.ResourceManager.HybridCompute.Models.LicenseEdition?), Azure.ResourceManager.HybridCompute.Models.LicenseCoreType? coreType = default(Azure.ResourceManager.HybridCompute.Models.LicenseCoreType?), int? processors = default(int?), int? assignedLicenses = default(int?), string immutableId = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense LicenseProfileArmEsuPropertiesWithoutAssignedLicense(string assignedLicenseImmutableId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.EsuKey> esuKeys = null, Azure.ResourceManager.HybridCompute.Models.EsuServerType? serverType = default(Azure.ResourceManager.HybridCompute.Models.EsuServerType?), Azure.ResourceManager.HybridCompute.Models.EsuEligibility? esuEligibility = default(Azure.ResourceManager.HybridCompute.Models.EsuEligibility?), Azure.ResourceManager.HybridCompute.Models.EsuKeyState? esuKeyState = default(Azure.ResourceManager.HybridCompute.Models.EsuKeyState?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView LicenseProfileMachineInstanceView(Azure.ResourceManager.HybridCompute.Models.LicenseStatus? licenseStatus = default(Azure.ResourceManager.HybridCompute.Models.LicenseStatus?), string licenseChannel = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties esuProfile = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus?), Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType? productType = default(Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType?), System.DateTimeOffset? billingStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? enrollmentOn = default(System.DateTimeOffset?), System.DateTimeOffset? disenrollmentOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ProductFeature> productFeatures = null, bool? softwareAssuranceCustomer = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties LicenseProfileMachineInstanceViewEsuProperties(string assignedLicenseImmutableId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.EsuKey> esuKeys = null, Azure.ResourceManager.HybridCompute.Models.EsuServerType? serverType = default(Azure.ResourceManager.HybridCompute.Models.EsuServerType?), Azure.ResourceManager.HybridCompute.Models.EsuEligibility? esuEligibility = default(Azure.ResourceManager.HybridCompute.Models.EsuEligibility?), Azure.ResourceManager.HybridCompute.Models.EsuKeyState? esuKeyState = default(Azure.ResourceManager.HybridCompute.Models.EsuKeyState?), Azure.ResourceManager.HybridCompute.Models.License assignedLicense = null, Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState? licenseAssignmentState = default(Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties LicenseProfileStorageModelEsuProperties(string assignedLicenseImmutableId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.EsuKey> esuKeys = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult MachineAssessPatchesResult(Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus? status = default(Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus?), System.Guid? assessmentActivityId = default(System.Guid?), bool? rebootPending = default(bool?), Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification availablePatchCountByClassification = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? startedBy = default(Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy?), Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? patchServiceUsed = default(Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed?), Azure.ResourceManager.HybridCompute.Models.OSType? osType = default(Azure.ResourceManager.HybridCompute.Models.OSType?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties MachineExtensionProperties(string forceUpdateTag = null, string publisher = null, string machineExtensionPropertiesType = null, string typeHandlerVersion = null, bool? enableAutomaticUpgrade = default(bool?), bool? autoUpgradeMinorVersion = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult MachineInstallPatchesResult(Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus? status = default(Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus?), string installationActivityId = null, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus? rebootStatus = default(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus?), bool? maintenanceWindowExceeded = default(bool?), int? excludedPatchCount = default(int?), int? notSelectedPatchCount = default(int?), int? pendingPatchCount = default(int?), int? installedPatchCount = default(int?), int? failedPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? startedBy = default(Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy?), Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? patchServiceUsed = default(Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed?), Azure.ResourceManager.HybridCompute.Models.OSType? osType = default(Azure.ResourceManager.HybridCompute.Models.OSType?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.MachineRunCommandData MachineRunCommandData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource source = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter> protectedParameters = null, bool? asyncExecution = default(bool?), string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = default(int?), System.Uri outputBlobUri = null, System.Uri errorBlobUri = null, Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity outputBlobManagedIdentity = null, Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity errorBlobManagedIdentity = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView MachineRunCommandInstanceView(Azure.ResourceManager.HybridCompute.Models.ExecutionState? executionState = default(Azure.ResourceManager.HybridCompute.Models.ExecutionState?), string executionMessage = null, int? exitCode = default(int?), string output = null, string error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.NetworkInterface NetworkInterface(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.IPAddress> ipAddresses = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.NetworkProfile NetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.NetworkInterface> networkInterfaces = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.OSProfile OSProfile(string computerName = null, Azure.ResourceManager.HybridCompute.Models.OSProfileWindowsConfiguration windowsConfiguration = null, Azure.ResourceManager.HybridCompute.Models.OSProfileLinuxConfiguration linuxConfiguration = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel PrivateEndpointConnectionDataModel(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails PrivateLinkScopeValidationDetails(string id = null, Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ConnectionDetail> connectionDetails = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ProductFeature ProductFeature(string name = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus?), System.DateTimeOffset? billingStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? enrollmentOn = default(System.DateTimeOffset?), System.DateTimeOffset? disenrollmentOn = default(System.DateTimeOffset?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentModeType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.AssessmentModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentModeType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AssessmentModeType AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.AssessmentModeType ImageDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.AssessmentModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.AssessmentModeType left, Azure.ResourceManager.HybridCompute.Models.AssessmentModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.AssessmentModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.AssessmentModeType left, Azure.ResourceManager.HybridCompute.Models.AssessmentModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailablePatchCountByClassification
    {
        internal AvailablePatchCountByClassification() { }
        public int? Critical { get { throw null; } }
        public int? Definition { get { throw null; } }
        public int? FeaturePack { get { throw null; } }
        public int? Other { get { throw null; } }
        public int? Security { get { throw null; } }
        public int? ServicePack { get { throw null; } }
        public int? Tools { get { throw null; } }
        public int? UpdateRollup { get { throw null; } }
        public int? Updates { get { throw null; } }
    }
    public partial class ConfigurationExtension
    {
        internal ConfigurationExtension() { }
        public string ConfigurationExtensionType { get { throw null; } }
        public string Publisher { get { throw null; } }
    }
    public partial class ConnectionDetail
    {
        internal ConnectionDetail() { }
        public string GroupId { get { throw null; } }
        public string Id { get { throw null; } }
        public string LinkIdentifier { get { throw null; } }
        public string MemberName { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EsuEligibility : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.EsuEligibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EsuEligibility(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.EsuEligibility Eligible { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.EsuEligibility Ineligible { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.EsuEligibility Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.EsuEligibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.EsuEligibility left, Azure.ResourceManager.HybridCompute.Models.EsuEligibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.EsuEligibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.EsuEligibility left, Azure.ResourceManager.HybridCompute.Models.EsuEligibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EsuKey
    {
        internal EsuKey() { }
        public string LicenseStatus { get { throw null; } }
        public string Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EsuKeyState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.EsuKeyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EsuKeyState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.EsuKeyState Active { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.EsuKeyState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.EsuKeyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.EsuKeyState left, Azure.ResourceManager.HybridCompute.Models.EsuKeyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.EsuKeyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.EsuKeyState left, Azure.ResourceManager.HybridCompute.Models.EsuKeyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EsuServerType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.EsuServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EsuServerType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.EsuServerType Datacenter { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.EsuServerType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.EsuServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.EsuServerType left, Azure.ResourceManager.HybridCompute.Models.EsuServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.EsuServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.EsuServerType left, Azure.ResourceManager.HybridCompute.Models.EsuServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.ExecutionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ExecutionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ExecutionState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ExecutionState Pending { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ExecutionState Running { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ExecutionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ExecutionState TimedOut { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ExecutionState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.ExecutionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.ExecutionState left, Azure.ResourceManager.HybridCompute.Models.ExecutionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.ExecutionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.ExecutionState left, Azure.ResourceManager.HybridCompute.Models.ExecutionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtensionsResourceStatus
    {
        internal ExtensionsResourceStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.ExtensionsStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public enum ExtensionsStatusLevelType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    public partial class ExtensionTargetProperties
    {
        public ExtensionTargetProperties() { }
        public string TargetVersion { get { throw null; } set { } }
    }
    public partial class HybridComputeMachineExtensionPatch : Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate
    {
        public HybridComputeMachineExtensionPatch() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public string MachineExtensionUpdatePropertiesType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ProtectedSettings { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class HybridComputeMachinePatch : Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate
    {
        public HybridComputeMachinePatch() { }
        public Azure.ResourceManager.HybridCompute.Models.AgentUpgrade AgentUpgrade { get { throw null; } set { } }
        public string CloudMetadataProvider { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.ArcKindEnum? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LocationData LocationData { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfile OSProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParentClusterResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkScopeResourceId { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateLinkResourceProperties
    {
        public HybridComputePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class HybridComputePrivateLinkScopePatch
    {
        public HybridComputePrivateLinkScopePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HybridComputePrivateLinkScopeProperties
    {
        public HybridComputePrivateLinkScopeProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel> PrivateEndpointConnections { get { throw null; } }
        public string PrivateLinkScopeId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class HybridComputePrivateLinkServiceConnectionStateProperty
    {
        public HybridComputePrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class HybridComputeResourceUpdate
    {
        public HybridComputeResourceUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HybridComputeServiceStatus
    {
        public HybridComputeServiceStatus() { }
        public string StartupType { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class HybridComputeServiceStatuses
    {
        public HybridComputeServiceStatuses() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus ExtensionService { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus GuestConfigurationService { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeStatusLevelType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeStatusLevelType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType Error { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType Info { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeStatusType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeStatusType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType Connected { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType Disconnected { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType Error { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAddress
    {
        internal IPAddress() { }
        public string Address { get { throw null; } }
        public string IPAddressVersion { get { throw null; } }
        public string SubnetAddressPrefix { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LastAttemptStatusEnum : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LastAttemptStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum left, Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum left, Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class License : Azure.ResourceManager.Models.TrackedResourceData
    {
        public License(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridCompute.Models.LicenseDetails LicenseDetails { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseAssignmentState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseAssignmentState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState Assigned { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState NotAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState left, Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState left, Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseCoreType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseCoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseCoreType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseCoreType PCore { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseCoreType VCore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseCoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseCoreType left, Azure.ResourceManager.HybridCompute.Models.LicenseCoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseCoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseCoreType left, Azure.ResourceManager.HybridCompute.Models.LicenseCoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LicenseDetails
    {
        public LicenseDetails() { }
        public int? AssignedLicenses { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseCoreType? CoreType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseEdition? Edition { get { throw null; } set { } }
        public string ImmutableId { get { throw null; } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseState? State { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseTarget? Target { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseEdition : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseEdition(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseEdition Datacenter { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseEdition Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseEdition left, Azure.ResourceManager.HybridCompute.Models.LicenseEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseEdition left, Azure.ResourceManager.HybridCompute.Models.LicenseEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LicenseProfileArmEsuPropertiesWithoutAssignedLicense : Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties
    {
        public LicenseProfileArmEsuPropertiesWithoutAssignedLicense() { }
        public Azure.ResourceManager.HybridCompute.Models.EsuEligibility? EsuEligibility { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.EsuKeyState? EsuKeyState { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.EsuServerType? ServerType { get { throw null; } }
    }
    public partial class LicenseProfileMachineInstanceView
    {
        public LicenseProfileMachineInstanceView() { }
        public System.DateTimeOffset? BillingStartOn { get { throw null; } }
        public System.DateTimeOffset? DisenrollmentOn { get { throw null; } }
        public System.DateTimeOffset? EnrollmentOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties EsuProfile { get { throw null; } set { } }
        public string LicenseChannel { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseStatus? LicenseStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.ProductFeature> ProductFeatures { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType? ProductType { get { throw null; } set { } }
        public bool? SoftwareAssuranceCustomer { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
    }
    public partial class LicenseProfileMachineInstanceViewEsuProperties : Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense
    {
        public LicenseProfileMachineInstanceViewEsuProperties() { }
        public Azure.ResourceManager.HybridCompute.Models.License AssignedLicense { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState? LicenseAssignmentState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseProfileProductType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseProfileProductType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType WindowsIoTEnterprise { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType WindowsServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType left, Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType left, Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LicenseProfileStorageModelEsuProperties
    {
        public LicenseProfileStorageModelEsuProperties() { }
        public string AssignedLicenseImmutableId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.EsuKey> EsuKeys { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseProfileSubscriptionStatus : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseProfileSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus Enabled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus Enabling { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus left, Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus left, Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseState Activated { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseState Deactivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseState left, Azure.ResourceManager.HybridCompute.Models.LicenseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseState left, Azure.ResourceManager.HybridCompute.Models.LicenseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseStatus : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseStatus ExtendedGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseStatus Licensed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseStatus NonGenuineGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseStatus Notification { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseStatus OOBGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseStatus OOTGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseStatus Unlicensed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseStatus left, Azure.ResourceManager.HybridCompute.Models.LicenseStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseStatus left, Azure.ResourceManager.HybridCompute.Models.LicenseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseTarget : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseTarget>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseTarget(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseTarget WindowsServer2012 { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseTarget WindowsServer2012R2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseTarget other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseTarget left, Azure.ResourceManager.HybridCompute.Models.LicenseTarget right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseTarget (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseTarget left, Azure.ResourceManager.HybridCompute.Models.LicenseTarget right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseType ESU { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.LicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.LicenseType left, Azure.ResourceManager.HybridCompute.Models.LicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.LicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.LicenseType left, Azure.ResourceManager.HybridCompute.Models.LicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinuxParameters
    {
        public LinuxParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux> ClassificationsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToInclude { get { throw null; } }
    }
    public partial class LocationData
    {
        public LocationData(string name) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } set { } }
        public string District { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class MachineAssessPatchesResult
    {
        internal MachineAssessPatchesResult() { }
        public System.Guid? AssessmentActivityId { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification AvailablePatchCountByClassification { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.OSType? OSType { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? PatchServiceUsed { get { throw null; } }
        public bool? RebootPending { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? StartedBy { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class MachineExtensionInstanceView
    {
        public MachineExtensionInstanceView() { }
        public string MachineExtensionInstanceViewType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus Status { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class MachineExtensionInstanceViewStatus
    {
        public MachineExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
    }
    public partial class MachineExtensionProperties
    {
        public MachineExtensionProperties() { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView InstanceView { get { throw null; } set { } }
        public string MachineExtensionPropertiesType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ProtectedSettings { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class MachineExtensionUpgrade
    {
        public MachineExtensionUpgrade() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties> ExtensionTargets { get { throw null; } }
    }
    public partial class MachineInstallPatchesContent
    {
        public MachineInstallPatchesContent(System.TimeSpan maximumDuration, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting rebootSetting) { }
        public Azure.ResourceManager.HybridCompute.Models.LinuxParameters LinuxParameters { get { throw null; } set { } }
        public System.TimeSpan MaximumDuration { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting RebootSetting { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.WindowsParameters WindowsParameters { get { throw null; } set { } }
    }
    public partial class MachineInstallPatchesResult
    {
        internal MachineInstallPatchesResult() { }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public int? ExcludedPatchCount { get { throw null; } }
        public int? FailedPatchCount { get { throw null; } }
        public string InstallationActivityId { get { throw null; } }
        public int? InstalledPatchCount { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public bool? MaintenanceWindowExceeded { get { throw null; } }
        public int? NotSelectedPatchCount { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.OSType? OSType { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? PatchServiceUsed { get { throw null; } }
        public int? PendingPatchCount { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus? RebootStatus { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? StartedBy { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus? Status { get { throw null; } }
    }
    public partial class MachineRunCommandInstanceView
    {
        internal MachineRunCommandInstanceView() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Error { get { throw null; } }
        public string ExecutionMessage { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.ExecutionState? ExecutionState { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public string Output { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus> Statuses { get { throw null; } }
    }
    public partial class MachineRunCommandScriptSource
    {
        public MachineRunCommandScriptSource() { }
        public string CommandId { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity ScriptUriManagedIdentity { get { throw null; } set { } }
    }
    public partial class NetworkInterface
    {
        internal NetworkInterface() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.IPAddress> IPAddresses { get { throw null; } }
    }
    public partial class NetworkProfile
    {
        internal NetworkProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
    }
    public partial class OSProfile
    {
        public OSProfile() { }
        public string ComputerName { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfileLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.OSProfileWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class OSProfileLinuxConfiguration
    {
        public OSProfileLinuxConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AssessmentModeType? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.PatchModeType? PatchMode { get { throw null; } set { } }
    }
    public partial class OSProfileWindowsConfiguration
    {
        public OSProfileWindowsConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AssessmentModeType? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.PatchModeType? PatchMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OSType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.OSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OSType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.OSType Linux { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.OSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.OSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.OSType left, Azure.ResourceManager.HybridCompute.Models.OSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.OSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.OSType left, Azure.ResourceManager.HybridCompute.Models.OSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchModeType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PatchModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchModeType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType AutomaticByOS { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType AutomaticByPlatform { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType ImageDefault { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchModeType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.PatchModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.PatchModeType left, Azure.ResourceManager.HybridCompute.Models.PatchModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.PatchModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.PatchModeType left, Azure.ResourceManager.HybridCompute.Models.PatchModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchOperationStartedBy : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchOperationStartedBy(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy Platform { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy left, Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy left, Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchOperationStatus : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus left, Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus left, Azure.ResourceManager.HybridCompute.Models.PatchOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PatchServiceUsed : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchServiceUsed(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed APT { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed Unknown { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed WU { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed WUWsus { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed YUM { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed Zypper { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed left, Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed left, Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionDataModel : Azure.ResourceManager.Models.ResourceData
    {
        internal PrivateEndpointConnectionDataModel() { }
        public Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        public PrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkScopeValidationDetails
    {
        internal PrivateLinkScopeValidationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ConnectionDetail> ConnectionDetails { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } }
    }
    public partial class ProductFeature
    {
        public ProductFeature() { }
        public System.DateTimeOffset? BillingStartOn { get { throw null; } }
        public System.DateTimeOffset? DisenrollmentOn { get { throw null; } }
        public System.DateTimeOffset? EnrollmentOn { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.ProvisioningState left, Azure.ResourceManager.HybridCompute.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.ProvisioningState left, Azure.ResourceManager.HybridCompute.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType left, Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType left, Azure.ResourceManager.HybridCompute.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunCommandInputParameter
    {
        public RunCommandInputParameter(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class RunCommandManagedIdentity
    {
        public RunCommandManagedIdentity() { }
        public string ClientId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationLinux : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationLinux(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux Critical { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux Other { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux Security { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchClassificationWindow : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchClassificationWindow(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow Critical { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow Definition { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow FeaturePack { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow Security { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow ServicePack { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow Tools { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow UpdateRollUp { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow Updates { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootSetting : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootSetting(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting Always { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting IfRequired { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmGuestPatchRebootStatus : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmGuestPatchRebootStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus NotNeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus Required { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus Started { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus left, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsParameters
    {
        public WindowsParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow> ClassificationsToInclude { get { throw null; } }
        public bool? ExcludeKbsRequiringReboot { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
        public System.DateTimeOffset? MaxPatchPublishOn { get { throw null; } set { } }
    }
}
