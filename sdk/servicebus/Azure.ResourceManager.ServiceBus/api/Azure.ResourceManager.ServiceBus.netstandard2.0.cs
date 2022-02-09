namespace Azure.ResourceManager.ServiceBus
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.ServiceBus.DisasterRecovery GetDisasterRecovery(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.MigrationConfigProperties GetMigrationConfigProperties(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule GetNamespaceAuthorizationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule GetNamespaceDisasterRecoveryAuthorizationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule GetNamespaceQueueAuthorizationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule GetNamespaceTopicAuthorizationRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.NetworkRuleSet GetNetworkRuleSet(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.ServiceBusNamespace GetServiceBusNamespace(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.ServiceBusQueue GetServiceBusQueue(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.ServiceBusRule GetServiceBusRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.ServiceBusSubscription GetServiceBusSubscription(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceBus.ServiceBusTopic GetServiceBusTopic(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DisasterRecovery : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DisasterRecovery() { }
        public virtual Azure.ResourceManager.ServiceBus.DisasterRecoveryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response BreakPairing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BreakPairingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.DisasterRecoveryDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.DisasterRecoveryDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response FailOver(Azure.ResourceManager.ServiceBus.Models.FailoverProperties parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FailOverAsync(Azure.ResourceManager.ServiceBus.Models.FailoverProperties parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRuleCollection GetNamespaceDisasterRecoveryAuthorizationRules() { throw null; }
    }
    public partial class DisasterRecoveryCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.DisasterRecovery>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.DisasterRecovery>, System.Collections.IEnumerable
    {
        protected DisasterRecoveryCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.DisasterRecoveryCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string alias, Azure.ResourceManager.ServiceBus.DisasterRecoveryData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.DisasterRecoveryCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string alias, Azure.ResourceManager.ServiceBus.DisasterRecoveryData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery> Get(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.DisasterRecovery> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.DisasterRecovery> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery>> GetAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery> GetIfExists(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery>> GetIfExistsAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.DisasterRecovery> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.DisasterRecovery>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.DisasterRecovery> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.DisasterRecovery>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DisasterRecoveryData : Azure.ResourceManager.Models.Resource
    {
        public DisasterRecoveryData() { }
        public string AlternateName { get { throw null; } set { } }
        public string PartnerNamespace { get { throw null; } set { } }
        public long? PendingReplicationOperationsCount { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.ProvisioningStateDisasterRecovery? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.RoleDisasterRecovery? Role { get { throw null; } }
    }
    public partial class MigrationConfigProperties : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationConfigProperties() { }
        public virtual Azure.ResourceManager.ServiceBus.MigrationConfigPropertiesData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response CompleteMigration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteMigrationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string configName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.MigrationConfigPropertiesDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.MigrationConfigPropertiesDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Revert(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevertAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationConfigPropertiesCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>, System.Collections.IEnumerable
    {
        protected MigrationConfigPropertiesCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.MigrationConfigPropertiesCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, Azure.ResourceManager.ServiceBus.MigrationConfigPropertiesData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.MigrationConfigPropertiesCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, Azure.ResourceManager.ServiceBus.MigrationConfigPropertiesData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties> Get(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.MigrationConfigProperties> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.MigrationConfigProperties> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>> GetAsync(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties> GetIfExists(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>> GetIfExistsAsync(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName configName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.MigrationConfigProperties> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.MigrationConfigProperties> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationConfigPropertiesData : Azure.ResourceManager.Models.Resource
    {
        public MigrationConfigPropertiesData() { }
        public string MigrationState { get { throw null; } }
        public long? PendingReplicationOperationsCount { get { throw null; } }
        public string PostMigrationName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string TargetNamespace { get { throw null; } set { } }
    }
    public partial class NamespaceAuthorizationRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceAuthorizationRule() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.NamespaceAuthorizationRuleDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.NamespaceAuthorizationRuleDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.ServiceBus.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.ServiceBus.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceAuthorizationRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>, System.Collections.IEnumerable
    {
        protected NamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.NamespaceAuthorizationRuleCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string authorizationRuleName, Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.NamespaceAuthorizationRuleCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string authorizationRuleName, Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceDisasterRecoveryAuthorizationRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceDisasterRecoveryAuthorizationRule() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias, string authorizationRuleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceDisasterRecoveryAuthorizationRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule>, System.Collections.IEnumerable
    {
        protected NamespaceDisasterRecoveryAuthorizationRuleCollection() { }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceDisasterRecoveryAuthorizationRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceQueueAuthorizationRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceQueueAuthorizationRule() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string queueName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.NamespaceQueueAuthorizationRuleDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.NamespaceQueueAuthorizationRuleDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.ServiceBus.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.ServiceBus.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceQueueAuthorizationRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>, System.Collections.IEnumerable
    {
        protected NamespaceQueueAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.NamespaceQueueAuthorizationRuleCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string authorizationRuleName, Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.NamespaceQueueAuthorizationRuleCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string authorizationRuleName, Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceTopicAuthorizationRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceTopicAuthorizationRule() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string topicName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.NamespaceTopicAuthorizationRuleDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.NamespaceTopicAuthorizationRuleDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.ServiceBus.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.ServiceBus.Models.RegenerateAccessKeyOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceTopicAuthorizationRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>, System.Collections.IEnumerable
    {
        protected NamespaceTopicAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.NamespaceTopicAuthorizationRuleCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string authorizationRuleName, Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.NamespaceTopicAuthorizationRuleCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string authorizationRuleName, Azure.ResourceManager.ServiceBus.ServiceBusAuthorizationRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkRuleSet : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkRuleSet() { }
        public virtual Azure.ResourceManager.ServiceBus.NetworkRuleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ServiceBus.Models.NetworkRuleSetCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, Azure.ResourceManager.ServiceBus.NetworkRuleSetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.NetworkRuleSetCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, Azure.ResourceManager.ServiceBus.NetworkRuleSetData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.NetworkRuleSet> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.NetworkRuleSet>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkRuleSetData : Azure.ResourceManager.Models.Resource
    {
        public NetworkRuleSetData() { }
        public Azure.ResourceManager.ServiceBus.Models.DefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceBus.Models.NetworkRuleSetIPRules> IPRules { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag? PublicNetworkAccess { get { throw null; } set { } }
        public bool? TrustedServiceAccessEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceBus.Models.NetworkRuleSetVirtualNetworkRules> VirtualNetworkRules { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.ServiceBus.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.ServiceBus.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.ServiceBus.PrivateEndpointConnectionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Resources.Models.WritableSubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.ConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.ServiceBus.ServiceBusNamespaceCollection GetServiceBusNamespaces(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class ServiceBusAuthorizationRuleData : Azure.ResourceManager.Models.Resource
    {
        public ServiceBusAuthorizationRuleData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceBus.Models.AccessRights> Rights { get { throw null; } }
    }
    public partial class ServiceBusNamespace : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceBusNamespace() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.Models.CheckNameAvailabilityResult> CheckDisasterRecoveryNameAvailability(Azure.ResourceManager.ServiceBus.Models.CheckNameAvailability parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.CheckNameAvailabilityResult>> CheckDisasterRecoveryNameAvailabilityAsync(Azure.ResourceManager.ServiceBus.Models.CheckNameAvailability parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespaceDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespaceDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.DisasterRecoveryCollection GetDisasterRecoveries() { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.MigrationConfigPropertiesCollection GetMigrationConfigProperties() { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRuleCollection GetNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.NetworkRuleSet GetNetworkRuleSet() { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.Models.PrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.Models.PrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusQueueCollection GetServiceBusQueues() { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusTopicCollection GetServiceBusTopics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> Update(Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespaceUpdateOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> UpdateAsync(Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespaceUpdateOptions parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusNamespaceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>, System.Collections.IEnumerable
    {
        protected ServiceBusNamespaceCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespaceCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string namespaceName, Azure.ResourceManager.ServiceBus.ServiceBusNamespaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusNamespaceCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string namespaceName, Azure.ResourceManager.ServiceBus.ServiceBusNamespaceData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceBusNamespaceData : Azure.ResourceManager.Models.TrackedResource
    {
        public ServiceBusNamespaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceBus.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.Sku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ServiceBusQueue : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceBusQueue() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusQueueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string queueName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusQueueDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusQueueDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRuleCollection GetNamespaceQueueAuthorizationRules() { throw null; }
    }
    public partial class ServiceBusQueueCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusQueue>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusQueue>, System.Collections.IEnumerable
    {
        protected ServiceBusQueueCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusQueueCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string queueName, Azure.ResourceManager.ServiceBus.ServiceBusQueueData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusQueueCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string queueName, Azure.ResourceManager.ServiceBus.ServiceBusQueueData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue> Get(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.ServiceBusQueue> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.ServiceBusQueue> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue>> GetAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue> GetIfExists(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue>> GetIfExistsAsync(string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusQueue> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusQueue>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusQueue> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusQueue>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceBusQueueData : Azure.ResourceManager.Models.Resource
    {
        public ServiceBusQueueData() { }
        public System.DateTimeOffset? AccessedAt { get { throw null; } }
        public System.TimeSpan? AutoDeleteOnIdle { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.MessageCountDetails CountDetails { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public bool? DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public System.TimeSpan? DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan? DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool? EnableBatchedOperations { get { throw null; } set { } }
        public bool? EnableExpress { get { throw null; } set { } }
        public bool? EnablePartitioning { get { throw null; } set { } }
        public string ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public string ForwardTo { get { throw null; } set { } }
        public System.TimeSpan? LockDuration { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public long? MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public int? MaxSizeInMegabytes { get { throw null; } set { } }
        public long? MessageCount { get { throw null; } }
        public bool? RequiresDuplicateDetection { get { throw null; } set { } }
        public bool? RequiresSession { get { throw null; } set { } }
        public long? SizeInBytes { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.EntityStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
    }
    public partial class ServiceBusRule : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceBusRule() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string topicName, string subscriptionName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusRuleDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusRuleDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusRuleCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusRule>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusRule>, System.Collections.IEnumerable
    {
        protected ServiceBusRuleCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusRuleCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string ruleName, Azure.ResourceManager.ServiceBus.ServiceBusRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusRuleCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string ruleName, Azure.ResourceManager.ServiceBus.ServiceBusRuleData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.ServiceBusRule> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.ServiceBusRule> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusRule> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusRule>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusRule> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusRule>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceBusRuleData : Azure.ResourceManager.Models.Resource
    {
        public ServiceBusRuleData() { }
        public Azure.ResourceManager.ServiceBus.Models.FilterAction Action { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.CorrelationFilter CorrelationFilter { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.FilterType? FilterType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.SqlFilter SqlFilter { get { throw null; } set { } }
    }
    public partial class ServiceBusSubscription : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceBusSubscription() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string topicName, string subscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusSubscriptionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusSubscriptionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusRuleCollection GetServiceBusRules() { throw null; }
    }
    public partial class ServiceBusSubscriptionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>, System.Collections.IEnumerable
    {
        protected ServiceBusSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusSubscriptionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string subscriptionName, Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusSubscriptionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string subscriptionName, Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription> Get(string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.ServiceBusSubscription> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.ServiceBusSubscription> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>> GetAsync(string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription> GetIfExists(string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>> GetIfExistsAsync(string subscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusSubscription> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusSubscription> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceBusSubscriptionData : Azure.ResourceManager.Models.Resource
    {
        public ServiceBusSubscriptionData() { }
        public System.DateTimeOffset? AccessedAt { get { throw null; } }
        public System.TimeSpan? AutoDeleteOnIdle { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.ServiceBusClientAffineProperties ClientAffineProperties { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.MessageCountDetails CountDetails { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public bool? DeadLetteringOnFilterEvaluationExceptions { get { throw null; } set { } }
        public bool? DeadLetteringOnMessageExpiration { get { throw null; } set { } }
        public System.TimeSpan? DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan? DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool? EnableBatchedOperations { get { throw null; } set { } }
        public string ForwardDeadLetteredMessagesTo { get { throw null; } set { } }
        public string ForwardTo { get { throw null; } set { } }
        public bool? IsClientAffine { get { throw null; } set { } }
        public System.TimeSpan? LockDuration { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public long? MessageCount { get { throw null; } }
        public bool? RequiresSession { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.EntityStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
    }
    public partial class ServiceBusTopic : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceBusTopic() { }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string topicName) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusTopicDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusTopicDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRuleCollection GetNamespaceTopicAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionCollection GetServiceBusSubscriptions() { throw null; }
    }
    public partial class ServiceBusTopicCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusTopic>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusTopic>, System.Collections.IEnumerable
    {
        protected ServiceBusTopicCollection() { }
        public virtual Azure.ResourceManager.ServiceBus.Models.ServiceBusTopicCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string topicName, Azure.ResourceManager.ServiceBus.ServiceBusTopicData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ServiceBus.Models.ServiceBusTopicCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string topicName, Azure.ResourceManager.ServiceBus.ServiceBusTopicData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic> Get(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceBus.ServiceBusTopic> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.ServiceBusTopic> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic>> GetAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic> GetIfExists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic>> GetIfExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusTopic> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusTopic>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceBus.ServiceBusTopic> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceBus.ServiceBusTopic>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceBusTopicData : Azure.ResourceManager.Models.Resource
    {
        public ServiceBusTopicData() { }
        public System.DateTimeOffset? AccessedAt { get { throw null; } }
        public System.TimeSpan? AutoDeleteOnIdle { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.MessageCountDetails CountDetails { get { throw null; } }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public System.TimeSpan? DefaultMessageTimeToLive { get { throw null; } set { } }
        public System.TimeSpan? DuplicateDetectionHistoryTimeWindow { get { throw null; } set { } }
        public bool? EnableBatchedOperations { get { throw null; } set { } }
        public bool? EnableExpress { get { throw null; } set { } }
        public bool? EnablePartitioning { get { throw null; } set { } }
        public long? MaxMessageSizeInKilobytes { get { throw null; } set { } }
        public int? MaxSizeInMegabytes { get { throw null; } set { } }
        public bool? RequiresDuplicateDetection { get { throw null; } set { } }
        public long? SizeInBytes { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.EntityStatus? Status { get { throw null; } set { } }
        public int? SubscriptionCount { get { throw null; } }
        public bool? SupportOrdering { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ServiceBus.Models.CheckNameAvailabilityResult> CheckServiceBusNameAvailability(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.ServiceBus.Models.CheckNameAvailability parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceBus.Models.CheckNameAvailabilityResult>> CheckServiceBusNameAvailabilityAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.ServiceBus.Models.CheckNameAvailability parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> GetServiceBusNamespaces(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceBus.ServiceBusNamespace> GetServiceBusNamespacesAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceBus.Models
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
    public enum AccessRights
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    public partial class CheckNameAvailability
    {
        public CheckNameAvailability(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.UnavailableReason? Reason { get { throw null; } }
    }
    public partial class ConnectionState
    {
        public ConnectionState() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class CorrelationFilter
    {
        public CorrelationFilter() { }
        public string ContentType { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ReplyTo { get { throw null; } set { } }
        public string ReplyToSessionId { get { throw null; } set { } }
        public bool? RequiresPreprocessing { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        public string To { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.ServiceBus.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceBus.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceBus.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceBus.Models.CreatedByType left, Azure.ResourceManager.ServiceBus.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceBus.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceBus.Models.CreatedByType left, Azure.ResourceManager.ServiceBus.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.ResourceManager.ServiceBus.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceBus.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceBus.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceBus.Models.DefaultAction left, Azure.ResourceManager.ServiceBus.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceBus.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceBus.Models.DefaultAction left, Azure.ResourceManager.ServiceBus.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DisasterRecoveryCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.DisasterRecovery>
    {
        protected DisasterRecoveryCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.DisasterRecovery Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.DisasterRecovery>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DisasterRecoveryDeleteOperation : Azure.Operation
    {
        protected DisasterRecoveryDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionProperties
    {
        public EncryptionProperties() { }
        public string KeySource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceBus.Models.KeyVaultProperties> KeyVaultProperties { get { throw null; } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState left, Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState left, Azure.ResourceManager.ServiceBus.Models.EndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class FailoverProperties
    {
        public FailoverProperties() { }
        public bool? IsSafeFailover { get { throw null; } set { } }
    }
    public partial class FilterAction
    {
        public FilterAction() { }
        public int? CompatibilityLevel { get { throw null; } set { } }
        public bool? RequiresPreprocessing { get { throw null; } set { } }
        public string SqlExpression { get { throw null; } set { } }
    }
    public enum FilterType
    {
        SqlFilter = 0,
        CorrelationFilter = 1,
    }
    public enum KeyType
    {
        PrimaryKey = 0,
        SecondaryKey = 1,
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public Azure.ResourceManager.ServiceBus.Models.UserAssignedIdentityProperties Identity { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    public enum ManagedServiceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    public partial class MessageCountDetails
    {
        internal MessageCountDetails() { }
        public long? ActiveMessageCount { get { throw null; } }
        public long? DeadLetterMessageCount { get { throw null; } }
        public long? ScheduledMessageCount { get { throw null; } }
        public long? TransferDeadLetterMessageCount { get { throw null; } }
        public long? TransferMessageCount { get { throw null; } }
    }
    public partial class MigrationConfigPropertiesCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>
    {
        protected MigrationConfigPropertiesCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.MigrationConfigProperties Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.MigrationConfigProperties>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationConfigPropertiesDeleteOperation : Azure.Operation
    {
        protected MigrationConfigPropertiesDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationConfigurationName : System.IEquatable<Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationConfigurationName(string value) { throw null; }
        public static Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName left, Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName left, Azure.ResourceManager.ServiceBus.Models.MigrationConfigurationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamespaceAuthorizationRuleCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>
    {
        protected NamespaceAuthorizationRuleCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceAuthorizationRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceAuthorizationRuleDeleteOperation : Azure.Operation
    {
        protected NamespaceAuthorizationRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceQueueAuthorizationRuleCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>
    {
        protected NamespaceQueueAuthorizationRuleCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceQueueAuthorizationRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceQueueAuthorizationRuleDeleteOperation : Azure.Operation
    {
        protected NamespaceQueueAuthorizationRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceTopicAuthorizationRuleCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>
    {
        protected NamespaceTopicAuthorizationRuleCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NamespaceTopicAuthorizationRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceTopicAuthorizationRuleDeleteOperation : Azure.Operation
    {
        protected NamespaceTopicAuthorizationRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction left, Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction left, Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSetCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.NetworkRuleSet>
    {
        protected NetworkRuleSetCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.NetworkRuleSet Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NetworkRuleSet>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.NetworkRuleSet>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkRuleSetIPRules
    {
        public NetworkRuleSetIPRules() { }
        public Azure.ResourceManager.ServiceBus.Models.NetworkRuleIPAction? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class NetworkRuleSetVirtualNetworkRules
    {
        public NetworkRuleSetVirtualNetworkRules() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.WritableSubResource Subnet { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkConnectionStatus : System.IEquatable<Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus left, Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus left, Azure.ResourceManager.ServiceBus.Models.PrivateLinkConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.Models.Resource
    {
        internal PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class PrivateLinkResourcesListResult
    {
        internal PrivateLinkResourcesListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ServiceBus.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public enum ProvisioningStateDisasterRecovery
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessFlag : System.IEquatable<Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessFlag(string value) { throw null; }
        public static Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag Disabled { get { throw null; } }
        public static Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag left, Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag left, Azure.ResourceManager.ServiceBus.Models.PublicNetworkAccessFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateAccessKeyOptions
    {
        public RegenerateAccessKeyOptions(Azure.ResourceManager.ServiceBus.Models.KeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.KeyType KeyType { get { throw null; } }
    }
    public enum RoleDisasterRecovery
    {
        Primary = 0,
        PrimaryNotReplicating = 1,
        Secondary = 2,
    }
    public partial class ServiceBusClientAffineProperties
    {
        public ServiceBusClientAffineProperties() { }
        public string ClientId { get { throw null; } set { } }
        public bool? IsDurable { get { throw null; } set { } }
        public bool? IsShared { get { throw null; } set { } }
    }
    public partial class ServiceBusNamespaceCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>
    {
        protected ServiceBusNamespaceCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.ServiceBusNamespace Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusNamespace>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusNamespaceDeleteOperation : Azure.Operation
    {
        protected ServiceBusNamespaceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusNamespaceUpdateOptions : Azure.ResourceManager.Models.TrackedResource
    {
        public ServiceBusNamespaceUpdateOptions(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.EncryptionProperties Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceBus.PrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.ServiceBus.Models.Sku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ServiceBusQueueCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.ServiceBusQueue>
    {
        protected ServiceBusQueueCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.ServiceBusQueue Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusQueue>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusQueueDeleteOperation : Azure.Operation
    {
        protected ServiceBusQueueDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusRuleCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.ServiceBusRule>
    {
        protected ServiceBusRuleCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.ServiceBusRule Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusRule>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusRuleDeleteOperation : Azure.Operation
    {
        protected ServiceBusRuleDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusSubscriptionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>
    {
        protected ServiceBusSubscriptionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.ServiceBusSubscription Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusSubscription>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusSubscriptionDeleteOperation : Azure.Operation
    {
        protected ServiceBusSubscriptionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusTopicCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.ServiceBus.ServiceBusTopic>
    {
        protected ServiceBusTopicCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.ServiceBus.ServiceBusTopic Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.ServiceBus.ServiceBusTopic>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceBusTopicDeleteOperation : Azure.Operation
    {
        protected ServiceBusTopicDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Sku
    {
        public Sku(Azure.ResourceManager.ServiceBus.Models.SkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.SkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceBus.Models.SkuTier? Tier { get { throw null; } set { } }
    }
    public enum SkuName
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public enum SkuTier
    {
        Basic = 0,
        Standard = 1,
        Premium = 2,
    }
    public partial class SqlFilter
    {
        public SqlFilter() { }
        public int? CompatibilityLevel { get { throw null; } set { } }
        public bool? RequiresPreprocessing { get { throw null; } set { } }
        public string SqlExpression { get { throw null; } set { } }
    }
    public partial class SqlRuleAction : Azure.ResourceManager.ServiceBus.Models.FilterAction
    {
        public SqlRuleAction() { }
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
    public partial class UserAssignedIdentityProperties
    {
        public UserAssignedIdentityProperties() { }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
}
