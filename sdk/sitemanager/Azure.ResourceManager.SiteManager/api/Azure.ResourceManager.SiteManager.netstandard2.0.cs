namespace Azure.ResourceManager.SiteManager
{
    public partial class AzureResourceManagerSiteManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSiteManagerContext() { }
        public static Azure.ResourceManager.SiteManager.AzureResourceManagerSiteManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EdgeSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.EdgeSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.EdgeSiteResource>, System.Collections.IEnumerable
    {
        protected EdgeSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SiteManager.EdgeSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.EdgeSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SiteManager.EdgeSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.EdgeSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
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
    public partial class EdgeSiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSiteResource() { }
        public virtual Azure.ResourceManager.SiteManager.EdgeSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.EdgeSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.EdgeSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> Update(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> UpdateAsync(Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SiteManagerExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource> CreateOrUpdateSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource>> CreateOrUpdateSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource> CreateOrUpdateSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource>> CreateOrUpdateSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response DeleteSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> DeleteSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response DeleteSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> DeleteSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetEdgeSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SiteManager.EdgeSiteResource GetEdgeSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SiteManager.EdgeSiteCollection GetEdgeSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSites(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSitesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> UpdateSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> UpdateSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> UpdateSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> UpdateSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SiteManager.Mocking
{
    public partial class MockableSiteManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerArmClient() { }
        public virtual Azure.ResourceManager.SiteManager.EdgeSiteResource GetEdgeSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSiteManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetEdgeSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SiteManager.EdgeSiteCollection GetEdgeSites() { throw null; }
    }
    public partial class MockableSiteManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource> CreateOrUpdateSitesBySubscription(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource>> CreateOrUpdateSitesBySubscriptionAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSitesBySubscription(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSitesBySubscriptionAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSites(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSitesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetSitesBySubscription(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetSitesBySubscriptionAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> UpdateSitesBySubscription(string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> UpdateSitesBySubscriptionAsync(string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSiteManagerTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerTenantResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource> CreateOrUpdateSitesByServiceGroup(Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.EdgeSiteResource>> CreateOrUpdateSitesByServiceGroupAsync(Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.EdgeSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSitesByServiceGroup(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSitesByServiceGroupAsync(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSites(string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetEdgeSitesAsync(string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> GetSitesByServiceGroup(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> GetSitesByServiceGroupAsync(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource> UpdateSitesByServiceGroup(string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.EdgeSiteResource>> UpdateSitesByServiceGroupAsync(string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.EdgeSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
