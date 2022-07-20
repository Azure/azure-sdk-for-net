namespace Azure.ResourceManager.CognitiveServices
{
    public partial class AccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.AccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.AccountResource>, System.Collections.IEnumerable
    {
        protected AccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.AccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CognitiveServices.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.AccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CognitiveServices.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.AccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.AccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.AccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.AccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.AccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.AccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.AccountProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
    }
    public partial class AccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.AccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetCognitiveServicesPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetCognitiveServicesPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionCollection GetCognitiveServicesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetCommitmentPlan(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetCommitmentPlanAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanCollection GetCommitmentPlans() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DeploymentResource> GetDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DeploymentResource>> GetDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.DeploymentCollection GetDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ApiKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ApiKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.AccountModel> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.AccountModel> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.AccountSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.AccountSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesUsage> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesUsage> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ApiKeys> RegenerateKey(Azure.ResourceManager.CognitiveServices.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ApiKeys>> RegenerateKeyAsync(Azure.ResourceManager.CognitiveServices.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.AccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.AccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CognitiveServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.Models.DomainAvailability> CheckDomainAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CheckDomainAvailabilityParameter checkDomainAvailabilityParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.DomainAvailability>> CheckDomainAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CheckDomainAvailabilityParameter checkDomainAvailabilityParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.SkuAvailability> CheckSkuAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CheckSkuAvailabilityParameter checkSkuAvailabilityParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.SkuAvailability> CheckSkuAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CheckSkuAvailabilityParameter checkSkuAvailabilityParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource> GetAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.AccountResource>> GetAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.AccountResource GetAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.AccountCollection GetAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.AccountResource> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.AccountResource> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource GetCognitiveServicesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanResource GetCommitmentPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> GetDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> GetDeletedAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.DeploymentResource GetDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> GetLocationResourceGroupDeletedAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource>> GetLocationResourceGroupDeletedAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource GetLocationResourceGroupDeletedAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountCollection GetLocationResourceGroupDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ResourceSku> GetResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ResourceSku> GetResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public CognitiveServicesPrivateEndpointConnectionData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommitmentPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>, System.Collections.IEnumerable
    {
        protected CommitmentPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Get(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommitmentPlanData : Azure.ResourceManager.Models.ResourceData
    {
        public CommitmentPlanData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties Properties { get { throw null; } set { } }
    }
    public partial class CommitmentPlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommitmentPlanResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string commitmentPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.DeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.DeploymentResource>, System.Collections.IEnumerable
    {
        protected DeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.DeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.CognitiveServices.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.DeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.CognitiveServices.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.DeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.DeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.DeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.DeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.DeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.DeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentData : Azure.ResourceManager.Models.ResourceData
    {
        public DeploymentData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentProperties Properties { get { throw null; } set { } }
    }
    public partial class DeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.DeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.DeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.DeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.DeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.DeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.DeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationResourceGroupDeletedAccountCollection : Azure.ResourceManager.ArmCollection
    {
        protected LocationResourceGroupDeletedAccountCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> Get(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource>> GetAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LocationResourceGroupDeletedAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LocationResourceGroupDeletedAccountResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.AccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.LocationResourceGroupDeletedAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class AccountModel : Azure.ResourceManager.CognitiveServices.Models.DeploymentModel
    {
        public AccountModel() { }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentModel BaseModel { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ModelDeprecationInfo Deprecation { get { throw null; } set { } }
        public int? MaxCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class AccountProperties
    {
        public AccountProperties() { }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ApiProperties ApiProperties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CallRateLimit CallRateLimit { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.SkuCapability> Capabilities { get { throw null; } }
        public string CustomSubDomainName { get { throw null; } set { } }
        public string DateCreated { get { throw null; } }
        public string DeletionDate { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? DynamicThrottlingEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.Encryption Encryption { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Endpoints { get { throw null; } }
        public string InternalId { get { throw null; } }
        public bool? IsMigrated { get { throw null; } }
        public string MigrationToken { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.NetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.QuotaLimit QuotaLimit { get { throw null; } }
        public bool? Restore { get { throw null; } set { } }
        public bool? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public string ScheduledPurgeDate { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.SkuChangeInfo SkuChangeInfo { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.UserOwnedStorage> UserOwnedStorage { get { throw null; } }
    }
    public partial class AccountSku
    {
        internal AccountSku() { }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } }
    }
    public partial class ApiKeys
    {
        internal ApiKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
    }
    public partial class ApiProperties
    {
        public ApiProperties() { }
        public string AadClientId { get { throw null; } set { } }
        public string AadTenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string EventHubConnectionString { get { throw null; } set { } }
        public string QnaAzureSearchEndpointId { get { throw null; } set { } }
        public string QnaAzureSearchEndpointKey { get { throw null; } set { } }
        public string QnaRuntimeEndpoint { get { throw null; } set { } }
        public bool? StatisticsEnabled { get { throw null; } set { } }
        public string StorageAccountConnectionString { get { throw null; } set { } }
        public string SuperUser { get { throw null; } set { } }
        public string WebsiteName { get { throw null; } set { } }
    }
    public partial class CallRateLimit
    {
        internal CallRateLimit() { }
        public float? Count { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ThrottlingRule> Rules { get { throw null; } }
    }
    public partial class CheckDomainAvailabilityParameter
    {
        public CheckDomainAvailabilityParameter(string subdomainName, string checkDomainAvailabilityParameterType) { }
        public string CheckDomainAvailabilityParameterType { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string SubdomainName { get { throw null; } }
    }
    public partial class CheckSkuAvailabilityParameter
    {
        public CheckSkuAvailabilityParameter(System.Collections.Generic.IEnumerable<string> skus, string kind, string checkSkuAvailabilityParameterType) { }
        public string CheckSkuAvailabilityParameterType { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IList<string> Skus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesPrivateLinkResource : Azure.ResourceManager.Models.ResourceData
    {
        public CognitiveServicesPrivateLinkResource() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class CognitiveServicesPrivateLinkResourceProperties
    {
        public CognitiveServicesPrivateLinkResourceProperties() { }
        public string DisplayName { get { throw null; } }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class CognitiveServicesPrivateLinkServiceConnectionState
    {
        public CognitiveServicesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class CognitiveServicesSku
    {
        public CognitiveServicesSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesSkuTier : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Enterprise { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesUsage
    {
        internal CognitiveServicesUsage() { }
        public double? CurrentValue { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.MetricName Name { get { throw null; } }
        public string NextResetTime { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus? Status { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.UnitType? Unit { get { throw null; } }
    }
    public partial class CommitmentCost
    {
        internal CommitmentCost() { }
        public string CommitmentMeterId { get { throw null; } }
        public string OverageMeterId { get { throw null; } }
    }
    public partial class CommitmentPeriod
    {
        public CommitmentPeriod() { }
        public int? Count { get { throw null; } set { } }
        public string EndDate { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota Quota { get { throw null; } }
        public string StartDate { get { throw null; } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class CommitmentPlanProperties
    {
        public CommitmentPlanProperties() { }
        public bool? AutoRenew { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Current { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.HostingModel? HostingModel { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Last { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Next { get { throw null; } set { } }
        public string PlanType { get { throw null; } set { } }
    }
    public partial class CommitmentQuota
    {
        internal CommitmentQuota() { }
        public long? Quantity { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class CommitmentTier
    {
        internal CommitmentTier() { }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentCost Cost { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.HostingModel? HostingModel { get { throw null; } }
        public string Kind { get { throw null; } }
        public int? MaxCount { get { throw null; } }
        public string PlanType { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota Quota { get { throw null; } }
        public string SkuName { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class DeploymentModel
    {
        public DeploymentModel() { }
        public string Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class DeploymentProperties
    {
        public DeploymentProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentModel Model { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.DeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentScaleSettings
    {
        public DeploymentScaleSettings() { }
        public int? ActiveCapacity { get { throw null; } }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType? ScaleType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentScaleType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentScaleType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType left, Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType left, Azure.ResourceManager.CognitiveServices.Models.DeploymentScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainAvailability
    {
        internal DomainAvailability() { }
        public string DomainAvailabilityType { get { throw null; } }
        public bool? IsSubdomainAvailable { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SubdomainName { get { throw null; } }
    }
    public partial class Encryption
    {
        public Encryption() { }
        public Azure.ResourceManager.CognitiveServices.Models.KeySource? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostingModel : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.HostingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostingModel(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.HostingModel ConnectedContainer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.HostingModel DisconnectedContainer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.HostingModel Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.HostingModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.HostingModel left, Azure.ResourceManager.CognitiveServices.Models.HostingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.HostingModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.HostingModel left, Azure.ResourceManager.CognitiveServices.Models.HostingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRule
    {
        public IPRule(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public enum KeyName
    {
        Key1 = 0,
        Key2 = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeySource : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.KeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeySource(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.KeySource MicrosoftCognitiveServices { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.KeySource MicrosoftKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.KeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.KeySource left, Azure.ResourceManager.CognitiveServices.Models.KeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.KeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.KeySource left, Azure.ResourceManager.CognitiveServices.Models.KeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    public partial class MetricName
    {
        internal MetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ModelDeprecationInfo
    {
        public ModelDeprecationInfo() { }
        public string FineTune { get { throw null; } set { } }
        public string Inference { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleAction : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction left, Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction left, Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSet
    {
        public NetworkRuleSet() { }
        public Azure.ResourceManager.CognitiveServices.Models.NetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.IPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ProvisioningState ResolvingDns { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess left, Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess left, Azure.ResourceManager.CognitiveServices.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuotaLimit
    {
        internal QuotaLimit() { }
        public float? Count { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ThrottlingRule> Rules { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaUsageStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaUsageStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus Blocked { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus Included { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus InOverage { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus left, Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus left, Azure.ResourceManager.CognitiveServices.Models.QuotaUsageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyContent
    {
        public RegenerateKeyContent(Azure.ResourceManager.CognitiveServices.Models.KeyName keyName) { }
        public Azure.ResourceManager.CognitiveServices.Models.KeyName KeyName { get { throw null; } }
    }
    public partial class RequestMatchPattern
    {
        internal RequestMatchPattern() { }
        public string Method { get { throw null; } }
        public string Path { get { throw null; } }
    }
    public partial class ResourceSku
    {
        internal ResourceSku() { }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class ResourceSkuRestrictionInfo
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictions
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceSkuRestrictionsReasonCode : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceSkuRestrictionsReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.CognitiveServices.Models.ResourceSkuRestrictionsReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResourceSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class SkuAvailability
    {
        internal SkuAvailability() { }
        public string Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SkuAvailabilityType { get { throw null; } }
        public bool? SkuAvailable { get { throw null; } }
        public string SkuName { get { throw null; } }
    }
    public partial class SkuCapability
    {
        internal SkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuChangeInfo
    {
        internal SkuChangeInfo() { }
        public float? CountOfDowngrades { get { throw null; } }
        public float? CountOfUpgradesAfterDowngrades { get { throw null; } }
        public string LastChangeDate { get { throw null; } }
    }
    public partial class ThrottlingRule
    {
        internal ThrottlingRule() { }
        public float? Count { get { throw null; } }
        public bool? DynamicThrottlingEnabled { get { throw null; } }
        public string Key { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.RequestMatchPattern> MatchPatterns { get { throw null; } }
        public float? MinCount { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnitType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.UnitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnitType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.UnitType Bytes { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.UnitType BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.UnitType Count { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.UnitType CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.UnitType Milliseconds { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.UnitType Percent { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.UnitType Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.UnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.UnitType left, Azure.ResourceManager.CognitiveServices.Models.UnitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.UnitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.UnitType left, Azure.ResourceManager.CognitiveServices.Models.UnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserOwnedStorage
    {
        public UserOwnedStorage() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string id) { }
        public string Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
    }
}
