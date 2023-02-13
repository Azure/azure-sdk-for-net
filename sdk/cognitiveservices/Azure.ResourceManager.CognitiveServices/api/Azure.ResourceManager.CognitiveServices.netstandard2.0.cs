namespace Azure.ResourceManager.CognitiveServices
{
    public partial class CognitiveServicesAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CognitiveServicesAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
    }
    public partial class CognitiveServicesAccountDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesAccountDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentData : Azure.ResourceManager.Models.ResourceData
    {
        public CognitiveServicesAccountDeploymentData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProperties Properties { get { throw null; } set { } }
    }
    public partial class CognitiveServicesAccountDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesAccountDeploymentResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesAccountResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource> GetCognitiveServicesAccountDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource>> GetCognitiveServicesAccountDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentCollection GetCognitiveServicesAccountDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource> GetCognitiveServicesPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>> GetCognitiveServicesPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionCollection GetCognitiveServicesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> GetCommitmentPlan(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetCommitmentPlanAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanCollection GetCommitmentPlans() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel> GetModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountModel> GetModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku> GetSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountSku> GetSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsage> GetUsagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys> RegenerateKey(Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiKeys>> RegenerateKeyAsync(Azure.ResourceManager.CognitiveServices.Models.RegenerateServiceAccountKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesCommitmentPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesCommitmentPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commitmentPlanName, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> Get(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetAsync(string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CognitiveServicesCommitmentPlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesCommitmentPlanResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string commitmentPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> GetCommitmentPlanAccountAssociation(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> GetCommitmentPlanAccountAssociationAsync(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationCollection GetCommitmentPlanAccountAssociations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesCommitmentPlanPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesDeletedAccountCollection : Azure.ResourceManager.ArmCollection
    {
        protected CognitiveServicesDeletedAccountCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> Get(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetAsync(Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesDeletedAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CognitiveServicesDeletedAccountResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CognitiveServicesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList> CheckDomainAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityList>> CheckDomainAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesDomainAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList> CheckSkuAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityList> CheckSkuAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource>> GetCognitiveServicesAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountDeploymentResource GetCognitiveServicesAccountDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource GetCognitiveServicesAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountCollection GetCognitiveServicesAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesAccountResource> GetCognitiveServicesAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource>> GetCognitiveServicesCommitmentPlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string commitmentPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource GetCognitiveServicesCommitmentPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanCollection GetCognitiveServicesCommitmentPlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesCommitmentPlanResource> GetCognitiveServicesCommitmentPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetCognitiveServicesDeletedAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource>> GetCognitiveServicesDeletedAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource GetCognitiveServicesDeletedAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountCollection GetCognitiveServicesDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource GetCognitiveServicesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource GetCommitmentPlanAccountAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.CommitmentPlanResource GetCommitmentPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.CommitmentTier> GetCommitmentTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetDeletedAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CognitiveServicesDeletedAccountResource> GetDeletedAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku> GetResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.Models.AvailableCognitiveServicesSku> GetResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CognitiveServicesPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected CognitiveServicesPrivateEndpointConnectionCollection() { }
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
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
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
    }
    public partial class CommitmentPlanAccountAssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>, System.Collections.IEnumerable
    {
        protected CommitmentPlanAccountAssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string commitmentPlanAssociationName, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string commitmentPlanAssociationName, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> Get(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> GetAsync(string commitmentPlanAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommitmentPlanAccountAssociationData : Azure.ResourceManager.Models.ResourceData
    {
        public CommitmentPlanAccountAssociationData() { }
        public string AccountId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
    }
    public partial class CommitmentPlanAccountAssociationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommitmentPlanAccountAssociationResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string commitmentPlanName, string commitmentPlanAssociationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanAccountAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string Kind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CommitmentPlanResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommitmentPlanResource() { }
        public virtual Azure.ResourceManager.CognitiveServices.CommitmentPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string commitmentPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CognitiveServices.CommitmentPlanResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CognitiveServices.CommitmentPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CognitiveServices.Models
{
    public partial class AvailableCognitiveServicesSku
    {
        internal AvailableCognitiveServicesSku() { }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictions> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class CognitiveServicesAccountDeploymentModel
    {
        public CognitiveServicesAccountDeploymentModel() { }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public string Format { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class CognitiveServicesAccountDeploymentProperties
    {
        public CognitiveServicesAccountDeploymentProperties() { }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel Model { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState? ProvisioningState { get { throw null; } }
        public string RaiPolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleSettings ScaleSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesAccountDeploymentProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesAccountDeploymentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesAccountDeploymentScaleSettings
    {
        public CognitiveServicesAccountDeploymentScaleSettings() { }
        public int? ActiveCapacity { get { throw null; } }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType? ScaleType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesAccountDeploymentScaleType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesAccountDeploymentScaleType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesAccountModel : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel
    {
        public CognitiveServicesAccountModel() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesAccountDeploymentModel BaseModel { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountModelDeprecationInfo Deprecation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> FinetuneCapabilities { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus? LifecycleStatus { get { throw null; } set { } }
        public int? MaxCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class CognitiveServicesAccountProperties
    {
        public CognitiveServicesAccountProperties() { }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountApiProperties ApiProperties { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountCallRateLimit CallRateLimit { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanAssociation> CommitmentPlanAssociations { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string CustomSubDomainName { get { throw null; } set { } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnableDynamicThrottling { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionProperties Encryption { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Endpoints { get { throw null; } }
        public bool? IsMigrated { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesMultiRegionSettings Locations { get { throw null; } set { } }
        public string MigrationToken { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.CognitiveServicesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaLimit QuotaLimit { get { throw null; } }
        public bool? Restore { get { throw null; } set { } }
        public bool? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public string ScheduledPurgeDate { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuChangeInfo SkuChangeInfo { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUserOwnedStorage> UserOwnedStorage { get { throw null; } }
    }
    public partial class CognitiveServicesAccountSku
    {
        internal CognitiveServicesAccountSku() { }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } }
    }
    public partial class CognitiveServicesCommitmentPlanPatch : Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesPatchResourceTags
    {
        public CognitiveServicesCommitmentPlanPatch() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSku Sku { get { throw null; } set { } }
    }
    public partial class CognitiveServicesDomainAvailabilityContent
    {
        public CognitiveServicesDomainAvailabilityContent(string subdomainName, Azure.Core.ResourceType resourceType) { }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public string SubdomainName { get { throw null; } }
    }
    public partial class CognitiveServicesDomainAvailabilityList
    {
        internal CognitiveServicesDomainAvailabilityList() { }
        public string DomainAvailabilityType { get { throw null; } }
        public bool? IsSubdomainAvailable { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SubdomainName { get { throw null; } }
    }
    public partial class CognitiveServicesIPRule
    {
        public CognitiveServicesIPRule(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public partial class CognitiveServicesMultiRegionSettings
    {
        public CognitiveServicesMultiRegionSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRegionSetting> Regions { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod? RoutingMethod { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesNetworkRuleAction : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesNetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesNetworkRuleSet
    {
        public CognitiveServicesNetworkRuleSet() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesNetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class CognitiveServicesPatchResourceTags
    {
        public CognitiveServicesPatchResourceTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class CognitiveServicesRegionSetting
    {
        public CognitiveServicesRegionSetting() { }
        public string Customsubdomain { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public float? Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesRoutingMethod : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesRoutingMethod(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod Performance { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod Priority { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod Weighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesRoutingMethod right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class CognitiveServicesSkuAvailabilityContent
    {
        public CognitiveServicesSkuAvailabilityContent(System.Collections.Generic.IEnumerable<string> skus, string kind, Azure.Core.ResourceType resourceType) { }
        public string Kind { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        public System.Collections.Generic.IList<string> Skus { get { throw null; } }
    }
    public partial class CognitiveServicesSkuAvailabilityList
    {
        internal CognitiveServicesSkuAvailabilityList() { }
        public bool? IsSkuAvailable { get { throw null; } }
        public string Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public string SkuAvailabilityType { get { throw null; } }
        public string SkuName { get { throw null; } }
    }
    public partial class CognitiveServicesSkuCapability
    {
        internal CognitiveServicesSkuCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class CognitiveServicesSkuChangeInfo
    {
        internal CognitiveServicesSkuChangeInfo() { }
        public float? CountOfDowngrades { get { throw null; } }
        public float? CountOfUpgradesAfterDowngrades { get { throw null; } }
        public System.DateTimeOffset? LastChangedOn { get { throw null; } }
    }
    public partial class CognitiveServicesSkuRestrictionInfo
    {
        internal CognitiveServicesSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CognitiveServicesSkuRestrictionReasonCode : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CognitiveServicesSkuRestrictionReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode left, Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CognitiveServicesSkuRestrictions
    {
        internal CognitiveServicesSkuRestrictions() { }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CognitiveServicesSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public enum CognitiveServicesSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
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
    public partial class CognitiveServicesVirtualNetworkRule
    {
        public CognitiveServicesVirtualNetworkRule(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
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
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota Quota { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class CommitmentPlanAssociation
    {
        internal CommitmentPlanAssociation() { }
        public Azure.Core.ResourceIdentifier CommitmentPlanId { get { throw null; } }
        public string CommitmentPlanLocation { get { throw null; } }
    }
    public partial class CommitmentPlanProperties
    {
        public CommitmentPlanProperties() { }
        public bool? AutoRenew { get { throw null; } set { } }
        public System.Guid? CommitmentPlanGuid { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Current { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel? HostingModel { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Last { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPeriod Next { get { throw null; } set { } }
        public string PlanType { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommitmentPlanProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommitmentPlanProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.CommitmentPlanProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel? HostingModel { get { throw null; } }
        public string Kind { get { throw null; } }
        public int? MaxCount { get { throw null; } }
        public string PlanType { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.CommitmentQuota Quota { get { throw null; } }
        public string SkuName { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelLifecycleStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelLifecycleStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus GenerallyAvailable { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus Preview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus left, Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus left, Azure.ResourceManager.CognitiveServices.Models.ModelLifecycleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateServiceAccountKeyContent
    {
        public RegenerateServiceAccountKeyContent(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountKeyName keyName) { }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountKeyName KeyName { get { throw null; } }
    }
    public partial class ServiceAccountApiKeys
    {
        internal ServiceAccountApiKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
    }
    public partial class ServiceAccountApiProperties
    {
        public ServiceAccountApiProperties() { }
        public System.Guid? AadClientId { get { throw null; } set { } }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? EnableStatistics { get { throw null; } set { } }
        public string EventHubConnectionString { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier QnaAzureSearchEndpointId { get { throw null; } set { } }
        public string QnaAzureSearchEndpointKey { get { throw null; } set { } }
        public string QnaRuntimeEndpoint { get { throw null; } set { } }
        public string StorageAccountConnectionString { get { throw null; } set { } }
        public string SuperUser { get { throw null; } set { } }
        public string WebsiteName { get { throw null; } set { } }
    }
    public partial class ServiceAccountCallRateLimit
    {
        internal ServiceAccountCallRateLimit() { }
        public float? Count { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> Rules { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountEncryptionKeySource : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountEncryptionKeySource(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource MicrosoftCognitiveServices { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource MicrosoftKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountEncryptionProperties
    {
        public ServiceAccountEncryptionProperties() { }
        public System.Guid? IdentityClientId { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountEncryptionKeySource? KeySource { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountHostingModel : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountHostingModel(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel ConnectedContainer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel DisconnectedContainer { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountHostingModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ServiceAccountKeyName
    {
        Key1 = 0,
        Key2 = 1,
    }
    public partial class ServiceAccountModelDeprecationInfo
    {
        public ServiceAccountModelDeprecationInfo() { }
        public System.DateTimeOffset? FineTuneOn { get { throw null; } set { } }
        public System.DateTimeOffset? InferenceOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountProvisioningState : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState ResolvingDns { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountQuotaLimit
    {
        internal ServiceAccountQuotaLimit() { }
        public float? Count { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingRule> Rules { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountQuotaUsageStatus : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountQuotaUsageStatus(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus Blocked { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus Included { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus InOverage { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountThrottlingMatchPattern
    {
        internal ServiceAccountThrottlingMatchPattern() { }
        public string Method { get { throw null; } }
        public string Path { get { throw null; } }
    }
    public partial class ServiceAccountThrottlingRule
    {
        internal ServiceAccountThrottlingRule() { }
        public float? Count { get { throw null; } }
        public bool? IsDynamicThrottlingEnabled { get { throw null; } }
        public string Key { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountThrottlingMatchPattern> MatchPatterns { get { throw null; } }
        public float? MinCount { get { throw null; } }
        public float? RenewalPeriod { get { throw null; } }
    }
    public partial class ServiceAccountUsage
    {
        internal ServiceAccountUsage() { }
        public double? CurrentValue { get { throw null; } }
        public double? Limit { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageMetricName Name { get { throw null; } }
        public string NextResetTime { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountQuotaUsageStatus? Status { get { throw null; } }
        public Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType? Unit { get { throw null; } }
    }
    public partial class ServiceAccountUsageMetricName
    {
        internal ServiceAccountUsageMetricName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceAccountUsageUnitType : System.IEquatable<Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceAccountUsageUnitType(string value) { throw null; }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Bytes { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Count { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Milliseconds { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Percent { get { throw null; } }
        public static Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType left, Azure.ResourceManager.CognitiveServices.Models.ServiceAccountUsageUnitType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceAccountUserOwnedStorage
    {
        public ServiceAccountUserOwnedStorage() { }
        public System.Guid? IdentityClientId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
}
