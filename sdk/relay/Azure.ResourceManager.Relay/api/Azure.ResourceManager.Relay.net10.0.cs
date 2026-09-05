namespace Azure.ResourceManager.Relay
{
    public partial class AzureResourceManagerRelayContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRelayContext() { }
        public static Azure.ResourceManager.Relay.AzureResourceManagerRelayContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class RelayAuthorizationRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>
    {
        public RelayAuthorizationRuleData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.RelayAccessRight> Rights { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayClusterResource>, System.Collections.IEnumerable
    {
        protected RelayClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Relay.RelayClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Relay.RelayClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.RelayClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.RelayClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>
    {
        public RelayClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.Relay.Models.RelayClusterSku sku) { }
        public Azure.ResourceManager.Relay.Models.RelayClusterProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.RelayClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayClusterResource() { }
        public virtual Azure.ResourceManager.Relay.RelayClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult> GetNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>> GetNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> Update(Azure.ResourceManager.Relay.Models.RelayClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> UpdateAsync(Azure.ResourceManager.Relay.Models.RelayClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RelayExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult> CheckRelayNamespaceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>> CheckRelayNamespaceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList> GetAvailableClusterRegion(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>> GetAvailableClusterRegionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> GetRelayCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> GetRelayClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayClusterResource GetRelayClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayClusterCollection GetRelayClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Relay.RelayClusterResource> GetRelayClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayClusterResource> GetRelayClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource GetRelayHybridConnectionAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayHybridConnectionResource GetRelayHybridConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> GetRelayNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource GetRelayNamespaceAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceResource GetRelayNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceCollection GetRelayNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNetworkRuleSetResource GetRelayNetworkRuleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource GetRelayPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateLinkResource GetRelayPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource GetWcfRelayAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.WcfRelayResource GetWcfRelayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class RelayHybridConnectionAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected RelayHybridConnectionAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayHybridConnectionAuthorizationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayHybridConnectionAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.Relay.RelayAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string hybridConnectionName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys> RegenerateKeys(Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelayHybridConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionResource>, System.Collections.IEnumerable
    {
        protected RelayHybridConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hybridConnectionName, Azure.ResourceManager.Relay.RelayHybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hybridConnectionName, Azure.ResourceManager.Relay.RelayHybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionResource> Get(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayHybridConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayHybridConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionResource>> GetAsync(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.RelayHybridConnectionResource> GetIfExists(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.RelayHybridConnectionResource>> GetIfExistsAsync(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayHybridConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayHybridConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayHybridConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayHybridConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>
    {
        public RelayHybridConnectionData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsClientAuthorizationRequired { get { throw null; } set { } }
        public int? ListenerCount { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string UserMetadata { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.RelayHybridConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayHybridConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayHybridConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayHybridConnectionResource() { }
        public virtual Azure.ResourceManager.Relay.RelayHybridConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string hybridConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource> GetRelayHybridConnectionAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource>> GetRelayHybridConnectionAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleCollection GetRelayHybridConnectionAuthorizationRules() { throw null; }
        Azure.ResourceManager.Relay.RelayHybridConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayHybridConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayHybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayHybridConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayHybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelayNamespaceAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected RelayNamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayNamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayNamespaceAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.Relay.RelayAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys> RegenerateKeys(Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelayNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayNamespaceResource>, System.Collections.IEnumerable
    {
        protected RelayNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.Relay.RelayNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.Relay.RelayNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.RelayNamespaceResource> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.RelayNamespaceResource>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayNamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>
    {
        public RelayNamespaceData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.TlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelaySku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.RelayNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayNamespaceResource() { }
        public virtual Azure.ResourceManager.Relay.RelayNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionResource> GetRelayHybridConnection(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayHybridConnectionResource>> GetRelayHybridConnectionAsync(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayHybridConnectionCollection GetRelayHybridConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource> GetRelayNamespaceAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource>> GetRelayNamespaceAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleCollection GetRelayNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayNetworkRuleSetResource GetRelayNetworkRuleSet() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> GetRelayPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>> GetRelayPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionCollection GetRelayPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource> GetRelayPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource>> GetRelayPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayPrivateLinkResourceCollection GetRelayPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.WcfRelayResource> GetWcfRelay(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.WcfRelayResource>> GetWcfRelayAsync(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.WcfRelayCollection GetWcfRelays() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> Update(Azure.ResourceManager.Relay.Models.RelayNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> UpdateAsync(Azure.ResourceManager.Relay.Models.RelayNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelayNetworkRuleSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>
    {
        public RelayNetworkRuleSetData() { }
        public Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule> IPRules { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public bool? TrustedServiceAccessEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.RelayNetworkRuleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayNetworkRuleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNetworkRuleSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayNetworkRuleSetResource() { }
        public virtual Azure.ResourceManager.Relay.RelayNetworkRuleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNetworkRuleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayNetworkRuleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayNetworkRuleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayNetworkRuleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNetworkRuleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNetworkRuleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayNetworkRuleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayNetworkRuleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected RelayPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>
    {
        public RelayPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelayPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Relay.RelayPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected RelayPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.RelayPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.RelayPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>
    {
        internal RelayPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.RelayPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WcfRelayAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected WcfRelayAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WcfRelayAuthorizationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WcfRelayAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.Relay.RelayAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string relayName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys> RegenerateKeys(Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayAccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WcfRelayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.WcfRelayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.WcfRelayResource>, System.Collections.IEnumerable
    {
        protected WcfRelayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relayName, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relayName, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.WcfRelayResource> Get(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.WcfRelayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.WcfRelayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.WcfRelayResource>> GetAsync(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relay.WcfRelayResource> GetIfExists(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relay.WcfRelayResource>> GetIfExistsAsync(string relayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.WcfRelayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.WcfRelayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.WcfRelayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.WcfRelayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WcfRelayData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>
    {
        public WcfRelayData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsClientAuthorizationRequired { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsTransportSecurityRequired { get { throw null; } set { } }
        public int? ListenerCount { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayType? RelayType { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string UserMetadata { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.WcfRelayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.WcfRelayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WcfRelayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WcfRelayResource() { }
        public virtual Azure.ResourceManager.Relay.WcfRelayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string relayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.WcfRelayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.WcfRelayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource> GetWcfRelayAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource>> GetWcfRelayAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleCollection GetWcfRelayAuthorizationRules() { throw null; }
        Azure.ResourceManager.Relay.WcfRelayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.WcfRelayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Relay.Mocking
{
    public partial class MockableRelayArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRelayArmClient() { }
        public virtual Azure.ResourceManager.Relay.RelayClusterResource GetRelayClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayHybridConnectionAuthorizationRuleResource GetRelayHybridConnectionAuthorizationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayHybridConnectionResource GetRelayHybridConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayNamespaceAuthorizationRuleResource GetRelayNamespaceAuthorizationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayNamespaceResource GetRelayNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayNetworkRuleSetResource GetRelayNetworkRuleSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource GetRelayPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayPrivateLinkResource GetRelayPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.WcfRelayAuthorizationRuleResource GetWcfRelayAuthorizationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relay.WcfRelayResource GetWcfRelayResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRelayResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRelayResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource> GetRelayCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayClusterResource>> GetRelayClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayClusterCollection GetRelayClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespace(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> GetRelayNamespaceAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayNamespaceCollection GetRelayNamespaces() { throw null; }
    }
    public partial class MockableRelaySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRelaySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult> CheckRelayNamespaceNameAvailability(Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>> CheckRelayNamespaceNameAvailabilityAsync(Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList> GetAvailableClusterRegion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>> GetAvailableClusterRegionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayClusterResource> GetRelayClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayClusterResource> GetRelayClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Relay.Models
{
    public static partial class ArmRelayModelFactory
    {
        public static Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion AvailableRelayClusterRegion(string location = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.AvailableRelayClustersList AvailableRelayClustersList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion> value = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayAccessKeys RelayAccessKeys(string primaryConnectionString = null, string secondaryConnectionString = null, string primaryKey = null, string secondaryKey = null, string keyName = null) { throw null; }
        public static Azure.ResourceManager.Relay.RelayAuthorizationRuleData RelayAuthorizationRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.RelayAccessRight> rights = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayClusterData RelayClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Relay.Models.RelayClusterProperties properties = null, Azure.ResourceManager.Relay.Models.RelayClusterSku sku = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterPatch RelayClusterPatch(Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate sku = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterProperties RelayClusterProperties(Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState? provisioningState = default(Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState?), string metricId = null, string status = null, bool? supportsScaling = default(bool?), bool? zoneRedundant = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSku RelayClusterSku(Azure.ResourceManager.Relay.Models.RelayClusterSkuName name = default(Azure.ResourceManager.Relay.Models.RelayClusterSkuName), Azure.ResourceManager.Relay.Models.RelayClusterSkuTier? tier = default(Azure.ResourceManager.Relay.Models.RelayClusterSkuTier?), int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity RelayClusterSkuCapacity(int? minimum = default(int?), int? maximum = default(int?), System.Collections.Generic.IEnumerable<int> allowedValues = null, int? @default = default(int?), Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType? scaleType = default(Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType?)) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails RelayClusterSkuDetails(Azure.ResourceManager.Relay.Models.RelayClusterSkuName? name = default(Azure.ResourceManager.Relay.Models.RelayClusterSkuName?), Azure.ResourceManager.Relay.Models.RelayClusterSkuTier? tier = default(Azure.ResourceManager.Relay.Models.RelayClusterSkuTier?)) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo RelayClusterSkuInfo(string resourceType = null, Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails sku = null, Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult RelayClusterSkuListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo> value = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate RelayClusterSkuUpdate(Azure.ResourceManager.Relay.Models.RelayClusterSkuName? name = default(Azure.ResourceManager.Relay.Models.RelayClusterSkuName?), Azure.ResourceManager.Relay.Models.RelayClusterSkuTier? tier = default(Azure.ResourceManager.Relay.Models.RelayClusterSkuTier?), int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayHybridConnectionData RelayHybridConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), int? listenerCount = default(int?), bool? isClientAuthorizationRequired = default(bool?), string userMetadata = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent RelayNameAvailabilityContent(string name = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult RelayNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason? reason = default(Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceData RelayNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Relay.Models.RelaySku sku = null, string provisioningState = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceBusEndpoint = null, string metricId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceData RelayNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceBusEndpoint = null, string metricId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?), Azure.ResourceManager.Relay.Models.TlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Relay.Models.TlsVersion?), Azure.ResourceManager.Relay.Models.RelaySku sku = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult RelayNamespaceIdListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.RelayNamespaceReference> value = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNamespacePatch RelayNamespacePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Relay.Models.RelaySku sku = null, string provisioningState = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceBusEndpoint = null, string metricId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNamespacePatch RelayNamespacePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Relay.Models.RelaySku sku = null, string provisioningState = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceBusEndpoint = null, string metricId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?), Azure.ResourceManager.Relay.Models.TlsVersion? minimumTlsVersion = default(Azure.ResourceManager.Relay.Models.TlsVersion?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNamespaceReference RelayNamespaceReference(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNetworkRuleSetData RelayNetworkRuleSetData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction? defaultAction, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule> ipRules) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNetworkRuleSetData RelayNetworkRuleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? trustedServiceAccessEnabled = default(bool?), Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction? defaultAction = default(Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction?), Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule> ipRules = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule RelayNetworkRuleSetIPRule(string ipMask = null, Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction? action = default(Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData RelayPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData RelayPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateLinkResourceData RelayPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState RelayPrivateLinkServiceConnectionState(Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus? status = default(Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus?), string description = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent RelayRegenerateAccessKeyContent(Azure.ResourceManager.Relay.Models.RelayAccessKeyType keyType = default(Azure.ResourceManager.Relay.Models.RelayAccessKeyType), string key = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelaySku RelaySku(Azure.ResourceManager.Relay.Models.RelaySkuName name = default(Azure.ResourceManager.Relay.Models.RelaySkuName), Azure.ResourceManager.Relay.Models.RelaySkuTier? tier = default(Azure.ResourceManager.Relay.Models.RelaySkuTier?)) { throw null; }
        public static Azure.ResourceManager.Relay.WcfRelayData WcfRelayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isDynamic = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), int? listenerCount = default(int?), Azure.ResourceManager.Relay.Models.RelayType? relayType = default(Azure.ResourceManager.Relay.Models.RelayType?), bool? isClientAuthorizationRequired = default(bool?), bool? isTransportSecurityRequired = default(bool?), string userMetadata = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
    }
    public partial class AvailableRelayClusterRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion>
    {
        internal AvailableRelayClusterRegion() { }
        public string Location { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableRelayClustersList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>
    {
        internal AvailableRelayClustersList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.AvailableRelayClusterRegion> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.AvailableRelayClustersList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.AvailableRelayClustersList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.AvailableRelayClustersList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.AvailableRelayClustersList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.AvailableRelayClustersList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayAccessKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>
    {
        internal RelayAccessKeys() { }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayAccessKeys JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayAccessKeys PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayAccessKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayAccessKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayAccessKeyType : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayAccessKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayAccessKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayAccessKeyType PrimaryKey { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayAccessKeyType SecondaryKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayAccessKeyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayAccessKeyType left, Azure.ResourceManager.Relay.Models.RelayAccessKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayAccessKeyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayAccessKeyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayAccessKeyType left, Azure.ResourceManager.Relay.Models.RelayAccessKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayAccessRight : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayAccessRight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayAccessRight(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayAccessRight Listen { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayAccessRight Manage { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayAccessRight Send { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayAccessRight other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayAccessRight left, Azure.ResourceManager.Relay.Models.RelayAccessRight right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayAccessRight (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayAccessRight? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayAccessRight left, Azure.ResourceManager.Relay.Models.RelayAccessRight right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterPatch>
    {
        public RelayClusterPatch() { }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterProperties>
    {
        public RelayClusterProperties() { }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } }
        public bool? SupportsScaling { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayClusterProvisioningState : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState Scaling { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState left, Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState left, Azure.ResourceManager.Relay.Models.RelayClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayClusterSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSku>
    {
        public RelayClusterSku(Azure.ResourceManager.Relay.Models.RelayClusterSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayClusterSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity>
    {
        internal RelayClusterSkuCapacity() { }
        public System.Collections.Generic.IReadOnlyList<int> AllowedValues { get { throw null; } }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType? ScaleType { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayClusterSkuDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails>
    {
        internal RelayClusterSkuDetails() { }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuName? Name { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuTier? Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayClusterSkuInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo>
    {
        internal RelayClusterSkuInfo() { }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuDetails Sku { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayClusterSkuListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>
    {
        internal RelayClusterSkuListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.RelayClusterSkuInfo> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayClusterSkuName : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayClusterSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayClusterSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuName Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayClusterSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayClusterSkuName left, Azure.ResourceManager.Relay.Models.RelayClusterSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayClusterSkuName left, Azure.ResourceManager.Relay.Models.RelayClusterSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayClusterSkuScaleType : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayClusterSkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType Automatic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType left, Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType left, Azure.ResourceManager.Relay.Models.RelayClusterSkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayClusterSkuTier : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayClusterSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayClusterSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayClusterSkuTier Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayClusterSkuTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayClusterSkuTier left, Azure.ResourceManager.Relay.Models.RelayClusterSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterSkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayClusterSkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayClusterSkuTier left, Azure.ResourceManager.Relay.Models.RelayClusterSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayClusterSkuUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate>
    {
        public RelayClusterSkuUpdate() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuName? Name { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayClusterSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayClusterSkuUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>
    {
        public RelayNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>
    {
        internal RelayNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNamespaceIdListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>
    {
        internal RelayNamespaceIdListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.RelayNamespaceReference> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceIdListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNamespacePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>
    {
        public RelayNamespacePatch() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.TlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelaySku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNamespaceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespaceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceReference>
    {
        internal RelayNamespaceReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNamespaceReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNamespaceReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayNamespaceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespaceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespaceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNamespaceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespaceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason InvalidName { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason NameInLockdown { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason NameInUse { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason None { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason SubscriptionIsDisabled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason TooManyNamespaceInCurrentSubscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason left, Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason left, Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayNetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayNetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction left, Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction left, Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayNetworkRuleSetDefaultAction : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayNetworkRuleSetDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction left, Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction left, Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayNetworkRuleSetIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>
    {
        public RelayNetworkRuleSetIPRule() { }
        public Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayPrivateLinkConnectionStatus : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayPrivateLinkConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus left, Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus left, Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>
    {
        public RelayPrivateLinkServiceConnectionState() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelayPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelayPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess left, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess left, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayRegenerateAccessKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>
    {
        public RelayRegenerateAccessKeyContent(Azure.ResourceManager.Relay.Models.RelayAccessKeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayAccessKeyType KeyType { get { throw null; } }
        protected virtual Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelaySku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelaySku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelaySku>
    {
        public RelaySku(Azure.ResourceManager.Relay.Models.RelaySkuName name) { }
        public Azure.ResourceManager.Relay.Models.RelaySkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelaySkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relay.Models.RelaySku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relay.Models.RelaySku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relay.Models.RelaySku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelaySku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelaySku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelaySku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelaySku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelaySku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelaySku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelaySkuName : System.IEquatable<Azure.ResourceManager.Relay.Models.RelaySkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelaySkuName(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelaySkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelaySkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelaySkuName left, Azure.ResourceManager.Relay.Models.RelaySkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelaySkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelaySkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelaySkuName left, Azure.ResourceManager.Relay.Models.RelaySkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelaySkuTier : System.IEquatable<Azure.ResourceManager.Relay.Models.RelaySkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelaySkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelaySkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.RelaySkuTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelaySkuTier left, Azure.ResourceManager.Relay.Models.RelaySkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelaySkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelaySkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelaySkuTier left, Azure.ResourceManager.Relay.Models.RelaySkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum RelayType
    {
        NetTcp = 0,
        Http = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsVersion : System.IEquatable<Azure.ResourceManager.Relay.Models.TlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.TlsVersion _12 { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.TlsVersion _13 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.TlsVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.TlsVersion left, Azure.ResourceManager.Relay.Models.TlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.TlsVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.TlsVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.TlsVersion left, Azure.ResourceManager.Relay.Models.TlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
}
