namespace Azure.ResourceManager.MySql
{
    public partial class MySqlAdvisorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>, System.Collections.IEnumerable
    {
        protected MySqlAdvisorCollection() { }
        public virtual Azure.Response<bool> Exists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource> Get(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlAdvisorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlAdvisorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource>> GetAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlAdvisorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlAdvisorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlAdvisorData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlAdvisorData() { }
        public System.BinaryData Properties { get { throw null; } set { } }
    }
    public partial class MySqlAdvisorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlAdvisorResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlAdvisorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateRecommendedActionSession(Azure.WaitUntil waitUntil, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateRecommendedActionSessionAsync(Azure.WaitUntil waitUntil, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> GetMySqlRecommendationAction(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>> GetMySqlRecommendationActionAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlRecommendationActionCollection GetMySqlRecommendationActions() { throw null; }
    }
    public partial class MySqlConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>, System.Collections.IEnumerable
    {
        protected MySqlConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class MySqlConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlConfigurationResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>, System.Collections.IEnumerable
    {
        protected MySqlDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class MySqlDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlDatabaseResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MySqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult> CheckMySqlNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>> CheckMySqlNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetLocationBasedPerformanceTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetLocationBasedPerformanceTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlAdvisorResource GetMySqlAdvisorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlConfigurationResource GetMySqlConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlDatabaseResource GetMySqlDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlFirewallRuleResource GetMySqlFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource GetMySqlPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateLinkResource GetMySqlPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryStatisticResource GetMySqlQueryStatisticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryTextResource GetMySqlQueryTextResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlRecommendationActionResource GetMySqlRecommendationActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerAdministratorResource GetMySqlServerAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> GetMySqlServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerKeyResource GetMySqlServerKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerResource GetMySqlServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerCollection GetMySqlServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource GetMySqlServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource GetMySqlVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlWaitStatisticResource GetMySqlWaitStatisticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MySqlFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected MySqlFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public partial class MySqlFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFirewallRuleResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MySqlQueryStatisticCollection : Azure.ResourceManager.ArmCollection
    {
        protected MySqlQueryStatisticCollection() { }
        public virtual Azure.Response<bool> Exists(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> Get(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> GetAll(Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> GetAllAsync(Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource>> GetAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlQueryStatisticData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlQueryStatisticData() { }
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
    public partial class MySqlQueryStatisticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlQueryStatisticResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlQueryStatisticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string queryStatisticId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlQueryTextCollection : Azure.ResourceManager.ArmCollection
    {
        protected MySqlQueryTextCollection() { }
        public virtual Azure.Response<bool> Exists(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource> Get(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlQueryTextResource> GetAll(System.Collections.Generic.IEnumerable<string> queryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlQueryTextResource> GetAllAsync(System.Collections.Generic.IEnumerable<string> queryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource>> GetAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlQueryTextData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlQueryTextData() { }
        public string QueryId { get { throw null; } set { } }
        public string QueryText { get { throw null; } set { } }
    }
    public partial class MySqlQueryTextResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlQueryTextResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlQueryTextData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string queryId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlRecommendationActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>, System.Collections.IEnumerable
    {
        protected MySqlRecommendationActionCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> Get(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> GetAll(string sessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> GetAllAsync(string sessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>> GetAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlRecommendationActionData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlRecommendationActionData() { }
        public int? ActionId { get { throw null; } set { } }
        public string AdvisorName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Details { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
        public string RecommendationType { get { throw null; } set { } }
        public System.Guid? SessionId { get { throw null; } set { } }
    }
    public partial class MySqlRecommendationActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlRecommendationActionResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlRecommendationActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName, string recommendedActionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlServerAdministratorData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlServerAdministratorData() { }
        public Azure.ResourceManager.MySql.Models.MySqlAdministratorType? AdministratorType { get { throw null; } set { } }
        public string LoginAccountName { get { throw null; } set { } }
        public System.Guid? SecureId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class MySqlServerAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerAdministratorResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>, System.Collections.IEnumerable
    {
        protected MySqlServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MySqlServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string ByokEnforcement { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MasterServerId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerState? UserVisibleState { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerVersion? Version { get { throw null; } set { } }
    }
    public partial class MySqlServerKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>, System.Collections.IEnumerable
    {
        protected MySqlServerKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlServerKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlServerKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlServerKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlServerKeyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerKeyType? ServerKeyType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class MySqlServerKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerKeyResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.Models.MySqlLogFile> GetLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.MySqlLogFile> GetLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource> GetMySqlAdvisor(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource>> GetMySqlAdvisorAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlAdvisorCollection GetMySqlAdvisors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource> GetMySqlConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource>> GetMySqlConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlConfigurationCollection GetMySqlConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource> GetMySqlDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource>> GetMySqlDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlDatabaseCollection GetMySqlDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> GetMySqlFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> GetMySqlFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlFirewallRuleCollection GetMySqlFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetMySqlPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetMySqlPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionCollection GetMySqlPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetMySqlPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetMySqlPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateLinkResourceCollection GetMySqlPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> GetMySqlQueryStatistic(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource>> GetMySqlQueryStatisticAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlQueryStatisticCollection GetMySqlQueryStatistics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource> GetMySqlQueryText(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource>> GetMySqlQueryTextAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlQueryTextCollection GetMySqlQueryTexts() { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerAdministratorResource GetMySqlServerAdministrator() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource> GetMySqlServerKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource>> GetMySqlServerKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerKeyCollection GetMySqlServerKeys() { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyCollection GetMySqlServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> GetMySqlServerSecurityAlertPolicy(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> GetMySqlServerSecurityAlertPolicyAsync(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> GetMySqlVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> GetMySqlVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleCollection GetMySqlVirtualNetworkRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> GetMySqlWaitStatistic(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource>> GetMySqlWaitStatisticAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlWaitStatisticCollection GetMySqlWaitStatistics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData> GetRecoverableServer(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>> GetRecoverableServerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetServerBasedPerformanceTiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetServerBasedPerformanceTiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult> ResetQueryPerformanceInsightData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>> ResetQueryPerformanceInsightDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.Models.MySqlConfigurations> UpdateConfigurations(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlConfigurations value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.Models.MySqlConfigurations>> UpdateConfigurationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlConfigurations value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected MySqlServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlServerSecurityAlertPolicyData() { }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public bool? SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class MySqlServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlVirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected MySqlVirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlVirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlVirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState? State { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetId { get { throw null; } set { } }
    }
    public partial class MySqlVirtualNetworkRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlVirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlWaitStatisticCollection : Azure.ResourceManager.ArmCollection
    {
        protected MySqlWaitStatisticCollection() { }
        public virtual Azure.Response<bool> Exists(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> Get(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> GetAll(Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> GetAllAsync(Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource>> GetAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlWaitStatisticData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlWaitStatisticData() { }
        public long? Count { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string EventName { get { throw null; } set { } }
        public string EventTypeName { get { throw null; } set { } }
        public long? QueryId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public double? TotalTimeInMinutes { get { throw null; } set { } }
        public long? UserId { get { throw null; } set { } }
    }
    public partial class MySqlWaitStatisticResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlWaitStatisticResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlWaitStatisticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string waitStatisticsId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.FlexibleServers
{
    public static partial class FlexibleServersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult> CheckMySqlFlexibleServerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>> CheckMySqlFlexibleServerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteCheckVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter mySqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteCheckVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter mySqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse> ExecuteGetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>> ExecuteGetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties> GetLocationBasedCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties> GetLocationBasedCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetMySqlFlexibleServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource GetMySqlFlexibleServerBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource GetMySqlFlexibleServerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource GetMySqlFlexibleServerDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource GetMySqlFlexibleServerFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource GetMySqlFlexibleServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerCollection GetMySqlFlexibleServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerBackupData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlFlexibleServerBackupData() { }
        public string BackupType { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerBackupResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlFlexibleServerConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState? IsConfigPendingRestart { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState? IsDynamicConfig { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState? IsReadOnly { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource? Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerConfigurationResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MySqlFlexibleServerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState? State { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage Storage { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion? Version { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlFlexibleServerDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerDatabaseResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlFlexibleServerFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerFirewallRuleResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> GetMySqlFlexibleServerBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> GetMySqlFlexibleServerBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupCollection GetMySqlFlexibleServerBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetMySqlFlexibleServerConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> GetMySqlFlexibleServerConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationCollection GetMySqlFlexibleServerConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> GetMySqlFlexibleServerDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> GetMySqlFlexibleServerDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseCollection GetMySqlFlexibleServerDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> GetMySqlFlexibleServerFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> GetMySqlFlexibleServerFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleCollection GetMySqlFlexibleServerFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter mySqlFlexibleServerRestartParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter mySqlFlexibleServerRestartParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations> UpdateConfigurations(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate mySqlFlexibleServerConfigurationListForBatchUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>> UpdateConfigurationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate mySqlFlexibleServerConfigurationListForBatchUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    public static partial class ArmFlexibleServersModelFactory
    {
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData MySqlFlexibleServerBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string backupType = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string source = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties MySqlFlexibleServerBackupProperties(int? backupRetentionDays = default(int?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? geoRedundantBackup = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties MySqlFlexibleServerCapabilityProperties(string zone = null, System.Collections.Generic.IEnumerable<string> supportedHAMode = null, System.Collections.Generic.IEnumerable<string> supportedGeoBackupRegions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability> supportedFlexibleServerEditions = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData MySqlFlexibleServerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, string dataType = null, string allowedValues = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource? source = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState? isReadOnly = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState? isConfigPendingRestart = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState? isDynamicConfig = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations MySqlFlexibleServerConfigurations(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData> values = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData MySqlFlexibleServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku sku = null, string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion? version = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion?), string availabilityZone = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode? createMode = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode?), Azure.Core.ResourceIdentifier sourceServerResourceId = null, System.DateTimeOffset? restorePointInTime = default(System.DateTimeOffset?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole? replicationRole = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole?), int? replicaCapacity = default(int?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption dataEncryption = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState? state = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState?), string fullyQualifiedDomainName = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage storage = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties backup = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability highAvailability = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork network = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow maintenanceWindow = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData MySqlFlexibleServerDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage MySqlFlexibleServerDelegatedSubnetUsage(string subnetName = null, long? usage = default(long?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability MySqlFlexibleServerEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability> supportedServerVersions = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData MySqlFlexibleServerFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability MySqlFlexibleServerHighAvailability(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode? mode = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState? state = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState?), string standbyAvailabilityZone = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult MySqlFlexibleServerNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string reason = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork MySqlFlexibleServerNetwork(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? publicNetworkAccess = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum?), Azure.Core.ResourceIdentifier delegatedSubnetResourceId = null, Azure.Core.ResourceIdentifier privateDnsZoneResourceId = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse MySqlFlexibleServerPrivateDnsZoneSuffixResponse(string privateDnsZoneSuffix = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability MySqlFlexibleServerServerVersionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability> supportedSkus = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability MySqlFlexibleServerSkuCapability(string name = null, long? vCores = default(long?), long? supportedIops = default(long?), long? supportedMemoryPerVCoreInMB = default(long?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage MySqlFlexibleServerStorage(int? storageSizeInGB = default(int?), int? iops = default(int?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? autoGrow = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum?), string storageSku = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability MySqlFlexibleServerStorageEditionCapability(string name = null, long? minStorageSize = default(long?), long? maxStorageSize = default(long?), long? minBackupRetentionDays = default(long?), long? maxBackupRetentionDays = default(long?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult MySqlFlexibleServerVirtualNetworkSubnetUsageResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage> delegatedSubnetsUsage = null) { throw null; }
    }
    public partial class MySqlFlexibleServerBackupProperties
    {
        public MySqlFlexibleServerBackupProperties() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? GeoRedundantBackup { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerCapabilityProperties
    {
        internal MySqlFlexibleServerCapabilityProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedGeoBackupRegions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAMode { get { throw null; } }
        public string Zone { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigDynamicState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigDynamicState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigPendingRestartState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigPendingRestartState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigReadOnlyState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigReadOnlyState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationForBatchUpdate
    {
        public MySqlFlexibleServerConfigurationForBatchUpdate() { }
        public string Name { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerConfigurationListForBatchUpdate
    {
        public MySqlFlexibleServerConfigurationListForBatchUpdate() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate> Values { get { throw null; } }
    }
    public partial class MySqlFlexibleServerConfigurations
    {
        internal MySqlFlexibleServerConfigurations() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigurationSource : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigurationSource(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource SystemDefault { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource UserOverride { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerCreateMode : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode GeoRestore { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode Replica { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerDataEncryption
    {
        public MySqlFlexibleServerDataEncryption() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryptionType? EncryptionType { get { throw null; } set { } }
        public System.Uri GeoBackupKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
    }
    public enum MySqlFlexibleServerDataEncryptionType
    {
        AzureKeyVault = 0,
        SystemManaged = 1,
    }
    public partial class MySqlFlexibleServerDelegatedSubnetUsage
    {
        internal MySqlFlexibleServerDelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
    }
    public partial class MySqlFlexibleServerEditionCapability
    {
        internal MySqlFlexibleServerEditionCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerEnableStatusEnum : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerEnableStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerHighAvailability
    {
        public MySqlFlexibleServerHighAvailability() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerHighAvailabilityMode : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerHighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode SameZone { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerHighAvailabilityState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerHighAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState CreatingStandby { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState Healthy { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState RemovingStandby { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerMaintenanceWindow
    {
        public MySqlFlexibleServerMaintenanceWindow() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerNameAvailabilityContent
    {
        public MySqlFlexibleServerNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerNameAvailabilityResult
    {
        internal MySqlFlexibleServerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class MySqlFlexibleServerNetwork
    {
        public MySqlFlexibleServerNetwork() { }
        public Azure.Core.ResourceIdentifier DelegatedSubnetResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateDnsZoneResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? PublicNetworkAccess { get { throw null; } }
    }
    public partial class MySqlFlexibleServerPatch
    {
        public MySqlFlexibleServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage Storage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class MySqlFlexibleServerPrivateDnsZoneSuffixResponse
    {
        internal MySqlFlexibleServerPrivateDnsZoneSuffixResponse() { }
        public string PrivateDnsZoneSuffix { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerReplicationRole : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole None { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole Replica { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerRestartParameter
    {
        public MySqlFlexibleServerRestartParameter() { }
        public int? MaxFailoverSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? RestartWithFailover { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerServerVersionCapability
    {
        internal MySqlFlexibleServerServerVersionCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability> SupportedSkus { get { throw null; } }
    }
    public partial class MySqlFlexibleServerSku
    {
        public MySqlFlexibleServerSku(string name, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier Tier { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerSkuCapability
    {
        internal MySqlFlexibleServerSkuCapability() { }
        public string Name { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVCoreInMB { get { throw null; } }
        public long? VCores { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerSkuTier : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier Burstable { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Starting { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerStorage
    {
        public MySqlFlexibleServerStorage() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? AutoGrow { get { throw null; } set { } }
        public int? Iops { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public string StorageSku { get { throw null; } }
    }
    public partial class MySqlFlexibleServerStorageEditionCapability
    {
        internal MySqlFlexibleServerStorageEditionCapability() { }
        public long? MaxBackupRetentionDays { get { throw null; } }
        public long? MaxStorageSize { get { throw null; } }
        public long? MinBackupRetentionDays { get { throw null; } }
        public long? MinStorageSize { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerVersion : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion Ver5_7 { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion Ver8_0_21 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerVirtualNetworkSubnetUsageParameter
    {
        public MySqlFlexibleServerVirtualNetworkSubnetUsageParameter() { }
        public Azure.Core.ResourceIdentifier VirtualNetworkResourceId { get { throw null; } set { } }
    }
    public partial class MySqlFlexibleServerVirtualNetworkSubnetUsageResult
    {
        internal MySqlFlexibleServerVirtualNetworkSubnetUsageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
    }
}
namespace Azure.ResourceManager.MySql.Models
{
    public static partial class ArmMySqlModelFactory
    {
        public static Azure.ResourceManager.MySql.MySqlAdvisorData MySqlAdvisorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlConfigurationData MySqlConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, string dataType = null, string allowedValues = null, string source = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlDatabaseData MySqlDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlFirewallRuleData MySqlFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlLogFile MySqlLogFile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? sizeInKB = default(long?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string logFileType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult MySqlNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string reason = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPerformanceTier MySqlPerformanceTier(string id = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minLargeStorageInMB = default(int?), int? maxLargeStorageInMB = default(int?), int? minStorageInMB = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives> serviceLevelObjectives = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives MySqlPerformanceTierServiceLevelObjectives(string id = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minStorageInMB = default(int?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData MySqlPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData MySqlPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties MySqlPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty MySqlPrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult MySqlQueryPerformanceInsightResetDataResult(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState? status = default(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState?), string message = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryStatisticData MySqlQueryStatisticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string queryId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string aggregationFunction = null, System.Collections.Generic.IEnumerable<string> databaseNames = null, long? queryExecutionCount = default(long?), string metricName = null, string metricDisplayName = null, double? metricValue = default(double?), string metricValueUnit = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryTextData MySqlQueryTextData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string queryId = null, string queryText = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlRecommendationActionData MySqlRecommendationActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string advisorName = null, System.Guid? sessionId = default(System.Guid?), int? actionId = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string reason = null, string recommendationType = null, System.Collections.Generic.IDictionary<string, string> details = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData MySqlRecoverableServerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastAvailableBackupOn = default(System.DateTimeOffset?), string serviceLevelObjective = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, string version = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerAdministratorData MySqlServerAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.Models.MySqlAdministratorType? administratorType = default(Azure.ResourceManager.MySql.Models.MySqlAdministratorType?), string loginAccountName = null, System.Guid? secureId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerData MySqlServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.MySql.Models.MySqlSku sku = null, string administratorLogin = null, Azure.ResourceManager.MySql.Models.MySqlServerVersion? version = default(Azure.ResourceManager.MySql.Models.MySqlServerVersion?), Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum?), Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum?), string byokEnforcement = null, Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption?), Azure.ResourceManager.MySql.Models.MySqlServerState? userVisibleState = default(Azure.ResourceManager.MySql.Models.MySqlServerState?), string fullyQualifiedDomainName = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), Azure.ResourceManager.MySql.Models.MySqlStorageProfile storageProfile = null, string replicationRole = null, Azure.Core.ResourceIdentifier masterServerId = null, int? replicaCapacity = default(int?), Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerKeyData MySqlServerKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ResourceManager.MySql.Models.MySqlServerKeyType? serverKeyType = default(Azure.ResourceManager.MySql.Models.MySqlServerKeyType?), System.Uri uri = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection MySqlServerPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties MySqlServerPrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty privateLinkServiceConnectionState = null, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState? provisioningState = default(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty MySqlServerPrivateLinkServiceConnectionStateProperty(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus status = default(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus), string description = null, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction? actionsRequired = default(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData MySqlServerSecurityAlertPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.Models.MySqlServerSecurityAlertPolicyState? state = default(Azure.ResourceManager.MySql.Models.MySqlServerSecurityAlertPolicyState?), System.Collections.Generic.IEnumerable<string> disabledAlerts = null, System.Collections.Generic.IEnumerable<string> emailAddresses = null, bool? sendToEmailAccountAdmins = default(bool?), string storageEndpoint = null, string storageAccountAccessKey = null, int? retentionDays = default(int?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData MySqlVirtualNetworkRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier virtualNetworkSubnetId = null, bool? ignoreMissingVnetServiceEndpoint = default(bool?), Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState? state = default(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlWaitStatisticData MySqlWaitStatisticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string eventName = null, string eventTypeName = null, long? queryId = default(long?), string databaseName = null, long? userId = default(long?), long? count = default(long?), double? totalTimeInMinutes = default(double?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlAdministratorType : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlAdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlAdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlAdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlAdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlAdministratorType left, Azure.ResourceManager.MySql.Models.MySqlAdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlAdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlAdministratorType left, Azure.ResourceManager.MySql.Models.MySqlAdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlConfigurations
    {
        public MySqlConfigurations() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MySql.MySqlConfigurationData> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlGeoRedundantBackup : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlGeoRedundantBackup(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup left, Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup left, Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlInfrastructureEncryption : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlInfrastructureEncryption(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption left, Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption left, Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlLogFile : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlLogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string LogFileType { get { throw null; } set { } }
        public long? SizeInKB { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlMinimalTlsVersionEnum : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlMinimalTlsVersionEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum Tls1_2 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum TLSEnforcementDisabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum left, Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum left, Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlNameAvailabilityContent
    {
        public MySqlNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    public partial class MySqlNameAvailabilityResult
    {
        internal MySqlNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class MySqlPerformanceTier
    {
        internal MySqlPerformanceTier() { }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxLargeStorageInMB { get { throw null; } }
        public int? MaxStorageInMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinLargeStorageInMB { get { throw null; } }
        public int? MinStorageInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives> ServiceLevelObjectives { get { throw null; } }
    }
    public partial class MySqlPerformanceTierServiceLevelObjectives
    {
        internal MySqlPerformanceTierServiceLevelObjectives() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxStorageInMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinStorageInMB { get { throw null; } }
        public int? VCores { get { throw null; } }
    }
    public partial class MySqlPrivateEndpointConnectionPatch
    {
        public MySqlPrivateEndpointConnectionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPrivateEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPrivateEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Approving { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Rejecting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState left, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState left, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPrivateLinkServiceConnectionStateRequiredAction : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPrivateLinkServiceConnectionStateRequiredAction(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPrivateLinkServiceConnectionStateStatus : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPrivateLinkServiceConnectionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPublicNetworkAccessEnum : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPublicNetworkAccessEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum left, Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum left, Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlQueryPerformanceInsightResetDataResult
    {
        internal MySqlQueryPerformanceInsightResetDataResult() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlQueryPerformanceInsightResetDataResultState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlQueryPerformanceInsightResetDataResultState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState left, Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState left, Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlRecoverableServerResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MySqlRecoverableServerResourceData() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupOn { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
        public int? VCores { get { throw null; } }
        public string Version { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlSecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlSecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName left, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName left, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlServerCreateOrUpdateContent
    {
        public MySqlServerCreateOrUpdateContent(Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate properties, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate Properties { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlServerKeyType : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerKeyType AzureKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlServerKeyType left, Azure.ResourceManager.MySql.Models.MySqlServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlServerKeyType left, Azure.ResourceManager.MySql.Models.MySqlServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlServerPatch
    {
        public MySqlServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageProfile StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerVersion? Version { get { throw null; } set { } }
    }
    public partial class MySqlServerPrivateEndpointConnection
    {
        internal MySqlServerPrivateEndpointConnection() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class MySqlServerPrivateEndpointConnectionProperties
    {
        internal MySqlServerPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class MySqlServerPrivateLinkServiceConnectionStateProperty
    {
        internal MySqlServerPrivateLinkServiceConnectionStateProperty() { }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Status { get { throw null; } }
    }
    public abstract partial class MySqlServerPropertiesForCreate
    {
        protected MySqlServerPropertiesForCreate() { }
        public Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerVersion? Version { get { throw null; } set { } }
    }
    public partial class MySqlServerPropertiesForDefaultCreate : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate
    {
        public MySqlServerPropertiesForDefaultCreate(string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
    }
    public partial class MySqlServerPropertiesForGeoRestore : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate
    {
        public MySqlServerPropertiesForGeoRestore(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
    }
    public partial class MySqlServerPropertiesForReplica : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate
    {
        public MySqlServerPropertiesForReplica(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
    }
    public partial class MySqlServerPropertiesForRestore : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate
    {
        public MySqlServerPropertiesForRestore(Azure.Core.ResourceIdentifier sourceServerId, System.DateTimeOffset restorePointInTime) { }
        public System.DateTimeOffset RestorePointInTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
    }
    public enum MySqlServerSecurityAlertPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlServerState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlServerState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlServerState left, Azure.ResourceManager.MySql.Models.MySqlServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlServerState left, Azure.ResourceManager.MySql.Models.MySqlServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlServerUpgradeContent
    {
        public MySqlServerUpgradeContent() { }
        public string TargetServerVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlServerVersion : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerVersion Ver5_6 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerVersion Ver5_7 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerVersion Ver8_0 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlServerVersion left, Azure.ResourceManager.MySql.Models.MySqlServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlServerVersion left, Azure.ResourceManager.MySql.Models.MySqlServerVersion right) { throw null; }
        public override string ToString() { throw null; }
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
    public enum MySqlSslEnforcementEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlStorageAutogrow : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlStorageAutogrow(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow left, Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow left, Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlStorageProfile
    {
        public MySqlStorageProfile() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow? StorageAutogrow { get { throw null; } set { } }
        public int? StorageInMB { get { throw null; } set { } }
    }
    public partial class MySqlTopQueryStatisticsInput
    {
        public MySqlTopQueryStatisticsInput(int numberOfTopQueries, string aggregationFunction, string observedMetric, System.DateTimeOffset observationStartOn, System.DateTimeOffset observationEndOn, string aggregationWindow) { }
        public string AggregationFunction { get { throw null; } }
        public string AggregationWindow { get { throw null; } }
        public int NumberOfTopQueries { get { throw null; } }
        public System.DateTimeOffset ObservationEndOn { get { throw null; } }
        public System.DateTimeOffset ObservationStartOn { get { throw null; } }
        public string ObservedMetric { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlVirtualNetworkRuleState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlVirtualNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Initializing { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState InProgress { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState left, Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState left, Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlWaitStatisticsInput
    {
        public MySqlWaitStatisticsInput(System.DateTimeOffset observationStartOn, System.DateTimeOffset observationEndOn, string aggregationWindow) { }
        public string AggregationWindow { get { throw null; } }
        public System.DateTimeOffset ObservationEndOn { get { throw null; } }
        public System.DateTimeOffset ObservationStartOn { get { throw null; } }
    }
}
