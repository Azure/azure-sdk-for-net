namespace Azure.ResourceManager.MySql
{
    public partial class AdvisorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.AdvisorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.AdvisorResource>, System.Collections.IEnumerable
    {
        protected AdvisorCollection() { }
        public virtual Azure.Response<bool> Exists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.AdvisorResource> Get(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.AdvisorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.AdvisorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.AdvisorResource>> GetAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.AdvisorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.AdvisorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.AdvisorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.AdvisorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorData : Azure.ResourceManager.Models.ResourceData
    {
        public AdvisorData() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class AdvisorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorResource() { }
        public virtual Azure.ResourceManager.MySql.AdvisorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateRecommendedActionSession(Azure.WaitUntil waitUntil, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateRecommendedActionSessionAsync(Azure.WaitUntil waitUntil, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.AdvisorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.AdvisorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.RecommendationActionResource> GetRecommendationAction(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.RecommendationActionResource>> GetRecommendationActionAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.RecommendationActionCollection GetRecommendationActions() { throw null; }
    }
    public partial class ConfigurationCollection : Azure.ResourceManager.ArmCollection
    {
        protected ConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationResource() { }
        public virtual Azure.ResourceManager.MySql.ConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.DatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.DatabaseResource>, System.Collections.IEnumerable
    {
        protected DatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.DatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.DatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.DatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.DatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.DatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.DatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.DatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.DatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.DatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.DatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class DatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseResource() { }
        public virtual Azure.ResourceManager.MySql.DatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.DatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.DatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.DatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.DatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public FirewallRuleData(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.MySql.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MySqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MySql.Models.NameAvailability> ExecuteCheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.NameAvailability>> ExecuteCheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.AdvisorResource GetAdvisorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.ConfigurationResource GetConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.Models.PerformanceTierProperties> GetLocationBasedPerformanceTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.PerformanceTierProperties> GetLocationBasedPerformanceTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.Models.RecommendedActionSessionsOperationStatus> GetLocationBasedRecommendedActionSessionsOperationStatu(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.RecommendedActionSessionsOperationStatus>> GetLocationBasedRecommendedActionSessionsOperationStatuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource GetMySqlPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateLinkResource GetMySqlPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.QueryStatisticResource GetQueryStatisticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.QueryTextResource GetQueryTextResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.RecommendationActionResource GetRecommendationActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.RecommendationActionResource> GetRecommendationActionsByLocationRecommendedActionSessionsOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.RecommendationActionResource> GetRecommendationActionsByLocationRecommendedActionSessionsOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.ServerResource> GetServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.ServerAdministratorResource GetServerAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerResource>> GetServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.ServerKeyResource GetServerKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.ServerResource GetServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.ServerCollection GetServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.ServerResource> GetServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.ServerResource> GetServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource GetServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.VirtualNetworkRuleResource GetVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.WaitStatisticResource GetWaitStatisticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MySqlPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MySqlPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class MySqlPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlPrivateLinkResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MySqlPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlPrivateLinkResourceData() { }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class QueryStatisticCollection : Azure.ResourceManager.ArmCollection
    {
        protected QueryStatisticCollection() { }
        public virtual Azure.Response<bool> Exists(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.QueryStatisticResource> Get(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.QueryStatisticResource> GetAll(Azure.ResourceManager.MySql.Models.TopQueryStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.QueryStatisticResource> GetAllAsync(Azure.ResourceManager.MySql.Models.TopQueryStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.QueryStatisticResource>> GetAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueryStatisticData : Azure.ResourceManager.Models.ResourceData
    {
        public QueryStatisticData() { }
        public string AggregationFunction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DatabaseNames { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string MetricDisplayName { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public double? MetricValue { get { throw null; } set { } }
        public string MetricValueUnit { get { throw null; } set { } }
        public long? QueryExecutionCount { get { throw null; } set { } }
        public string QueryId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class QueryStatisticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QueryStatisticResource() { }
        public virtual Azure.ResourceManager.MySql.QueryStatisticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string queryStatisticId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.QueryStatisticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.QueryStatisticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueryTextCollection : Azure.ResourceManager.ArmCollection
    {
        protected QueryTextCollection() { }
        public virtual Azure.Response<bool> Exists(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.QueryTextResource> Get(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.QueryTextResource> GetAll(System.Collections.Generic.IEnumerable<string> queryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.QueryTextResource> GetAllAsync(System.Collections.Generic.IEnumerable<string> queryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.QueryTextResource>> GetAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueryTextData : Azure.ResourceManager.Models.ResourceData
    {
        public QueryTextData() { }
        public string QueryId { get { throw null; } set { } }
        public string QueryText { get { throw null; } set { } }
    }
    public partial class QueryTextResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QueryTextResource() { }
        public virtual Azure.ResourceManager.MySql.QueryTextData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string queryId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.QueryTextResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.QueryTextResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecommendationActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.RecommendationActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.RecommendationActionResource>, System.Collections.IEnumerable
    {
        protected RecommendationActionCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.RecommendationActionResource> Get(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.RecommendationActionResource> GetAll(string sessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.RecommendationActionResource> GetAllAsync(string sessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.RecommendationActionResource>> GetAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.RecommendationActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.RecommendationActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.RecommendationActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.RecommendationActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecommendationActionData : Azure.ResourceManager.Models.ResourceData
    {
        public RecommendationActionData() { }
        public int? ActionId { get { throw null; } set { } }
        public string AdvisorName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Details { get { throw null; } }
        public System.DateTimeOffset? ExpirationOn { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
        public string RecommendationType { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
    }
    public partial class RecommendationActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecommendationActionResource() { }
        public virtual Azure.ResourceManager.MySql.RecommendationActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName, string recommendedActionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.RecommendationActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.RecommendationActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerAdministratorResource() { }
        public virtual Azure.ResourceManager.MySql.ServerAdministratorResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ServerAdministratorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ServerAdministratorResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerAdministratorResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerAdministratorResourceData() { }
        public Azure.ResourceManager.MySql.Models.AdministratorType? AdministratorType { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public System.Guid? Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.ServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.ServerResource>, System.Collections.IEnumerable
    {
        protected ServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.Models.ServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.Models.ServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.ServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.ServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.ServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.ServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.ServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.ServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.ServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.ServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string ByokEnforcement { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.InfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public string MasterServerId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.Models.ServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.SslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.ServerState? UserVisibleState { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.ServerKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.ServerKeyResource>, System.Collections.IEnumerable
    {
        protected ServerKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.MySql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.MySql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.ServerKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.ServerKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.ServerKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.ServerKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.ServerKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.ServerKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerKeyData() { }
        public System.DateTimeOffset? CreationOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ServerKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerKeyResource() { }
        public virtual Azure.ResourceManager.MySql.ServerKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerResource() { }
        public virtual Azure.ResourceManager.MySql.ServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.AdvisorResource> GetAdvisor(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.AdvisorResource>> GetAdvisorAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.AdvisorCollection GetAdvisors() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.ConfigurationResource> GetByServerConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.ConfigurationResource> GetByServerConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ConfigurationResource> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ConfigurationResource>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.ConfigurationCollection GetConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.Models.LogFile> GetLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.LogFile> GetLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetMySqlPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetMySqlPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionCollection GetMySqlPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetMySqlPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetMySqlPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateLinkResourceCollection GetMySqlPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.QueryStatisticResource> GetQueryStatistic(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.QueryStatisticResource>> GetQueryStatisticAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.QueryStatisticCollection GetQueryStatistics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.QueryTextResource> GetQueryText(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.QueryTextResource>> GetQueryTextAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.QueryTextCollection GetQueryTexts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.Models.RecoverableServerResource> GetRecoverableServer(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.RecoverableServerResource>> GetRecoverableServerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.ServerAdministratorResource GetServerAdministratorResource() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.Models.PerformanceTierProperties> GetServerBasedPerformanceTiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.PerformanceTierProperties> GetServerBasedPerformanceTiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerKeyResource> GetServerKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerKeyResource>> GetServerKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.ServerKeyCollection GetServerKeys() { throw null; }
        public virtual Azure.ResourceManager.MySql.ServerSecurityAlertPolicyCollection GetServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> GetServerSecurityAlertPolicy(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>> GetServerSecurityAlertPolicyAsync(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.Models.ConfigurationListResult> GetUpdateConfigurationsServerParameter(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.ConfigurationListResult value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.Models.ConfigurationListResult>> GetUpdateConfigurationsServerParameterAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.ConfigurationListResult value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> GetVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>> GetVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.VirtualNetworkRuleCollection GetVirtualNetworkRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.WaitStatisticResource> GetWaitStatistic(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.WaitStatisticResource>> GetWaitStatisticAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.WaitStatisticCollection GetWaitStatistics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResult> ResetQueryPerformanceInsightData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResult>> ResetQueryPerformanceInsightDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartMySqlServer(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartMySqlServerAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StopMySqlServer(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopMySqlServerAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UpgradeMySqlServer(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.ServerUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeMySqlServerAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.ServerUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected ServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.MySql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.MySql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerSecurityAlertPolicyData() { }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.ServerSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.MySql.ServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.ServerSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.MySql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.MySql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public VirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState? State { get { throw null; } }
        public string VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.MySql.VirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.VirtualNetworkRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.VirtualNetworkRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.VirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WaitStatisticCollection : Azure.ResourceManager.ArmCollection
    {
        protected WaitStatisticCollection() { }
        public virtual Azure.Response<bool> Exists(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.WaitStatisticResource> Get(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.WaitStatisticResource> GetAll(Azure.ResourceManager.MySql.Models.WaitStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.WaitStatisticResource> GetAllAsync(Azure.ResourceManager.MySql.Models.WaitStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.WaitStatisticResource>> GetAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WaitStatisticData : Azure.ResourceManager.Models.ResourceData
    {
        public WaitStatisticData() { }
        public long? Count { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string EventName { get { throw null; } set { } }
        public string EventTypeName { get { throw null; } set { } }
        public long? QueryId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public double? TotalTimeInMs { get { throw null; } set { } }
        public long? UserId { get { throw null; } set { } }
    }
    public partial class WaitStatisticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WaitStatisticResource() { }
        public virtual Azure.ResourceManager.MySql.WaitStatisticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string waitStatisticsId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.WaitStatisticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.WaitStatisticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.FlexibleServers
{
    public partial class ConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>, System.Collections.IEnumerable
    {
        protected ConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart? IsConfigPendingRestart { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig? IsDynamicConfig { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly? IsReadOnly { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource? Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.ConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.ConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>, System.Collections.IEnumerable
    {
        protected DatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class DatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.DatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public FirewallRuleData(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } set { } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FlexibleServersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.NameAvailability> ExecuteCheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.NameAvailability>> ExecuteCheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.VirtualNetworkSubnetUsageResult> ExecuteCheckVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.VirtualNetworkSubnetUsageParameter virtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.VirtualNetworkSubnetUsageResult>> ExecuteCheckVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.VirtualNetworkSubnetUsageParameter virtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.GetPrivateDnsZoneSuffixResponse> ExecuteGetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.GetPrivateDnsZoneSuffixResponse>> ExecuteGetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource GetConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.Models.CapabilityProperties> GetLocationBasedCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.Models.CapabilityProperties> GetLocationBasedCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> GetServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> GetServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource GetServerBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.ServerResource GetServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.ServerCollection GetServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> GetServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> GetServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource>, System.Collections.IEnumerable
    {
        protected ServerBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerBackupData() { }
        public string BackupType { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class ServerBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerBackupResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.ServerBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>, System.Collections.IEnumerable
    {
        protected ServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.FlexibleServers.ServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.FlexibleServers.ServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.Backup Backup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.DataEncryption DataEncryption { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.Network Network { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole? ReplicationRole { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSku Sku { get { throw null; } set { } }
        public string SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState? State { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.Storage Storage { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.ServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationListResult> BatchUpdateConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationListForBatchUpdate configurationListForBatchUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationListResult>> BatchUpdateConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationListForBatchUpdate configurationListForBatchUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource> GetConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationResource>> GetConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.ConfigurationCollection GetConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource> GetServerBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerBackupResource>> GetServerBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.ServerBackupCollection GetServerBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerRestartParameter serverRestartParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerRestartParameter serverRestartParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.ServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.ServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    public partial class Backup
    {
        public Backup() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum? GeoRedundantBackup { get { throw null; } set { } }
    }
    public partial class CapabilityProperties
    {
        internal CapabilityProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedGeoBackupRegions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAMode { get { throw null; } }
        public string Zone { get { throw null; } }
    }
    public partial class ConfigurationForBatchUpdate
    {
        public ConfigurationForBatchUpdate() { }
        public string Name { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ConfigurationListForBatchUpdate
    {
        public ConfigurationListForBatchUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationForBatchUpdate> Value { get { throw null; } }
    }
    public partial class ConfigurationListResult
    {
        internal ConfigurationListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.ConfigurationData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationSource : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationSource(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource SystemDefault { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource UserOverride { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource left, Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource left, Azure.ResourceManager.MySql.FlexibleServers.Models.ConfigurationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode GeoRestore { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode Replica { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataEncryption
    {
        public DataEncryption() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.DataEncryptionType? EncryptionType { get { throw null; } set { } }
        public System.Uri GeoBackupKeyUri { get { throw null; } set { } }
        public string GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentityId { get { throw null; } set { } }
    }
    public enum DataEncryptionType
    {
        AzureKeyVault = 0,
        SystemManaged = 1,
    }
    public partial class DelegatedSubnetUsage
    {
        internal DelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableStatusEnum : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum left, Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum left, Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FlexibleServersSku
    {
        public FlexibleServersSku(string name, Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FlexibleServersSkuTier : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FlexibleServersSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier Burstable { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier left, Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier left, Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GetPrivateDnsZoneSuffixResponse
    {
        internal GetPrivateDnsZoneSuffixResponse() { }
        public string PrivateDnsZoneSuffix { get { throw null; } }
    }
    public partial class HighAvailability
    {
        public HighAvailability() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HighAvailabilityMode : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode SameZone { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HighAvailabilityState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HighAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState CreatingStandby { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState Healthy { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState RemovingStandby { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState left, Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState left, Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Identity
    {
        public Identity() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType? ManagedServiceIdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsConfigPendingRestart : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsConfigPendingRestart(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart left, Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart left, Azure.ResourceManager.MySql.FlexibleServers.Models.IsConfigPendingRestart right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsDynamicConfig : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsDynamicConfig(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig left, Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig left, Azure.ResourceManager.MySql.FlexibleServers.Models.IsDynamicConfig right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IsReadOnly : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IsReadOnly(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly left, Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly left, Azure.ResourceManager.MySql.FlexibleServers.Models.IsReadOnly right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceWindow
    {
        public MaintenanceWindow() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType left, Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType left, Azure.ResourceManager.MySql.FlexibleServers.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class Network
    {
        public Network() { }
        public string DelegatedSubnetResourceId { get { throw null; } set { } }
        public string PrivateDnsZoneResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum? PublicNetworkAccess { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationRole : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole None { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole Replica { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole left, Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole left, Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerEditionCapability
    {
        internal ServerEditionCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.StorageEditionCapability> SupportedStorageEditions { get { throw null; } }
    }
    public partial class ServerPatch
    {
        public ServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.Backup Backup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.DataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.FlexibleServersSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.Storage Storage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ServerRestartParameter
    {
        public ServerRestartParameter() { }
        public int? MaxFailoverSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum? RestartWithFailover { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState Starting { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState left, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState left, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerVersion : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion Eight021 { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion Five7 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion left, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion left, Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerVersionCapability
    {
        internal ServerVersionCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapability> SupportedSkus { get { throw null; } }
    }
    public partial class SkuCapability
    {
        internal SkuCapability() { }
        public string Name { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVCoreMB { get { throw null; } }
        public long? VCores { get { throw null; } }
    }
    public partial class Storage
    {
        public Storage() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.EnableStatusEnum? AutoGrow { get { throw null; } set { } }
        public int? Iops { get { throw null; } set { } }
        public int? StorageSizeGB { get { throw null; } set { } }
        public string StorageSku { get { throw null; } }
    }
    public partial class StorageEditionCapability
    {
        internal StorageEditionCapability() { }
        public long? MaxBackupRetentionDays { get { throw null; } }
        public long? MaxStorageSize { get { throw null; } }
        public long? MinBackupRetentionDays { get { throw null; } }
        public long? MinStorageSize { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class VirtualNetworkSubnetUsageParameter
    {
        public VirtualNetworkSubnetUsageParameter() { }
        public string VirtualNetworkResourceId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkSubnetUsageResult
    {
        internal VirtualNetworkSubnetUsageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.DelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
    }
}
namespace Azure.ResourceManager.MySql.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministratorType : System.IEquatable<Azure.ResourceManager.MySql.Models.AdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.AdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.AdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.AdministratorType left, Azure.ResourceManager.MySql.Models.AdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.AdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.AdministratorType left, Azure.ResourceManager.MySql.Models.AdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationListResult
    {
        public ConfigurationListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MySql.ConfigurationData> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoRedundantBackup : System.IEquatable<Azure.ResourceManager.MySql.Models.GeoRedundantBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoRedundantBackup(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.GeoRedundantBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.GeoRedundantBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.GeoRedundantBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.GeoRedundantBackup left, Azure.ResourceManager.MySql.Models.GeoRedundantBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.GeoRedundantBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.GeoRedundantBackup left, Azure.ResourceManager.MySql.Models.GeoRedundantBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureEncryption : System.IEquatable<Azure.ResourceManager.MySql.Models.InfrastructureEncryption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureEncryption(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.InfrastructureEncryption Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.InfrastructureEncryption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.InfrastructureEncryption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.InfrastructureEncryption left, Azure.ResourceManager.MySql.Models.InfrastructureEncryption right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.InfrastructureEncryption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.InfrastructureEncryption left, Azure.ResourceManager.MySql.Models.InfrastructureEncryption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogFile : Azure.ResourceManager.Models.ResourceData
    {
        public LogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public long? SizeInKB { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MinimalTlsVersionEnum : System.IEquatable<Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MinimalTlsVersionEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum TLS10 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum TLS11 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum TLS12 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum TLSEnforcementDisabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum left, Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum left, Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlPrivateEndpointConnectionPatch
    {
        public MySqlPrivateEndpointConnectionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MySqlPrivateLinkResourceProperties
    {
        internal MySqlPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
    }
    public partial class MySqlPrivateLinkServiceConnectionStateProperty
    {
        public MySqlPrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class MySqlSku
    {
        public MySqlSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlSkuTier : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlSkuTier left, Azure.ResourceManager.MySql.Models.MySqlSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlSkuTier left, Azure.ResourceManager.MySql.Models.MySqlSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NameAvailability
    {
        internal NameAvailability() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class NameAvailabilityContent
    {
        public NameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class PerformanceTierProperties
    {
        internal PerformanceTierProperties() { }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxLargeStorageMB { get { throw null; } }
        public int? MaxStorageMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinLargeStorageMB { get { throw null; } }
        public int? MinStorageMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.Models.PerformanceTierServiceLevelObjectives> ServiceLevelObjectives { get { throw null; } }
    }
    public partial class PerformanceTierServiceLevelObjectives
    {
        internal PerformanceTierServiceLevelObjectives() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxStorageMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinStorageMB { get { throw null; } }
        public int? VCore { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState Approving { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState Rejecting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState left, Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState left, Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStateActionsRequire : System.IEquatable<Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStateActionsRequire(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire left, Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire left, Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStateStatus : System.IEquatable<Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessEnum : System.IEquatable<Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum left, Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum left, Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryPerformanceInsightResetDataResult
    {
        internal QueryPerformanceInsightResetDataResult() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryPerformanceInsightResetDataResultState : System.IEquatable<Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryPerformanceInsightResetDataResultState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState left, Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState left, Azure.ResourceManager.MySql.Models.QueryPerformanceInsightResetDataResultState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendedActionSessionsOperationStatus
    {
        internal RecommendedActionSessionsOperationStatus() { }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class RecoverableServerResource : Azure.ResourceManager.Models.ResourceData
    {
        public RecoverableServerResource() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public string LastAvailableBackupDateTime { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
        public int? VCore { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName left, Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName left, Azure.ResourceManager.MySql.Models.SecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerCreateOrUpdateContent
    {
        public ServerCreateOrUpdateContent(Azure.ResourceManager.MySql.Models.ServerPropertiesForCreate properties, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.ServerPropertiesForCreate Properties { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerKeyType : System.IEquatable<Azure.ResourceManager.MySql.Models.ServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.ServerKeyType AzureKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.ServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.ServerKeyType left, Azure.ResourceManager.MySql.Models.ServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.ServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.ServerKeyType left, Azure.ResourceManager.MySql.Models.ServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerPatch
    {
        public ServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.SslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerPrivateEndpointConnection
    {
        internal ServerPrivateEndpointConnection() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.ServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class ServerPrivateEndpointConnectionProperties
    {
        internal ServerPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.ServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.PrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class ServerPrivateLinkServiceConnectionStateProperty
    {
        internal ServerPrivateLinkServiceConnectionStateProperty() { }
        public Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateActionsRequire? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.PrivateLinkServiceConnectionStateStatus Status { get { throw null; } }
    }
    public partial class ServerPropertiesForCreate
    {
        public ServerPropertiesForCreate() { }
        public Azure.ResourceManager.MySql.Models.InfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.PublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.SslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.StorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.ServerVersion? Version { get { throw null; } set { } }
    }
    public partial class ServerPropertiesForDefaultCreate : Azure.ResourceManager.MySql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForDefaultCreate(string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
    }
    public partial class ServerPropertiesForGeoRestore : Azure.ResourceManager.MySql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForGeoRestore(string sourceServerId) { }
        public string SourceServerId { get { throw null; } }
    }
    public partial class ServerPropertiesForReplica : Azure.ResourceManager.MySql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForReplica(string sourceServerId) { }
        public string SourceServerId { get { throw null; } }
    }
    public partial class ServerPropertiesForRestore : Azure.ResourceManager.MySql.Models.ServerPropertiesForCreate
    {
        public ServerPropertiesForRestore(string sourceServerId, System.DateTimeOffset restorePointInOn) { }
        public System.DateTimeOffset RestorePointInOn { get { throw null; } }
        public string SourceServerId { get { throw null; } }
    }
    public enum ServerSecurityAlertPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerState : System.IEquatable<Azure.ResourceManager.MySql.Models.ServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.ServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.ServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.ServerState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.ServerState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.ServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.ServerState left, Azure.ResourceManager.MySql.Models.ServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.ServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.ServerState left, Azure.ResourceManager.MySql.Models.ServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerUpgradeContent
    {
        public ServerUpgradeContent() { }
        public string TargetServerVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerVersion : System.IEquatable<Azure.ResourceManager.MySql.Models.ServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.ServerVersion Eight0 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.ServerVersion Five6 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.ServerVersion Five7 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.ServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.ServerVersion left, Azure.ResourceManager.MySql.Models.ServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.ServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.ServerVersion left, Azure.ResourceManager.MySql.Models.ServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SslEnforcementEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAutogrow : System.IEquatable<Azure.ResourceManager.MySql.Models.StorageAutogrow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAutogrow(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.StorageAutogrow Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.StorageAutogrow Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.StorageAutogrow other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.StorageAutogrow left, Azure.ResourceManager.MySql.Models.StorageAutogrow right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.StorageAutogrow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.StorageAutogrow left, Azure.ResourceManager.MySql.Models.StorageAutogrow right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageProfile
    {
        public StorageProfile() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.GeoRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.StorageAutogrow? StorageAutogrow { get { throw null; } set { } }
        public int? StorageMB { get { throw null; } set { } }
    }
    public partial class TopQueryStatisticsInput
    {
        public TopQueryStatisticsInput(int numberOfTopQueries, string aggregationFunction, string observedMetric, System.DateTimeOffset observationStartOn, System.DateTimeOffset observationEndOn, string aggregationWindow) { }
        public string AggregationFunction { get { throw null; } }
        public string AggregationWindow { get { throw null; } }
        public int NumberOfTopQueries { get { throw null; } }
        public System.DateTimeOffset ObservationEndOn { get { throw null; } }
        public System.DateTimeOffset ObservationStartOn { get { throw null; } }
        public string ObservedMetric { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualNetworkRuleState : System.IEquatable<Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState Initializing { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState InProgress { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState left, Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState left, Azure.ResourceManager.MySql.Models.VirtualNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WaitStatisticsInput
    {
        public WaitStatisticsInput(System.DateTimeOffset observationStartOn, System.DateTimeOffset observationEndOn, string aggregationWindow) { }
        public string AggregationWindow { get { throw null; } }
        public System.DateTimeOffset ObservationEndOn { get { throw null; } }
        public System.DateTimeOffset ObservationStartOn { get { throw null; } }
    }
}
