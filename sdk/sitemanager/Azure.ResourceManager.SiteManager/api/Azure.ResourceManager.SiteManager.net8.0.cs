namespace Azure.ResourceManager.SiteManager
{
    public partial class AzureResourceManagerSiteManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSiteManagerContext() { }
        public static Azure.ResourceManager.SiteManager.AzureResourceManagerSiteManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EdgeSiteData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>
    {
        public EdgeSiteData() { }
        public Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGroupEdgeSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>, System.Collections.IEnumerable
    {
        protected ResourceGroupEdgeSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGroupEdgeSiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGroupEdgeSiteResource() { }
        public virtual Azure.ResourceManager.SiteManager.EdgeSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> Update(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>> UpdateAsync(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SiteManagerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> GetResourceGroupEdgeSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>> GetResourceGroupEdgeSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource GetResourceGroupEdgeSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteCollection GetResourceGroupEdgeSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> GetSubscriptionEdgeSite(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>> GetSubscriptionEdgeSiteAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource GetSubscriptionEdgeSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteCollection GetSubscriptionEdgeSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource> GetTenantSite(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource>> GetTenantSiteAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SiteManager.TenantSiteResource GetTenantSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SiteManager.TenantSiteCollection GetTenantSites(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName) { throw null; }
    }
    public partial class SubscriptionEdgeSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>, System.Collections.IEnumerable
    {
        protected SubscriptionEdgeSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionEdgeSiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionEdgeSiteResource() { }
        public virtual Azure.ResourceManager.SiteManager.EdgeSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> Update(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>> UpdateAsync(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.TenantSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.TenantSiteResource>, System.Collections.IEnumerable
    {
        protected TenantSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.TenantSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.TenantSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.TenantSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.TenantSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SiteManager.TenantSiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SiteManager.TenantSiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SiteManager.TenantSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.TenantSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SiteManager.TenantSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.TenantSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantSiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantSiteResource() { }
        public virtual Azure.ResourceManager.SiteManager.EdgeSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string servicegroupName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource> Update(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource>> UpdateAsync(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SiteManager.Mocking
{
    public partial class MockableSiteManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerArmClient() { }
        public virtual Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource GetResourceGroupEdgeSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource GetSubscriptionEdgeSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SiteManager.TenantSiteResource GetTenantSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSiteManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource> GetResourceGroupEdgeSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteResource>> GetResourceGroupEdgeSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SiteManager.ResourceGroupEdgeSiteCollection GetResourceGroupEdgeSites() { throw null; }
    }
    public partial class MockableSiteManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource> GetSubscriptionEdgeSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteResource>> GetSubscriptionEdgeSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SiteManager.SubscriptionEdgeSiteCollection GetSubscriptionEdgeSites() { throw null; }
    }
    public partial class MockableSiteManagerTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource> GetTenantSite(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.TenantSiteResource>> GetTenantSiteAsync(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SiteManager.TenantSiteCollection GetTenantSites(string servicegroupName) { throw null; }
    }
}
namespace Azure.ResourceManager.SiteManager.Models
{
    public static partial class ArmSiteManagerModelFactory
    {
        public static Azure.ResourceManager.SiteManager.EdgeSiteData EdgeSiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties EdgeSiteProperties(string displayName = null, string description = null, Azure.ResourceManager.SiteManager.Models.SiteAddressProperties siteAddress = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState? provisioningState = default(Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState?)) { throw null; }
    }
    public partial class EdgeSitePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatch>
    {
        public EdgeSitePatch() { }
        public Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.EdgeSitePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.EdgeSitePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSitePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties>
    {
        public EdgeSitePatchProperties() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.SiteManager.Models.SiteAddressProperties SiteAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSitePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSiteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties>
    {
        public EdgeSiteProperties() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SiteManager.Models.SiteAddressProperties SiteAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.EdgeSiteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeSiteProvisioningState : System.IEquatable<Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeSiteProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState left, Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState left, Azure.ResourceManager.SiteManager.Models.EdgeSiteProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SiteAddressProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteAddressProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteAddressProperties>
    {
        public SiteAddressProperties() { }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string StateOrProvince { get { throw null; } set { } }
        public string StreetAddress1 { get { throw null; } set { } }
        public string StreetAddress2 { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteAddressProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteAddressProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteAddressProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteAddressProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteAddressProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteAddressProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteAddressProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
