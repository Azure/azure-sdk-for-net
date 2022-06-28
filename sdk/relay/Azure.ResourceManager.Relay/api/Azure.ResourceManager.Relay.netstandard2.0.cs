namespace Azure.ResourceManager.Relay
{
    public partial class AuthorizationRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public AuthorizationRuleData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.AccessRight> Rights { get { throw null; } }
    }
    public partial class HybridConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.HybridConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.HybridConnectionResource>, System.Collections.IEnumerable
    {
        protected HybridConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.HybridConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hybridConnectionName, Azure.ResourceManager.Relay.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.HybridConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hybridConnectionName, Azure.ResourceManager.Relay.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.HybridConnectionResource> Get(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.HybridConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.HybridConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.HybridConnectionResource>> GetAsync(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.HybridConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.HybridConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.HybridConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.HybridConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public HybridConnectionData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public int? ListenerCount { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public bool? RequiresClientAuthorization { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string UserMetadata { get { throw null; } set { } }
    }
    public partial class HybridConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectionResource() { }
        public virtual Azure.ResourceManager.Relay.HybridConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string hybridConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.HybridConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.HybridConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> GetNamespaceHybridConnectionAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>> GetNamespaceHybridConnectionAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleCollection GetNamespaceHybridConnectionAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.HybridConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.HybridConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.HybridConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.Relay.AuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.Relay.Models.RegenerateAccessKeyParameters regenerateAccessKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.Relay.Models.RegenerateAccessKeyParameters regenerateAccessKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceHybridConnectionAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NamespaceHybridConnectionAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceHybridConnectionAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceHybridConnectionAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.Relay.AuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string hybridConnectionName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.Relay.Models.RegenerateAccessKeyParameters regenerateAccessKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.Relay.Models.RegenerateAccessKeyParameters regenerateAccessKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceWcfRelayAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NamespaceWcfRelayAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceWcfRelayAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceWcfRelayAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.Relay.AuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string relayName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys> RegenerateKeys(Azure.ResourceManager.Relay.Models.RegenerateAccessKeyParameters regenerateAccessKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.AccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.Relay.Models.RegenerateAccessKeyParameters regenerateAccessKeyParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.AuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkRuleSetData : Azure.ResourceManager.Models.ResourceData
    {
        public NetworkRuleSetData() { }
        public Azure.ResourceManager.Relay.Models.DefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.Models.NWRuleSetIPRules> IPRules { get { throw null; } }
    }
    public partial class NetworkRuleSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkRuleSetResource() { }
        public virtual Azure.ResourceManager.Relay.NetworkRuleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NetworkRuleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.NetworkRuleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.NetworkRuleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.NetworkRuleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NetworkRuleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NetworkRuleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RelayExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Relay.Models.CheckNameAvailabilityResult> CheckNameAvailabilityNamespace(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Relay.Models.CheckNameAvailability checkNameAvailability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityNamespaceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Relay.Models.CheckNameAvailability checkNameAvailability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relay.HybridConnectionResource GetHybridConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource GetNamespaceAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.NamespaceHybridConnectionAuthorizationRuleResource GetNamespaceHybridConnectionAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource GetNamespaceWcfRelayAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.NetworkRuleSetResource GetNetworkRuleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.RelayNamespaceResource>> GetRelayNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceResource GetRelayNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayNamespaceCollection GetRelayNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Relay.RelayNamespaceResource> GetRelayNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource GetRelayPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.RelayPrivateLinkResource GetRelayPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relay.WcfRelayResource GetWcfRelayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayNamespaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RelayNamespaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string MetricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelaySku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.Relay.HybridConnectionResource> GetHybridConnection(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.HybridConnectionResource>> GetHybridConnectionAsync(string hybridConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.HybridConnectionCollection GetHybridConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource> GetNamespaceAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceAuthorizationRuleResource>> GetNamespaceAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.NamespaceAuthorizationRuleCollection GetNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.Relay.NetworkRuleSetResource GetNetworkRuleSet() { throw null; }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public RelayPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Relay.Models.ConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.EndPointProvisioningState? ProvisioningState { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.RelayPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.RelayPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.RelayPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.RelayPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelayPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal RelayPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Relay.WcfRelayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Relay.WcfRelayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Relay.WcfRelayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Relay.WcfRelayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WcfRelayData : Azure.ResourceManager.Models.ResourceData
    {
        public WcfRelayData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public int? ListenerCount { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.Relaytype? RelayType { get { throw null; } set { } }
        public bool? RequiresClientAuthorization { get { throw null; } set { } }
        public bool? RequiresTransportSecurity { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string UserMetadata { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource> GetNamespaceWcfRelayAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleResource>> GetNamespaceWcfRelayAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relay.NamespaceWcfRelayAuthorizationRuleCollection GetNamespaceWcfRelayAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relay.WcfRelayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relay.WcfRelayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Relay.Models
{
    public partial class AccessKeys
    {
        internal AccessKeys() { }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessRight : System.IEquatable<Azure.ResourceManager.Relay.Models.AccessRight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessRight(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.AccessRight Listen { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.AccessRight Manage { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.AccessRight Send { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.AccessRight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.AccessRight left, Azure.ResourceManager.Relay.Models.AccessRight right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.AccessRight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.AccessRight left, Azure.ResourceManager.Relay.Models.AccessRight right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Relay.Models.UnavailableReason? Reason { get { throw null; } }
    }
    public partial class ConnectionState
    {
        public ConnectionState() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultAction : System.IEquatable<Azure.ResourceManager.Relay.Models.DefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.DefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.DefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.DefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.DefaultAction left, Azure.ResourceManager.Relay.Models.DefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.DefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.DefaultAction left, Azure.ResourceManager.Relay.Models.DefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndPointProvisioningState : System.IEquatable<Azure.ResourceManager.Relay.Models.EndPointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndPointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.EndPointProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.EndPointProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.EndPointProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.EndPointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.EndPointProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.EndPointProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.EndPointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.EndPointProvisioningState left, Azure.ResourceManager.Relay.Models.EndPointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.EndPointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.EndPointProvisioningState left, Azure.ResourceManager.Relay.Models.EndPointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.Relay.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.KeyType PrimaryKey { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.KeyType SecondaryKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.KeyType left, Azure.ResourceManager.Relay.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.KeyType left, Azure.ResourceManager.Relay.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.Relay.Models.NetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.NetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.NetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.NetworkRuleIPAction left, Azure.ResourceManager.Relay.Models.NetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.NetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.NetworkRuleIPAction left, Azure.ResourceManager.Relay.Models.NetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NWRuleSetIPRules
    {
        public NWRuleSetIPRules() { }
        public Azure.ResourceManager.Relay.Models.NetworkRuleIPAction? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkConnectionStatus : System.IEquatable<Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus left, Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus left, Azure.ResourceManager.Relay.Models.PrivateLinkConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Relay.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.PublicNetworkAccess SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.PublicNetworkAccess left, Azure.ResourceManager.Relay.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.PublicNetworkAccess left, Azure.ResourceManager.Relay.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateAccessKeyParameters
    {
        public RegenerateAccessKeyParameters(Azure.ResourceManager.Relay.Models.KeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.KeyType KeyType { get { throw null; } }
    }
    public partial class RelayNamespacePatch : Azure.ResourceManager.Models.ResourceData
    {
        public RelayNamespacePatch() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string MetricId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Relay.RelayPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.Relay.Models.RelaySku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class RelaySku
    {
        public RelaySku(Azure.ResourceManager.Relay.Models.RelaySkuName name) { }
        public Azure.ResourceManager.Relay.Models.RelaySkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Relay.Models.RelaySkuTier? Tier { get { throw null; } set { } }
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
    public enum Relaytype
    {
        NetTcp = 0,
        Http = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnavailableReason : System.IEquatable<Azure.ResourceManager.Relay.Models.UnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Relay.Models.UnavailableReason InvalidName { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.UnavailableReason NameInLockdown { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.UnavailableReason NameInUse { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.UnavailableReason None { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.UnavailableReason SubscriptionIsDisabled { get { throw null; } }
        public static Azure.ResourceManager.Relay.Models.UnavailableReason TooManyNamespaceInCurrentSubscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relay.Models.UnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relay.Models.UnavailableReason left, Azure.ResourceManager.Relay.Models.UnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relay.Models.UnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relay.Models.UnavailableReason left, Azure.ResourceManager.Relay.Models.UnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
}
