namespace Azure.ResourceManager.AppPlatform
{
    public partial class ApiPortalCustomDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiPortalCustomDomainResource() { }
        public virtual Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiPortalName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiPortalCustomDomainResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>, System.Collections.IEnumerable
    {
        protected ApiPortalCustomDomainResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiPortalCustomDomainResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiPortalCustomDomainResourceData() { }
        public string ApiPortalCustomDomainThumbprint { get { throw null; } set { } }
    }
    public partial class ApiPortalResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApiPortalResource() { }
        public virtual Azure.ResourceManager.AppPlatform.ApiPortalResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string apiPortalName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource> GetApiPortalCustomDomainResource(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource>> GetApiPortalCustomDomainResourceAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResourceCollection GetApiPortalCustomDomainResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ApiPortalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ApiPortalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.CustomDomainValidateResult> ValidateDomain(Azure.ResourceManager.AppPlatform.Models.CustomDomainValidatePayload validatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.CustomDomainValidateResult>> ValidateDomainAsync(Azure.ResourceManager.AppPlatform.Models.CustomDomainValidatePayload validatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ApiPortalResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalResource>, System.Collections.IEnumerable
    {
        protected ApiPortalResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiPortalName, Azure.ResourceManager.AppPlatform.ApiPortalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ApiPortalResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiPortalName, Azure.ResourceManager.AppPlatform.ApiPortalResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiPortalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiPortalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalResource> Get(string apiPortalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.ApiPortalResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.ApiPortalResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalResource>> GetAsync(string apiPortalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.ApiPortalResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.ApiPortalResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ApiPortalResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApiPortalResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ApiPortalResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.ApiPortalProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformSku Sku { get { throw null; } set { } }
    }
    public partial class AppBuildCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResource>, System.Collections.IEnumerable
    {
        protected AppBuildCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string buildName, Azure.ResourceManager.AppPlatform.AppBuildData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string buildName, Azure.ResourceManager.AppPlatform.AppBuildData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResource> Get(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppBuildResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppBuildResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResource>> GetAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppBuildResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppBuildResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppBuildData : Azure.ResourceManager.Models.ResourceData
    {
        public AppBuildData() { }
        public Azure.ResourceManager.AppPlatform.Models.AppBuildProperties Properties { get { throw null; } set { } }
    }
    public partial class AppBuilderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppBuilderResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppBuilderResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName, string builderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuilderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuilderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> GetBuildpackBindingResource(string buildpackBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>> GetBuildpackBindingResourceAsync(string buildpackBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.BuildpackBindingResourceCollection GetBuildpackBindingResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuilderResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppBuilderResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuilderResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppBuilderResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppBuilderResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuilderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuilderResource>, System.Collections.IEnumerable
    {
        protected AppBuilderResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuilderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string builderName, Azure.ResourceManager.AppPlatform.AppBuilderResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuilderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string builderName, Azure.ResourceManager.AppPlatform.AppBuilderResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string builderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string builderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuilderResource> Get(string builderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppBuilderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppBuilderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuilderResource>> GetAsync(string builderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppBuilderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuilderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppBuilderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuilderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppBuilderResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AppBuilderResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.AppBuilderProperties Properties { get { throw null; } set { } }
    }
    public partial class AppBuildResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppBuildResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName, string buildName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResultResource> GetAppBuildResult(string buildResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResultResource>> GetAppBuildResultAsync(string buildResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildResultCollection GetAppBuildResults() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppBuildData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppBuildData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppBuildResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResultResource>, System.Collections.IEnumerable
    {
        protected AppBuildResultCollection() { }
        public virtual Azure.Response<bool> Exists(string buildResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResultResource> Get(string buildResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppBuildResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppBuildResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResultResource>> GetAsync(string buildResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppBuildResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppBuildResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppBuildResultData : Azure.ResourceManager.Models.ResourceData
    {
        public AppBuildResultData() { }
        public Azure.ResourceManager.AppPlatform.Models.BuildResultProperties Properties { get { throw null; } set { } }
    }
    public partial class AppBuildResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppBuildResultResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName, string buildName, string buildResultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.BuildResultLog> GetBuildResultLog(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.BuildResultLog>> GetBuildResultLogAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppBuildServiceAgentPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppBuildServiceAgentPoolResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName, string agentPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppBuildServiceAgentPoolResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>, System.Collections.IEnumerable
    {
        protected AppBuildServiceAgentPoolResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentPoolName, Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> Get(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>> GetAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppBuildServiceAgentPoolResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AppBuildServiceAgentPoolResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.BuildServiceAgentPoolProperties Properties { get { throw null; } set { } }
    }
    public partial class AppBuildServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceResource>, System.Collections.IEnumerable
    {
        protected AppBuildServiceCollection() { }
        public virtual Azure.Response<bool> Exists(string buildServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceResource> Get(string buildServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppBuildServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppBuildServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceResource>> GetAsync(string buildServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppBuildServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppBuildServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppBuildServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppBuildServiceData : Azure.ResourceManager.Models.ResourceData
    {
        public AppBuildServiceData() { }
        public Azure.ResourceManager.AppPlatform.Models.BuildServiceProperties Properties { get { throw null; } set { } }
    }
    public partial class AppBuildServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppBuildServiceResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResource> GetAppBuild(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildResource>> GetAppBuildAsync(string buildName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuilderResource> GetAppBuilderResource(string builderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuilderResource>> GetAppBuilderResourceAsync(string builderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppBuilderResourceCollection GetAppBuilderResources() { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildCollection GetAppBuilds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource> GetAppBuildServiceAgentPoolResource(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource>> GetAppBuildServiceAgentPoolResourceAsync(string agentPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResourceCollection GetAppBuildServiceAgentPoolResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.ResourceUploadResult> GetResourceUploadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.ResourceUploadResult>> GetResourceUploadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource> GetSupportedBuildpackResource(string buildpackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource>> GetSupportedBuildpackResourceAsync(string buildpackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.SupportedBuildpackResourceCollection GetSupportedBuildpackResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.SupportedStackResource> GetSupportedStackResource(string stackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.SupportedStackResource>> GetSupportedStackResourceAsync(string stackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.SupportedStackResourceCollection GetSupportedStackResources() { throw null; }
    }
    public partial class AppDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppDeploymentResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppDeploymentResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string appName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GenerateHeapDump(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.DiagnosticContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GenerateHeapDumpAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.DiagnosticContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation GenerateThreadDump(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.DiagnosticContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> GenerateThreadDumpAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.DiagnosticContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.LogFileUriResult> GetLogFileUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.LogFileUriResult>> GetLogFileUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartJfr(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.DiagnosticContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartJfrAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.DiagnosticContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppDeploymentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppDeploymentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppDeploymentResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppDeploymentResource>, System.Collections.IEnumerable
    {
        protected AppDeploymentResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.AppPlatform.AppDeploymentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.AppPlatform.AppDeploymentResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppDeploymentResource> GetAll(System.Collections.Generic.IEnumerable<string> version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppDeploymentResource> GetAllAsync(System.Collections.Generic.IEnumerable<string> version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppDeploymentResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AppDeploymentResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformSku Sku { get { throw null; } set { } }
    }
    public partial class AppPlatformAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppPlatformAppResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppPlatformAppResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string appName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> Get(string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppDeploymentResource> GetAppDeploymentResource(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppDeploymentResource>> GetAppDeploymentResourceAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppDeploymentResourceCollection GetAppDeploymentResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> GetAppPlatformCustomDomainResource(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>> GetAppPlatformCustomDomainResourceAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResourceCollection GetAppPlatformCustomDomainResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>> GetAsync(string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.BindingResource> GetBindingResource(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.BindingResource>> GetBindingResourceAsync(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.BindingResourceCollection GetBindingResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.ResourceUploadResult> GetResourceUploadUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.ResourceUploadResult>> GetResourceUploadUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> SetActiveDeployments(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.ActiveDeploymentList activeDeploymentCollection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>> SetActiveDeploymentsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.ActiveDeploymentList activeDeploymentCollection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppPlatformAppResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppPlatformAppResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.CustomDomainValidateResult> ValidateDomain(Azure.ResourceManager.AppPlatform.Models.CustomDomainValidatePayload validatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.CustomDomainValidateResult>> ValidateDomainAsync(Azure.ResourceManager.AppPlatform.Models.CustomDomainValidatePayload validatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppPlatformAppResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>, System.Collections.IEnumerable
    {
        protected AppPlatformAppResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string appName, Azure.ResourceManager.AppPlatform.AppPlatformAppResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string appName, Azure.ResourceManager.AppPlatform.AppPlatformAppResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string appName, string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appName, string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> Get(string appName, string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>> GetAsync(string appName, string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppPlatformAppResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AppPlatformAppResourceData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class AppPlatformCustomDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppPlatformCustomDomainResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string appName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppPlatformCustomDomainResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>, System.Collections.IEnumerable
    {
        protected AppPlatformCustomDomainResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppPlatformCustomDomainResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public AppPlatformCustomDomainResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.CustomDomainProperties Properties { get { throw null; } set { } }
    }
    public static partial class AppPlatformExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppPlatform.Models.ServiceNameAvailabilityResult> CheckServiceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppPlatform.Models.ServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.ServiceNameAvailabilityResult>> CheckServiceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AppPlatform.Models.ServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppPlatform.ApiPortalCustomDomainResource GetApiPortalCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.ApiPortalResource GetApiPortalResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppBuilderResource GetAppBuilderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppBuildResource GetAppBuildResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppBuildResultResource GetAppBuildResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppBuildServiceAgentPoolResource GetAppBuildServiceAgentPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppBuildServiceResource GetAppBuildServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppDeploymentResource GetAppDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppPlatformAppResource GetAppPlatformAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppPlatformCustomDomainResource GetAppPlatformCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppPlatformServiceResource GetAppPlatformServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> GetAppPlatformServiceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> GetAppPlatformServiceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppPlatform.AppPlatformServiceResourceCollection GetAppPlatformServiceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> GetAppPlatformServiceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> GetAppPlatformServiceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppPlatform.BindingResource GetBindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.BuildpackBindingResource GetBuildpackBindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.CertificateResource GetCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.ConfigServerResource GetConfigServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.ConfigurationServiceResource GetConfigurationServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource GetGatewayCustomDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.GatewayResource GetGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource GetGatewayRouteConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.MonitoringSettingResource GetMonitoringSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeVersion> GetRuntimeVersionsRuntimeVersions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeVersion> GetRuntimeVersionsRuntimeVersionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppPlatform.ServiceRegistryResource GetServiceRegistryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppPlatform.Models.AvailableAppPlatformSku> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.Models.AvailableAppPlatformSku> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppPlatform.StorageResource GetStorageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.SupportedBuildpackResource GetSupportedBuildpackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppPlatform.SupportedStackResource GetSupportedStackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class AppPlatformServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppPlatformServiceResource() { }
        public virtual Azure.ResourceManager.AppPlatform.AppPlatformServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DisableTestEndpoint(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableTestEndpointAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.TestKeys> EnableTestEndpoint(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.TestKeys>> EnableTestEndpointAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalResource> GetApiPortalResource(string apiPortalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ApiPortalResource>> GetApiPortalResourceAsync(string apiPortalName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.ApiPortalResourceCollection GetApiPortalResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceResource> GetAppBuildService(string buildServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppBuildServiceResource>> GetAppBuildServiceAsync(string buildServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppBuildServiceCollection GetAppBuildServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformAppResource> GetAppPlatformAppResource(string appName, string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformAppResource>> GetAppPlatformAppResourceAsync(string appName, string syncStatus = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.AppPlatformAppResourceCollection GetAppPlatformAppResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.CertificateResource> GetCertificateResource(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.CertificateResource>> GetCertificateResourceAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.CertificateResourceCollection GetCertificateResources() { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.ConfigServerResource GetConfigServerResource() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> GetConfigurationServiceResource(string configurationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>> GetConfigurationServiceResourceAsync(string configurationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.ConfigurationServiceResourceCollection GetConfigurationServiceResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppDeploymentResource> GetForClusterDeployments(System.Collections.Generic.IEnumerable<string> version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppDeploymentResource> GetForClusterDeploymentsAsync(System.Collections.Generic.IEnumerable<string> version = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayResource> GetGatewayResource(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayResource>> GetGatewayResourceAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.GatewayResourceCollection GetGatewayResources() { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.MonitoringSettingResource GetMonitoringSettingResource() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> GetServiceRegistryResource(string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>> GetServiceRegistryResourceAsync(string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.ServiceRegistryResourceCollection GetServiceRegistryResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.StorageResource> GetStorageResource(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.StorageResource>> GetStorageResourceAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.StorageResourceCollection GetStorageResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.TestKeys> GetTestKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.TestKeys>> GetTestKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.TestKeys> RegenerateTestKey(Azure.ResourceManager.AppPlatform.Models.RegenerateTestKeyRequestPayload regenerateTestKeyRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.TestKeys>> RegenerateTestKeyAsync(Azure.ResourceManager.AppPlatform.Models.RegenerateTestKeyRequestPayload regenerateTestKeyRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppPlatformServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.AppPlatformServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.Models.ConfigServerSettingsValidateResult> ValidateConfigServer(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.ConfigServerSettings configServerSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.Models.ConfigServerSettingsValidateResult>> ValidateConfigServerAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.ConfigServerSettings configServerSettings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppPlatformServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>, System.Collections.IEnumerable
    {
        protected AppPlatformServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.AppPlatform.AppPlatformServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceName, Azure.ResourceManager.AppPlatform.AppPlatformServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> Get(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>> GetAsync(string serviceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.AppPlatformServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppPlatformServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AppPlatformServiceResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.AppPlatform.Models.ClusterResourceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformSku Sku { get { throw null; } set { } }
    }
    public partial class BindingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BindingResource() { }
        public virtual Azure.ResourceManager.AppPlatform.BindingResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string appName, string bindingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.BindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.BindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BindingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.BindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BindingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.BindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BindingResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.BindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.BindingResource>, System.Collections.IEnumerable
    {
        protected BindingResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BindingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bindingName, Azure.ResourceManager.AppPlatform.BindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BindingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bindingName, Azure.ResourceManager.AppPlatform.BindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.BindingResource> Get(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.BindingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.BindingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.BindingResource>> GetAsync(string bindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.BindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.BindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.BindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.BindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BindingResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BindingResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.BindingResourceProperties Properties { get { throw null; } set { } }
    }
    public partial class BuildpackBindingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BuildpackBindingResource() { }
        public virtual Azure.ResourceManager.AppPlatform.BuildpackBindingResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName, string builderName, string buildpackBindingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.BuildpackBindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.BuildpackBindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BuildpackBindingResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>, System.Collections.IEnumerable
    {
        protected BuildpackBindingResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string buildpackBindingName, Azure.ResourceManager.AppPlatform.BuildpackBindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string buildpackBindingName, Azure.ResourceManager.AppPlatform.BuildpackBindingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string buildpackBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildpackBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> Get(string buildpackBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>> GetAsync(string buildpackBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.BuildpackBindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.BuildpackBindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BuildpackBindingResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public BuildpackBindingResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProperties Properties { get { throw null; } set { } }
    }
    public partial class CertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CertificateResource() { }
        public virtual Azure.ResourceManager.AppPlatform.CertificateResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.CertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.CertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.CertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.CertificateResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.CertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.CertificateResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CertificateResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.CertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.CertificateResource>, System.Collections.IEnumerable
    {
        protected CertificateResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.CertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.AppPlatform.CertificateResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.CertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.AppPlatform.CertificateResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.CertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.CertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.CertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.CertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.CertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.CertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.CertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.CertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CertificateResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public CertificateResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.CertificateProperties Properties { get { throw null; } set { } }
    }
    public partial class ConfigServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigServerResource() { }
        public virtual Azure.ResourceManager.AppPlatform.ConfigServerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ConfigServerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ConfigServerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ConfigServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ConfigServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ConfigServerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ConfigServerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigServerResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigServerResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.ConfigServerProperties Properties { get { throw null; } set { } }
    }
    public partial class ConfigurationServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigurationServiceResource() { }
        public virtual Azure.ResourceManager.AppPlatform.ConfigurationServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string configurationServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ConfigurationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.ConfigurationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceSettingsValidateResult> Validate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceSettings settings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceSettingsValidateResult>> ValidateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceSettings settings, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>, System.Collections.IEnumerable
    {
        protected ConfigurationServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationServiceName, Azure.ResourceManager.AppPlatform.ConfigurationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationServiceName, Azure.ResourceManager.AppPlatform.ConfigurationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> Get(string configurationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>> GetAsync(string configurationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ConfigurationServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigurationServiceResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ConfigurationServiceResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProperties Properties { get { throw null; } set { } }
    }
    public partial class GatewayCustomDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GatewayCustomDomainResource() { }
        public virtual Azure.ResourceManager.AppPlatform.GatewayCustomDomainResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.GatewayCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.GatewayCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayCustomDomainResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>, System.Collections.IEnumerable
    {
        protected GatewayCustomDomainResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppPlatform.GatewayCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.AppPlatform.GatewayCustomDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayCustomDomainResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public GatewayCustomDomainResourceData() { }
        public string GatewayCustomDomainThumbprint { get { throw null; } set { } }
    }
    public partial class GatewayResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GatewayResource() { }
        public virtual Azure.ResourceManager.AppPlatform.GatewayResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource> GetGatewayCustomDomainResource(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayCustomDomainResource>> GetGatewayCustomDomainResourceAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.GatewayCustomDomainResourceCollection GetGatewayCustomDomainResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> GetGatewayRouteConfigResource(string routeConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>> GetGatewayRouteConfigResourceAsync(string routeConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppPlatform.GatewayRouteConfigResourceCollection GetGatewayRouteConfigResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.GatewayResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.GatewayResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.Models.CustomDomainValidateResult> ValidateDomain(Azure.ResourceManager.AppPlatform.Models.CustomDomainValidatePayload validatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.Models.CustomDomainValidateResult>> ValidateDomainAsync(Azure.ResourceManager.AppPlatform.Models.CustomDomainValidatePayload validatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.GatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.GatewayResource>, System.Collections.IEnumerable
    {
        protected GatewayResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppPlatform.GatewayResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.AppPlatform.GatewayResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.GatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.GatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.GatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.GatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.GatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.GatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public GatewayResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.GatewayProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformSku Sku { get { throw null; } set { } }
    }
    public partial class GatewayRouteConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GatewayRouteConfigResource() { }
        public virtual Azure.ResourceManager.AppPlatform.GatewayRouteConfigResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string gatewayName, string routeConfigName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.GatewayRouteConfigResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.GatewayRouteConfigResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GatewayRouteConfigResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>, System.Collections.IEnumerable
    {
        protected GatewayRouteConfigResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string routeConfigName, Azure.ResourceManager.AppPlatform.GatewayRouteConfigResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string routeConfigName, Azure.ResourceManager.AppPlatform.GatewayRouteConfigResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string routeConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string routeConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> Get(string routeConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>> GetAsync(string routeConfigName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.GatewayRouteConfigResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayRouteConfigResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public GatewayRouteConfigResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.GatewayRouteConfigProperties Properties { get { throw null; } set { } }
    }
    public partial class MonitoringSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitoringSettingResource() { }
        public virtual Azure.ResourceManager.AppPlatform.MonitoringSettingResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.MonitoringSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.MonitoringSettingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.MonitoringSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.MonitoringSettingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.MonitoringSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.MonitoringSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.MonitoringSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.MonitoringSettingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.MonitoringSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.MonitoringSettingResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MonitoringSettingResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public MonitoringSettingResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.MonitoringSettingProperties Properties { get { throw null; } set { } }
    }
    public partial class ServiceRegistryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceRegistryResource() { }
        public virtual Azure.ResourceManager.AppPlatform.ServiceRegistryResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string serviceRegistryName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceRegistryResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>, System.Collections.IEnumerable
    {
        protected ServiceRegistryResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> Get(string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>> GetAsync(string serviceRegistryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.ServiceRegistryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.ServiceRegistryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceRegistryResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public ServiceRegistryResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProperties Properties { get { throw null; } set { } }
    }
    public partial class StorageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageResource() { }
        public virtual Azure.ResourceManager.AppPlatform.StorageResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string storageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.StorageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.StorageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.StorageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.StorageResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.StorageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppPlatform.StorageResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.StorageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.StorageResource>, System.Collections.IEnumerable
    {
        protected StorageResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.StorageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.AppPlatform.StorageResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppPlatform.StorageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageName, Azure.ResourceManager.AppPlatform.StorageResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.StorageResource> Get(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.StorageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.StorageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.StorageResource>> GetAsync(string storageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.StorageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.StorageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.StorageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.StorageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public StorageResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.StorageProperties Properties { get { throw null; } set { } }
    }
    public partial class SupportedBuildpackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportedBuildpackResource() { }
        public virtual Azure.ResourceManager.AppPlatform.SupportedBuildpackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName, string buildpackName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportedBuildpackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource>, System.Collections.IEnumerable
    {
        protected SupportedBuildpackResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string buildpackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string buildpackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource> Get(string buildpackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource>> GetAsync(string buildpackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.SupportedBuildpackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportedBuildpackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SupportedBuildpackResourceData() { }
        public string SupportedBuildpackId { get { throw null; } set { } }
    }
    public partial class SupportedStackResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupportedStackResource() { }
        public virtual Azure.ResourceManager.AppPlatform.SupportedStackResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string buildServiceName, string stackName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.SupportedStackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.SupportedStackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupportedStackResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.SupportedStackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.SupportedStackResource>, System.Collections.IEnumerable
    {
        protected SupportedStackResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string stackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string stackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppPlatform.SupportedStackResource> Get(string stackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppPlatform.SupportedStackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppPlatform.SupportedStackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppPlatform.SupportedStackResource>> GetAsync(string stackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppPlatform.SupportedStackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppPlatform.SupportedStackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppPlatform.SupportedStackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppPlatform.SupportedStackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupportedStackResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SupportedStackResourceData() { }
        public Azure.ResourceManager.AppPlatform.Models.SupportedStackResourceProperties Properties { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.AppPlatform.Models
{
    public partial class ActiveDeploymentList
    {
        public ActiveDeploymentList() { }
        public System.Collections.Generic.IList<string> ActiveDeploymentNames { get { throw null; } }
    }
    public partial class ApiPortalInstance
    {
        internal ApiPortalInstance() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ApiPortalProperties
    {
        public ApiPortalProperties() { }
        public System.Collections.Generic.IList<string> GatewayIds { get { throw null; } }
        public bool? HttpsOnly { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.ApiPortalInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Public { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.ApiPortalResourceRequests ResourceRequests { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> SourceUris { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.SsoProperties SsoProperties { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiPortalProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiPortalProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ApiPortalProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiPortalResourceRequests
    {
        internal ApiPortalResourceRequests() { }
        public string Cpu { get { throw null; } }
        public string Memory { get { throw null; } }
    }
    public partial class AppBuilderProperties
    {
        public AppBuilderProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppPlatform.Models.BuildpacksGroupProperties> BuildpackGroups { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.StackProperties Stack { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppBuilderProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppBuilderProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState left, Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState left, Azure.ResourceManager.AppPlatform.Models.AppBuilderProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppBuildProperties
    {
        public AppBuildProperties() { }
        public string AgentPool { get { throw null; } set { } }
        public string Builder { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Env { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState? ProvisioningState { get { throw null; } }
        public string RelativePath { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TriggeredBuildResultId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppBuildProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppBuildProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState left, Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState left, Azure.ResourceManager.AppPlatform.Models.AppBuildProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppPlatformErrorInfo
    {
        public AppPlatformErrorInfo() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class AppPlatformResourceSkuCapabilities
    {
        internal AppPlatformResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppPlatformResourceSkuRestrictionsReasonCode : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppPlatformResourceSkuRestrictionsReasonCode(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode left, Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppPlatformResourceSkuRestrictionsType : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppPlatformResourceSkuRestrictionsType(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType Location { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType Zone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType left, Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType left, Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppPlatformResourceSkuZoneDetails
    {
        internal AppPlatformResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    public partial class AppPlatformSku
    {
        public AppPlatformSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class AppResourceProperties
    {
        public AppResourceProperties() { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> AddonConfigs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppPlatform.Models.CustomPersistentDiskData> CustomPersistentDisks { get { throw null; } }
        public bool? EnableEndToEndTls { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public bool? HttpsOnly { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppPlatform.Models.LoadedCertificate> LoadedCertificates { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.PersistentDisk PersistentDisk { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Public { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.TemporaryDisk TemporaryDisk { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppResourceProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.AppResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailableAppPlatformSku
    {
        internal AvailableAppPlatformSku() { }
        public Azure.ResourceManager.AppPlatform.Models.SkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class AzureFileVolume : Azure.ResourceManager.AppPlatform.Models.CustomPersistentDiskProperties
    {
        public AzureFileVolume(string mountPath, string shareName) : base (default(string)) { }
        public string ShareName { get { throw null; } set { } }
    }
    public partial class BindingResourceProperties
    {
        public BindingResourceProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> BindingParameters { get { throw null; } }
        public string CreatedAt { get { throw null; } }
        public string GeneratedProperties { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string UpdatedAt { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BindingType : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.BindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BindingType(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.BindingType ApacheSkyWalking { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BindingType AppDynamics { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BindingType ApplicationInsights { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BindingType Dynatrace { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BindingType ElasticApm { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BindingType NewRelic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.BindingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.BindingType left, Azure.ResourceManager.AppPlatform.Models.BindingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.BindingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.BindingType left, Azure.ResourceManager.AppPlatform.Models.BindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildpackBindingLaunchProperties
    {
        public BuildpackBindingLaunchProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Secrets { get { throw null; } }
    }
    public partial class BuildpackBindingProperties
    {
        public BuildpackBindingProperties() { }
        public Azure.ResourceManager.AppPlatform.Models.BindingType? BindingType { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.BuildpackBindingLaunchProperties LaunchProperties { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BuildpackBindingProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BuildpackBindingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState left, Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState left, Azure.ResourceManager.AppPlatform.Models.BuildpackBindingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildpacksGroupProperties
    {
        public BuildpacksGroupProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Buildpacks { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class BuildResultLog
    {
        internal BuildResultLog() { }
        public System.Uri BlobUri { get { throw null; } }
    }
    public partial class BuildResultProperties
    {
        public BuildResultProperties() { }
        public string BuildPodName { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.BuildStageProperties> BuildStages { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BuildResultProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BuildResultProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState Building { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState Queuing { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState left, Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState left, Azure.ResourceManager.AppPlatform.Models.BuildResultProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildResultUserSourceInfo : Azure.ResourceManager.AppPlatform.Models.UserSourceInfo
    {
        public BuildResultUserSourceInfo() { }
        public string BuildResultId { get { throw null; } set { } }
    }
    public partial class BuildServiceAgentPoolProperties
    {
        public BuildServiceAgentPoolProperties() { }
        public Azure.ResourceManager.AppPlatform.Models.BuildServiceAgentPoolSizeProperties PoolSize { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class BuildServiceAgentPoolSizeProperties
    {
        public BuildServiceAgentPoolSizeProperties() { }
        public string Cpu { get { throw null; } }
        public string Memory { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class BuildServiceProperties
    {
        public BuildServiceProperties() { }
        public string KPackVersion { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.BuildServicePropertiesResourceRequests ResourceRequests { get { throw null; } set { } }
    }
    public partial class BuildServicePropertiesResourceRequests
    {
        public BuildServicePropertiesResourceRequests() { }
        public string Cpu { get { throw null; } }
        public string Memory { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BuildServiceProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BuildServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.BuildServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BuildStageProperties
    {
        internal BuildStageProperties() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState? Status { get { throw null; } }
    }
    public abstract partial class CertificateProperties
    {
        protected CertificateProperties() { }
        public string ActivateDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DnsNames { get { throw null; } }
        public string ExpirationDate { get { throw null; } }
        public string IssuedDate { get { throw null; } }
        public string Issuer { get { throw null; } }
        public string SubjectName { get { throw null; } }
        public string Thumbprint { get { throw null; } }
    }
    public partial class ClusterResourceProperties
    {
        public ClusterResourceProperties() { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.PowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceId { get { throw null; } }
        public int? Version { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class ConfigServerGitProperty
    {
        public ConfigServerGitProperty(System.Uri uri) { }
        public string HostKey { get { throw null; } set { } }
        public string HostKeyAlgorithm { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppPlatform.Models.GitPatternRepository> Repositories { get { throw null; } }
        public System.Collections.Generic.IList<string> SearchPaths { get { throw null; } }
        public bool? StrictHostKeyChecking { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class ConfigServerProperties
    {
        public ConfigServerProperties() { }
        public Azure.ResourceManager.AppPlatform.Models.ConfigServerGitProperty ConfigServerGitProperty { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformErrorInfo Error { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.ConfigServerState? ProvisioningState { get { throw null; } }
    }
    public partial class ConfigServerSettings
    {
        public ConfigServerSettings() { }
        public Azure.ResourceManager.AppPlatform.Models.ConfigServerGitProperty GitProperty { get { throw null; } set { } }
    }
    public partial class ConfigServerSettingsErrorRecord
    {
        internal ConfigServerSettingsErrorRecord() { }
        public System.Collections.Generic.IReadOnlyList<string> Messages { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class ConfigServerSettingsValidateResult
    {
        internal ConfigServerSettingsValidateResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.ConfigServerSettingsErrorRecord> Details { get { throw null; } }
        public bool? IsValid { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigServerState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.ConfigServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigServerState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigServerState Deleted { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigServerState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigServerState NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigServerState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigServerState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.ConfigServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.ConfigServerState left, Azure.ResourceManager.AppPlatform.Models.ConfigServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.ConfigServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.ConfigServerState left, Azure.ResourceManager.AppPlatform.Models.ConfigServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationServiceGitPropertyValidateResult
    {
        internal ConfigurationServiceGitPropertyValidateResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.ValidationMessages> GitReposValidationResult { get { throw null; } }
        public bool? IsValid { get { throw null; } }
    }
    public partial class ConfigurationServiceGitRepository
    {
        public ConfigurationServiceGitRepository(string name, System.Collections.Generic.IEnumerable<string> patterns, System.Uri uri, string label) { }
        public string HostKey { get { throw null; } set { } }
        public string HostKeyAlgorithm { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        public string PrivateKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchPaths { get { throw null; } }
        public bool? StrictHostKeyChecking { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class ConfigurationServiceInstance
    {
        internal ConfigurationServiceInstance() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ConfigurationServiceProperties
    {
        public ConfigurationServiceProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceGitRepository> GitPropertyRepositories { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceResourceRequests ResourceRequests { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationServiceProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigurationServiceResourceRequests
    {
        internal ConfigurationServiceResourceRequests() { }
        public string Cpu { get { throw null; } }
        public int? InstanceCount { get { throw null; } }
        public string Memory { get { throw null; } }
    }
    public partial class ConfigurationServiceSettings
    {
        public ConfigurationServiceSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceGitRepository> GitPropertyRepositories { get { throw null; } }
    }
    public partial class ConfigurationServiceSettingsValidateResult
    {
        internal ConfigurationServiceSettingsValidateResult() { }
        public Azure.ResourceManager.AppPlatform.Models.ConfigurationServiceGitPropertyValidateResult GitPropertyValidationResult { get { throw null; } }
    }
    public partial class ContentCertificateProperties : Azure.ResourceManager.AppPlatform.Models.CertificateProperties
    {
        public ContentCertificateProperties() { }
        public string Content { get { throw null; } set { } }
    }
    public partial class CustomContainer
    {
        public CustomContainer() { }
        public System.Collections.Generic.IList<string> Args { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public string ContainerImage { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.ImageRegistryCredential ImageRegistryCredential { get { throw null; } set { } }
        public string LanguageFramework { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
    }
    public partial class CustomContainerUserSourceInfo : Azure.ResourceManager.AppPlatform.Models.UserSourceInfo
    {
        public CustomContainerUserSourceInfo() { }
        public Azure.ResourceManager.AppPlatform.Models.CustomContainer CustomContainer { get { throw null; } set { } }
    }
    public partial class CustomDomainProperties
    {
        public CustomDomainProperties() { }
        public string AppName { get { throw null; } }
        public string CertName { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class CustomDomainValidatePayload
    {
        public CustomDomainValidatePayload(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class CustomDomainValidateResult
    {
        internal CustomDomainValidateResult() { }
        public bool? IsValid { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class CustomPersistentDiskData
    {
        public CustomPersistentDiskData(string storageId) { }
        public Azure.ResourceManager.AppPlatform.Models.CustomPersistentDiskProperties CustomPersistentDiskProperties { get { throw null; } set { } }
        public string StorageId { get { throw null; } set { } }
    }
    public abstract partial class CustomPersistentDiskProperties
    {
        protected CustomPersistentDiskProperties(string mountPath) { }
        public System.Collections.Generic.IList<string> MountOptions { get { throw null; } }
        public string MountPath { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
    }
    public partial class DeploymentInstance
    {
        internal DeploymentInstance() { }
        public string DiscoveryStatus { get { throw null; } }
        public string Name { get { throw null; } }
        public string Reason { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
        public string Zone { get { throw null; } }
    }
    public partial class DeploymentResourceProperties
    {
        public DeploymentResourceProperties() { }
        public bool? Active { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.DeploymentSettings DeploymentSettings { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.DeploymentInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.UserSourceInfo Source { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentResourceProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState left, Azure.ResourceManager.AppPlatform.Models.DeploymentResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentResourceStatus : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus Running { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus left, Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus left, Azure.ResourceManager.AppPlatform.Models.DeploymentResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentSettings
    {
        public DeploymentSettings() { }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.BinaryData>> AddonConfigs { get { throw null; } }
        public bool? DisableProbe { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ResourceRequests ResourceRequests { get { throw null; } set { } }
    }
    public partial class DiagnosticContent
    {
        public DiagnosticContent() { }
        public string AppInstance { get { throw null; } set { } }
        public string DurationValue { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
    }
    public partial class GatewayApiMetadataProperties
    {
        public GatewayApiMetadataProperties() { }
        public string Description { get { throw null; } set { } }
        public string Documentation { get { throw null; } set { } }
        public System.Uri ServerUri { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class GatewayApiRoute
    {
        public GatewayApiRoute() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Filters { get { throw null; } }
        public int? Order { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Predicates { get { throw null; } }
        public bool? SsoEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public bool? TokenRelay { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class GatewayCorsProperties
    {
        public GatewayCorsProperties() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowedHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public System.Collections.Generic.IList<string> ExposedHeaders { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
    }
    public partial class GatewayInstance
    {
        internal GatewayInstance() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class GatewayOperatorProperties
    {
        internal GatewayOperatorProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.GatewayInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.GatewayOperatorResourceRequests ResourceRequests { get { throw null; } }
    }
    public partial class GatewayOperatorResourceRequests
    {
        internal GatewayOperatorResourceRequests() { }
        public string Cpu { get { throw null; } }
        public int? InstanceCount { get { throw null; } }
        public string Memory { get { throw null; } }
    }
    public partial class GatewayProperties
    {
        public GatewayProperties() { }
        public Azure.ResourceManager.AppPlatform.Models.GatewayApiMetadataProperties ApiMetadataProperties { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.GatewayCorsProperties CorsProperties { get { throw null; } set { } }
        public bool? HttpsOnly { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.GatewayInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.GatewayOperatorProperties OperatorProperties { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState? ProvisioningState { get { throw null; } }
        public bool? Public { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.GatewayResourceRequests ResourceRequests { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.SsoProperties SsoProperties { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GatewayProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GatewayProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState left, Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState left, Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayResourceRequests
    {
        public GatewayResourceRequests() { }
        public string Cpu { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
    }
    public partial class GatewayRouteConfigProperties
    {
        public GatewayRouteConfigProperties() { }
        public string AppResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.GatewayProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppPlatform.Models.GatewayApiRoute> Routes { get { throw null; } }
    }
    public partial class GitPatternRepository
    {
        public GitPatternRepository(string name, System.Uri uri) { }
        public string HostKey { get { throw null; } set { } }
        public string HostKeyAlgorithm { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Pattern { get { throw null; } }
        public string PrivateKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SearchPaths { get { throw null; } }
        public bool? StrictHostKeyChecking { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class ImageRegistryCredential
    {
        public ImageRegistryCredential() { }
        public string Password { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class JarUploadedUserSourceInfo : Azure.ResourceManager.AppPlatform.Models.UploadedUserSourceInfo
    {
        public JarUploadedUserSourceInfo() { }
        public string JvmOptions { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public partial class KeyVaultCertificateProperties : Azure.ResourceManager.AppPlatform.Models.CertificateProperties
    {
        public KeyVaultCertificateProperties(System.Uri vaultUri, string keyVaultCertName) { }
        public string CertVersion { get { throw null; } set { } }
        public bool? ExcludePrivateKey { get { throw null; } set { } }
        public string KeyVaultCertName { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KPackBuildStageProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KPackBuildStageProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState left, Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState left, Azure.ResourceManager.AppPlatform.Models.KPackBuildStageProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadedCertificate
    {
        public LoadedCertificate(Azure.Core.ResourceIdentifier resourceId) { }
        public bool? LoadTrustStore { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public partial class LogFileUriResult
    {
        internal LogFileUriResult() { }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class MonitoringSettingProperties
    {
        public MonitoringSettingProperties() { }
        public string AppInsightsAgentVersionsJava { get { throw null; } }
        public string AppInsightsInstrumentationKey { get { throw null; } set { } }
        public double? AppInsightsSamplingRate { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformErrorInfo Error { get { throw null; } set { } }
        public Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState? ProvisioningState { get { throw null; } }
        public bool? TraceEnabled { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitoringSettingState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitoringSettingState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState left, Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState left, Azure.ResourceManager.AppPlatform.Models.MonitoringSettingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetCoreZipUploadedUserSourceInfo : Azure.ResourceManager.AppPlatform.Models.UploadedUserSourceInfo
    {
        public NetCoreZipUploadedUserSourceInfo() { }
        public string NetCoreMainEntryPath { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public partial class NetworkProfile
    {
        public NetworkProfile() { }
        public string AppNetworkResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AppSubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundPublicIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.RequiredTraffic> RequiredTraffics { get { throw null; } }
        public string ServiceCidr { get { throw null; } set { } }
        public string ServiceRuntimeNetworkResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ServiceRuntimeSubnetId { get { throw null; } set { } }
    }
    public partial class PersistentDisk
    {
        public PersistentDisk() { }
        public string MountPath { get { throw null; } set { } }
        public int? SizeInGB { get { throw null; } set { } }
        public int? UsedInGB { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PowerState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.PowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PowerState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.PowerState Running { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.PowerState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.PowerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.PowerState left, Azure.ResourceManager.AppPlatform.Models.PowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.PowerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.PowerState left, Azure.ResourceManager.AppPlatform.Models.PowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Moved { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState MoveFailed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Starting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Stopping { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.ProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.ProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateTestKeyRequestPayload
    {
        public RegenerateTestKeyRequestPayload(Azure.ResourceManager.AppPlatform.Models.TestKeyType keyType) { }
        public Azure.ResourceManager.AppPlatform.Models.TestKeyType KeyType { get { throw null; } }
    }
    public partial class RequiredTraffic
    {
        internal RequiredTraffic() { }
        public Azure.ResourceManager.AppPlatform.Models.TrafficDirection? Direction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Fqdns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPs { get { throw null; } }
        public int? Port { get { throw null; } }
        public string Protocol { get { throw null; } }
    }
    public partial class ResourceRequests
    {
        public ResourceRequests() { }
        public string Cpu { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
    }
    public partial class ResourceSkuLocationInfo
    {
        internal ResourceSkuLocationInfo() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictionInfo
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    public partial class ResourceSkuRestrictions
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.AppPlatformResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    public partial class ResourceUploadResult
    {
        internal ResourceUploadResult() { }
        public string RelativePath { get { throw null; } }
        public System.Uri UploadUri { get { throw null; } }
    }
    public partial class ServiceNameAvailabilityContent
    {
        public ServiceNameAvailabilityContent(string resourceType, string name) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ServiceNameAvailabilityResult
    {
        internal ServiceNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class ServiceRegistryInstance
    {
        internal ServiceRegistryInstance() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ServiceRegistryProperties
    {
        public ServiceRegistryProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppPlatform.Models.ServiceRegistryInstance> Instances { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.ServiceRegistryResourceRequests ResourceRequests { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceRegistryProvisioningState : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceRegistryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState left, Azure.ResourceManager.AppPlatform.Models.ServiceRegistryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceRegistryResourceRequests
    {
        internal ServiceRegistryResourceRequests() { }
        public string Cpu { get { throw null; } }
        public int? InstanceCount { get { throw null; } }
        public string Memory { get { throw null; } }
    }
    public partial class SkuCapacity
    {
        internal SkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int Minimum { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.SkuScaleType? ScaleType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuScaleType : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.SkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.SkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.SkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.SkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.SkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.SkuScaleType left, Azure.ResourceManager.AppPlatform.Models.SkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.SkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.SkuScaleType left, Azure.ResourceManager.AppPlatform.Models.SkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SourceUploadedUserSourceInfo : Azure.ResourceManager.AppPlatform.Models.UploadedUserSourceInfo
    {
        public SourceUploadedUserSourceInfo() { }
        public string ArtifactSelector { get { throw null; } set { } }
        public string RuntimeVersion { get { throw null; } set { } }
    }
    public partial class SsoProperties
    {
        public SsoProperties() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        public System.Uri IssuerUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Scope { get { throw null; } }
    }
    public partial class StackProperties
    {
        public StackProperties() { }
        public string Id { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class StorageAccount : Azure.ResourceManager.AppPlatform.Models.StorageProperties
    {
        public StorageAccount(string accountName, string accountKey) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
    }
    public abstract partial class StorageProperties
    {
        protected StorageProperties() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportedRuntimePlatform : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedRuntimePlatform(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform Java { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform NetCore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform left, Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform left, Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportedRuntimeValue : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportedRuntimeValue(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue Java11 { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue Java17 { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue Java8 { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue NetCore31 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue left, Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue left, Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportedRuntimeVersion
    {
        internal SupportedRuntimeVersion() { }
        public Azure.ResourceManager.AppPlatform.Models.SupportedRuntimePlatform? Platform { get { throw null; } }
        public Azure.ResourceManager.AppPlatform.Models.SupportedRuntimeValue? Value { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SupportedStackResourceProperties
    {
        public SupportedStackResourceProperties() { }
        public string StackId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class TemporaryDisk
    {
        public TemporaryDisk() { }
        public string MountPath { get { throw null; } set { } }
        public int? SizeInGB { get { throw null; } set { } }
    }
    public partial class TestKeys
    {
        internal TestKeys() { }
        public bool? Enabled { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string PrimaryTestEndpoint { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        public string SecondaryTestEndpoint { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestKeyType : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.TestKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestKeyType(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.TestKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.TestKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.TestKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.TestKeyType left, Azure.ResourceManager.AppPlatform.Models.TestKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.TestKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.TestKeyType left, Azure.ResourceManager.AppPlatform.Models.TestKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficDirection : System.IEquatable<Azure.ResourceManager.AppPlatform.Models.TrafficDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficDirection(string value) { throw null; }
        public static Azure.ResourceManager.AppPlatform.Models.TrafficDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.AppPlatform.Models.TrafficDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppPlatform.Models.TrafficDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppPlatform.Models.TrafficDirection left, Azure.ResourceManager.AppPlatform.Models.TrafficDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppPlatform.Models.TrafficDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppPlatform.Models.TrafficDirection left, Azure.ResourceManager.AppPlatform.Models.TrafficDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UploadedUserSourceInfo : Azure.ResourceManager.AppPlatform.Models.UserSourceInfo
    {
        public UploadedUserSourceInfo() { }
        public string RelativePath { get { throw null; } set { } }
    }
    public abstract partial class UserSourceInfo
    {
        protected UserSourceInfo() { }
        public string Version { get { throw null; } set { } }
    }
    public partial class ValidationMessages
    {
        internal ValidationMessages() { }
        public System.Collections.Generic.IReadOnlyList<string> Messages { get { throw null; } }
        public string Name { get { throw null; } }
    }
}
