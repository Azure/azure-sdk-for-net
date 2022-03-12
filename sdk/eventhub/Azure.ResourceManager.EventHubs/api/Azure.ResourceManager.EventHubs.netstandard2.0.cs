namespace Azure.ResourceManager.EventHubs
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.EventHubs.ConsumerGroup GetConsumerGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.DisasterRecovery GetDisasterRecovery(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule GetDisasterRecoveryAuthorizationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHub GetEventHub(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubAuthorizationRule GetEventHubAuthorizationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubCluster GetEventHubCluster(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubNamespace GetEventHubNamespace(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule GetNamespaceAuthorizationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.NetworkRuleSet GetNetworkRuleSet(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.SchemaGroup GetSchemaGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AuthorizationRuleData : Azure.ResourceManager.EventHubs.Models.ProxyResource
    {
        public AuthorizationRuleData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.AccessRights> Rights { get { throw null; } }
    }
    public partial class ConsumerGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConsumerGroup() { }
        public virtual Azure.ResourceManager.EventHubs.ConsumerGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsumerGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.ConsumerGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.ConsumerGroup>, System.Collections.IEnumerable
    {
        protected ConsumerGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.ConsumerGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string consumerGroupName, Azure.ResourceManager.EventHubs.ConsumerGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.ConsumerGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consumerGroupName, Azure.ResourceManager.EventHubs.ConsumerGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup> Get(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.ConsumerGroup> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.ConsumerGroup> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup>> GetAsync(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup> GetIfExists(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup>> GetIfExistsAsync(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.ConsumerGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.ConsumerGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.ConsumerGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.ConsumerGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConsumerGroupData : Azure.ResourceManager.EventHubs.Models.ProxyResource
    {
        public ConsumerGroupData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        public string UserMetadata { get { throw null; } set { } }
    }
    public partial class DisasterRecovery : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DisasterRecovery() { }
        public virtual Azure.ResourceManager.EventHubs.DisasterRecoveryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response BreakPairing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BreakPairingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response FailOver(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FailOverAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> GetDisasterRecoveryAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>> GetDisasterRecoveryAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRuleCollection GetDisasterRecoveryAuthorizationRules() { throw null; }
    }
    public partial class DisasterRecoveryAuthorizationRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DisasterRecoveryAuthorizationRule() { }
        public virtual Azure.ResourceManager.EventHubs.AuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias, string authorizationRuleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisasterRecoveryAuthorizationRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>, System.Collections.IEnumerable
    {
        protected DisasterRecoveryAuthorizationRuleCollection() { }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.DisasterRecoveryAuthorizationRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DisasterRecoveryCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.DisasterRecovery>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.DisasterRecovery>, System.Collections.IEnumerable
    {
        protected DisasterRecoveryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.DisasterRecovery> CreateOrUpdate(Azure.WaitUntil waitUntil, string alias, Azure.ResourceManager.EventHubs.DisasterRecoveryData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.DisasterRecovery>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alias, Azure.ResourceManager.EventHubs.DisasterRecoveryData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery> Get(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.DisasterRecovery> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.DisasterRecovery> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery>> GetAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery> GetIfExists(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery>> GetIfExistsAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.DisasterRecovery> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.DisasterRecovery>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.DisasterRecovery> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.DisasterRecovery>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DisasterRecoveryData : Azure.ResourceManager.EventHubs.Models.ProxyResource
    {
        public DisasterRecoveryData() { }
        public string AlternateName { get { throw null; } set { } }
        public string PartnerNamespace { get { throw null; } set { } }
        public long? PendingReplicationOperationsCount { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.ProvisioningStateDR? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.RoleDisasterRecovery? Role { get { throw null; } }
    }
    public partial class EventHub : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHub() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string eventHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHub> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHub>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup> GetConsumerGroup(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.ConsumerGroup>> GetConsumerGroupAsync(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.ConsumerGroupCollection GetConsumerGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> GetEventHubAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>> GetEventHubAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleCollection GetEventHubAuthorizationRules() { throw null; }
    }
    public partial class EventHubAuthorizationRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubAuthorizationRule() { }
        public virtual Azure.ResourceManager.EventHubs.AuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubAuthorizationRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>, System.Collections.IEnumerable
    {
        protected EventHubAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.AuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.AuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubCluster : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubCluster() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties> GetConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties>> GetConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties> PatchConfiguration(Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties>> PatchConfigurationAsync(Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubCluster> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubClusterData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubCluster>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubClusterData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubClusterCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubCluster>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubCluster>, System.Collections.IEnumerable
    {
        protected EventHubClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubCluster> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.EventHubs.EventHubClusterData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubCluster>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.EventHubs.EventHubClusterData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubCluster> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubCluster> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubCluster> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubCluster>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubCluster> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubCluster>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EventHubClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string CreatedAt { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.ClusterSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string UpdatedAt { get { throw null; } }
    }
    public partial class EventHubCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHub>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHub>, System.Collections.IEnumerable
    {
        protected EventHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHub> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventHubName, Azure.ResourceManager.EventHubs.EventHubData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHub>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventHubName, Azure.ResourceManager.EventHubs.EventHubData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHub> Get(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHub> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHub> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHub>> GetAsync(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHub> GetIfExists(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHub>> GetIfExistsAsync(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHub> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHub>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHub> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHub>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubData : Azure.ResourceManager.EventHubs.Models.ProxyResource
    {
        public EventHubData() { }
        public Azure.ResourceManager.EventHubs.Models.CaptureDescription CaptureDescription { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public long? MessageRetentionInDays { get { throw null; } set { } }
        public long? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PartitionIds { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EntityStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
    }
    public partial class EventHubNamespace : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubNamespace() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult> CheckNameAvailabilityDisasterRecoveryConfig(Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityDisasterRecoveryConfigAsync(Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.DisasterRecoveryCollection GetDisasterRecoveries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery> GetDisasterRecovery(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.DisasterRecovery>> GetDisasterRecoveryAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHub> GetEventHub(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHub>> GetEventHubAsync(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubCollection GetEventHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> GetNamespaceAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>> GetNamespaceAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.NamespaceAuthorizationRuleCollection GetNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.EventHubs.NetworkRuleSet GetNetworkRuleSet() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.PrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.PrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup> GetSchemaGroup(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup>> GetSchemaGroupAsync(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.SchemaGroupCollection GetSchemaGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> Update(Azure.ResourceManager.EventHubs.EventHubNamespaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> UpdateAsync(Azure.ResourceManager.EventHubs.EventHubNamespaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubNamespaceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubNamespace>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubNamespace>, System.Collections.IEnumerable
    {
        protected EventHubNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubNamespace> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.EventHubs.EventHubNamespaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubNamespace>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.EventHubs.EventHubNamespaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubNamespace> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubNamespace> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubNamespace> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubNamespace>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubNamespace> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubNamespace>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubNamespaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EventHubNamespaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AlternateName { get { throw null; } set { } }
        public string ClusterArmId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAutoInflateEnabled { get { throw null; } set { } }
        public bool? KafkaEnabled { get { throw null; } set { } }
        public int? MaximumThroughputUnits { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class NamespaceAuthorizationRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceAuthorizationRule() { }
        public virtual Azure.ResourceManager.EventHubs.AuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceAuthorizationRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>, System.Collections.IEnumerable
    {
        protected NamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.AuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.AuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.NamespaceAuthorizationRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkRuleSet : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkRuleSet() { }
        public virtual Azure.ResourceManager.EventHubs.NetworkRuleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.NetworkRuleSet> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.NetworkRuleSetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.NetworkRuleSet>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.NetworkRuleSetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.NetworkRuleSet> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.NetworkRuleSet>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkRuleSetData : Azure.ResourceManager.EventHubs.Models.ProxyResource
    {
        public NetworkRuleSetData() { }
        public Azure.ResourceManager.EventHubs.Models.DefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.NetworkRuleSetIpRules> IpRules { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag? PublicNetworkAccess { get { throw null; } set { } }
        public bool? TrustedServiceAccessEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.NetworkRuleSetVirtualNetworkRules> VirtualNetworkRules { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.EventHubs.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventHubs.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventHubs.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.EventHubs.Models.ProxyResource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.ConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster> GetEventHubCluster(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubCluster>> GetEventHubClusterAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubClusterCollection GetEventHubClusters(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace> GetEventHubNamespace(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubNamespace>> GetEventHubNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubNamespaceCollection GetEventHubNamespaces(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class SchemaGroup : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SchemaGroup() { }
        public virtual Azure.ResourceManager.EventHubs.SchemaGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string schemaGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaGroupCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.SchemaGroup>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.SchemaGroup>, System.Collections.IEnumerable
    {
        protected SchemaGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.SchemaGroup> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaGroupName, Azure.ResourceManager.EventHubs.SchemaGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.SchemaGroup>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaGroupName, Azure.ResourceManager.EventHubs.SchemaGroupData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup> Get(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.SchemaGroup> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.SchemaGroup> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup>> GetAsync(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup> GetIfExists(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.SchemaGroup>> GetIfExistsAsync(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.SchemaGroup> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.SchemaGroup>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.SchemaGroup> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.SchemaGroup>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchemaGroupData : Azure.ResourceManager.EventHubs.Models.ProxyResource
    {
        public SchemaGroupData() { }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public System.Guid? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> GroupProperties { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.SchemaCompatibility? SchemaCompatibility { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.SchemaType? SchemaType { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAtUtc { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult> CheckNameAvailabilityNamespace(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityNamespaceAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventHubs.Models.AvailableCluster> GetAvailableClusterRegionClusters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.AvailableCluster> GetAvailableClusterRegionClustersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubCluster> GetEventHubClusters(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubCluster> GetEventHubClustersAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubNamespace> GetEventHubNamespaces(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubNamespace> GetEventHubNamespacesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EventHubs.Models
{
    public partial class AccessKeys
    {
        internal AccessKeys() { }
        public string AliasPrimaryConnectionString { get { throw null; } }
        public string AliasSecondaryConnectionString { get { throw null; } }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessRights : System.IEquatable<Azure.ResourceManager.EventHubs.Models.AccessRights>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessRights(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.AccessRights Listen { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.AccessRights Manage { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.AccessRights Send { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.AccessRights other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.AccessRights left, Azure.ResourceManager.EventHubs.Models.AccessRights right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.AccessRights (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.AccessRights left, Azure.ResourceManager.EventHubs.Models.AccessRights right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableCluster
    {
        internal AvailableCluster() { }
        public string Location { get { throw null; } }
    }
    public partial class CaptureDescription
    {
        public CaptureDescription() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubDestination Destination { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EncodingCaptureDescription? Encoding { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
        public int? SizeLimitInBytes { get { throw null; } set { } }
        public bool? SkipEmptyArchives { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityOptions
    {
        public CheckNameAvailabilityOptions(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.UnavailableReason? Reason { get { throw null; } }
    }
    public partial class ClusterQuotaConfigurationProperties
    {
        public ClusterQuotaConfigurationProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } }
    }
    public partial class ClusterSku
    {
        public ClusterSku(Azure.ResourceManager.EventHubs.Models.ClusterSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.ClusterSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterSkuName : System.IEquatable<Azure.ResourceManager.EventHubs.Models.ClusterSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterSkuName(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.ClusterSkuName Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.ClusterSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.ClusterSkuName left, Azure.ResourceManager.EventHubs.Models.ClusterSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.ClusterSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.ClusterSkuName left, Azure.ResourceManager.EventHubs.Models.ClusterSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectionState
    {
        public ConnectionState() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.ResourceManager.EventHubs.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.DefaultAction left, Azure.ResourceManager.EventHubs.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.DefaultAction left, Azure.ResourceManager.EventHubs.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EncodingCaptureDescription
    {
        Avro = 0,
        AvroDeflate = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndPointProvisioningState : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndPointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState left, Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState left, Azure.ResourceManager.EventHubs.Models.EndPointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EntityStatus
    {
        Unknown = 0,
        Active = 1,
        Disabled = 2,
        Restoring = 3,
        SendDisabled = 4,
        ReceiveDisabled = 5,
        Creating = 6,
        Deleting = 7,
        Renaming = 8,
    }
    public partial class EventHubDestination
    {
        public EventHubDestination() { }
        public string ArchiveNameFormat { get { throw null; } set { } }
        public string BlobContainer { get { throw null; } set { } }
        public string DataLakeAccountName { get { throw null; } set { } }
        public string DataLakeFolderPath { get { throw null; } set { } }
        public System.Guid? DataLakeSubscriptionId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    public partial class EventHubEncryption
    {
        public EventHubEncryption() { }
        public string KeySource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.KeyVaultProperties> KeyVaultProperties { get { throw null; } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
    }
    public partial class EventHubsSku
    {
        public EventHubsSku(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsSkuName : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsSkuName(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsSkuTier : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.EventHubs.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.KeyType PrimaryKey { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.KeyType SecondaryKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.KeyType left, Azure.ResourceManager.EventHubs.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.KeyType left, Azure.ResourceManager.EventHubs.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction left, Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction left, Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSetIpRules
    {
        public NetworkRuleSetIpRules() { }
        public Azure.ResourceManager.EventHubs.Models.NetworkRuleIPAction? Action { get { throw null; } set { } }
        public string IpMask { get { throw null; } set { } }
    }
    public partial class NetworkRuleSetVirtualNetworkRules
    {
        public NetworkRuleSetVirtualNetworkRules() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkConnectionStatus : System.IEquatable<Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus left, Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus left, Azure.ResourceManager.EventHubs.Models.PrivateLinkConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        internal PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public enum ProvisioningStateDR
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public partial class ProxyResource : Azure.ResourceManager.Models.ResourceData
    {
        public ProxyResource() { }
        public string Location { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessFlag : System.IEquatable<Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessFlag(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag left, Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag left, Azure.ResourceManager.EventHubs.Models.PublicNetworkAccessFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateAccessKeyOptions
    {
        public RegenerateAccessKeyOptions(Azure.ResourceManager.EventHubs.Models.KeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.KeyType KeyType { get { throw null; } }
    }
    public enum RoleDisasterRecovery
    {
        Primary = 0,
        PrimaryNotReplicating = 1,
        Secondary = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchemaCompatibility : System.IEquatable<Azure.ResourceManager.EventHubs.Models.SchemaCompatibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchemaCompatibility(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.SchemaCompatibility Backward { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.SchemaCompatibility Forward { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.SchemaCompatibility None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.SchemaCompatibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.SchemaCompatibility left, Azure.ResourceManager.EventHubs.Models.SchemaCompatibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.SchemaCompatibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.SchemaCompatibility left, Azure.ResourceManager.EventHubs.Models.SchemaCompatibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchemaType : System.IEquatable<Azure.ResourceManager.EventHubs.Models.SchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchemaType(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.SchemaType Avro { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.SchemaType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.SchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.SchemaType left, Azure.ResourceManager.EventHubs.Models.SchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.SchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.SchemaType left, Azure.ResourceManager.EventHubs.Models.SchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum UnavailableReason
    {
        None = 0,
        InvalidName = 1,
        SubscriptionIsDisabled = 2,
        NameInUse = 3,
        NameInLockdown = 4,
        TooManyNamespaceInCurrentSubscription = 5,
    }
}
