namespace Azure.ResourceManager.HybridCompute
{
    public static partial class HybridComputeExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> GetHybridComputeExtensionValue(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>> GetHybridComputeExtensionValueAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource GetHybridComputeExtensionValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueCollection GetHybridComputeExtensionValues(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string publisher, string extensionType) { throw null; }
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
    public partial class HybridComputeExtensionValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>, System.Collections.IEnumerable
    {
        protected HybridComputeExtensionValueCollection() { }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridComputeExtensionValueData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData>
    {
        public HybridComputeExtensionValueData() { }
        public string ExtensionType { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeExtensionValueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridComputeExtensionValueResource() { }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string publisher, string extensionType, string version) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class HybridComputeMachineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineData>
    {
        public HybridComputeMachineData(Azure.Core.AzureLocation location) { }
        public string ADFqdn { get { throw null; } }
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
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation LocationData { get { throw null; } set { } }
        public string MachineFqdn { get { throw null; } }
        public string MSSqlDiscovered { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface> NetworkInterfaces { get { throw null; } }
        public string OSEdition { get { throw null; } }
        public string OSName { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile OSProfile { get { throw null; } set { } }
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
        Azure.ResourceManager.HybridCompute.HybridComputeMachineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.HybridComputeMachineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HybridComputeMachineExtensionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData>
    {
        public HybridComputeMachineExtensionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile> GetNetworkProfile(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>> GetNetworkProfileAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class HybridComputePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData>
    {
        public HybridComputePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HybridComputePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData>
    {
        public HybridComputePrivateLinkResourceData() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HybridComputePrivateLinkScopeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData>
    {
        public HybridComputePrivateLinkScopeData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MachineRunCommandData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.MachineRunCommandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.MachineRunCommandData>
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
        Azure.ResourceManager.HybridCompute.MachineRunCommandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.MachineRunCommandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.MachineRunCommandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.MachineRunCommandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.MachineRunCommandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.MachineRunCommandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.MachineRunCommandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource GetHybridComputeExtensionValueResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource> GetHybridComputeExtensionValue(Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueResource>> GetHybridComputeExtensionValueAsync(Azure.Core.AzureLocation location, string publisher, string extensionType, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueCollection GetHybridComputeExtensionValues(Azure.Core.AzureLocation location, string publisher, string extensionType) { throw null; }
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
    public partial class AgentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AgentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentConfiguration>
    {
        internal AgentConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode? ConfigMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension> ExtensionsAllowList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension> ExtensionsBlockList { get { throw null; } }
        public string ExtensionsEnabled { get { throw null; } }
        public string GuestConfigurationEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IncomingConnectionsPorts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ProxyBypass { get { throw null; } }
        public System.Uri ProxyUri { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.AgentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AgentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AgentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.AgentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AgentUpgrade : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AgentUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentUpgrade>
    {
        public AgentUpgrade() { }
        public System.Guid? CorrelationId { get { throw null; } set { } }
        public string DesiredVersion { get { throw null; } set { } }
        public bool? IsAutomaticUpgradeEnabled { get { throw null; } set { } }
        public string LastAttemptDesiredVersion { get { throw null; } }
        public System.DateTimeOffset? LastAttemptedOn { get { throw null; } }
        public string LastAttemptMessage { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum? LastAttemptStatus { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.AgentUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AgentUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AgentUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.AgentUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AgentUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArcKindEnum : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.ArcKindEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArcKindEnum(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum Avs { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum Aws { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum Eps { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum Gcp { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum Hci { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.ArcKindEnum ScVmm { get { throw null; } }
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
        public static Azure.ResourceManager.HybridCompute.Models.AgentConfiguration AgentConfiguration(System.Uri proxyUri = null, System.Collections.Generic.IEnumerable<string> incomingConnectionsPorts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension> extensionsAllowList = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension> extensionsBlockList = null, System.Collections.Generic.IEnumerable<string> proxyBypass = null, string extensionsEnabled = null, string guestConfigurationEnabled = null, Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode? configMode = default(Azure.ResourceManager.HybridCompute.Models.AgentConfigurationMode?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AgentUpgrade AgentUpgrade(string desiredVersion = null, System.Guid? correlationId = default(System.Guid?), bool? isAutomaticUpgradeEnabled = default(bool?), string lastAttemptDesiredVersion = null, System.DateTimeOffset? lastAttemptedOn = default(System.DateTimeOffset?), Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum? lastAttemptStatus = default(Azure.ResourceManager.HybridCompute.Models.LastAttemptStatusEnum?), string lastAttemptMessage = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification AvailablePatchCountByClassification(int? security = default(int?), int? critical = default(int?), int? definition = default(int?), int? updateRollup = default(int?), int? featurePack = default(int?), int? servicePack = default(int?), int? tools = default(int?), int? updates = default(int?), int? other = default(int?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.EsuKey EsuKey(string sku = null, string licenseStatus = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus ExtensionsResourceStatus(string code = null, Azure.ResourceManager.HybridCompute.Models.ExtensionsStatusLevelType? level = default(Azure.ResourceManager.HybridCompute.Models.ExtensionsStatusLevelType?), string displayStatus = null, string message = null, System.DateTimeOffset? time = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension HybridComputeConfigurationExtension(string publisher = null, string configurationExtensionType = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail HybridComputeConnectionDetail(Azure.Core.ResourceIdentifier id = null, string privateIPAddress = null, string linkIdentifier = null, string groupId = null, string memberName = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeExtensionValueData HybridComputeExtensionValueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string version = null, string extensionType = null, string publisher = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress HybridComputeIPAddress(string address = null, string ipAddressVersion = null, string subnetAddressPrefix = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense HybridComputeLicense(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState? provisioningState = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType? licenseType = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType?), Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails licenseDetails = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails HybridComputeLicenseDetails(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState? state = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState?), Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget? target = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget?), Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition? edition = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition?), Azure.ResourceManager.HybridCompute.Models.LicenseCoreType? licenseCoreType = default(Azure.ResourceManager.HybridCompute.Models.LicenseCoreType?), int? processors = default(int?), int? assignedLicenses = default(int?), string immutableId = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineData HybridComputeMachineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData> resources = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HybridCompute.Models.ArcKindEnum? kind = default(Azure.ResourceManager.HybridCompute.Models.ArcKindEnum?), Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation locationData = null, Azure.ResourceManager.HybridCompute.Models.AgentConfiguration agentConfiguration = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses serviceStatuses = null, string cloudMetadataProvider = null, Azure.ResourceManager.HybridCompute.Models.AgentUpgrade agentUpgrade = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile osProfile = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView licenseProfile = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType? status = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusType?), System.DateTimeOffset? lastStatusChange = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResponseError> errorDetails = null, string agentVersion = null, System.Guid? vmId = default(System.Guid?), string displayName = null, string machineFqdn = null, string clientPublicKey = null, string osName = null, string osVersion = null, string osType = null, System.Guid? vmUuid = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView> extensions = null, string osSku = null, string osEdition = null, string domainName = null, string adFqdn = null, string dnsFqdn = null, Azure.Core.ResourceIdentifier privateLinkScopeResourceId = null, Azure.Core.ResourceIdentifier parentClusterResourceId = null, string msSqlDiscovered = null, System.Collections.Generic.IReadOnlyDictionary<string, string> detectedProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface> networkInterfaces = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputeMachineExtensionData HybridComputeMachineExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface HybridComputeNetworkInterface(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress> ipAddresses = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile HybridComputeNetworkProfile(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface> networkInterfaces = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile HybridComputeOSProfile(string computerName = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration windowsConfiguration = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration linuxConfiguration = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateEndpointConnectionData HybridComputePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties HybridComputePrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null, System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkResourceData HybridComputePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties HybridComputePrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.HybridComputePrivateLinkScopeData HybridComputePrivateLinkScopeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties HybridComputePrivateLinkScopeProperties(Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType?), string provisioningState = null, string privateLinkScopeId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty HybridComputePrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature HybridComputeProductFeature(string name = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus?), System.DateTimeOffset? billingStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? enrollmentOn = default(System.DateTimeOffset?), System.DateTimeOffset? disenrollmentOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense LicenseProfileArmEsuPropertiesWithoutAssignedLicense(System.Guid? assignedLicenseImmutableId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.EsuKey> esuKeys = null, Azure.ResourceManager.HybridCompute.Models.EsuServerType? serverType = default(Azure.ResourceManager.HybridCompute.Models.EsuServerType?), Azure.ResourceManager.HybridCompute.Models.EsuEligibility? esuEligibility = default(Azure.ResourceManager.HybridCompute.Models.EsuEligibility?), Azure.ResourceManager.HybridCompute.Models.EsuKeyState? esuKeyState = default(Azure.ResourceManager.HybridCompute.Models.EsuKeyState?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView LicenseProfileMachineInstanceView(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus? licenseStatus = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus?), string licenseChannel = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties esuProfile = null, Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus?), Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType? productType = default(Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType?), System.DateTimeOffset? billingStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? enrollmentOn = default(System.DateTimeOffset?), System.DateTimeOffset? disenrollmentOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature> productFeatures = null, bool? isSoftwareAssuranceCustomer = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties LicenseProfileMachineInstanceViewEsuProperties(System.Guid? assignedLicenseImmutableId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.EsuKey> esuKeys = null, Azure.ResourceManager.HybridCompute.Models.EsuServerType? serverType = default(Azure.ResourceManager.HybridCompute.Models.EsuServerType?), Azure.ResourceManager.HybridCompute.Models.EsuEligibility? esuEligibility = default(Azure.ResourceManager.HybridCompute.Models.EsuEligibility?), Azure.ResourceManager.HybridCompute.Models.EsuKeyState? esuKeyState = default(Azure.ResourceManager.HybridCompute.Models.EsuKeyState?), Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense assignedLicense = null, Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState? licenseAssignmentState = default(Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState?)) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties LicenseProfileStorageModelEsuProperties(System.Guid? assignedLicenseImmutableId = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.EsuKey> esuKeys = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult MachineAssessPatchesResult(Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus? status = default(Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus?), System.Guid? assessmentActivityId = default(System.Guid?), bool? isRebootPending = default(bool?), Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification availablePatchCountByClassification = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? startedBy = default(Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy?), Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? patchServiceUsed = default(Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed?), Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType? osType = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties MachineExtensionProperties(string forceUpdateTag = null, string publisher = null, string machineExtensionPropertiesType = null, string typeHandlerVersion = null, bool? enableAutomaticUpgrade = default(bool?), bool? autoUpgradeMinorVersion = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> settings = null, System.Collections.Generic.IDictionary<string, System.BinaryData> protectedSettings = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent MachineInstallPatchesContent(System.TimeSpan maximumDuration = default(System.TimeSpan), Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting rebootSetting = default(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting), Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters windowsParameters = null, Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters linuxParameters = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult MachineInstallPatchesResult(Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus? status = default(Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus?), string installationActivityId = null, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus? rebootStatus = default(Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus?), bool? maintenanceWindowExceeded = default(bool?), int? excludedPatchCount = default(int?), int? notSelectedPatchCount = default(int?), int? pendingPatchCount = default(int?), int? installedPatchCount = default(int?), int? failedPatchCount = default(int?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? startedBy = default(Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy?), Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? patchServiceUsed = default(Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed?), Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType? osType = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.MachineRunCommandData MachineRunCommandData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource source = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter> protectedParameters = null, bool? asyncExecution = default(bool?), string runAsUser = null, string runAsPassword = null, int? timeoutInSeconds = default(int?), System.Uri outputBlobUri = null, System.Uri errorBlobUri = null, Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity outputBlobManagedIdentity = null, Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity errorBlobManagedIdentity = null, string provisioningState = null, Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView instanceView = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView MachineRunCommandInstanceView(Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState? executionState = default(Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState?), string executionMessage = null, int? exitCode = default(int?), string output = null, string error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus> statuses = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel PrivateEndpointConnectionDataModel(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails PrivateLinkScopeValidationDetails(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail> connectionDetails = null) { throw null; }
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
    public partial class AvailablePatchCountByClassification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification>
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
        Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EsuKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.EsuKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.EsuKey>
    {
        internal EsuKey() { }
        public string LicenseStatus { get { throw null; } }
        public string Sku { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.EsuKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.EsuKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.EsuKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.EsuKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.EsuKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.EsuKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.EsuKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.HybridCompute.Models.EsuServerType DataCenter { get { throw null; } }
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
    public partial class ExtensionsResourceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus>
    {
        internal ExtensionsResourceStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.ExtensionsStatusLevelType? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ExtensionsStatusLevelType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
    }
    public partial class ExtensionTargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties>
    {
        public ExtensionTargetProperties() { }
        public string TargetVersion { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeConfigurationExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension>
    {
        internal HybridComputeConfigurationExtension() { }
        public string ConfigurationExtensionType { get { throw null; } }
        public string Publisher { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConfigurationExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeConnectionDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail>
    {
        internal HybridComputeConnectionDetail() { }
        public string GroupId { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string LinkIdentifier { get { throw null; } }
        public string MemberName { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeExecutionState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeExecutionState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState Pending { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState Running { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState TimedOut { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState left, Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState left, Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridComputeIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress>
    {
        internal HybridComputeIPAddress() { }
        public string Address { get { throw null; } }
        public string IPAddressVersion { get { throw null; } }
        public string SubnetAddressPrefix { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeLicense : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense>
    {
        public HybridComputeLicense(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails LicenseDetails { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType? LicenseType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeLicenseDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails>
    {
        public HybridComputeLicenseDetails() { }
        public int? AssignedLicenses { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition? Edition { get { throw null; } set { } }
        public string ImmutableId { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseCoreType? LicenseCoreType { get { throw null; } set { } }
        public int? Processors { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState? State { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget? Target { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeLicenseEdition : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeLicenseEdition(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition DataCenter { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeLicenseState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeLicenseState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState Activated { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState Deactivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeLicenseStatus : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeLicenseStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus ExtendedGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus Licensed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus NonGenuineGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus Notification { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus OobGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus OotGrace { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus Unlicensed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeLicenseTarget : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeLicenseTarget(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget WindowsServer2012 { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget WindowsServer2012R2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseTarget right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeLicenseType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType Esu { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridComputeLinuxConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration>
    {
        public HybridComputeLinuxConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AssessmentModeType? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.PatchModeType? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeLinuxParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters>
    {
        public HybridComputeLinuxParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationLinux> ClassificationsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToInclude { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation>
    {
        public HybridComputeLocation(string name) { }
        public string City { get { throw null; } set { } }
        public string CountryOrRegion { get { throw null; } set { } }
        public string District { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeMachineExtensionPatch : Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch>
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
        Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachineExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeMachinePatch : Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch>
    {
        public HybridComputeMachinePatch() { }
        public Azure.ResourceManager.HybridCompute.Models.AgentUpgrade AgentUpgrade { get { throw null; } set { } }
        public string CloudMetadataProvider { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.ArcKindEnum? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLocation LocationData { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile OSProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParentClusterResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkScopeResourceId { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeMachinePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeNetworkInterface : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface>
    {
        internal HybridComputeNetworkInterface() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.HybridComputeIPAddress> IPAddresses { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>
    {
        internal HybridComputeNetworkProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkInterface> NetworkInterfaces { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeOSProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile>
    {
        public HybridComputeOSProfile() { }
        public string ComputerName { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxConfiguration LinuxConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeOSType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeOSType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType left, Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridComputePrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties>
    {
        public HybridComputePrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputePrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties>
    {
        public HybridComputePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputePrivateLinkScopePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch>
    {
        public HybridComputePrivateLinkScopePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputePrivateLinkScopeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties>
    {
        public HybridComputePrivateLinkScopeProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel> PrivateEndpointConnections { get { throw null; } }
        public string PrivateLinkScopeId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkScopeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputePrivateLinkServiceConnectionStateProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty>
    {
        public HybridComputePrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateLinkServiceConnectionStateProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeProductFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature>
    {
        public HybridComputeProductFeature() { }
        public System.DateTimeOffset? BillingStartOn { get { throw null; } }
        public System.DateTimeOffset? DisenrollmentOn { get { throw null; } }
        public System.DateTimeOffset? EnrollmentOn { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputeProvisioningState : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState left, Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState left, Azure.ResourceManager.HybridCompute.Models.HybridComputeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridComputePublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridComputePublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType left, Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType left, Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridComputeResourceUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate>
    {
        public HybridComputeResourceUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeResourceUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeServiceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus>
    {
        public HybridComputeServiceStatus() { }
        public string StartupType { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeServiceStatuses : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses>
    {
        public HybridComputeServiceStatuses() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus ExtensionService { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatus GuestConfigurationService { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeServiceStatuses>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HybridComputeWindowsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration>
    {
        public HybridComputeWindowsConfiguration() { }
        public Azure.ResourceManager.HybridCompute.Models.AssessmentModeType? AssessmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.PatchModeType? PatchMode { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridComputeWindowsParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters>
    {
        public HybridComputeWindowsParameters() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.VmGuestPatchClassificationWindow> ClassificationsToInclude { get { throw null; } }
        public bool? ExcludeKbsRequiringReboot { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
        public System.DateTimeOffset? MaxPatchPublishOn { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LicenseProfileArmEsuPropertiesWithoutAssignedLicense : Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense>
    {
        public LicenseProfileArmEsuPropertiesWithoutAssignedLicense() { }
        public Azure.ResourceManager.HybridCompute.Models.EsuEligibility? EsuEligibility { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.EsuKeyState? EsuKeyState { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.EsuServerType? ServerType { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LicenseProfileMachineInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView>
    {
        public LicenseProfileMachineInstanceView() { }
        public System.DateTimeOffset? BillingStartOn { get { throw null; } }
        public System.DateTimeOffset? DisenrollmentOn { get { throw null; } }
        public System.DateTimeOffset? EnrollmentOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties EsuProfile { get { throw null; } set { } }
        public bool? IsSoftwareAssuranceCustomer { get { throw null; } set { } }
        public string LicenseChannel { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLicenseStatus? LicenseStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridCompute.Models.HybridComputeProductFeature> ProductFeatures { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType? ProductType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseProfileSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LicenseProfileMachineInstanceViewEsuProperties : Azure.ResourceManager.HybridCompute.Models.LicenseProfileArmEsuPropertiesWithoutAssignedLicense, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties>
    {
        public LicenseProfileMachineInstanceViewEsuProperties() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLicense AssignedLicense { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.LicenseAssignmentState? LicenseAssignmentState { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileMachineInstanceViewEsuProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LicenseProfileProductType : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LicenseProfileProductType(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.LicenseProfileProductType WindowsIotEnterprise { get { throw null; } }
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
    public partial class LicenseProfileStorageModelEsuProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties>
    {
        public LicenseProfileStorageModelEsuProperties() { }
        public System.Guid? AssignedLicenseImmutableId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.EsuKey> EsuKeys { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.LicenseProfileStorageModelEsuProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MachineAssessPatchesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>
    {
        internal MachineAssessPatchesResult() { }
        public System.Guid? AssessmentActivityId { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.AvailablePatchCountByClassification AvailablePatchCountByClassification { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public bool? IsRebootPending { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType? OSType { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? PatchServiceUsed { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? StartedBy { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineAssessPatchesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineExtensionInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView>
    {
        public MachineExtensionInstanceView() { }
        public string MachineExtensionInstanceViewType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus Status { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineExtensionInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus>
    {
        public MachineExtensionInstanceViewStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeStatusLevelType? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties>
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
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineExtensionUpgrade : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade>
    {
        public MachineExtensionUpgrade() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HybridCompute.Models.ExtensionTargetProperties> ExtensionTargets { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineExtensionUpgrade>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineInstallPatchesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent>
    {
        public MachineInstallPatchesContent(System.TimeSpan maximumDuration, Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting rebootSetting) { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeLinuxParameters LinuxParameters { get { throw null; } set { } }
        public System.TimeSpan MaximumDuration { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootSetting RebootSetting { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeWindowsParameters WindowsParameters { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineInstallPatchesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>
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
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeOSType? OSType { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed? PatchServiceUsed { get { throw null; } }
        public int? PendingPatchCount { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.VmGuestPatchRebootStatus? RebootStatus { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.PatchOperationStartedBy? StartedBy { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus? Status { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineInstallPatchesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineOperationStatus : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus left, Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus left, Azure.ResourceManager.HybridCompute.Models.MachineOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineRunCommandInstanceView : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView>
    {
        internal MachineRunCommandInstanceView() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Error { get { throw null; } }
        public string ExecutionMessage { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputeExecutionState? ExecutionState { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public string Output { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.ExtensionsResourceStatus> Statuses { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandInstanceView>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MachineRunCommandScriptSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource>
    {
        public MachineRunCommandScriptSource() { }
        public string CommandId { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity ScriptUriManagedIdentity { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.MachineRunCommandScriptSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct PatchServiceUsed : System.IEquatable<Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PatchServiceUsed(string value) { throw null; }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed Apt { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed Unknown { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed WU { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed WUWsus { get { throw null; } }
        public static Azure.ResourceManager.HybridCompute.Models.PatchServiceUsed Yum { get { throw null; } }
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
    public partial class PrivateEndpointConnectionDataModel : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel>
    {
        internal PrivateEndpointConnectionDataModel() { }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePrivateEndpointConnectionProperties Properties { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateEndpointConnectionDataModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateLinkScopeValidationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>
    {
        internal PrivateLinkScopeValidationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridCompute.Models.HybridComputeConnectionDetail> ConnectionDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.HybridCompute.Models.HybridComputePublicNetworkAccessType? PublicNetworkAccess { get { throw null; } }
        Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.PrivateLinkScopeValidationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandInputParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter>
    {
        public RunCommandInputParameter(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandInputParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCommandManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity>
    {
        public RunCommandManagedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridCompute.Models.RunCommandManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
