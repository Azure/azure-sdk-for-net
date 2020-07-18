namespace Azure.ResourceManager.EventHubs
{
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
    public partial class ClustersOperations
    {
        protected ClustersOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.Cluster> Get(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.Cluster>> GetAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AvailableClustersList> ListAvailableClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AvailableClustersList>> ListAvailableClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.Cluster> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.Cluster> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespaceIdListResult> ListNamespaces(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespaceIdListResult>> ListNamespacesAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.ClustersDeleteOperation StartDelete(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EventHubs.ClustersDeleteOperation> StartDeleteAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.ClustersPatchOperation StartPatch(string resourceGroupName, string clusterName, Azure.ResourceManager.EventHubs.Models.Cluster parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EventHubs.ClustersPatchOperation> StartPatchAsync(string resourceGroupName, string clusterName, Azure.ResourceManager.EventHubs.Models.Cluster parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.ClustersPutOperation StartPut(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EventHubs.ClustersPutOperation> StartPutAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClustersPatchOperation : Azure.Operation<Azure.ResourceManager.EventHubs.Models.Cluster>
    {
        internal ClustersPatchOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.EventHubs.Models.Cluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EventHubs.Models.Cluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EventHubs.Models.Cluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClustersPutOperation : Azure.Operation<Azure.ResourceManager.EventHubs.Models.Cluster>
    {
        internal ClustersPutOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.EventHubs.Models.Cluster Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EventHubs.Models.Cluster>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EventHubs.Models.Cluster>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationOperations
    {
        protected ConfigurationOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties> Get(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties>> GetAsync(string resourceGroupName, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties> Patch(string resourceGroupName, string clusterName, Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties>> PatchAsync(string resourceGroupName, string clusterName, Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsumerGroupsOperations
    {
        protected ConsumerGroupsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ConsumerGroup> CreateOrUpdate(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, Azure.ResourceManager.EventHubs.Models.ConsumerGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ConsumerGroup>> CreateOrUpdateAsync(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, Azure.ResourceManager.EventHubs.Models.ConsumerGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ConsumerGroup> Get(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ConsumerGroup>> GetAsync(string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.ConsumerGroup> ListByEventHub(string resourceGroupName, string namespaceName, string eventHubName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.ConsumerGroup> ListByEventHubAsync(string resourceGroupName, string namespaceName, string eventHubName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisasterRecoveryConfigsOperations
    {
        protected DisasterRecoveryConfigsOperations() { }
        public virtual Azure.Response BreakPairing(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BreakPairingAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult> CheckNameAvailability(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery> CreateOrUpdate(string resourceGroupName, string namespaceName, string alias, Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery>> CreateOrUpdateAsync(string resourceGroupName, string namespaceName, string alias, Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response FailOver(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FailOverAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery> Get(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery>> GetAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> GetAuthorizationRule(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule>> GetAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery> List(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery> ListAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> ListAuthorizationRules(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> ListAuthorizationRulesAsync(string resourceGroupName, string namespaceName, string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> ListKeys(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> ListKeysAsync(string resourceGroupName, string namespaceName, string alias, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsManagementClient
    {
        protected EventHubsManagementClient() { }
        public EventHubsManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.EventHubs.EventHubsManagementClientOptions options = null) { }
        public EventHubsManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.EventHubs.EventHubsManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.EventHubs.ClustersOperations Clusters { get { throw null; } }
        public virtual Azure.ResourceManager.EventHubs.ConfigurationOperations Configuration { get { throw null; } }
        public virtual Azure.ResourceManager.EventHubs.ConsumerGroupsOperations ConsumerGroups { get { throw null; } }
        public virtual Azure.ResourceManager.EventHubs.DisasterRecoveryConfigsOperations DisasterRecoveryConfigs { get { throw null; } }
        public virtual Azure.ResourceManager.EventHubs.EventHubsOperations EventHubs { get { throw null; } }
        public virtual Azure.ResourceManager.EventHubs.NamespacesOperations Namespaces { get { throw null; } }
        public virtual Azure.ResourceManager.EventHubs.Operations Operations { get { throw null; } }
        public virtual Azure.ResourceManager.EventHubs.RegionsOperations Regions { get { throw null; } }
    }
    public partial class EventHubsManagementClientOptions : Azure.Core.ClientOptions
    {
        public EventHubsManagementClientOptions() { }
    }
    public partial class EventHubsOperations
    {
        protected EventHubsOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.Eventhub> CreateOrUpdate(string resourceGroupName, string namespaceName, string eventHubName, Azure.ResourceManager.EventHubs.Models.Eventhub parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.Eventhub>> CreateOrUpdateAsync(string resourceGroupName, string namespaceName, string eventHubName, Azure.ResourceManager.EventHubs.Models.Eventhub parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> CreateOrUpdateAuthorizationRule(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule>> CreateOrUpdateAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAuthorizationRule(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.Eventhub> Get(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.Eventhub>> GetAsync(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> GetAuthorizationRule(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule>> GetAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> ListAuthorizationRules(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> ListAuthorizationRulesAsync(string resourceGroupName, string namespaceName, string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.Eventhub> ListByNamespace(string resourceGroupName, string namespaceName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.Eventhub> ListByNamespaceAsync(string resourceGroupName, string namespaceName, int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> ListKeys(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> ListKeysAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> RegenerateKeys(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> RegenerateKeysAsync(string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespacesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.EventHubs.Models.EHNamespace>
    {
        internal NamespacesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.EventHubs.Models.EHNamespace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class NamespacesOperations
    {
        protected NamespacesOperations() { }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.EventHubs.Models.CheckNameAvailabilityParameter parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> CreateOrUpdateAuthorizationRule(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule>> CreateOrUpdateAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.AuthorizationRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.IpFilterRule> CreateOrUpdateIpFilterRule(string resourceGroupName, string namespaceName, string ipFilterRuleName, Azure.ResourceManager.EventHubs.Models.IpFilterRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.IpFilterRule>> CreateOrUpdateIpFilterRuleAsync(string resourceGroupName, string namespaceName, string ipFilterRuleName, Azure.ResourceManager.EventHubs.Models.IpFilterRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.NetworkRuleSet> CreateOrUpdateNetworkRuleSet(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.NetworkRuleSet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.NetworkRuleSet>> CreateOrUpdateNetworkRuleSetAsync(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.NetworkRuleSet parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule> CreateOrUpdateVirtualNetworkRule(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule>> CreateOrUpdateVirtualNetworkRuleAsync(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteAuthorizationRule(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIpFilterRule(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIpFilterRuleAsync(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVirtualNetworkRule(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVirtualNetworkRuleAsync(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespace> Get(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespace>> GetAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> GetAuthorizationRule(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AuthorizationRule>> GetAuthorizationRuleAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.IpFilterRule> GetIpFilterRule(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.IpFilterRule>> GetIpFilterRuleAsync(string resourceGroupName, string namespaceName, string ipFilterRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.NetworkRuleSet> GetNetworkRuleSet(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.NetworkRuleSet>> GetNetworkRuleSetAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule> GetVirtualNetworkRule(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule>> GetVirtualNetworkRuleAsync(string resourceGroupName, string namespaceName, string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.EHNamespace> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.EHNamespace> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> ListAuthorizationRules(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> ListAuthorizationRulesAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.EHNamespace> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.EHNamespace> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.IpFilterRule> ListIPFilterRules(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.IpFilterRule> ListIPFilterRulesAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> ListKeys(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> ListKeysAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule> ListVirtualNetworkRules(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule> ListVirtualNetworkRulesAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys> RegenerateKeys(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.AccessKeys>> RegenerateKeysAsync(string resourceGroupName, string namespaceName, string authorizationRuleName, Azure.ResourceManager.EventHubs.Models.RegenerateAccessKeyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.NamespacesCreateOrUpdateOperation StartCreateOrUpdate(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EventHubs.NamespacesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.NamespacesDeleteOperation StartDelete(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EventHubs.NamespacesDeleteOperation> StartDeleteAsync(string resourceGroupName, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespace> Update(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EHNamespace>> UpdateAsync(string resourceGroupName, string namespaceName, Azure.ResourceManager.EventHubs.Models.EHNamespace parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Operations
    {
        protected Operations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegionsOperations
    {
        protected RegionsOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.MessagingRegions> ListBySku(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.MessagingRegions> ListBySkuAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ArmDisasterRecovery : Azure.ResourceManager.EventHubs.Models.Resource
    {
        public ArmDisasterRecovery() { }
        public string AlternateName { get { throw null; } set { } }
        public string PartnerNamespace { get { throw null; } set { } }
        public long? PendingReplicationOperationsCount { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.ProvisioningStateDR? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.RoleDisasterRecovery? Role { get { throw null; } }
    }
    public partial class ArmDisasterRecoveryListResult
    {
        internal ArmDisasterRecoveryListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.ArmDisasterRecovery> Value { get { throw null; } }
    }
    public partial class AuthorizationRule : Azure.ResourceManager.EventHubs.Models.Resource
    {
        public AuthorizationRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.AccessRights> Rights { get { throw null; } set { } }
    }
    public partial class AuthorizationRuleListResult
    {
        internal AuthorizationRuleListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.AuthorizationRule> Value { get { throw null; } }
    }
    public partial class AvailableCluster
    {
        internal AvailableCluster() { }
        public string Location { get { throw null; } }
    }
    public partial class AvailableClustersList
    {
        internal AvailableClustersList() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.AvailableCluster> Value { get { throw null; } }
    }
    public partial class CaptureDescription
    {
        public CaptureDescription() { }
        public Azure.ResourceManager.EventHubs.Models.Destination Destination { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EncodingCaptureDescription? Encoding { get { throw null; } set { } }
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
        public Azure.ResourceManager.EventHubs.Models.UnavailableReason? Reason { get { throw null; } }
    }
    public partial class Cluster : Azure.ResourceManager.EventHubs.Models.TrackedResource
    {
        public Cluster() { }
        public string Created { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.ClusterSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public string Updated { get { throw null; } }
    }
    public partial class ClusterListResult
    {
        internal ClusterListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.Cluster> Value { get { throw null; } }
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
    public partial class ConsumerGroup : Azure.ResourceManager.EventHubs.Models.Resource
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.ConsumerGroup> Value { get { throw null; } }
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
    public partial class Destination
    {
        public Destination() { }
        public string ArchiveNameFormat { get { throw null; } set { } }
        public string BlobContainer { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string StorageAccountResourceId { get { throw null; } set { } }
    }
    public partial class EHNamespace : Azure.ResourceManager.EventHubs.Models.TrackedResource
    {
        public EHNamespace() { }
        public string ClusterArmId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.Identity Identity { get { throw null; } set { } }
        public bool? IsAutoInflateEnabled { get { throw null; } set { } }
        public bool? KafkaEnabled { get { throw null; } set { } }
        public int? MaximumThroughputUnits { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.Sku Sku { get { throw null; } set { } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.EHNamespaceIdContainer> Value { get { throw null; } }
    }
    public partial class EHNamespaceListResult
    {
        internal EHNamespaceListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.EHNamespace> Value { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.KeyVaultProperties> KeyVaultProperties { get { throw null; } set { } }
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
    public partial class Eventhub : Azure.ResourceManager.EventHubs.Models.Resource
    {
        public Eventhub() { }
        public Azure.ResourceManager.EventHubs.Models.CaptureDescription CaptureDescription { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public long? MessageRetentionInDays { get { throw null; } set { } }
        public long? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PartitionIds { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EntityStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
    }
    public partial class EventHubListResult
    {
        internal EventHubListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.Eventhub> Value { get { throw null; } }
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAction : System.IEquatable<Azure.ResourceManager.EventHubs.Models.IPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAction(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.IPAction Accept { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.IPAction Reject { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.IPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.IPAction left, Azure.ResourceManager.EventHubs.Models.IPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.IPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.IPAction left, Azure.ResourceManager.EventHubs.Models.IPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IpFilterRule : Azure.ResourceManager.EventHubs.Models.Resource
    {
        public IpFilterRule() { }
        public Azure.ResourceManager.EventHubs.Models.IPAction? Action { get { throw null; } set { } }
        public string FilterName { get { throw null; } set { } }
        public string IpMask { get { throw null; } set { } }
    }
    public partial class IpFilterRuleListResult
    {
        internal IpFilterRuleListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.IpFilterRule> Value { get { throw null; } }
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
    public partial class MessagingRegions : Azure.ResourceManager.EventHubs.Models.TrackedResource
    {
        public MessagingRegions() { }
        public Azure.ResourceManager.EventHubs.Models.MessagingRegionsProperties Properties { get { throw null; } set { } }
    }
    public partial class MessagingRegionsListResult
    {
        internal MessagingRegionsListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.MessagingRegions> Value { get { throw null; } }
    }
    public partial class MessagingRegionsProperties
    {
        public MessagingRegionsProperties() { }
        public string Code { get { throw null; } }
        public string FullName { get { throw null; } }
    }
    public partial class NetworkRuleSet : Azure.ResourceManager.EventHubs.Models.Resource
    {
        public NetworkRuleSet() { }
        public Azure.ResourceManager.EventHubs.Models.DefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.NWRuleSetIpRules> IpRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.NWRuleSetVirtualNetworkRules> VirtualNetworkRules { get { throw null; } set { } }
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
        public Azure.ResourceManager.EventHubs.Models.Subnet Subnet { get { throw null; } set { } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.EventHubs.Models.OperationDisplay Display { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.Operation> Value { get { throw null; } }
    }
    public enum ProvisioningStateDR
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public partial class RegenerateAccessKeyParameters
    {
        public RegenerateAccessKeyParameters(Azure.ResourceManager.EventHubs.Models.KeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.KeyType KeyType { get { throw null; } }
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
        public Sku(Azure.ResourceManager.EventHubs.Models.SkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.SkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.SkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuName : System.IEquatable<Azure.ResourceManager.EventHubs.Models.SkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuName(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.SkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.SkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.SkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.SkuName left, Azure.ResourceManager.EventHubs.Models.SkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.SkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.SkuName left, Azure.ResourceManager.EventHubs.Models.SkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuTier : System.IEquatable<Azure.ResourceManager.EventHubs.Models.SkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuTier(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.SkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.SkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.SkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.SkuTier left, Azure.ResourceManager.EventHubs.Models.SkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.SkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.SkuTier left, Azure.ResourceManager.EventHubs.Models.SkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Subnet
    {
        public Subnet() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class TrackedResource : Azure.ResourceManager.EventHubs.Models.Resource
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
    public partial class VirtualNetworkRule : Azure.ResourceManager.EventHubs.Models.Resource
    {
        public VirtualNetworkRule() { }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRuleListResult
    {
        internal VirtualNetworkRuleListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.VirtualNetworkRule> Value { get { throw null; } }
    }
}
