namespace Azure.ResourceManager.ContainerRegistry
{
    public partial class AzureResourceManagerContainerRegistryContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerRegistryContext() { }
        public static Azure.ResourceManager.ContainerRegistry.AzureResourceManagerContainerRegistryContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConnectedRegistryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>, System.Collections.IEnumerable
    {
        protected ConnectedRegistryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectedRegistryName, Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectedRegistryName, Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> Get(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetIfExists(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetIfExistsAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectedRegistryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>
    {
        public ConnectedRegistryData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus? ActivationStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ClientTokenIds { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState? ConnectionState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties GarbageCollection { get { throw null; } set { } }
        public System.DateTimeOffset? LastActivityOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging Logging { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer LoginServer { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationsList { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent Parent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail> StatusDetails { get { throw null; } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectedRegistryResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string connectedRegistryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Deactivate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeactivateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryAgentPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetIfExists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetIfExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryAgentPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>
    {
        public ContainerRegistryAgentPoolData(Azure.Core.AzureLocation location) { }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string Tier { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryAgentPoolResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string agentPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus> GetQueueStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>> GetQueueStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryCacheRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryCacheRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cacheRuleName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cacheRuleName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> Get(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetIfExists(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetIfExistsAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryCacheRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>
    {
        public ContainerRegistryCacheRuleData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier CredentialSetResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string SourceRepository { get { throw null; } set { } }
        public string TargetRepository { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCacheRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryCacheRuleResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string cacheRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string registryName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> Get(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetIfExists(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetIfExistsAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryCredentialSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryCredentialSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string credentialSetName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string credentialSetName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> Get(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetIfExists(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetIfExistsAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryCredentialSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>
    {
        public ContainerRegistryCredentialSetData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential> AuthCredentials { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LoginServer { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCredentialSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryCredentialSetResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string credentialSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>
    {
        public ContainerRegistryData(Azure.Core.AzureLocation location, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku) { }
        public Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DataEndpointHostNames { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAdminUserEnabled { get { throw null; } set { } }
        public bool? IsAnonymousPullEnabled { get { throw null; } set { } }
        public bool? IsDataEndpointEnabled { get { throw null; } set { } }
        public string LoginServer { get { throw null; } }
        public bool? NetworkRuleBypassAllowedForTasks { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? NetworkRuleBypassOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies Policies { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? RoleAssignmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus Status { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ContainerRegistryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult> CheckContainerRegistryNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>> CheckContainerRegistryNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource GetConnectedRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCollection GetContainerRegistries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistry(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetContainerRegistryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource GetContainerRegistryCacheRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource GetContainerRegistryCredentialSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource GetContainerRegistryPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource GetContainerRegistryPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource GetContainerRegistryReplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource GetContainerRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource GetContainerRegistryRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource GetContainerRegistryTaskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource GetContainerRegistryTokenResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource GetContainerRegistryWebhookResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ScopeMapResource GetScopeMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>
    {
        public ContainerRegistryPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryPrivateLinkResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>
    {
        public ContainerRegistryPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredPrivateLinkZoneNames { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryReplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryReplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicationName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicationName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> Get(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetIfExists(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetIfExistsAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryReplicationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>
    {
        public ContainerRegistryReplicationData(Azure.Core.AzureLocation location) { }
        public bool? IsRegionEndpointEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus Status { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryReplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryReplicationResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string replicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult> GenerateCredentials(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>> GenerateCredentialsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition> GetBuildSourceUploadUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>> GetBuildSourceUploadUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ConnectedRegistryCollection GetConnectedRegistries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource> GetConnectedRegistry(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource>> GetConnectedRegistryAsync(string connectedRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource> GetContainerRegistryAgentPool(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource>> GetContainerRegistryAgentPoolAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolCollection GetContainerRegistryAgentPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource> GetContainerRegistryCacheRule(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource>> GetContainerRegistryCacheRuleAsync(string cacheRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleCollection GetContainerRegistryCacheRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource> GetContainerRegistryCredentialSet(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource>> GetContainerRegistryCredentialSetAsync(string credentialSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetCollection GetContainerRegistryCredentialSets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource> GetContainerRegistryPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource>> GetContainerRegistryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionCollection GetContainerRegistryPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource> GetContainerRegistryPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource>> GetContainerRegistryPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceCollection GetContainerRegistryPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource> GetContainerRegistryReplication(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource>> GetContainerRegistryReplicationAsync(string replicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationCollection GetContainerRegistryReplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetContainerRegistryRun(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetContainerRegistryRunAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunCollection GetContainerRegistryRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetContainerRegistryTask(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetContainerRegistryTaskAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetContainerRegistryTaskRun(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetContainerRegistryTaskRunAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunCollection GetContainerRegistryTaskRuns() { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskCollection GetContainerRegistryTasks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetContainerRegistryToken(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetContainerRegistryTokenAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenCollection GetContainerRegistryTokens() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetContainerRegistryWebhook(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetContainerRegistryWebhookAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookCollection GetContainerRegistryWebhooks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetScopeMap(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetScopeMapAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ScopeMapCollection GetScopeMaps() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage> GetUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage> GetUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportImage(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportImageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult> RegenerateCredential(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>> RegenerateCredentialAsync(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> ScheduleRun(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> ScheduleRun(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> ScheduleRunAsync(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> ScheduleRunAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryRunCollection() { }
        public virtual Azure.Response<bool> Exists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> Get(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> GetIfExists(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetIfExistsAsync(string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>
    {
        public ContainerRegistryRunData() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CustomRegistries { get { throw null; } }
        public System.DateTimeOffset? FinishOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger ImageUpdateTrigger { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor LogArtifact { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor> OutputImages { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RunErrorMessage { get { throw null; } }
        public string RunId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType? RunType { get { throw null; } set { } }
        public string SourceRegistryAuth { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor SourceTrigger { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus? Status { get { throw null; } set { } }
        public string Task { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor TimerTrigger { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Cancel(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string runId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult> GetLogSasUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>> GetLogSasUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> Update(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> UpdateAsync(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTaskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTaskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> Get(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetIfExists(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetIfExistsAsync(string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTaskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>
    {
        public ContainerRegistryTaskData(Azure.Core.AzureLocation location) { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsSystemTask { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties Step { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties Trigger { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTaskResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> Update(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> UpdateAsync(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTaskRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTaskRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string taskRunName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> Get(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetIfExists(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetIfExistsAsync(string taskRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTaskRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>
    {
        public ContainerRegistryTaskRunData() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData RunResult { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTaskRunResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string taskRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryTokenCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryTokenCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string tokenName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string tokenName, Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> Get(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> GetIfExists(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetIfExistsAsync(string tokenName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryTokenData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>
    {
        public ContainerRegistryTokenData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ScopeMapId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus? Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTokenResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryTokenResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string tokenName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerRegistryWebhookCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>, System.Collections.IEnumerable
    {
        protected ContainerRegistryWebhookCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string webhookName, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> Get(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> GetIfExists(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetIfExistsAsync(string webhookName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerRegistryWebhookData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>
    {
        public ContainerRegistryWebhookData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> Actions { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerRegistryWebhookResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string webhookName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig> GetCallbackConfig(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>> GetCallbackConfigAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent> GetEvents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent> GetEventsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo> Ping(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>> PingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScopeMapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>, System.Collections.IEnumerable
    {
        protected ScopeMapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scopeMapName, Azure.ResourceManager.ContainerRegistry.ScopeMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scopeMapName, Azure.ResourceManager.ContainerRegistry.ScopeMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> Get(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> GetIfExists(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetIfExistsAsync(string scopeMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScopeMapData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>
    {
        public ScopeMapData() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public string ScopeMapType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopeMapResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScopeMapResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ScopeMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string registryName, string scopeMapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.ScopeMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.ScopeMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerRegistry.ScopeMapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Mocking
{
    public partial class MockableContainerRegistryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryArmClient() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ConnectedRegistryResource GetConnectedRegistryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolResource GetContainerRegistryAgentPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleResource GetContainerRegistryCacheRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetResource GetContainerRegistryCredentialSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionResource GetContainerRegistryPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResource GetContainerRegistryPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationResource GetContainerRegistryReplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource GetContainerRegistryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunResource GetContainerRegistryRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskResource GetContainerRegistryTaskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunResource GetContainerRegistryTaskRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenResource GetContainerRegistryTokenResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookResource GetContainerRegistryWebhookResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerRegistry.ScopeMapResource GetScopeMapResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerRegistryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistryResourceGroupResource() { }
        public virtual Azure.ResourceManager.ContainerRegistry.ContainerRegistryCollection GetContainerRegistries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistry(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource>> GetContainerRegistryAsync(string registryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableContainerRegistrySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerRegistrySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult> CheckContainerRegistryNameAvailability(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>> CheckContainerRegistryNameAvailabilityAsync(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryResource> GetContainerRegistriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AadAuthenticationAsArmPolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AadAuthenticationAsArmPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionsRequiredForPrivateLinkServiceConsumer : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionsRequiredForPrivateLinkServiceConsumer(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer None { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer Recreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer left, Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer left, Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmContainerRegistryModelFactory
    {
        public static Azure.ResourceManager.ContainerRegistry.ConnectedRegistryData ConnectedRegistryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode? mode = default(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode?), string version = null, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState? connectionState = default(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState?), System.DateTimeOffset? lastActivityOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus? activationStatus = default(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus?), Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent parent = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> clientTokenIds = null, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer loginServer = null, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging logging = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail> statusDetails = null, System.Collections.Generic.IEnumerable<string> notificationsList = null, Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties garbageCollection = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer ConnectedRegistryLoginServer(string host = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties tls = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail ConnectedRegistryStatusDetail(string statusDetailType = null, string code = null, string description = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Guid? correlationId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties ConnectedRegistrySyncProperties(Azure.Core.ResourceIdentifier tokenId = null, string schedule = null, System.TimeSpan? syncWindow = default(System.TimeSpan?), System.TimeSpan messageTtl = default(System.TimeSpan), System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?), string gatewayEndpoint = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryAgentPoolData ContainerRegistryAgentPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? count = default(int?), string tier = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS? os = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS?), Azure.Core.ResourceIdentifier virtualNetworkSubnetResourceId = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus ContainerRegistryAgentPoolQueueStatus(int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential ContainerRegistryAuthCredential(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName? name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName?), string usernameSecretIdentifier = null, string passwordSecretIdentifier = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth credentialHealth = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency ContainerRegistryBaseImageDependency(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType? dependencyType = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType?), string registry = null, string repository = null, string tag = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent ContainerRegistryBaseImageTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType? baseImageTriggerType = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType?), string updateTriggerEndpoint = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType? updateTriggerPayloadType = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCacheRuleData ContainerRegistryCacheRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier credentialSetResourceId = null, string sourceRepository = null, string targetRepository = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth ContainerRegistryCredentialHealth(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryCredentialSetData ContainerRegistryCredentialSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string loginServer = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential> authCredentials = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryData ContainerRegistryData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string loginServer, System.DateTimeOffset? createdOn, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet networkRuleSet, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies policies, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, System.Collections.Generic.IEnumerable<string> dataEndpointHostNames, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? zoneRedundancy) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryData ContainerRegistryData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string loginServer, System.DateTimeOffset? createdOn, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus status, bool? isAdminUserEnabled, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet networkRuleSet, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies policies, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption encryption, bool? isDataEndpointEnabled, System.Collections.Generic.IEnumerable<string> dataEndpointHostNames, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? zoneRedundancy, bool? isAnonymousPullEnabled) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryData ContainerRegistryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string loginServer = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus status = null, bool? isAdminUserEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet networkRuleSet = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies policies = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption encryption = null, bool? isDataEndpointEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> dataEndpointHostNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? networkRuleBypassOptions = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption?), bool? networkRuleBypassAllowedForTasks = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy?), bool? isAnonymousPullEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? roleAssignmentMode = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep ContainerRegistryDockerBuildStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, System.Collections.Generic.IEnumerable<string> imageNames = null, bool? isPushEnabled = default(bool?), bool? noCache = default(bool?), string dockerFilePath = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> arguments = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep ContainerRegistryEncodedTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string encodedTaskContent = null, string encodedValuesContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep ContainerRegistryFileTaskStep(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null, string taskFilePath = null, string valuesFilePath = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult ContainerRegistryGenerateCredentialsResult(string username = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword> passwords = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent ContainerRegistryImportImageContent(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource source = null, System.Collections.Generic.IEnumerable<string> targetTags = null, System.Collections.Generic.IEnumerable<string> untaggedTargetRepositories = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode? mode = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource ContainerRegistryImportSource(Azure.Core.ResourceIdentifier resourceId = null, string registryAddress = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials credentials = null, string sourceImage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials ContainerRegistryImportSourceCredentials(string username = null, string password = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties ContainerRegistryKeyVaultProperties(string keyIdentifier = null, string versionedKeyIdentifier = null, string identity = null, bool? isKeyRotationEnabled = default(bool?), System.DateTimeOffset? lastKeyRotationTimestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult ContainerRegistryListCredentialsResult(string username = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword> passwords = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent ContainerRegistryNameAvailabilityContent(string name, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType resourceType) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent ContainerRegistryNameAvailabilityContent(string name = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType resourceType = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType), string resourceGroupName = null, Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult ContainerRegistryNameAvailableResult(bool? isNameAvailable, string reason, string message) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult ContainerRegistryNameAvailableResult(string availableLoginServerName = null, bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword ContainerRegistryPassword(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName? name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName?), string value = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateEndpointConnectionData ContainerRegistryPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryPrivateLinkResourceData ContainerRegistryPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredPrivateLinkZoneNames = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryReplicationData ContainerRegistryReplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus status = null, bool? isRegionEndpointEnabled = default(bool?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus ContainerRegistryResourceStatus(string displayStatus = null, string message = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy ContainerRegistryRetentionPolicy(int? days = default(int?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData ContainerRegistryRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string runId = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType? runType = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType?), string agentPoolName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? finishOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor> outputImages = null, string task = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger imageUpdateTrigger = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor sourceTrigger = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor timerTrigger = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform = null, int? agentCpu = default(int?), string sourceRegistryAuth = null, System.Collections.Generic.IEnumerable<string> customRegistries = null, string runErrorMessage = null, string updateTriggerToken = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor logArtifact = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), bool? isArchiveEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult ContainerRegistryRunGetLogResult(string logLink = null, string logArtifactLink = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku ContainerRegistrySku(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier? tier = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent ContainerRegistrySourceTriggerUpdateContent(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent sourceRepository = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent> sourceTriggerEvents = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskData ContainerRegistryTaskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform = null, int? agentCpu = default(int?), string agentPoolName = null, int? timeoutInSeconds = default(int?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties step = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties trigger = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials credentials = null, string logTemplate = null, bool? isSystemTask = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTaskRunData ContainerRegistryTaskRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent runRequest = null, Azure.ResourceManager.ContainerRegistry.ContainerRegistryRunData runResult = null, string forceUpdateTag = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties ContainerRegistryTaskStepProperties(string containerRegistryTaskStepType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency> baseImageDependencies = null, string contextPath = null, string contextAccessToken = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent ContainerRegistryTimerTriggerUpdateContent(string schedule = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus?), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties ContainerRegistryTlsCertificateProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType? certificateType = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType?), string certificateLocation = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties ContainerRegistryTlsProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties certificate = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryTokenData ContainerRegistryTokenData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), Azure.Core.ResourceIdentifier scopeMapId = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials credentials = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword ContainerRegistryTokenPassword(System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName? name = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName?), string value = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage ContainerRegistryUsage(string name = null, long? limit = default(long?), long? currentValue = default(long?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit? unit = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig ContainerRegistryWebhookCallbackConfig(System.Uri serviceUri = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customHeaders = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent ContainerRegistryWebhookCreateOrUpdateContent(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri serviceUri = null, System.Collections.Generic.IDictionary<string, string> customHeaders = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus?), string scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> actions = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ContainerRegistryWebhookData ContainerRegistryWebhookData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? status = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus?), string scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> actions = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent ContainerRegistryWebhookEvent(System.Guid? id = default(System.Guid?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage eventRequestMessage = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage eventResponseMessage = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent ContainerRegistryWebhookEventContent(System.Guid? id = default(System.Guid?), System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string action = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget target = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent request = null, string actorName = null, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource source = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo ContainerRegistryWebhookEventInfo(System.Guid? id = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent ContainerRegistryWebhookEventRequestContent(System.Guid? id = default(System.Guid?), string addr = null, string host = null, string method = null, string userAgent = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage ContainerRegistryWebhookEventRequestMessage(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent content = null, System.Collections.Generic.IReadOnlyDictionary<string, string> headers = null, string method = null, System.Uri requestUri = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage ContainerRegistryWebhookEventResponseMessage(string content = null, System.Collections.Generic.IReadOnlyDictionary<string, string> headers = null, string reasonPhrase = null, string statusCode = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource ContainerRegistryWebhookEventSource(string addr = null, string instanceId = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget ContainerRegistryWebhookEventTarget(string mediaType = null, long? size = default(long?), string digest = null, long? length = default(long?), string repository = null, System.Uri uri = null, string tag = null, string name = null, string version = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.ScopeMapData ScopeMapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string scopeMapType = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState?), System.Collections.Generic.IEnumerable<string> actions = null) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition SourceUploadDefinition(System.Uri uploadUri = null, string relativePath = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope Unsecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryActivationStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryActivationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus Active { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryActivationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryAuditLogStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryAuditLogStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryConnectionState : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryConnectionState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Offline { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Online { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Syncing { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedRegistryLogging : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>
    {
        public ConnectedRegistryLogging() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryAuditLogStatus? AuditLogStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel? LogLevel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryLoginServer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>
    {
        public ConnectedRegistryLoginServer() { }
        public string Host { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties Tls { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLoginServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryLogLevel : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryLogLevel(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Debug { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Error { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Information { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel None { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectedRegistryMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectedRegistryMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode Mirror { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode Registry { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode left, Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectedRegistryParent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>
    {
        public ConnectedRegistryParent(Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties syncProperties) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties SyncProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryParent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>
    {
        public ConnectedRegistryPatch() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ClientTokenIds { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties GarbageCollection { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryLogging Logging { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotificationsList { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties SyncProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistryStatusDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>
    {
        internal ConnectedRegistryStatusDetail() { }
        public string Code { get { throw null; } }
        public System.Guid? CorrelationId { get { throw null; } }
        public string Description { get { throw null; } }
        public string StatusDetailType { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistryStatusDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistrySyncProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>
    {
        public ConnectedRegistrySyncProperties(Azure.Core.ResourceIdentifier tokenId, System.TimeSpan messageTtl) { }
        public string GatewayEndpoint { get { throw null; } }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public System.TimeSpan MessageTtl { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public System.TimeSpan? SyncWindow { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TokenId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedRegistrySyncUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>
    {
        public ConnectedRegistrySyncUpdateProperties() { }
        public System.TimeSpan? MessageTtl { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public System.TimeSpan? SyncWindow { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ConnectedRegistrySyncUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>
    {
        public ContainerRegistryAgentPoolPatch() { }
        public int? Count { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAgentPoolQueueStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>
    {
        internal ContainerRegistryAgentPoolQueueStatus() { }
        public int? Count { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAgentPoolQueueStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryAuthCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>
    {
        public ContainerRegistryAuthCredential() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth CredentialHealth { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName? Name { get { throw null; } set { } }
        public string PasswordSecretIdentifier { get { throw null; } set { } }
        public string UsernameSecretIdentifier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryBaseImageDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>
    {
        internal ContainerRegistryBaseImageDependency() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType? DependencyType { get { throw null; } }
        public string Digest { get { throw null; } }
        public string Registry { get { throw null; } }
        public string Repository { get { throw null; } }
        public string Tag { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryBaseImageDependencyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryBaseImageDependencyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType BuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType RunTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryBaseImageTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>
    {
        public ContainerRegistryBaseImageTrigger(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType baseImageTriggerType, string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryBaseImageTriggerType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryBaseImageTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType All { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType Runtime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryBaseImageTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>
    {
        public ContainerRegistryBaseImageTriggerUpdateContent(string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerType? BaseImageTriggerType { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        public string UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType? UpdateTriggerPayloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCacheRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>
    {
        public ContainerRegistryCacheRulePatch() { }
        public Azure.Core.ResourceIdentifier CredentialSetResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCacheRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCertificateType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType LocalDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCpuVariant : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCpuVariant(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant V6 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant V7 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant V8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryCredentialHealth : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>
    {
        internal ContainerRegistryCredentialHealth() { }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCredentialHealthStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCredentialHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryCredentialName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryCredentialName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName Credential1 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryCredentialRegenerateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>
    {
        public ContainerRegistryCredentialRegenerateContent(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialRegenerateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>
    {
        public ContainerRegistryCredentials() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials> CustomRegistries { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials SourceRegistry { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode? SourceRegistryLoginMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryCredentialSetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>
    {
        public ContainerRegistryCredentialSetPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryAuthCredential> AuthCredentials { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentialSetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>
    {
        public ContainerRegistryDockerBuildContent(string dockerFilePath, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildStep : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>
    {
        public ContainerRegistryDockerBuildStep(string dockerFilePath) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryDockerBuildStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>
    {
        public ContainerRegistryDockerBuildStepUpdateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public string DockerFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageNames { get { throw null; } }
        public bool? IsPushEnabled { get { throw null; } set { } }
        public bool? NoCache { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryDockerBuildStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskRunContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>
    {
        public ContainerRegistryEncodedTaskRunContent(string encodedTaskContent, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskStep : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>
    {
        public ContainerRegistryEncodedTaskStep(string encodedTaskContent) { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncodedTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>
    {
        public ContainerRegistryEncodedTaskStepUpdateContent() { }
        public string EncodedTaskContent { get { throw null; } set { } }
        public string EncodedValuesContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncodedTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>
    {
        public ContainerRegistryEncryption() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryEncryptionStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryEncryptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryExportPolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryExportPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryFileTaskRunContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>
    {
        public ContainerRegistryFileTaskRunContent(string taskFilePath, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties platform) { }
        public int? AgentCpu { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties Platform { get { throw null; } set { } }
        public string SourceLocation { get { throw null; } set { } }
        public string TaskFilePath { get { throw null; } set { } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskStep : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>
    {
        public ContainerRegistryFileTaskStep(string taskFilePath) { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryFileTaskStepUpdateContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>
    {
        public ContainerRegistryFileTaskStepUpdateContent() { }
        public string TaskFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        public string ValuesFilePath { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryFileTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryGenerateCredentialsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>
    {
        public ContainerRegistryGenerateCredentialsContent() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName? Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TokenId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryGenerateCredentialsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>
    {
        internal ContainerRegistryGenerateCredentialsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryGenerateCredentialsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImageDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>
    {
        public ContainerRegistryImageDescriptor() { }
        public string Digest { get { throw null; } set { } }
        public string Registry { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
        public string Tag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImageUpdateTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>
    {
        public ContainerRegistryImageUpdateTrigger() { }
        public System.Guid? Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageDescriptor> Images { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImageUpdateTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImportImageContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent>
    {
        public ContainerRegistryImportImageContent(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource source) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource Source { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetTags { get { throw null; } }
        public System.Collections.Generic.IList<string> UntaggedTargetRepositories { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryImportMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryImportMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode Force { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode NoForce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryImportSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>
    {
        public ContainerRegistryImportSource(string sourceImage) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials Credentials { get { throw null; } set { } }
        public string RegistryAddress { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("RegistryUri is deprecated, use RegistryAddress instead")]
        public System.Uri RegistryUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string SourceImage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryImportSourceCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>
    {
        public ContainerRegistryImportSourceCredentials(string password) { }
        public string Password { get { throw null; } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryImportSourceCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>
    {
        public ContainerRegistryIPRule(string ipAddressOrRange) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction? Action { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryIPRuleAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryIPRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>
    {
        public ContainerRegistryKeyVaultProperties() { }
        public string Identity { get { throw null; } set { } }
        public bool? IsKeyRotationEnabled { get { throw null; } }
        public string KeyIdentifier { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        public string VersionedKeyIdentifier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryListCredentialsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>
    {
        internal ContainerRegistryListCredentialsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword> Passwords { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryListCredentialsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>
    {
        public ContainerRegistryNameAvailabilityContent(string name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryNameAvailableResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>
    {
        internal ContainerRegistryNameAvailableResult() { }
        public string AvailableLoginServerName { get { throw null; } }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNameAvailableResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryNetworkRuleBypassOption : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryNetworkRuleBypassOption(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption AzureServices { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryNetworkRuleDefaultAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryNetworkRuleDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryNetworkRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>
    {
        public ContainerRegistryNetworkRuleSet(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction defaultAction) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleDefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryIPRule> IPRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryOS : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryOS(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS Linux { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryOSArchitecture : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryOSArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture Amd64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture Arm { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture Arm64 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture ThreeHundredEightySix { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture X86 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryOverrideTaskStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>
    {
        public ContainerRegistryOverrideTaskStepProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument> Arguments { get { throw null; } }
        public string ContextPath { get { throw null; } set { } }
        public string File { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public string UpdateTriggerToken { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPassword : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>
    {
        internal ContainerRegistryPassword() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPasswordName? Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPassword>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ContainerRegistryPasswordName
    {
        Password = 0,
        Password2 = 1,
    }
    public partial class ContainerRegistryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>
    {
        public ContainerRegistryPatch() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAdminUserEnabled { get { throw null; } set { } }
        public bool? IsAnonymousPullEnabled { get { throw null; } set { } }
        public bool? IsDataEndpointEnabled { get { throw null; } set { } }
        public bool? NetworkRuleBypassAllowedForTasks { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleBypassOption? NetworkRuleBypassOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryNetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies Policies { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode? RoleAssignmentMode { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPlatformProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>
    {
        public ContainerRegistryPlatformProperties(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS os) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant? Variant { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPlatformUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>
    {
        public ContainerRegistryPlatformUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOSArchitecture? Architecture { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOS? OS { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCpuVariant? Variant { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryPolicies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>
    {
        public ContainerRegistryPolicies() { }
        public Azure.ResourceManager.ContainerRegistry.Models.AadAuthenticationAsArmPolicyStatus? AzureADAuthenticationAsArmStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryExportPolicyStatus? ExportStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? QuarantineStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy TrustPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryPolicyStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>
    {
        public ContainerRegistryPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ActionsRequiredForPrivateLinkServiceConsumer? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryReplicationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>
    {
        public ContainerRegistryReplicationPatch() { }
        public bool? IsRegionEndpointEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryReplicationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryResourceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>
    {
        internal ContainerRegistryResourceStatus() { }
        public string DisplayStatus { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryResourceType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryResourceType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType MicrosoftContainerRegistryRegistries { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryRetentionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>
    {
        public ContainerRegistryRetentionPolicy() { }
        public int? Days { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryRoleAssignmentMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryRoleAssignmentMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode AbacRepositoryPermissions { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode LegacyRegistryPermissions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRoleAssignmentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryRunArgument : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>
    {
        public ContainerRegistryRunArgument(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunArgument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContainerRegistryRunContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>
    {
        protected ContainerRegistryRunContent() { }
        public string AgentPoolName { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunGetLogResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>
    {
        internal ContainerRegistryRunGetLogResult() { }
        public string LogArtifactLink { get { throw null; } }
        public string LogLink { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunGetLogResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryRunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>
    {
        public ContainerRegistryRunPatch() { }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryRunStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Error { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Running { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Started { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryRunType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryRunType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType AutoBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType AutoRun { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType QuickBuild { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType QuickRun { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySecretObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>
    {
        public ContainerRegistrySecretObject() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType? ObjectType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySecretObjectType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySecretObjectType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType Opaque { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType VaultSecret { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>
    {
        public ContainerRegistrySku(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName name) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySkuName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySkuName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Classic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySkuTier : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySkuTier(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Classic { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySourceTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>
    {
        public ContainerRegistrySourceTrigger(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties sourceRepository, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent> sourceTriggerEvents, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistrySourceTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>
    {
        public ContainerRegistrySourceTriggerDescriptor() { }
        public string BranchName { get { throw null; } set { } }
        public string CommitId { get { throw null; } set { } }
        public string EventType { get { throw null; } set { } }
        public System.Guid? Id { get { throw null; } set { } }
        public string ProviderType { get { throw null; } set { } }
        public string PullRequestId { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistrySourceTriggerEvent : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistrySourceTriggerEvent(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent Commit { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent PullRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistrySourceTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>
    {
        public ContainerRegistrySourceTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent SourceRepository { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerEvent> SourceTriggerEvents { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskOverridableValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>
    {
        public ContainerRegistryTaskOverridableValue(string name, string value) { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskOverridableValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>
    {
        public ContainerRegistryTaskPatch() { }
        public int? AgentCpu { get { throw null; } set { } }
        public string AgentPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCredentials Credentials { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string LogTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPlatformUpdateContent Platform { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent Step { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? TimeoutInSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent Trigger { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunContent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>
    {
        public ContainerRegistryTaskRunContent(Azure.Core.ResourceIdentifier taskId) { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryOverrideTaskStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TaskId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTaskRunPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>
    {
        public ContainerRegistryTaskRunPatch() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryRunContent RunRequest { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskRunPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTaskStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTaskStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ContainerRegistryTaskStepProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>
    {
        protected ContainerRegistryTaskStepProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageDependency> BaseImageDependencies { get { throw null; } }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContainerRegistryTaskStepUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>
    {
        protected ContainerRegistryTaskStepUpdateContent() { }
        public string ContextAccessToken { get { throw null; } set { } }
        public string ContextPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTaskStepUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTimerTrigger : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>
    {
        public ContainerRegistryTimerTrigger(string schedule, string name) { }
        public string Name { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTimerTriggerDescriptor : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>
    {
        public ContainerRegistryTimerTriggerDescriptor() { }
        public string ScheduleOccurrence { get { throw null; } set { } }
        public string TimerTriggerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerDescriptor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTimerTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>
    {
        public ContainerRegistryTimerTriggerUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Schedule { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTlsCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>
    {
        internal ContainerRegistryTlsCertificateProperties() { }
        public string CertificateLocation { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryCertificateType? CertificateType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTlsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>
    {
        internal ContainerRegistryTlsProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsCertificateProperties Certificate { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTlsStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTlsStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTlsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTokenCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>
    {
        public ContainerRegistryTokenCertificate() { }
        public string EncodedPemCertificate { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName? Name { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTokenCertificateName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTokenCertificateName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName Certificate1 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName Certificate2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificateName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTokenCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>
    {
        public ContainerRegistryTokenCredentials() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCertificate> Certificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword> Passwords { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTokenPassword : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>
    {
        public ContainerRegistryTokenPassword() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName? Name { get { throw null; } set { } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPassword>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTokenPasswordName : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTokenPasswordName(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName Password1 { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName Password2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPasswordName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTokenPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>
    {
        public ContainerRegistryTokenPatch() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenCredentials Credentials { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ScopeMapId { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTokenStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTokenStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTokenStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTriggerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>
    {
        public ContainerRegistryTriggerProperties() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTrigger> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTrigger> TimerTriggers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTriggerStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryTriggerUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>
    {
        public ContainerRegistryTriggerUpdateContent() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryBaseImageTriggerUpdateContent BaseImageTrigger { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySourceTriggerUpdateContent> SourceTriggers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTimerTriggerUpdateContent> TimerTriggers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTriggerUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryTrustPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>
    {
        public ContainerRegistryTrustPolicy() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryPolicyStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryTrustPolicyType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryTrustPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType Notary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryTrustPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryUpdateTriggerPayloadType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryUpdateTriggerPayloadType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType Token { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUpdateTriggerPayloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>
    {
        internal ContainerRegistryUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryUsageUnit : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryUsageUnit(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit Count { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryUsageUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryWebhookAction : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryWebhookAction(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction ChartDelete { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction ChartPush { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction Delete { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction Push { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction Quarantine { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryWebhookCallbackConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>
    {
        internal ContainerRegistryWebhookCallbackConfig() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomHeaders { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCallbackConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent>
    {
        public ContainerRegistryWebhookCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> Actions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomHeaders { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEvent : Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>
    {
        internal ContainerRegistryWebhookEvent() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage EventRequestMessage { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage EventResponseMessage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>
    {
        internal ContainerRegistryWebhookEventContent() { }
        public string Action { get { throw null; } }
        public string ActorName { get { throw null; } }
        public System.Guid? Id { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent Request { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource Source { get { throw null; } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>
    {
        internal ContainerRegistryWebhookEventInfo() { }
        public System.Guid? Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>
    {
        internal ContainerRegistryWebhookEventRequestContent() { }
        public string Addr { get { throw null; } }
        public string Host { get { throw null; } }
        public System.Guid? Id { get { throw null; } }
        public string Method { get { throw null; } }
        public string UserAgent { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventRequestMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>
    {
        internal ContainerRegistryWebhookEventRequestMessage() { }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventContent Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public string Method { get { throw null; } }
        public System.Uri RequestUri { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventRequestMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventResponseMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>
    {
        internal ContainerRegistryWebhookEventResponseMessage() { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Headers { get { throw null; } }
        public string ReasonPhrase { get { throw null; } }
        public string StatusCode { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventResponseMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>
    {
        internal ContainerRegistryWebhookEventSource() { }
        public string Addr { get { throw null; } }
        public string InstanceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookEventTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>
    {
        internal ContainerRegistryWebhookEventTarget() { }
        public string Digest { get { throw null; } }
        public long? Length { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Name { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Tag { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookEventTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerRegistryWebhookPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>
    {
        public ContainerRegistryWebhookPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookAction> Actions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> CustomHeaders { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryWebhookStatus : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryWebhookStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRegistryZoneRedundancy : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRegistryZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy left, Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>
    {
        public CustomRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject Password { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistrySecretObject UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.CustomRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GarbageCollectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>
    {
        public GarbageCollectionProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public string Schedule { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.GarbageCollectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScopeMapPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>
    {
        public ScopeMapPatch() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.ScopeMapPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceCodeRepoAuthInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>
    {
        public SourceCodeRepoAuthInfo(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType tokenType, string token) { }
        public int? ExpireInSeconds { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType TokenType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceCodeRepoAuthInfoUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>
    {
        public SourceCodeRepoAuthInfoUpdateContent() { }
        public int? ExpiresIn { get { throw null; } set { } }
        public string RefreshToken { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType? TokenType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceCodeRepoAuthTokenType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceCodeRepoAuthTokenType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType OAuth { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType Pat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType left, Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType left, Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceCodeRepoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>
    {
        public SourceCodeRepoProperties(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType sourceControlType, System.Uri repositoryUri) { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfo SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceControlType SourceControlType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SourceCodeRepoUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>
    {
        public SourceCodeRepoUpdateContent() { }
        public string Branch { get { throw null; } set { } }
        public System.Uri RepositoryUri { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoAuthInfoUpdateContent SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceControlType? SourceControlType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceCodeRepoUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlType : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceControlType Github { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceControlType VisualStudioTeamService { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Models.SourceControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceControlType left, Azure.ResourceManager.ContainerRegistry.Models.SourceControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceRegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>
    {
        public SourceRegistryCredentials() { }
        public string Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode? LoginMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceRegistryLoginMode : System.IEquatable<Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceRegistryLoginMode(string value) { throw null; }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode Default { get { throw null; } }
        public static Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode left, Azure.ResourceManager.ContainerRegistry.Models.SourceRegistryLoginMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceUploadDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>
    {
        internal SourceUploadDefinition() { }
        public string RelativePath { get { throw null; } }
        public System.Uri UploadUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerRegistry.Models.SourceUploadDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
