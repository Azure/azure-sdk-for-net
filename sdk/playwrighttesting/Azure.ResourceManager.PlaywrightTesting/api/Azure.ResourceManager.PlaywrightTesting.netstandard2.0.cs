namespace Azure.ResourceManager.PlaywrightTesting
{
    public partial class AzureResourceManagerPlaywrightTestingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPlaywrightTestingContext() { }
        public static Azure.ResourceManager.PlaywrightTesting.AzureResourceManagerPlaywrightTestingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class PlaywrightTestingAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>, System.Collections.IEnumerable
    {
        protected PlaywrightTestingAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightTestingAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>
    {
        public PlaywrightTestingAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingAccountQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>, System.Collections.IEnumerable
    {
        protected PlaywrightTestingAccountQuotaCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> Get(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>> GetAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> GetIfExists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>> GetIfExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightTestingAccountQuotaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>
    {
        internal PlaywrightTestingAccountQuotaData() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingAccountQuotaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightTestingAccountQuotaResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightTestingAccountResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaCollection GetAllPlaywrightTestingAccountQuota() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource> GetPlaywrightTestingAccountQuota(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource>> GetPlaywrightTestingAccountQuotaAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> Update(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> UpdateAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PlaywrightTestingExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult> CheckPlaywrightTestingNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>> CheckPlaywrightTestingNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaCollection GetAllPlaywrightTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetPlaywrightTestingAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource GetPlaywrightTestingAccountQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource GetPlaywrightTestingAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountCollection GetPlaywrightTestingAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetPlaywrightTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetPlaywrightTestingQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource GetPlaywrightTestingQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PlaywrightTestingQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>, System.Collections.IEnumerable
    {
        protected PlaywrightTestingQuotaCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> Get(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetIfExists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetIfExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightTestingQuotaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>
    {
        internal PlaywrightTestingQuotaData() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingQuotaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightTestingQuotaResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.PlaywrightTesting.Mocking
{
    public partial class MockablePlaywrightTestingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingArmClient() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaResource GetPlaywrightTestingAccountQuotaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource GetPlaywrightTestingAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource GetPlaywrightTestingQuotaResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePlaywrightTestingResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetPlaywrightTestingAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountCollection GetPlaywrightTestingAccounts() { throw null; }
    }
    public partial class MockablePlaywrightTestingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult> CheckPlaywrightTestingNameAvailability(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>> CheckPlaywrightTestingNameAvailabilityAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaCollection GetAllPlaywrightTestingQuota(string location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetPlaywrightTestingQuota(string location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetPlaywrightTestingQuotaAsync(string location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlaywrightTesting.Models
{
    public partial class AccountUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>
    {
        public AccountUpdateProperties() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? LocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? ScalableExecution { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmPlaywrightTestingModelFactory
    {
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData PlaywrightTestingAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties PlaywrightTestingAccountFreeTrialProperties(System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset expiryOn = default(System.DateTimeOffset), int allocatedValue = 0, int usedValue = 0, float percentageUsed = 0f) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties PlaywrightTestingAccountProperties(System.Uri dashboardUri = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? regionalAffinity = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? scalableExecution = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? reporting = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? localAuth = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountQuotaData PlaywrightTestingAccountQuotaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties PlaywrightTestingAccountQuotaProperties(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties freeTrial = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties PlaywrightTestingFreeTrialProperties(string accountId = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState state = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult PlaywrightTestingNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason? reason = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData PlaywrightTestingQuotaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties PlaywrightTestingQuotaProperties(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties freeTrial = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType? offeringType = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
    }
    public partial class PlaywrightTestingAccountFreeTrialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties>
    {
        internal PlaywrightTestingAccountFreeTrialProperties() { }
        public int AllocatedValue { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset ExpiryOn { get { throw null; } }
        public float PercentageUsed { get { throw null; } }
        public int UsedValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>
    {
        public PlaywrightTestingAccountPatch() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties>
    {
        public PlaywrightTestingAccountProperties() { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? LocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus? ScalableExecution { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingAccountQuotaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties>
    {
        internal PlaywrightTestingAccountQuotaProperties() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountFreeTrialProperties FreeTrial { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountQuotaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingEnablementStatus : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingEnablementStatus(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingEnablementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightTestingFreeTrialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties>
    {
        internal PlaywrightTestingFreeTrialProperties() { }
        public string AccountId { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingFreeTrialState : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingFreeTrialState(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState Active { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState Expired { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState NotEligible { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState NotRegistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightTestingNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent>
    {
        public PlaywrightTestingNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>
    {
        internal PlaywrightTestingNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingNameUnavailableReason : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingOfferingType : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingOfferingType(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType GeneralAvailability { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType PrivatePreview { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType PublicPreview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingProvisioningState : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingQuotaName : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingQuotaName(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName Reporting { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName ScalableExecution { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightTestingQuotaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties>
    {
        internal PlaywrightTestingQuotaProperties() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingFreeTrialProperties FreeTrial { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingOfferingType? OfferingType { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
