namespace Azure.ResourceManager.SpringAppDiscovery
{
    public partial class ErrorSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>, System.Collections.IEnumerable
    {
        protected ErrorSummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> Get(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>> GetAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> GetIfExists(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>> GetIfExistsAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ErrorSummaryData : Azure.ResourceManager.Models.ResourceData
    {
        public ErrorSummaryData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.ErrorSummariesProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ErrorSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ErrorSummaryResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string errorSummaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SpringAppDiscoveryExtensions
    {
        public static Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource GetErrorSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource GetSpringbootappsModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetSpringbootappsModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetSpringbootappsModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource GetSpringbootserversModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetSpringbootserversModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetSpringbootserversModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetSpringbootsitesModel(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> GetSpringbootsitesModelAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource GetSpringbootsitesModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelCollection GetSpringbootsitesModels(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetSpringbootsitesModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetSpringbootsitesModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SummaryResource GetSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SpringbootappsModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>, System.Collections.IEnumerable
    {
        protected SpringbootappsModelCollection() { }
        public virtual Azure.Response<bool> Exists(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> Get(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> GetAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetIfExists(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> GetIfExistsAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringbootappsModelData : Azure.ResourceManager.Models.ResourceData
    {
        public SpringbootappsModelData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SpringbootappsModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringbootappsModelResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string springbootappsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpringbootserversModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>, System.Collections.IEnumerable
    {
        protected SpringbootserversModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string springbootserversName, Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string springbootserversName, Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> Get(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> GetAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetIfExists(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> GetIfExistsAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringbootserversModelData : Azure.ResourceManager.Models.ResourceData
    {
        public SpringbootserversModelData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootserversProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SpringbootserversModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringbootserversModelResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string springbootserversName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootserversModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootserversModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpringbootsitesModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>, System.Collections.IEnumerable
    {
        protected SpringbootsitesModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string springbootsitesName, Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string springbootsitesName, Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> Get(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> GetAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetIfExists(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> GetIfExistsAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringbootsitesModelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SpringbootsitesModelData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesModelExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesProperties Properties { get { throw null; } set { } }
    }
    public partial class SpringbootsitesModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringbootsitesModelResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string springbootsitesName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryCollection GetErrorSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource> GetErrorSummary(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource>> GetErrorSummaryAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetSpringbootappsModel(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource>> GetSpringbootappsModelAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelCollection GetSpringbootappsModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetSpringbootserversModel(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource>> GetSpringbootserversModelAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelCollection GetSpringbootserversModels() { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SummaryCollection GetSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> GetSummary(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>> GetSummaryAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRefreshSite(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRefreshSiteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>, System.Collections.IEnumerable
    {
        protected SummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> Get(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>> GetAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> GetIfExists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>> GetIfExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SummaryData : Azure.ResourceManager.Models.ResourceData
    {
        public SummaryData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SummariesProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SummaryResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string summaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SpringAppDiscovery.Mocking
{
    public partial class MockableSpringAppDiscoveryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSpringAppDiscoveryArmClient() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryResource GetErrorSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource GetSpringbootappsModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource GetSpringbootserversModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource GetSpringbootsitesModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SummaryResource GetSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSpringAppDiscoveryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSpringAppDiscoveryResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetSpringbootsitesModel(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource>> GetSpringbootsitesModelAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelCollection GetSpringbootsitesModels() { throw null; }
    }
    public partial class MockableSpringAppDiscoverySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSpringAppDiscoverySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetSpringbootappsModels(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelResource> GetSpringbootappsModelsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetSpringbootserversModels(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelResource> GetSpringbootserversModelsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetSpringbootsitesModels(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelResource> GetSpringbootsitesModelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SpringAppDiscovery.Models
{
    public static partial class ArmSpringAppDiscoveryModelFactory
    {
        public static Azure.ResourceManager.SpringAppDiscovery.ErrorSummaryData ErrorSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.ErrorSummariesProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringbootappsModelData SpringbootappsModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsModelPatch SpringbootappsModelPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringbootserversModelData SpringbootserversModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootserversProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootserversModelPatch SpringbootserversModelPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootserversProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringbootsitesModelData SpringbootsitesModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesProperties properties = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesModelExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesModelPatch SpringbootsitesModelPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SummaryData SummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.SummariesProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
    }
    public partial class Error
    {
        public Error() { }
        public string Code { get { throw null; } set { } }
        public long? Id { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string PossibleCauses { get { throw null; } set { } }
        public string RecommendedAction { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string Severity { get { throw null; } set { } }
        public string SummaryMessage { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedTimeStamp { get { throw null; } set { } }
    }
    public partial class ErrorSummariesProperties
    {
        public ErrorSummariesProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.ErrorSummaryModel> DiscoveryScopeErrorSummaries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.Error> Errors { get { throw null; } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class ErrorSummaryModel
    {
        public ErrorSummaryModel() { }
        public long? AffectedObjectsCount { get { throw null; } set { } }
        public string AffectedResourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState left, Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState left, Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpringbootappsModelPatch : Azure.ResourceManager.Models.ResourceData
    {
        public SpringbootappsModelPatch() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SpringbootappsProperties
    {
        public SpringbootappsProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsPropertiesApplicationConfigurationsItem> ApplicationConfigurations { get { throw null; } }
        public string AppName { get { throw null; } set { } }
        public int? AppPort { get { throw null; } set { } }
        public string AppType { get { throw null; } set { } }
        public string ArtifactName { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> BindingPorts { get { throw null; } }
        public string BuildJdkVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Certificates { get { throw null; } }
        public string Checksum { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ConnectionStrings { get { throw null; } }
        public System.Collections.Generic.IList<string> Dependencies { get { throw null; } }
        public System.Collections.Generic.IList<string> Environments { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.Error> Errors { get { throw null; } }
        public int? InstanceCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsPropertiesInstancesItem> Instances { get { throw null; } }
        public string JarFileLocation { get { throw null; } set { } }
        public int? JvmMemoryInMB { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> JvmOptions { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MachineArmIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootappsPropertiesMiscsItem> Miscs { get { throw null; } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RuntimeJdkVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Servers { get { throw null; } }
        public string SiteName { get { throw null; } set { } }
        public string SpringBootVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StaticContentLocations { get { throw null; } }
    }
    public partial class SpringbootappsPropertiesApplicationConfigurationsItem
    {
        public SpringbootappsPropertiesApplicationConfigurationsItem(string key) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SpringbootappsPropertiesInstancesItem
    {
        public SpringbootappsPropertiesInstancesItem(string machineArmId) { }
        public int? InstanceCount { get { throw null; } set { } }
        public int? JvmMemoryInMB { get { throw null; } set { } }
        public string MachineArmId { get { throw null; } set { } }
    }
    public partial class SpringbootappsPropertiesMiscsItem
    {
        public SpringbootappsPropertiesMiscsItem(string key) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SpringbootserversModelPatch : Azure.ResourceManager.Models.ResourceData
    {
        public SpringbootserversModelPatch() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootserversProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SpringbootserversProperties
    {
        public SpringbootserversProperties(string server) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.Error> Errors { get { throw null; } }
        public System.Collections.Generic.IList<string> FqdnAndIPAddressList { get { throw null; } }
        public string MachineArmId { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public int? SpringBootApps { get { throw null; } set { } }
        public int? TotalApps { get { throw null; } set { } }
    }
    public partial class SpringbootsitesModelExtendedLocation
    {
        public SpringbootsitesModelExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public string SpringbootsitesModelExtendedLocationType { get { throw null; } set { } }
    }
    public partial class SpringbootsitesModelPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SpringbootsitesModelPatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringbootsitesProperties Properties { get { throw null; } set { } }
    }
    public partial class SpringbootsitesProperties
    {
        public SpringbootsitesProperties() { }
        public string MasterSiteId { get { throw null; } set { } }
        public string MigrateProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class SummariesProperties
    {
        public SummariesProperties() { }
        public long? DiscoveredApps { get { throw null; } set { } }
        public long? DiscoveredServers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.Error> Errors { get { throw null; } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
}
