namespace Azure.ResourceManager.DataShare
{
    public partial class AzureResourceManagerDataShareContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDataShareContext() { }
        public static Azure.ResourceManager.DataShare.AzureResourceManagerDataShareContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DataShareAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareAccountResource>, System.Collections.IEnumerable
    {
        protected DataShareAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataShare.DataShareAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataShare.DataShareAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataShareAccountResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareAccountResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataShareAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataShareAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataShareAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>
    {
        public DataShareAccountData(Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataShareAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataShareAccountResource() { }
        public virtual Azure.ResourceManager.DataShare.DataShareAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareResource> GetDataShare(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareResource>> GetDataShareAsync(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareCollection GetDataShares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource> GetShareSubscription(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> GetShareSubscriptionAsync(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareSubscriptionCollection GetShareSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.DataShareAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> Update(Azure.ResourceManager.DataShare.Models.DataShareAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> UpdateAsync(Azure.ResourceManager.DataShare.Models.DataShareAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataShareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareResource>, System.Collections.IEnumerable
    {
        protected DataShareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.DataShare.DataShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.DataShare.DataShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareResource> Get(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataShareResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareResource>> GetAsync(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareResource> GetIfExists(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareResource>> GetIfExistsAsync(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataShareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataShareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataShareConsumerInvitationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>, System.Collections.IEnumerable
    {
        protected DataShareConsumerInvitationCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> Get(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>> GetAsync(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> GetIfExists(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataShareConsumerInvitationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>
    {
        public DataShareConsumerInvitationData(System.Guid invitationId) { }
        public int? DataSetCount { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Guid InvitationId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus? InvitationStatus { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProviderEmail { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ProviderTenantName { get { throw null; } }
        public System.DateTimeOffset? RespondedOn { get { throw null; } }
        public System.DateTimeOffset? SentOn { get { throw null; } }
        public string ShareName { get { throw null; } }
        public string TermsOfUse { get { throw null; } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareConsumerInvitationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareConsumerInvitationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataShareConsumerInvitationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataShareConsumerInvitationResource() { }
        public virtual Azure.ResourceManager.DataShare.DataShareConsumerInvitationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(Azure.Core.AzureLocation location, System.Guid invitationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.DataShareConsumerInvitationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareConsumerInvitationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareConsumerInvitationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataShareData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>
    {
        public DataShareData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareKind? ShareKind { get { throw null; } set { } }
        public string Terms { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DataShareExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration> ActivateEmail(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration emailRegistration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>> ActivateEmailAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration emailRegistration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> GetDataShareAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> GetDataShareAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareAccountResource GetDataShareAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareAccountCollection GetDataShareAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataShare.DataShareAccountResource> GetDataShareAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareAccountResource> GetDataShareAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> GetDataShareConsumerInvitation(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>> GetDataShareConsumerInvitationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource GetDataShareConsumerInvitationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareConsumerInvitationCollection GetDataShareConsumerInvitations(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareInvitationResource GetDataShareInvitationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareResource GetDataShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource GetDataShareSynchronizationSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareTriggerResource GetDataShareTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource GetProviderShareSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareDataSetMappingResource GetShareDataSetMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareDataSetResource GetShareDataSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareSubscriptionResource GetShareSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration> RegisterEmail(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>> RegisterEmailAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> RejectConsumerInvitation(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.DataShareConsumerInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>> RejectConsumerInvitationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.DataShareConsumerInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataShareInvitationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareInvitationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareInvitationResource>, System.Collections.IEnumerable
    {
        protected DataShareInvitationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareInvitationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string invitationName, Azure.ResourceManager.DataShare.DataShareInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareInvitationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string invitationName, Azure.ResourceManager.DataShare.DataShareInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareInvitationResource> Get(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataShareInvitationResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareInvitationResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareInvitationResource>> GetAsync(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareInvitationResource> GetIfExists(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareInvitationResource>> GetIfExistsAsync(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataShareInvitationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareInvitationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataShareInvitationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareInvitationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataShareInvitationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareInvitationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>
    {
        public DataShareInvitationData() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Guid? InvitationId { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus? InvitationStatus { get { throw null; } }
        public System.DateTimeOffset? RespondedOn { get { throw null; } }
        public System.DateTimeOffset? SentOn { get { throw null; } }
        public string TargetActiveDirectoryId { get { throw null; } set { } }
        public string TargetEmail { get { throw null; } set { } }
        public string TargetObjectId { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareInvitationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareInvitationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataShareInvitationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareInvitationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataShareInvitationResource() { }
        public virtual Azure.ResourceManager.DataShare.DataShareInvitationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string invitationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareInvitationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareInvitationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.DataShareInvitationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareInvitationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareInvitationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareInvitationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareInvitationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataShareResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataShareResource() { }
        public virtual Azure.ResourceManager.DataShare.DataShareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareInvitationResource> GetDataShareInvitation(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareInvitationResource>> GetDataShareInvitationAsync(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareInvitationCollection GetDataShareInvitations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> GetDataShareSynchronizationSetting(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>> GetDataShareSynchronizationSettingAsync(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareSynchronizationSettingCollection GetDataShareSynchronizationSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> GetProviderShareSubscription(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> GetProviderShareSubscriptionAsync(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ProviderShareSubscriptionCollection GetProviderShareSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetResource> GetShareDataSet(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetResource>> GetShareDataSetAsync(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareDataSetCollection GetShareDataSets() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetails(Azure.ResourceManager.DataShare.Models.ShareSynchronization shareSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetailsAsync(Azure.ResourceManager.DataShare.Models.ShareSynchronization shareSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.ShareSynchronization> GetSynchronizations(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.ShareSynchronization> GetSynchronizationsAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.DataShareData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataShareSynchronizationSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>, System.Collections.IEnumerable
    {
        protected DataShareSynchronizationSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string synchronizationSettingName, Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string synchronizationSettingName, Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> Get(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>> GetAsync(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> GetIfExists(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>> GetIfExistsAsync(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataShareSynchronizationSettingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>
    {
        public DataShareSynchronizationSettingData() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataShareSynchronizationSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataShareSynchronizationSettingResource() { }
        public virtual Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string synchronizationSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataShareTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareTriggerResource>, System.Collections.IEnumerable
    {
        protected DataShareTriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareTriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataShare.DataShareTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareTriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataShare.DataShareTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareTriggerResource> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataShareTriggerResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareTriggerResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareTriggerResource>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareTriggerResource> GetIfExists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.DataShareTriggerResource>> GetIfExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataShareTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataShareTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataShareTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataShareTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataShareTriggerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareTriggerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>
    {
        public DataShareTriggerData() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareTriggerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareTriggerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataShareTriggerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareTriggerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataShareTriggerResource() { }
        public virtual Azure.ResourceManager.DataShare.DataShareTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareSubscriptionName, string triggerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareTriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareTriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.DataShareTriggerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.DataShareTriggerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.DataShareTriggerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareTriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataShareTriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataShareTriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProviderShareSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ProviderShareSubscriptionCollection() { }
        public virtual Azure.Response<bool> Exists(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Get(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> GetAsync(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> GetIfExists(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> GetIfExistsAsync(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderShareSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>
    {
        public ProviderShareSubscriptionData() { }
        public string ConsumerEmail { get { throw null; } }
        public string ConsumerName { get { throw null; } }
        public string ConsumerTenantName { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string ProviderEmail { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public System.DateTimeOffset? SharedOn { get { throw null; } }
        public string ShareSubscriptionObjectId { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus? ShareSubscriptionStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ProviderShareSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ProviderShareSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderShareSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderShareSubscriptionResource() { }
        public virtual Azure.ResourceManager.DataShare.ProviderShareSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Adjust(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> AdjustAsync(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string providerShareSubscriptionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Reinstate(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> ReinstateAsync(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Revoke(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> RevokeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.ProviderShareSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ProviderShareSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ProviderShareSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareDataSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareDataSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareDataSetResource>, System.Collections.IEnumerable
    {
        protected ShareDataSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataSetName, Azure.ResourceManager.DataShare.ShareDataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataSetName, Azure.ResourceManager.DataShare.ShareDataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetResource> Get(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.ShareDataSetResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.ShareDataSetResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetResource>> GetAsync(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.ShareDataSetResource> GetIfExists(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.ShareDataSetResource>> GetIfExistsAsync(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.ShareDataSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareDataSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.ShareDataSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareDataSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ShareDataSetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>
    {
        public ShareDataSetData() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareDataSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareDataSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareDataSetMappingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>, System.Collections.IEnumerable
    {
        protected ShareDataSetMappingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataSetMappingName, Azure.ResourceManager.DataShare.ShareDataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataSetMappingName, Azure.ResourceManager.DataShare.ShareDataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> Get(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>> GetAsync(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> GetIfExists(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>> GetIfExistsAsync(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ShareDataSetMappingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>
    {
        public ShareDataSetMappingData() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareDataSetMappingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareDataSetMappingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareDataSetMappingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ShareDataSetMappingResource() { }
        public virtual Azure.ResourceManager.DataShare.ShareDataSetMappingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareSubscriptionName, string dataSetMappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.ShareDataSetMappingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareDataSetMappingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetMappingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareDataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareDataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareDataSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ShareDataSetResource() { }
        public virtual Azure.ResourceManager.DataShare.ShareDataSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string dataSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.ShareDataSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareDataSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareDataSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareDataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareDataSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareDataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ShareSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string shareSubscriptionName, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string shareSubscriptionName, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource> Get(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.ShareSubscriptionResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.ShareSubscriptionResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> GetAsync(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataShare.ShareSubscriptionResource> GetIfExists(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> GetIfExistsAsync(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.ShareSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.ShareSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ShareSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>
    {
        public ShareSubscriptionData(System.Guid invitationId, Azure.Core.AzureLocation sourceShareLocation) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Guid InvitationId { get { throw null; } set { } }
        public string ProviderEmail { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ProviderTenantName { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string ShareDescription { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareKind? ShareKind { get { throw null; } }
        public string ShareName { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus? ShareSubscriptionStatus { get { throw null; } }
        public string ShareTerms { get { throw null; } }
        public Azure.Core.AzureLocation SourceShareLocation { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ShareSubscriptionResource() { }
        public virtual Azure.ResourceManager.DataShare.ShareSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> CancelSynchronization(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>> CancelSynchronizationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet> GetConsumerSourceDataSets(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet> GetConsumerSourceDataSetsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareTriggerResource> GetDataShareTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareTriggerResource>> GetDataShareTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareTriggerCollection GetDataShareTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetMappingResource> GetShareDataSetMapping(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareDataSetMappingResource>> GetShareDataSetMappingAsync(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareDataSetMappingCollection GetShareDataSetMappings() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting> GetSourceShareSynchronizationSettings(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting> GetSourceShareSynchronizationSettingsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetails(Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetailsAsync(Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> GetSynchronizations(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> GetSynchronizationsAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> Synchronize(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>> SynchronizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DataShare.ShareSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.ShareSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.ShareSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataShare.Mocking
{
    public partial class MockableDataShareArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDataShareArmClient() { }
        public virtual Azure.ResourceManager.DataShare.DataShareAccountResource GetDataShareAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource GetDataShareConsumerInvitationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareInvitationResource GetDataShareInvitationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareResource GetDataShareResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareSynchronizationSettingResource GetDataShareSynchronizationSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareTriggerResource GetDataShareTriggerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource GetProviderShareSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareDataSetMappingResource GetShareDataSetMappingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareDataSetResource GetShareDataSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareSubscriptionResource GetShareSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDataShareResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataShareResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource> GetDataShareAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareAccountResource>> GetDataShareAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareAccountCollection GetDataShareAccounts() { throw null; }
    }
    public partial class MockableDataShareSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataShareSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataShareAccountResource> GetDataShareAccounts(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataShareAccountResource> GetDataShareAccountsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableDataShareTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataShareTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration> ActivateEmail(Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration emailRegistration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>> ActivateEmailAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration emailRegistration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> GetDataShareConsumerInvitation(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>> GetDataShareConsumerInvitationAsync(Azure.Core.AzureLocation location, System.Guid invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataShareConsumerInvitationCollection GetDataShareConsumerInvitations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration> RegisterEmail(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>> RegisterEmailAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource> RejectConsumerInvitation(Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.DataShareConsumerInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataShareConsumerInvitationResource>> RejectConsumerInvitationAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.DataShareConsumerInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataShare.Models
{
    public partial class AdlsGen1FileDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet>
    {
        public AdlsGen1FileDataSet(string accountName, string fileName, string folderPath, string resourceGroup, string subscriptionId) { }
        public string AccountName { get { throw null; } set { } }
        public System.Guid? DataSetId { get { throw null; } }
        public string FileName { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdlsGen1FolderDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet>
    {
        public AdlsGen1FolderDataSet(string accountName, string folderPath, string resourceGroup, string subscriptionId) { }
        public string AccountName { get { throw null; } set { } }
        public System.Guid? DataSetId { get { throw null; } }
        public string FolderPath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdlsGen2FileDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet>
    {
        public AdlsGen2FileDataSet(string filePath, string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public System.Guid? DataSetId { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public string FileSystem { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdlsGen2FileDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping>
    {
        public AdlsGen2FileDataSetMapping(System.Guid dataSetId, string filePath, string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public string FileSystem { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareOutputType? OutputType { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdlsGen2FileSystemDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet>
    {
        public AdlsGen2FileSystemDataSet(string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public System.Guid? DataSetId { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdlsGen2FileSystemDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping>
    {
        public AdlsGen2FileSystemDataSetMapping(System.Guid dataSetId, string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdlsGen2FolderDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet>
    {
        public AdlsGen2FolderDataSet(string fileSystem, string folderPath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public System.Guid? DataSetId { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdlsGen2FolderDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping>
    {
        public AdlsGen2FolderDataSetMapping(System.Guid dataSetId, string fileSystem, string folderPath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDataShareModelFactory
    {
        public static Azure.ResourceManager.DataShare.Models.AdlsGen1FileDataSet AdlsGen1FileDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string accountName = null, System.Guid? dataSetId = default(System.Guid?), string fileName = null, string folderPath = null, string resourceGroup = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.AdlsGen1FolderDataSet AdlsGen1FolderDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string accountName = null, System.Guid? dataSetId = default(System.Guid?), string folderPath = null, string resourceGroup = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSet AdlsGen2FileDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), string filePath = null, string fileSystem = null, string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.AdlsGen2FileDataSetMapping AdlsGen2FileDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), string filePath = null, string fileSystem = null, Azure.ResourceManager.DataShare.Models.DataShareOutputType? outputType = default(Azure.ResourceManager.DataShare.Models.DataShareOutputType?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSet AdlsGen2FileSystemDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), string fileSystem = null, string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.AdlsGen2FileSystemDataSetMapping AdlsGen2FileSystemDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), string fileSystem = null, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSet AdlsGen2FolderDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), string fileSystem = null, string folderPath = null, string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.AdlsGen2FolderDataSetMapping AdlsGen2FolderDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), string fileSystem = null, string folderPath = null, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.BlobContainerDataSet BlobContainerDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string containerName = null, System.Guid? dataSetId = default(System.Guid?), string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping BlobContainerDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string containerName = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.BlobDataSet BlobDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string containerName = null, System.Guid? dataSetId = default(System.Guid?), string filePath = null, string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.BlobDataSetMapping BlobDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string containerName = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), string filePath = null, Azure.ResourceManager.DataShare.Models.DataShareOutputType? outputType = default(Azure.ResourceManager.DataShare.Models.DataShareOutputType?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.BlobFolderDataSet BlobFolderDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string containerName = null, System.Guid? dataSetId = default(System.Guid?), string prefix = null, string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping BlobFolderDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string containerName = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), string prefix = null, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string resourceGroup = null, string storageAccountName = null, string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet ConsumerSourceDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), Azure.Core.AzureLocation? dataSetLocation = default(Azure.Core.AzureLocation?), string dataSetName = null, string dataSetPath = null, Azure.ResourceManager.DataShare.Models.ShareDataSetType? dataSetType = default(Azure.ResourceManager.DataShare.Models.ShareDataSetType?)) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareAccountData DataShareAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string userEmail = null, string userName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareConsumerInvitationData DataShareConsumerInvitationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? dataSetCount = default(int?), string description = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.Guid invitationId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus? invitationStatus = default(Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string providerEmail = null, string providerName = null, string providerTenantName = null, System.DateTimeOffset? respondedOn = default(System.DateTimeOffset?), System.DateTimeOffset? sentOn = default(System.DateTimeOffset?), string shareName = null, string termsOfUse = null, string userEmail = null, string userName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareData DataShareData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), Azure.ResourceManager.DataShare.Models.DataShareKind? shareKind = default(Azure.ResourceManager.DataShare.Models.DataShareKind?), string terms = null, string userEmail = null, string userName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration DataShareEmailRegistration(string activationCode = null, System.DateTimeOffset? activationExpireOn = default(System.DateTimeOffset?), string email = null, Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus? registrationStatus = default(Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareInvitationData DataShareInvitationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.Guid? invitationId = default(System.Guid?), Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus? invitationStatus = default(Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus?), System.DateTimeOffset? respondedOn = default(System.DateTimeOffset?), System.DateTimeOffset? sentOn = default(System.DateTimeOffset?), string targetActiveDirectoryId = null, string targetEmail = null, string targetObjectId = null, string userEmail = null, string userName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareOperationResult DataShareOperationResult(System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResponseError error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataShare.Models.DataShareOperationStatus status = default(Azure.ResourceManager.DataShare.Models.DataShareOperationStatus)) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData DataShareSynchronizationSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.DataShare.DataShareTriggerData DataShareTriggerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.KustoClusterDataSet KustoClusterDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), Azure.Core.ResourceIdentifier kustoClusterResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping KustoClusterDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), Azure.Core.ResourceIdentifier kustoClusterResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet KustoDatabaseDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), Azure.Core.ResourceIdentifier kustoDatabaseResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping KustoDatabaseDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), Azure.Core.ResourceIdentifier kustoClusterResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.KustoTableDataSet KustoTableDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), Azure.Core.ResourceIdentifier kustoDatabaseResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties tableLevelSharingProperties = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping KustoTableDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), Azure.Core.ResourceIdentifier kustoClusterResourceId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataShare.ProviderShareSubscriptionData ProviderShareSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string consumerEmail = null, string consumerName = null, string consumerTenantName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string providerEmail = null, string providerName = null, System.DateTimeOffset? sharedOn = default(System.DateTimeOffset?), string shareSubscriptionObjectId = null, Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus? shareSubscriptionStatus = default(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting ScheduledSourceSynchronizationSetting(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval? recurrenceInterval = default(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval?), System.DateTimeOffset? synchronizeOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting ScheduledSynchronizationSetting(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval recurrenceInterval = default(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval), System.DateTimeOffset synchronizeOn = default(System.DateTimeOffset), string userName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ScheduledTrigger ScheduledTrigger(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval recurrenceInterval = default(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval), Azure.ResourceManager.DataShare.Models.SynchronizationMode? synchronizationMode = default(Azure.ResourceManager.DataShare.Models.SynchronizationMode?), System.DateTimeOffset synchronizeOn = default(System.DateTimeOffset), Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus? triggerStatus = default(Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus?), string userName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareDataSetData ShareDataSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareDataSetMappingData ShareDataSetMappingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareSubscriptionData ShareSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.Guid invitationId = default(System.Guid), string providerEmail = null, string providerName = null, string providerTenantName = null, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string shareDescription = null, Azure.ResourceManager.DataShare.Models.DataShareKind? shareKind = default(Azure.ResourceManager.DataShare.Models.DataShareKind?), string shareName = null, Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus? shareSubscriptionStatus = default(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus?), string shareTerms = null, Azure.Core.AzureLocation sourceShareLocation = default(Azure.Core.AzureLocation), string userEmail = null, string userName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization ShareSubscriptionSynchronization(int? durationInMilliSeconds = default(int?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string message = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string status = null, System.Guid synchronizationId = default(System.Guid), Azure.ResourceManager.DataShare.Models.SynchronizationMode? synchronizationMode = default(Azure.ResourceManager.DataShare.Models.SynchronizationMode?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ShareSynchronization ShareSynchronization(string consumerEmail = null, string consumerName = null, string consumerTenantName = null, int? durationInMilliSeconds = default(int?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string message = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string status = null, System.Guid? synchronizationId = default(System.Guid?), Azure.ResourceManager.DataShare.Models.SynchronizationMode? synchronizationMode = default(Azure.ResourceManager.DataShare.Models.SynchronizationMode?)) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet SqlDBTableDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string databaseName = null, System.Guid? dataSetId = default(System.Guid?), string schemaName = null, Azure.Core.ResourceIdentifier sqlServerResourceId = null, string tableName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping SqlDBTableDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string databaseName = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string schemaName = null, Azure.Core.ResourceIdentifier sqlServerResourceId = null, string tableName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet SqlDWTableDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), string dataWarehouseName = null, string schemaName = null, Azure.Core.ResourceIdentifier sqlServerResourceId = null, string tableName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping SqlDWTableDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), string dataWarehouseName = null, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), string schemaName = null, Azure.Core.ResourceIdentifier sqlServerResourceId = null, string tableName = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet SynapseWorkspaceSqlPoolTableDataSet(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? dataSetId = default(System.Guid?), Azure.Core.ResourceIdentifier synapseWorkspaceSqlPoolTableResourceId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping SynapseWorkspaceSqlPoolTableDataSetMapping(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid dataSetId = default(System.Guid), Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? dataSetMappingStatus = default(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus?), Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? provisioningState = default(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState?), Azure.Core.ResourceIdentifier synapseWorkspaceSqlPoolTableResourceId = null) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SynchronizationDetails SynchronizationDetails(System.Guid? dataSetId = default(System.Guid?), Azure.ResourceManager.DataShare.Models.ShareDataSetType? dataSetType = default(Azure.ResourceManager.DataShare.Models.ShareDataSetType?), int? durationInMilliSeconds = default(int?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), long? filesRead = default(long?), long? filesWritten = default(long?), string message = null, string name = null, long? rowsCopied = default(long?), long? rowsRead = default(long?), long? sizeRead = default(long?), long? sizeWritten = default(long?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string status = null, long? vCore = default(long?)) { throw null; }
    }
    public partial class BlobContainerDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSet>
    {
        public BlobContainerDataSet(string containerName, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public System.Guid? DataSetId { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobContainerDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobContainerDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobContainerDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping>
    {
        public BlobContainerDataSetMapping(string containerName, System.Guid dataSetId, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobContainerDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSet>
    {
        public BlobDataSet(string containerName, string filePath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public System.Guid? DataSetId { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSetMapping>
    {
        public BlobDataSetMapping(string containerName, System.Guid dataSetId, string filePath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareOutputType? OutputType { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobFolderDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSet>
    {
        public BlobFolderDataSet(string containerName, string prefix, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public System.Guid? DataSetId { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobFolderDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobFolderDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobFolderDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping>
    {
        public BlobFolderDataSetMapping(string containerName, System.Guid dataSetId, string prefix, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.BlobFolderDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConsumerSourceDataSet : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet>
    {
        public ConsumerSourceDataSet() { }
        public System.Guid? DataSetId { get { throw null; } }
        public Azure.Core.AzureLocation? DataSetLocation { get { throw null; } }
        public string DataSetName { get { throw null; } }
        public string DataSetPath { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareDataSetType? DataSetType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSetMappingStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataSetMappingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSetMappingStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataSetMappingStatus Broken { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetMappingStatus Ok { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus left, Azure.ResourceManager.DataShare.Models.DataSetMappingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataSetMappingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus left, Azure.ResourceManager.DataShare.Models.DataSetMappingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataShareAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareAccountPatch>
    {
        public DataShareAccountPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataShareEmailRegistration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>
    {
        public DataShareEmailRegistration() { }
        public string ActivationCode { get { throw null; } set { } }
        public System.DateTimeOffset? ActivationExpireOn { get { throw null; } }
        public string Email { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus? RegistrationStatus { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareEmailRegistrationStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareEmailRegistrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus Activated { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus ActivationAttemptsExhausted { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus ActivationPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus left, Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus left, Azure.ResourceManager.DataShare.Models.DataShareEmailRegistrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareInvitationStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareInvitationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus Withdrawn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus left, Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus left, Azure.ResourceManager.DataShare.Models.DataShareInvitationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareKind : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareKind(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareKind CopyBased { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareKind InPlace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareKind left, Azure.ResourceManager.DataShare.Models.DataShareKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareKind left, Azure.ResourceManager.DataShare.Models.DataShareKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataShareOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>
    {
        internal DataShareOperationResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareOperationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareOperationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareOperationStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareOperationStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareOperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareOperationStatus TransientFailure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareOperationStatus left, Azure.ResourceManager.DataShare.Models.DataShareOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareOperationStatus left, Azure.ResourceManager.DataShare.Models.DataShareOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareOutputType : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareOutputType(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareOutputType Csv { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareOutputType Parquet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareOutputType left, Azure.ResourceManager.DataShare.Models.DataShareOutputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareOutputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareOutputType left, Azure.ResourceManager.DataShare.Models.DataShareOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareProvisioningState : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState left, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareProvisioningState left, Azure.ResourceManager.DataShare.Models.DataShareProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareSynchronizationRecurrenceInterval : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareSynchronizationRecurrenceInterval(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval Day { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval Hour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval left, Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval left, Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataShareSynchronizeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent>
    {
        public DataShareSynchronizeContent() { }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.DataShareSynchronizeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataShareTriggerStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataShareTriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus SourceSynchronizationSettingDeleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus left, Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus left, Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoClusterDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSet>
    {
        public KustoClusterDataSet(Azure.Core.ResourceIdentifier kustoClusterResourceId) { }
        public System.Guid? DataSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoClusterDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoClusterDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KustoClusterDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping>
    {
        public KustoClusterDataSetMapping(System.Guid dataSetId, Azure.Core.ResourceIdentifier kustoClusterResourceId) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoClusterDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KustoDatabaseDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet>
    {
        public KustoDatabaseDataSet(Azure.Core.ResourceIdentifier kustoDatabaseResourceId) { }
        public System.Guid? DataSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier KustoDatabaseResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KustoDatabaseDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping>
    {
        public KustoDatabaseDataSetMapping(System.Guid dataSetId, Azure.Core.ResourceIdentifier kustoClusterResourceId) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoDatabaseDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KustoTableDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSet>
    {
        public KustoTableDataSet(Azure.Core.ResourceIdentifier kustoDatabaseResourceId, Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties tableLevelSharingProperties) { }
        public System.Guid? DataSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier KustoDatabaseResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoTableDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoTableDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KustoTableDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping>
    {
        public KustoTableDataSetMapping(System.Guid dataSetId, Azure.Core.ResourceIdentifier kustoClusterResourceId) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.KustoTableDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledSourceSynchronizationSetting : Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting>
    {
        internal ScheduledSourceSynchronizationSetting() { }
        public Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval? RecurrenceInterval { get { throw null; } }
        public System.DateTimeOffset? SynchronizeOn { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSourceSynchronizationSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledSynchronizationSetting : Azure.ResourceManager.DataShare.DataShareSynchronizationSettingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting>
    {
        public ScheduledSynchronizationSetting(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval recurrenceInterval, System.DateTimeOffset synchronizeOn) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval RecurrenceInterval { get { throw null; } set { } }
        public System.DateTimeOffset SynchronizeOn { get { throw null; } set { } }
        public string UserName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledSynchronizationSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduledTrigger : Azure.ResourceManager.DataShare.DataShareTriggerData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledTrigger>
    {
        public ScheduledTrigger(Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval recurrenceInterval, System.DateTimeOffset synchronizeOn) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareSynchronizationRecurrenceInterval RecurrenceInterval { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } set { } }
        public System.DateTimeOffset SynchronizeOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareTriggerStatus? TriggerStatus { get { throw null; } }
        public string UserName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ScheduledTrigger System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ScheduledTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ScheduledTrigger System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ScheduledTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareDataSetType : System.IEquatable<Azure.ResourceManager.DataShare.Models.ShareDataSetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareDataSetType(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType AdlsGen1File { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType AdlsGen1Folder { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType AdlsGen2File { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType AdlsGen2FileSystem { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType AdlsGen2Folder { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType Blob { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType BlobFolder { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType Container { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType KustoCluster { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType KustoDatabase { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType KustoTable { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType SqlDBTable { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType SqlDWTable { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareDataSetType SynapseWorkspaceSqlPoolTable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.ShareDataSetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.ShareDataSetType left, Azure.ResourceManager.DataShare.Models.ShareDataSetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.ShareDataSetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.ShareDataSetType left, Azure.ResourceManager.DataShare.Models.ShareDataSetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareSubscriptionStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus Revoking { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus SourceDeleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus left, Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus left, Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareSubscriptionSynchronization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>
    {
        public ShareSubscriptionSynchronization(System.Guid synchronizationId) { }
        public int? DurationInMilliSeconds { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Guid SynchronizationId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShareSynchronization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ShareSynchronization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSynchronization>
    {
        public ShareSynchronization() { }
        public string ConsumerEmail { get { throw null; } set { } }
        public string ConsumerName { get { throw null; } set { } }
        public string ConsumerTenantName { get { throw null; } set { } }
        public int? DurationInMilliSeconds { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public System.Guid? SynchronizationId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ShareSynchronization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ShareSynchronization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.ShareSynchronization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.ShareSynchronization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSynchronization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSynchronization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.ShareSynchronization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class SourceShareSynchronizationSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting>
    {
        protected SourceShareSynchronizationSetting() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDBTableDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet>
    {
        public SqlDBTableDataSet() { }
        public string DatabaseName { get { throw null; } set { } }
        public System.Guid? DataSetId { get { throw null; } }
        public string SchemaName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDBTableDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping>
    {
        public SqlDBTableDataSetMapping(string databaseName, System.Guid dataSetId, string schemaName, Azure.Core.ResourceIdentifier sqlServerResourceId, string tableName) { }
        public string DatabaseName { get { throw null; } set { } }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDBTableDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDWTableDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet>
    {
        public SqlDWTableDataSet() { }
        public System.Guid? DataSetId { get { throw null; } }
        public string DataWarehouseName { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDWTableDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping>
    {
        public SqlDWTableDataSetMapping(System.Guid dataSetId, string dataWarehouseName, string schemaName, Azure.Core.ResourceIdentifier sqlServerResourceId, string tableName) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string DataWarehouseName { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SqlDWTableDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynapseWorkspaceSqlPoolTableDataSet : Azure.ResourceManager.DataShare.ShareDataSetData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet>
    {
        public SynapseWorkspaceSqlPoolTableDataSet(Azure.Core.ResourceIdentifier synapseWorkspaceSqlPoolTableResourceId) { }
        public System.Guid? DataSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SynapseWorkspaceSqlPoolTableResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynapseWorkspaceSqlPoolTableDataSetMapping : Azure.ResourceManager.DataShare.ShareDataSetMappingData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping>
    {
        public SynapseWorkspaceSqlPoolTableDataSetMapping(System.Guid dataSetId, Azure.Core.ResourceIdentifier synapseWorkspaceSqlPoolTableResourceId) { }
        public System.Guid DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataShareProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SynapseWorkspaceSqlPoolTableResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynapseWorkspaceSqlPoolTableDataSetMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SynchronizationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynchronizationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynchronizationDetails>
    {
        internal SynchronizationDetails() { }
        public System.Guid? DataSetId { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareDataSetType? DataSetType { get { throw null; } }
        public int? DurationInMilliSeconds { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public long? FilesRead { get { throw null; } }
        public long? FilesWritten { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public long? RowsCopied { get { throw null; } }
        public long? RowsRead { get { throw null; } }
        public long? SizeRead { get { throw null; } }
        public long? SizeWritten { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public long? VCore { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SynchronizationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynchronizationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.SynchronizationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.SynchronizationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynchronizationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynchronizationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.SynchronizationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynchronizationMode : System.IEquatable<Azure.ResourceManager.DataShare.Models.SynchronizationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynchronizationMode(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SynchronizationMode FullSync { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.SynchronizationMode Incremental { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.SynchronizationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.SynchronizationMode left, Azure.ResourceManager.DataShare.Models.SynchronizationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.SynchronizationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.SynchronizationMode left, Azure.ResourceManager.DataShare.Models.SynchronizationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TableLevelSharingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties>
    {
        public TableLevelSharingProperties() { }
        public System.Collections.Generic.IList<string> ExternalTablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> ExternalTablesToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToInclude { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
