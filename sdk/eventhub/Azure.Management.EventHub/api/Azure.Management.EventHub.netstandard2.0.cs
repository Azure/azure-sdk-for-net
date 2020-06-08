namespace Azure.Management.EventHub
{
    public partial class ClustersClient
    {
        protected ClustersClient() { }
        public virtual Azure.Response<Azure.Management.EventHub.Models.Cluster> Get(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.Cluster>> GetAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AvailableClustersList> ListAvailableClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AvailableClustersList>> ListAvailableClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.Cluster> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.Cluster> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.EHNamespaceIdListResult> ListNamespaces(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.EHNamespaceIdListResult>> ListNamespacesAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.EventHub.ClustersDeleteOperation StartDelete(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.EventHub.ClustersDeleteOperation> StartDeleteAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.EventHub.ClustersPatchOperation StartPatch(string resourceGroupName, string clusterName, Azure.Management.EventHub.Models.Cluster parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.EventHub.ClustersPatchOperation> StartPatchAsync(string resourceGroupName, string clusterName, Azure.Management.EventHub.Models.Cluster parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.EventHub.ClustersPutOperation StartPut(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.EventHub.ClustersPutOperation> StartPutAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClustersDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal ClustersDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClustersPatchOperation : Azure.Operation<Azure.Management.EventHub.Models.Cluster>
    {
        internal ClustersPatchOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.EventHub.Models.Cluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.EventHub.Models.Cluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.EventHub.Models.Cluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClustersPutOperation : Azure.Operation<Azure.Management.EventHub.Models.Cluster>
    {
        internal ClustersPutOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.EventHub.Models.Cluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.EventHub.Models.Cluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.EventHub.Models.Cluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationClient
    {
        protected ConfigurationClient() { }
        public virtual Azure.Response<Azure.Management.EventHub.Models.ClusterQuotaConfigurationProperties> Get(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.ClusterQuotaConfigurationProperties>> GetAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.ClusterQuotaConfigurationProperties> Patch(string resourceGroupName, string clusterName, Azure.Management.EventHub.Models.ClusterQuotaConfigurationProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.ClusterQuotaConfigurationProperties>> PatchAsync(string resourceGroupName, string clusterName, Azure.Management.EventHub.Models.ClusterQuotaConfigurationProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsumerGroupsClient
    {
        protected ConsumerGroupsClient() { }
        public virtual Azure.Response<Azure.Management.EventHub.Models.ConsumerGroup> CreateOrUpdate(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, Azure.Management.EventHub.Models.ConsumerGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.ConsumerGroup>> CreateOrUpdateAsync(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, Azure.Management.EventHub.Models.ConsumerGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.ConsumerGroup> Get(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.ConsumerGroup>> GetAsync(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.ConsumerGroup> ListByEventHub(string resourceGroupName, string namespaceName, string eventHubName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.ConsumerGroup> ListByEventHubAsync(string resourceGroupName, string namespaceName, string eventHubName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisasterRecoveryConfigsClient
    {
        protected DisasterRecoveryConfigsClient() { }
        public virtual Azure.Response BreakPairing(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BreakPairingAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.CheckNameAvailabilityResult> CheckNameAvailability(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.ArmDisasterRecovery> CreateOrUpdate(string resourceGroupName, string namespaceName, string alias, Azure.Management.EventHub.Models.ArmDisasterRecovery parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.ArmDisasterRecovery>> CreateOrUpdateAsync(string resourceGroupName, string namespaceName, string alias, Azure.Management.EventHub.Models.ArmDisasterRecovery parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response FailOver(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FailOverAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.ArmDisasterRecovery> Get(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.ArmDisasterRecovery>> GetAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule> GetAuthorizationRule(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule>> GetAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.ArmDisasterRecovery> List(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.ArmDisasterRecovery> ListAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.AuthorizationRule> ListAuthorizationRules(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.AuthorizationRule> ListAuthorizationRulesAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AccessKeys> ListKeys(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AccessKeys>> ListKeysAsync(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubManagementClient
    {
        protected EventHubManagementClient() { }
        public EventHubManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.EventHub.EventHubManagementClientOptions options = null) { }
        public EventHubManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Management.EventHub.EventHubManagementClientOptions options = null) { }
        public virtual Azure.Management.EventHub.ClustersClient GetClustersClient() { throw null; }
        public virtual Azure.Management.EventHub.ConfigurationClient GetConfigurationClient() { throw null; }
        public virtual Azure.Management.EventHub.ConsumerGroupsClient GetConsumerGroupsClient() { throw null; }
        public virtual Azure.Management.EventHub.DisasterRecoveryConfigsClient GetDisasterRecoveryConfigsClient() { throw null; }
        public virtual Azure.Management.EventHub.EventHubsClient GetEventHubsClient() { throw null; }
        public virtual Azure.Management.EventHub.NamespacesClient GetNamespacesClient() { throw null; }
        public virtual Azure.Management.EventHub.OperationsClient GetOperationsClient() { throw null; }
        public virtual Azure.Management.EventHub.RegionsClient GetRegionsClient() { throw null; }
    }
    public partial class EventHubManagementClientOptions : Azure.Core.ClientOptions
    {
        public EventHubManagementClientOptions() { }
    }
    public partial class EventHubsClient
    {
        protected EventHubsClient() { }
        public virtual Azure.Response<Azure.Management.EventHub.Models.Eventhub> CreateOrUpdate(string resourceGroupName, string namespaceName, string eventHubName, Azure.Management.EventHub.Models.Eventhub parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.Eventhub>> CreateOrUpdateAsync(string resourceGroupName, string namespaceName, string eventHubName, Azure.Management.EventHub.Models.Eventhub parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule> CreateOrUpdateAuthorizationRule(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.Management.EventHub.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule>> CreateOrUpdateAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.Management.EventHub.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAuthorizationRule(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.Eventhub> Get(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.Eventhub>> GetAsync(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule> GetAuthorizationRule(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule>> GetAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.AuthorizationRule> ListAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.AuthorizationRule> ListAuthorizationRulesAsync(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.Eventhub> ListByNamespace(string resourceGroupName, string namespaceName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.Eventhub> ListByNamespaceAsync(string resourceGroupName, string namespaceName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AccessKeys> ListKeys(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AccessKeys>> ListKeysAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AccessKeys> RegenerateKeys(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.Management.EventHub.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AccessKeys>> RegenerateKeysAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.Management.EventHub.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespacesClient
    {
        protected NamespacesClient() { }
        public virtual Azure.Response<Azure.Management.EventHub.Models.CheckNameAvailabilityResult> CheckNameAvailability(Azure.Management.EventHub.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.Management.EventHub.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule> CreateOrUpdateAuthorizationRule(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.Management.EventHub.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule>> CreateOrUpdateAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.Management.EventHub.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.IpFilterRule> CreateOrUpdateIpFilterRule(string resourceGroupName, string namespaceName, string ipFilterRuleName, Azure.Management.EventHub.Models.IpFilterRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.IpFilterRule>> CreateOrUpdateIpFilterRuleAsync(string resourceGroupName, string namespaceName, string ipFilterRuleName, Azure.Management.EventHub.Models.IpFilterRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.NetworkRuleSet> CreateOrUpdateNetworkRuleSet(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.NetworkRuleSet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.NetworkRuleSet>> CreateOrUpdateNetworkRuleSetAsync(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.NetworkRuleSet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.VirtualNetworkRule> CreateOrUpdateVirtualNetworkRule(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, Azure.Management.EventHub.Models.VirtualNetworkRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.VirtualNetworkRule>> CreateOrUpdateVirtualNetworkRuleAsync(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, Azure.Management.EventHub.Models.VirtualNetworkRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAuthorizationRule(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIpFilterRule(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIpFilterRuleAsync(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVirtualNetworkRule(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVirtualNetworkRuleAsync(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.EHNamespace> Get(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.EHNamespace>> GetAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule> GetAuthorizationRule(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AuthorizationRule>> GetAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.IpFilterRule> GetIpFilterRule(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.IpFilterRule>> GetIpFilterRuleAsync(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.NetworkRuleSet> GetNetworkRuleSet(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.NetworkRuleSet>> GetNetworkRuleSetAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.VirtualNetworkRule> GetVirtualNetworkRule(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.VirtualNetworkRule>> GetVirtualNetworkRuleAsync(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.EHNamespace> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.EHNamespace> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.AuthorizationRule> ListAuthorizationRules(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.AuthorizationRule> ListAuthorizationRulesAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.EHNamespace> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.EHNamespace> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.IpFilterRule> ListIPFilterRules(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.IpFilterRule> ListIPFilterRulesAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AccessKeys> ListKeys(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AccessKeys>> ListKeysAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.VirtualNetworkRule> ListVirtualNetworkRules(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.VirtualNetworkRule> ListVirtualNetworkRulesAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.AccessKeys> RegenerateKeys(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.Management.EventHub.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.AccessKeys>> RegenerateKeysAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.Management.EventHub.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.EventHub.NamespacesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.EventHub.NamespacesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.EventHub.NamespacesDeleteOperation StartDelete(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.EventHub.NamespacesDeleteOperation> StartDeleteAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.EventHub.Models.EHNamespace> Update(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.EventHub.Models.EHNamespace>> UpdateAsync(string resourceGroupName, string namespaceName, Azure.Management.EventHub.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespacesCreateOrUpdateOperation : Azure.Operation<Azure.Management.EventHub.Models.EHNamespace>
    {
        internal NamespacesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.EventHub.Models.EHNamespace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.EventHub.Models.EHNamespace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.EventHub.Models.EHNamespace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespacesDeleteOperation : Azure.Operation<Azure.Response>
    {
        internal NamespacesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationsClient
    {
        protected OperationsClient() { }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegionsClient
    {
        protected RegionsClient() { }
        public virtual Azure.Pageable<Azure.Management.EventHub.Models.MessagingRegions> ListBySku(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.EventHub.Models.MessagingRegions> ListBySkuAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Management.EventHub.Models
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
    public readonly partial struct AccessRights : System.IEquatable<Azure.Management.EventHub.Models.AccessRights>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessRights(string value) { throw null; }
        public static Azure.Management.EventHub.Models.AccessRights Listen { get { throw null; } }
        public static Azure.Management.EventHub.Models.AccessRights Manage { get { throw null; } }
        public static Azure.Management.EventHub.Models.AccessRights Send { get { throw null; } }
        public bool Equals(Azure.Management.EventHub.Models.AccessRights other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.EventHub.Models.AccessRights left, Azure.Management.EventHub.Models.AccessRights right) { throw null; }
        public static implicit operator Azure.Management.EventHub.Models.AccessRights (string value) { throw null; }
        public static bool operator !=(Azure.Management.EventHub.Models.AccessRights left, Azure.Management.EventHub.Models.AccessRights right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArmDisasterRecovery : Azure.Management.EventHub.Models.Resource
    {
        public ArmDisasterRecovery() { }
        public string AlternateName { get { throw null; } set { } }
        public string PartnerNamespace { get { throw null; } set { } }
        public long? PendingReplicationOperationsCount { get { throw null; } }
        public Azure.Management.EventHub.Models.ProvisioningStateDR? ProvisioningState { get { throw null; } }
        public Azure.Management.EventHub.Models.RoleDisasterRecovery? Role { get { throw null; } }
    }
    public partial class ArmDisasterRecoveryListResult
    {
        internal ArmDisasterRecoveryListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.ArmDisasterRecovery> Value { get { throw null; } }
    }
    public partial class AuthorizationRule : Azure.Management.EventHub.Models.Resource
    {
        public AuthorizationRule() { }
        public System.Collections.Generic.IList<Azure.Management.EventHub.Models.AccessRights> Rights { get { throw null; } set { } }
    }
    public partial class AuthorizationRuleListResult
    {
        internal AuthorizationRuleListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.AuthorizationRule> Value { get { throw null; } }
    }
    public partial class AvailableCluster
    {
        internal AvailableCluster() { }
        public string Location { get { throw null; } }
    }
    public partial class AvailableClustersList
    {
        internal AvailableClustersList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.AvailableCluster> Value { get { throw null; } }
    }
    public partial class CaptureDescription
    {
        public CaptureDescription() { }
        public Azure.Management.EventHub.Models.Destination Destination { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.Management.EventHub.Models.EncodingCaptureDescription? Encoding { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
        public int? SizeLimitInBytes { get { throw null; } set { } }
        public bool? SkipEmptyArchives { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityParameter
    {
        public CheckNameAvailabilityParameter(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.Management.EventHub.Models.UnavailableReason? Reason { get { throw null; } }
    }
    public partial class Cluster : Azure.Management.EventHub.Models.TrackedResource
    {
        public Cluster() { }
        public string Created { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.Management.EventHub.Models.ClusterSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string Updated { get { throw null; } }
    }
    public partial class ClusterListResult
    {
        internal ClusterListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.Cluster> Value { get { throw null; } }
    }
    public partial class ClusterQuotaConfigurationProperties
    {
        public ClusterQuotaConfigurationProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } set { } }
    }
    public partial class ClusterSku
    {
        public ClusterSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ConsumerGroup : Azure.Management.EventHub.Models.Resource
    {
        public ConsumerGroup() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        public string UserMetadata { get { throw null; } set { } }
    }
    public partial class ConsumerGroupListResult
    {
        internal ConsumerGroupListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.ConsumerGroup> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.Management.EventHub.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.Management.EventHub.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.Management.EventHub.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.Management.EventHub.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.EventHub.Models.DefaultAction left, Azure.Management.EventHub.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.Management.EventHub.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.Management.EventHub.Models.DefaultAction left, Azure.Management.EventHub.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Destination
    {
        public Destination() { }
        public string ArchiveNameFormat { get { throw null; } set { } }
        public string BlobContainer { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    public partial class EHNamespace : Azure.Management.EventHub.Models.TrackedResource
    {
        public EHNamespace() { }
        public string ClusterArmId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public Azure.Management.EventHub.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.Management.EventHub.Models.Identity Identity { get { throw null; } set { } }
        public bool? IsAutoInflateEnabled { get { throw null; } set { } }
        public bool? KafkaEnabled { get { throw null; } set { } }
        public int? MaximumThroughputUnits { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.Management.EventHub.Models.Sku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class EHNamespaceIdContainer
    {
        internal EHNamespaceIdContainer() { }
        public string Id { get { throw null; } }
    }
    public partial class EHNamespaceIdListResult
    {
        internal EHNamespaceIdListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.EHNamespaceIdContainer> Value { get { throw null; } }
    }
    public partial class EHNamespaceListResult
    {
        internal EHNamespaceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.EHNamespace> Value { get { throw null; } }
    }
    public enum EncodingCaptureDescription
    {
        Avro = 0,
        AvroDeflate = 1,
    }
    public partial class Encryption
    {
        public Encryption() { }
        public string KeySource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.EventHub.Models.KeyVaultProperties> KeyVaultProperties { get { throw null; } set { } }
    }
    public enum EntityStatus
    {
        Active = 0,
        Disabled = 1,
        Restoring = 2,
        SendDisabled = 3,
        ReceiveDisabled = 4,
        Creating = 5,
        Deleting = 6,
        Renaming = 7,
        Unknown = 8,
    }
    public partial class Eventhub : Azure.Management.EventHub.Models.Resource
    {
        public Eventhub() { }
        public Azure.Management.EventHub.Models.CaptureDescription CaptureDescription { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public long? MessageRetentionInDays { get { throw null; } set { } }
        public long? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PartitionIds { get { throw null; } }
        public Azure.Management.EventHub.Models.EntityStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
    }
    public partial class EventHubListResult
    {
        internal EventHubListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.Eventhub> Value { get { throw null; } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAction : System.IEquatable<Azure.Management.EventHub.Models.IPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAction(string value) { throw null; }
        public static Azure.Management.EventHub.Models.IPAction Accept { get { throw null; } }
        public static Azure.Management.EventHub.Models.IPAction Reject { get { throw null; } }
        public bool Equals(Azure.Management.EventHub.Models.IPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.EventHub.Models.IPAction left, Azure.Management.EventHub.Models.IPAction right) { throw null; }
        public static implicit operator Azure.Management.EventHub.Models.IPAction (string value) { throw null; }
        public static bool operator !=(Azure.Management.EventHub.Models.IPAction left, Azure.Management.EventHub.Models.IPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IpFilterRule : Azure.Management.EventHub.Models.Resource
    {
        public IpFilterRule() { }
        public Azure.Management.EventHub.Models.IPAction? Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IpMask { get { throw null; } set { } }
    }
    public partial class IpFilterRuleListResult
    {
        internal IpFilterRuleListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.IpFilterRule> Value { get { throw null; } }
    }
    public enum KeyType
    {
        PrimaryKey = 0,
        SecondaryKey = 1,
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    public partial class MessagingRegions : Azure.Management.EventHub.Models.TrackedResource
    {
        public MessagingRegions() { }
        public Azure.Management.EventHub.Models.MessagingRegionsProperties Properties { get { throw null; } set { } }
    }
    public partial class MessagingRegionsListResult
    {
        internal MessagingRegionsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.MessagingRegions> Value { get { throw null; } }
    }
    public partial class MessagingRegionsProperties
    {
        public MessagingRegionsProperties() { }
        public string Code { get { throw null; } }
        public string FullName { get { throw null; } }
    }
    public partial class NetworkRuleSet : Azure.Management.EventHub.Models.Resource
    {
        public NetworkRuleSet() { }
        public Azure.Management.EventHub.Models.DefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.EventHub.Models.NWRuleSetIpRules> IpRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.EventHub.Models.NWRuleSetVirtualNetworkRules> VirtualNetworkRules { get { throw null; } set { } }
    }
    public partial class NWRuleSetIpRules
    {
        public NWRuleSetIpRules() { }
        public string Action { get { throw null; } set { } }
        public string IpMask { get { throw null; } set { } }
    }
    public partial class NWRuleSetVirtualNetworkRules
    {
        public NWRuleSetVirtualNetworkRules() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Management.EventHub.Models.Subnet Subnet { get { throw null; } set { } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.Management.EventHub.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationListResult
    {
        internal OperationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.Operation> Value { get { throw null; } }
    }
    public enum ProvisioningStateDR
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public partial class RegenerateAccessKeyParameters
    {
        public RegenerateAccessKeyParameters(Azure.Management.EventHub.Models.KeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.Management.EventHub.Models.KeyType KeyType { get { throw null; } }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public enum RoleDisasterRecovery
    {
        Primary = 0,
        PrimaryNotReplicating = 1,
        Secondary = 2,
    }
    public partial class Sku
    {
        public Sku(Azure.Management.EventHub.Models.SkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.Management.EventHub.Models.SkuName Name { get { throw null; } set { } }
        public Azure.Management.EventHub.Models.SkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuName : System.IEquatable<Azure.Management.EventHub.Models.SkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuName(string value) { throw null; }
        public static Azure.Management.EventHub.Models.SkuName Basic { get { throw null; } }
        public static Azure.Management.EventHub.Models.SkuName Standard { get { throw null; } }
        public bool Equals(Azure.Management.EventHub.Models.SkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.EventHub.Models.SkuName left, Azure.Management.EventHub.Models.SkuName right) { throw null; }
        public static implicit operator Azure.Management.EventHub.Models.SkuName (string value) { throw null; }
        public static bool operator !=(Azure.Management.EventHub.Models.SkuName left, Azure.Management.EventHub.Models.SkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuTier : System.IEquatable<Azure.Management.EventHub.Models.SkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuTier(string value) { throw null; }
        public static Azure.Management.EventHub.Models.SkuTier Basic { get { throw null; } }
        public static Azure.Management.EventHub.Models.SkuTier Standard { get { throw null; } }
        public bool Equals(Azure.Management.EventHub.Models.SkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.EventHub.Models.SkuTier left, Azure.Management.EventHub.Models.SkuTier right) { throw null; }
        public static implicit operator Azure.Management.EventHub.Models.SkuTier (string value) { throw null; }
        public static bool operator !=(Azure.Management.EventHub.Models.SkuTier left, Azure.Management.EventHub.Models.SkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Subnet
    {
        public Subnet() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class TrackedResource : Azure.Management.EventHub.Models.Resource
    {
        public TrackedResource() { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
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
    public partial class VirtualNetworkRule : Azure.Management.EventHub.Models.Resource
    {
        public VirtualNetworkRule() { }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRuleListResult
    {
        internal VirtualNetworkRuleListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.EventHub.Models.VirtualNetworkRule> Value { get { throw null; } }
    }
}
