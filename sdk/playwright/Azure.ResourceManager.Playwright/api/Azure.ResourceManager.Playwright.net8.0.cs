namespace Azure.ResourceManager.Playwright
{
    public partial class AzureResourceManagerPlaywrightContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPlaywrightContext() { }
        public static Azure.ResourceManager.Playwright.AzureResourceManagerPlaywrightContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class PlaywrightExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult> CheckPlaywrightNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>> CheckPlaywrightNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightQuotaCollection GetAllPlaywrightQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> GetPlaywrightQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>> GetPlaywrightQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightQuotaResource GetPlaywrightQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetPlaywrightWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> GetPlaywrightWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource GetPlaywrightWorkspaceQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource GetPlaywrightWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightWorkspaceCollection GetPlaywrightWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetPlaywrightWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetPlaywrightWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PlaywrightQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>, System.Collections.IEnumerable
    {
        protected PlaywrightQuotaCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> Get(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>> GetAsync(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> GetIfExists(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>> GetIfExistsAsync(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightQuotaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>
    {
        internal PlaywrightQuotaData() { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightQuotaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightQuotaResource() { }
        public virtual Azure.ResourceManager.Playwright.PlaywrightQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Playwright.PlaywrightQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>, System.Collections.IEnumerable
    {
        protected PlaywrightWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string playwrightWorkspaceName, Azure.ResourceManager.Playwright.PlaywrightWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string playwrightWorkspaceName, Azure.ResourceManager.Playwright.PlaywrightWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> Get(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> GetAsync(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetIfExists(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> GetIfExistsAsync(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>
    {
        public PlaywrightWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>, System.Collections.IEnumerable
    {
        protected PlaywrightWorkspaceQuotaCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> Get(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>> GetAsync(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> GetIfExists(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>> GetIfExistsAsync(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightWorkspaceQuotaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>
    {
        internal PlaywrightWorkspaceQuotaData() { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceQuotaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightWorkspaceQuotaResource() { }
        public virtual Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string playwrightWorkspaceName, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightWorkspaceResource() { }
        public virtual Azure.ResourceManager.Playwright.PlaywrightWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string playwrightWorkspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaCollection GetAllPlaywrightWorkspaceQuota() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource> GetPlaywrightWorkspaceQuota(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource>> GetPlaywrightWorkspaceQuotaAsync(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.PlaywrightWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.PlaywrightWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> Update(Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> UpdateAsync(Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Playwright.Mocking
{
    public partial class MockablePlaywrightArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightArmClient() { }
        public virtual Azure.ResourceManager.Playwright.PlaywrightQuotaResource GetPlaywrightQuotaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaResource GetPlaywrightWorkspaceQuotaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource GetPlaywrightWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePlaywrightResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetPlaywrightWorkspace(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource>> GetPlaywrightWorkspaceAsync(string playwrightWorkspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Playwright.PlaywrightWorkspaceCollection GetPlaywrightWorkspaces() { throw null; }
    }
    public partial class MockablePlaywrightSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult> CheckPlaywrightNameAvailability(Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>> CheckPlaywrightNameAvailabilityAsync(Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Playwright.PlaywrightQuotaCollection GetAllPlaywrightQuota(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource> GetPlaywrightQuota(Azure.Core.AzureLocation location, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Playwright.PlaywrightQuotaResource>> GetPlaywrightQuotaAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName playwrightQuotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetPlaywrightWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Playwright.PlaywrightWorkspaceResource> GetPlaywrightWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Playwright.Models
{
    public static partial class ArmPlaywrightModelFactory
    {
        public static Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties PlaywrightFreeTrialProperties(string workspaceId = null, Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState state = default(Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState)) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult PlaywrightNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason? reason = default(Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightQuotaData PlaywrightQuotaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties PlaywrightQuotaProperties(Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties freeTrial = null, Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState? provisioningState = default(Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightWorkspaceData PlaywrightWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties PlaywrightWorkspaceFreeTrialProperties(System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset expiryOn = default(System.DateTimeOffset), int allocatedValue = 0, float usedValue = 0f, float percentageUsed = 0f) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties PlaywrightWorkspaceProperties(Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState? provisioningState = default(Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState?), System.Uri dataplaneUri = null, Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus? regionalAffinity = default(Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus?), Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus? localAuth = default(Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus?), string workspaceId = null) { throw null; }
        public static Azure.ResourceManager.Playwright.PlaywrightWorkspaceQuotaData PlaywrightWorkspaceQuotaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties PlaywrightWorkspaceQuotaProperties(Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties freeTrial = null, Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState? provisioningState = default(Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightEnablementStatus : System.IEquatable<Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightEnablementStatus(string value) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus left, Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus left, Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightFreeTrialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties>
    {
        internal PlaywrightFreeTrialProperties() { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState State { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightFreeTrialState : System.IEquatable<Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightFreeTrialState(string value) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState Active { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState Expired { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState left, Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState left, Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent>
    {
        public PlaywrightNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>
    {
        internal PlaywrightNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason left, Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason left, Azure.ResourceManager.Playwright.Models.PlaywrightNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightProvisioningState : System.IEquatable<Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState left, Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState left, Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightQuotaName : System.IEquatable<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightQuotaName(string value) { throw null; }
        public static Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName ExecutionMinutes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName left, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName left, Azure.ResourceManager.Playwright.Models.PlaywrightQuotaName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightQuotaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties>
    {
        internal PlaywrightQuotaProperties() { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightFreeTrialProperties FreeTrial { get { throw null; } }
        public Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightQuotaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceFreeTrialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties>
    {
        internal PlaywrightWorkspaceFreeTrialProperties() { }
        public int AllocatedValue { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset ExpiryOn { get { throw null; } }
        public float PercentageUsed { get { throw null; } }
        public float UsedValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch>
    {
        public PlaywrightWorkspacePatch() { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties>
    {
        public PlaywrightWorkspaceProperties() { }
        public System.Uri DataplaneUri { get { throw null; } }
        public Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus? LocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceQuotaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties>
    {
        internal PlaywrightWorkspaceQuotaProperties() { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceFreeTrialProperties FreeTrial { get { throw null; } }
        public Azure.ResourceManager.Playwright.Models.PlaywrightProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceQuotaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightWorkspaceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties>
    {
        public PlaywrightWorkspaceUpdateProperties() { }
        public Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus? LocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Playwright.Models.PlaywrightEnablementStatus? RegionalAffinity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Playwright.Models.PlaywrightWorkspaceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
