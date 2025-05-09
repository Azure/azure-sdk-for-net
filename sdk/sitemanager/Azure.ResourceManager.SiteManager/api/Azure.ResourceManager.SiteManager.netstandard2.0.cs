namespace Azure.ResourceManager.SiteManager
{
    public partial class AzureResourceManagerSiteManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSiteManagerContext() { }
        public static Azure.ResourceManager.SiteManager.AzureResourceManagerSiteManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class SiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.SiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.SiteResource>, System.Collections.IEnumerable
    {
        protected SiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.SiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.SiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SiteManager.SiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SiteManager.SiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SiteManager.SiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SiteManager.SiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SiteManager.SiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SiteManager.SiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.SiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>
    {
        public SiteData() { }
        public Azure.ResourceManager.SiteManager.Models.SiteProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.SiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.SiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.SiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.SiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SiteManagerExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource> CreateOrUpdateSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource>> CreateOrUpdateSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource> CreateOrUpdateSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource>> CreateOrUpdateSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response DeleteSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> DeleteSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response DeleteSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> DeleteSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> GetSite(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetSiteAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SiteManager.SiteResource GetSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SiteManager.SiteCollection GetSites(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SiteManager.SiteResource> GetSites(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SiteManager.SiteResource> GetSites(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SiteManager.SiteResource> GetSitesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SiteManager.SiteResource> GetSitesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> GetSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> GetSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> UpdateSitesByServiceGroup(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> UpdateSitesByServiceGroupAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> UpdateSitesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> UpdateSitesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.SiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteResource() { }
        public virtual Azure.ResourceManager.SiteManager.SiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SiteManager.SiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.SiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.SiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.SiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.SiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> Update(Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> UpdateAsync(Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SiteManager.Mocking
{
    public partial class MockableSiteManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerArmClient() { }
        public virtual Azure.ResourceManager.SiteManager.SiteResource GetSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSiteManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> GetSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SiteManager.SiteCollection GetSites() { throw null; }
    }
    public partial class MockableSiteManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource> CreateOrUpdateSitesBySubscription(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource>> CreateOrUpdateSitesBySubscriptionAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSitesBySubscription(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSitesBySubscriptionAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.SiteResource> GetSites(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.SiteResource> GetSitesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> GetSitesBySubscription(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetSitesBySubscriptionAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> UpdateSitesBySubscription(string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> UpdateSitesBySubscriptionAsync(string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSiteManagerTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSiteManagerTenantResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource> CreateOrUpdateSitesByServiceGroup(Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SiteManager.SiteResource>> CreateOrUpdateSitesByServiceGroupAsync(Azure.WaitUntil waitUntil, string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteSitesByServiceGroup(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSitesByServiceGroupAsync(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SiteManager.SiteResource> GetSites(string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SiteManager.SiteResource> GetSitesAsync(string servicegroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> GetSitesByServiceGroup(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> GetSitesByServiceGroupAsync(string servicegroupName, string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SiteManager.SiteResource> UpdateSitesByServiceGroup(string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SiteManager.SiteResource>> UpdateSitesByServiceGroupAsync(string servicegroupName, string siteName, Azure.ResourceManager.SiteManager.Models.SiteUpdate properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SiteManager.Models
{
    public static partial class ArmSiteManagerModelFactory
    {
        public static Azure.ResourceManager.SiteManager.SiteData SiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SiteManager.Models.SiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SiteManager.Models.SiteProperties SiteProperties(string displayName = null, string description = null, Azure.ResourceManager.SiteManager.Models.SiteAddressProperties siteAddress = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState left, Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState left, Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState right) { throw null; }
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
    public partial class SiteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteProperties>
    {
        public SiteProperties() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.SiteManager.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SiteManager.Models.SiteAddressProperties SiteAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdate>
    {
        public SiteUpdate() { }
        public Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties>
    {
        public SiteUpdateProperties() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.SiteManager.Models.SiteAddressProperties SiteAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SiteManager.Models.SiteUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
