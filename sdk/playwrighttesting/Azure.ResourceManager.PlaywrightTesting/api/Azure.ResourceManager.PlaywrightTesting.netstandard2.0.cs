namespace Azure.ResourceManager.PlaywrightTesting
{
    public partial class AccountQuotumCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>, System.Collections.IEnumerable
    {
        protected AccountQuotumCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> Get(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>> GetAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> GetIfExists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>> GetIfExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountQuotumData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>
    {
        public AccountQuotumData() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.PlaywrightTesting.AccountQuotumData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.AccountQuotumData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountQuotumResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountQuotumResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.AccountQuotumData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlaywrightTesting.AccountQuotumData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.AccountQuotumData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountQuotumData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.PlaywrightTesting.AccountQuotumCollection GetAccountQuota() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource> GetAccountQuotum(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource>> GetAccountQuotumAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult> CheckNameAvailabilityAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource GetAccountQuotumResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaCollection GetAllPlaywrightTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetPlaywrightTestingAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource GetPlaywrightTestingAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountCollection GetPlaywrightTestingAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetPlaywrightTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetPlaywrightTestingQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public PlaywrightTestingQuotaData() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.PlaywrightTesting.AccountQuotumResource GetAccountQuotumResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult> CheckNameAvailabilityAccount(Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAccountAsync(Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaCollection GetAllPlaywrightTestingQuota(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetPlaywrightTestingQuota(Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetPlaywrightTestingQuotaAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName quotaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlaywrightTesting.Models
{
    public partial class AccountFreeTrialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties>
    {
        public AccountFreeTrialProperties(System.DateTimeOffset createdOn, System.DateTimeOffset expiryOn, int allocatedValue, int usedValue, float percentageUsed) { }
        public int AllocatedValue { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset ExpiryOn { get { throw null; } }
        public float PercentageUsed { get { throw null; } }
        public int UsedValue { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties>
    {
        public AccountProperties() { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? ScalableExecution { get { throw null; } set { } }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountQuotaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties>
    {
        public AccountQuotaProperties() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties FreeTrial { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>
    {
        public AccountUpdateProperties() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? ScalableExecution { get { throw null; } set { } }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmPlaywrightTestingModelFactory
    {
        public static Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties AccountProperties(System.Uri dashboardUri = null, Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? regionalAffinity = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? scalableExecution = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? reporting = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties AccountQuotaProperties(Azure.ResourceManager.PlaywrightTesting.Models.AccountFreeTrialProperties freeTrial = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.AccountQuotumData AccountQuotumData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlaywrightTesting.Models.AccountQuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult CheckNameAvailabilityResult(bool? nameAvailable = default(bool?), Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason? reason = default(Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData PlaywrightTestingAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PlaywrightTesting.Models.AccountProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData PlaywrightTestingQuotaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties QuotaProperties(Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties freeTrial = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
    }
    public partial class CheckNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent>
    {
        public CheckNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.CheckNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnablementStatus : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnablementStatus(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus left, Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus left, Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FreeTrialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>
    {
        public FreeTrialProperties(string accountId, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState state) { }
        public string AccountId { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState State { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FreeTrialState : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FreeTrialState(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState Active { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState Expired { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState NotEligible { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState NotRegistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState left, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState left, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightTestingAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>
    {
        public PlaywrightTestingAccountPatch() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.AccountUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class QuotaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties>
    {
        public QuotaProperties() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties FreeTrial { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.QuotaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
