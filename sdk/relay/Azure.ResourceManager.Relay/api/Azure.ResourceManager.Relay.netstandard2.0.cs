namespace Azure.ResourceManager.Relay
{
    public partial class RelayAuthorizationRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>
    {
        public RelayAuthorizationRuleData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.RelayAccessRight> Rights { get { throw null; } }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class RelayExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult> CheckRelayNamespaceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>> CheckRelayNamespaceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class RelayHybridConnectionAuthorizationRuleResource : Azure.ResourceManager.ArmResource
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
        Azure.ResourceManager.Relay.RelayHybridConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayHybridConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayHybridConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayHybridConnectionResource : Azure.ResourceManager.ArmResource
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
    public partial class RelayNamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelaySku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Relay.RelayNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNamespaceResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> Update(Azure.ResourceManager.Relay.Models.RelayNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> UpdateAsync(Azure.ResourceManager.Relay.Models.RelayNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelayNetworkRuleSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>
    {
        public RelayNetworkRuleSetData() { }
        public Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule> IPRules { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        Azure.ResourceManager.Relay.RelayNetworkRuleSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayNetworkRuleSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayNetworkRuleSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNetworkRuleSetResource : Azure.ResourceManager.ArmResource
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
        Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelayPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelayPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Relay.RelayPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class WcfRelayAuthorizationRuleResource : Azure.ResourceManager.ArmResource
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
        Azure.ResourceManager.Relay.WcfRelayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.WcfRelayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.WcfRelayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.WcfRelayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WcfRelayResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Relay.Mocking
{
    public partial class MockableRelayArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRelayArmClient() { }
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
        public virtual Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespace(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> GetRelayNamespaceAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.RelayNamespaceCollection GetRelayNamespaces() { throw null; }
    }
    public partial class MockableRelaySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRelaySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult> CheckRelayNamespaceNameAvailability(Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>> CheckRelayNamespaceNameAvailabilityAsync(Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Relay.Models
{
    public static partial class ArmRelayModelFactory
    {
        public static Azure.ResourceManager.Relay.Models.RelayAccessKeys RelayAccessKeys(string primaryConnectionString = null, string secondaryConnectionString = null, string primaryKey = null, string secondaryKey = null, string keyName = null) { throw null; }
        public static Azure.ResourceManager.Relay.RelayAuthorizationRuleData RelayAuthorizationRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.RelayAccessRight> rights = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayHybridConnectionData RelayHybridConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), int? listenerCount = default(int?), bool? isClientAuthorizationRequired = default(bool?), string userMetadata = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult RelayNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason? reason = default(Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceData RelayNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Relay.Models.RelaySku sku = null, string provisioningState = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceBusEndpoint = null, string metricId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayNamespacePatch RelayNamespacePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Relay.Models.RelaySku sku = null, string provisioningState = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string serviceBusEndpoint = null, string metricId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNetworkRuleSetData RelayNetworkRuleSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction? defaultAction = default(Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction?), Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule> ipRules = null) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData RelayPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateLinkResourceData RelayPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent RelayRegenerateAccessKeyContent(Azure.ResourceManager.Relay.Models.RelayAccessKeyType keyType = default(Azure.ResourceManager.Relay.Models.RelayAccessKeyType), string key = null) { throw null; }
        public static Azure.ResourceManager.Relay.WcfRelayData WcfRelayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isDynamic = default(bool?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), int? listenerCount = default(int?), Azure.ResourceManager.Relay.Models.RelayType? relayType = default(Azure.ResourceManager.Relay.Models.RelayType?), bool? isClientAuthorizationRequired = default(bool?), bool? isTransportSecurityRequired = default(bool?), string userMetadata = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
    }
    public partial class RelayAccessKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayAccessKeys>
    {
        internal RelayAccessKeys() { }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayAccessKeyType left, Azure.ResourceManager.Relay.Models.RelayAccessKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayAccessKeyType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayAccessRight left, Azure.ResourceManager.Relay.Models.RelayAccessRight right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayAccessRight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayAccessRight left, Azure.ResourceManager.Relay.Models.RelayAccessRight right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityContent>
    {
        public RelayNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
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
        Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelayNamespacePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>
    {
        public RelayNamespacePatch() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string MetricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelaySku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.Relay.Models.RelayNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relay.Models.RelayNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason left, Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNameUnavailableReason (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction left, Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction left, Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction left, Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayNetworkRuleSetIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayNetworkRuleSetIPRule>
    {
        public RelayNetworkRuleSetIPRule() { }
        public Azure.ResourceManager.Relay.Models.RelayNetworkRuleIPAction? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPrivateEndpointConnectionProvisioningState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus left, Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus left, Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayPrivateLinkServiceConnectionState>
    {
        public RelayPrivateLinkServiceConnectionState() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayPrivateLinkConnectionStatus? Status { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess left, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess left, Azure.ResourceManager.Relay.Models.RelayPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelayRegenerateAccessKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relay.Models.RelayRegenerateAccessKeyContent>
    {
        public RelayRegenerateAccessKeyContent(Azure.ResourceManager.Relay.Models.RelayAccessKeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelayAccessKeyType KeyType { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelaySkuName left, Azure.ResourceManager.Relay.Models.RelaySkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelaySkuName (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.RelaySkuTier left, Azure.ResourceManager.Relay.Models.RelaySkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.RelaySkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.RelaySkuTier left, Azure.ResourceManager.Relay.Models.RelaySkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum RelayType
    {
        NetTcp = 0,
        Http = 1,
    }
}
