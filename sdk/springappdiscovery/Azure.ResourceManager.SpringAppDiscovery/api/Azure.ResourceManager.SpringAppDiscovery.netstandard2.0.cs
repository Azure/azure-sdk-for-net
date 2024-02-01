namespace Azure.ResourceManager.SpringAppDiscovery
{
    public static partial class SpringAppDiscoveryExtensions
    {
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource GetSpringBootAppResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetSpringBootApps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetSpringBootAppsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource GetSpringBootServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetSpringBootServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetSpringBootServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetSpringBootSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> GetSpringBootSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource GetSpringBootSiteErrorSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource GetSpringBootSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteCollection GetSpringBootSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetSpringBootSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetSpringBootSitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource GetSpringBootSiteSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SpringBootAppCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>, System.Collections.IEnumerable
    {
        protected SpringBootAppCollection() { }
        public virtual Azure.Response<bool> Exists(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> Get(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> GetAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetIfExists(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> GetIfExistsAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringBootAppData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData>
    {
        public SpringBootAppData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootAppResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringBootAppResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string springbootappsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpringBootServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>, System.Collections.IEnumerable
    {
        protected SpringBootServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string springbootserversName, Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string springbootserversName, Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> Get(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> GetAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetIfExists(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> GetIfExistsAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringBootServerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData>
    {
        public SpringBootServerData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringBootServerResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string springbootserversName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpringBootSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>, System.Collections.IEnumerable
    {
        protected SpringBootSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string springbootsitesName, Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string springbootsitesName, Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> Get(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> GetAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetIfExists(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> GetIfExistsAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringBootSiteData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData>
    {
        public SpringBootSiteData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteErrorSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>, System.Collections.IEnumerable
    {
        protected SpringBootSiteErrorSummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> Get(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>> GetAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> GetIfExists(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>> GetIfExistsAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringBootSiteErrorSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData>
    {
        public SpringBootSiteErrorSummaryData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteErrorSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringBootSiteErrorSummaryResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string errorSummaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpringBootSiteResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringBootSiteResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string springbootsitesName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetSpringBootApp(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource>> GetSpringBootAppAsync(string springbootappsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootAppCollection GetSpringBootApps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetSpringBootServer(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource>> GetSpringBootServerAsync(string springbootserversName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootServerCollection GetSpringBootServers() { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryCollection GetSpringBootSiteErrorSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource> GetSpringBootSiteErrorSummary(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource>> GetSpringBootSiteErrorSummaryAsync(string errorSummaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryCollection GetSpringBootSiteSummaries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> GetSpringBootSiteSummary(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>> GetSpringBootSiteSummaryAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRefreshSite(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRefreshSiteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpringBootSiteSummaryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>, System.Collections.IEnumerable
    {
        protected SpringBootSiteSummaryCollection() { }
        public virtual Azure.Response<bool> Exists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> Get(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>> GetAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> GetIfExists(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>> GetIfExistsAsync(string summaryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpringBootSiteSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData>
    {
        public SpringBootSiteSummaryData() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteSummaryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpringBootSiteSummaryResource() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName, string summaryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SpringAppDiscovery.Mocking
{
    public partial class MockableSpringAppDiscoveryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSpringAppDiscoveryArmClient() { }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource GetSpringBootAppResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource GetSpringBootServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryResource GetSpringBootSiteErrorSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource GetSpringBootSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryResource GetSpringBootSiteSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSpringAppDiscoveryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSpringAppDiscoveryResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetSpringBootSite(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource>> GetSpringBootSiteAsync(string springbootsitesName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteCollection GetSpringBootSites() { throw null; }
    }
    public partial class MockableSpringAppDiscoverySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSpringAppDiscoverySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetSpringBootApps(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootAppResource> GetSpringBootAppsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetSpringBootServers(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootServerResource> GetSpringBootServersAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetSpringBootSites(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteResource> GetSpringBootSitesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SpringAppDiscovery.Models
{
    public static partial class ArmSpringAppDiscoveryModelFactory
    {
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootAppData SpringBootAppData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch SpringBootAppPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootServerData SpringBootServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch SpringBootServerPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteData SpringBootSiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties properties = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteErrorSummaryData SpringBootSiteErrorSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch SpringBootSitePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.SpringBootSiteSummaryData SpringBootSiteSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties properties = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpringAppDiscoveryProvisioningState : System.IEquatable<Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpringAppDiscoveryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState left, Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState left, Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpringBootAppApplicationConfigurationsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem>
    {
        public SpringBootAppApplicationConfigurationsItem(string key) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootAppInstancesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem>
    {
        public SpringBootAppInstancesItem(Azure.Core.ResourceIdentifier machineArmId) { }
        public int? InstanceCount { get { throw null; } set { } }
        public int? JvmMemoryInMB { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MachineArmId { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootAppMiscsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem>
    {
        public SpringBootAppMiscsItem(string key) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootAppPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch>
    {
        public SpringBootAppPatch() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootAppProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties>
    {
        public SpringBootAppProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppApplicationConfigurationsItem> ApplicationConfigurations { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError> Errors { get { throw null; } }
        public int? InstanceCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppInstancesItem> Instances { get { throw null; } }
        public string JarFileLocation { get { throw null; } set { } }
        public int? JvmMemoryInMB { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> JvmOptions { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> MachineArmIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppMiscsItem> Miscs { get { throw null; } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RuntimeJdkVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Servers { get { throw null; } }
        public string SiteName { get { throw null; } set { } }
        public string SpringBootVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StaticContentLocations { get { throw null; } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootAppProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootServerPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch>
    {
        public SpringBootServerPatch() { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties>
    {
        public SpringBootServerProperties(string server) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError> Errors { get { throw null; } }
        public System.Collections.Generic.IList<System.Net.IPAddress> FqdnAndIPAddressList { get { throw null; } }
        public Azure.Core.ResourceIdentifier MachineArmId { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string Server { get { throw null; } set { } }
        public int? SpringBootApps { get { throw null; } set { } }
        public int? TotalApps { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError>
    {
        public SpringBootSiteError() { }
        public string Code { get { throw null; } set { } }
        public long? Id { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string PossibleCauses { get { throw null; } set { } }
        public string RecommendedAction { get { throw null; } set { } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string Severity { get { throw null; } set { } }
        public string SummaryMessage { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedTimeStamp { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteErrorSummariesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties>
    {
        public SpringBootSiteErrorSummariesProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel> DiscoveryScopeErrorSummaries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError> Errors { get { throw null; } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummariesProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteErrorSummaryModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel>
    {
        public SpringBootSiteErrorSummaryModel() { }
        public long? AffectedObjectsCount { get { throw null; } set { } }
        public string AffectedResourceType { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteErrorSummaryModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteModelExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation>
    {
        public SpringBootSiteModelExtendedLocation() { }
        public string Name { get { throw null; } set { } }
        public string SpringbootsitesModelExtendedLocationType { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteModelExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSitePatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch>
    {
        public SpringBootSitePatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSitePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties>
    {
        public SpringBootSiteProperties() { }
        public string MasterSiteId { get { throw null; } set { } }
        public string MigrateProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpringBootSiteSummariesProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties>
    {
        public SpringBootSiteSummariesProperties() { }
        public long? DiscoveredApps { get { throw null; } set { } }
        public long? DiscoveredServers { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteError> Errors { get { throw null; } }
        public Azure.ResourceManager.SpringAppDiscovery.Models.SpringAppDiscoveryProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SpringAppDiscovery.Models.SpringBootSiteSummariesProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
