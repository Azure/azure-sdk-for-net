namespace Azure.ResourceManager.NotificationHubs
{
    public partial class AzureResourceManagerNotificationHubsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNotificationHubsContext() { }
        public static Azure.ResourceManager.NotificationHubs.AzureResourceManagerNotificationHubsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NotificationHubAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NotificationHubAuthorizationRuleCollection() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubAuthorizationRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>
    {
        public NotificationHubAuthorizationRuleData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> AccessRights { get { throw null; } }
        public string ClaimType { get { throw null; } }
        public string ClaimValue { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string PrimaryKey { get { throw null; } set { } }
        public int? Revision { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> Rights { get { throw null; } }
        public string SecondaryKey { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubAuthorizationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.IEnumerable
    {
        protected NotificationHubCollection() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.NotificationHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.NotificationHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Get(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAll(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAllAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetIfExists(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetIfExistsAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>
    {
        public NotificationHubData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.BrowserCredential BrowserCredential { get { throw null; } set { } }
        public long? DailyMaxActiveDevices { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential FcmV1Credential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NotificationHubName { get { throw null; } set { } }
        public System.TimeSpan? RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential XiaomiCredential { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubNamespaceAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NotificationHubNamespaceAuthorizationRuleCollection() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubNamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubNamespaceAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>, System.Collections.IEnumerable
    {
        protected NotificationHubNamespaceCollection() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAll(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAllAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubNamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>
    {
        public NotificationHubNamespaceData(Azure.Core.AzureLocation location) { }
        public NotificationHubNamespaceData(Azure.Core.AzureLocation location, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string DataCenter { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? HubNamespaceType { get { throw null; } set { } }
        public bool? IsCritical { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string NamespaceName { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? NamespaceStatus { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType? NamespaceType { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls NetworkAcls { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? OperationProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.PnsCredentials PnsCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? ReplicationRegion { get { throw null; } set { } }
        public string ScaleUnit { get { throw null; } set { } }
        public System.Uri ServiceBusEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference? ZoneRedundancy { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubNamespaceResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult> CheckNotificationHubAvailability(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>> CheckNotificationHubAvailabilityAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetNotificationHub(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetNotificationHubAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> GetNotificationHubNamespaceAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> GetNotificationHubNamespaceAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleCollection GetNotificationHubNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> GetNotificationHubPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>> GetNotificationHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionCollection GetNotificationHubPrivateEndpointConnections() { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubCollection GetNotificationHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> GetNotificationHubsPrivateLinkResource(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>> GetNotificationHubsPrivateLinkResourceAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceCollection GetNotificationHubsPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials> GetPnsCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>> GetPnsCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> Update(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected NotificationHubPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>
    {
        public NotificationHubPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult> DebugSend(System.BinaryData anyObject, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult> DebugSend(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>> DebugSendAsync(System.BinaryData anyObject, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>> DebugSendAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> GetNotificationHubAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> GetNotificationHubAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleCollection GetNotificationHubAuthorizationRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials> GetPnsCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>> GetPnsCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Update(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Update(Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NotificationHubsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult> CheckNotificationHubNamespaceAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>> CheckNotificationHubNamespaceAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource GetNotificationHubAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetNotificationHubNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource GetNotificationHubNamespaceAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource GetNotificationHubNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceCollection GetNotificationHubNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource GetNotificationHubPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubResource GetNotificationHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource GetNotificationHubsPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NotificationHubsPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubsPrivateLinkResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string subResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubsPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected NotificationHubsPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> Get(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>> GetAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> GetIfExists(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>> GetIfExistsAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubsPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>
    {
        public NotificationHubsPrivateLinkResourceData() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.NotificationHubs.Mocking
{
    public partial class MockableNotificationHubsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNotificationHubsArmClient() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource GetNotificationHubAuthorizationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource GetNotificationHubNamespaceAuthorizationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource GetNotificationHubNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource GetNotificationHubPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubResource GetNotificationHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResource GetNotificationHubsPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNotificationHubsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNotificationHubsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespace(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetNotificationHubNamespaceAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceCollection GetNotificationHubNamespaces() { throw null; }
    }
    public partial class MockableNotificationHubsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNotificationHubsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult> CheckNotificationHubNamespaceAvailability(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>> CheckNotificationHubNamespaceAvailabilityAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
}
namespace Azure.ResourceManager.NotificationHubs.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowedReplicationRegion : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowedReplicationRegion(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion AustraliaEast { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion BrazilSouth { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion Default { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion None { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion NorthEurope { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion SouthAfricaNorth { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion SouthEastAsia { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion WestUS2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion left, Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion left, Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmNotificationHubsModelFactory
    {
        public static Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData NotificationHubAuthorizationRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> accessRights = null, string primaryKey = null, string secondaryKey = null, string keyName = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string claimType = null, string claimValue = null, int? revision = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData NotificationHubAuthorizationRuleData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> rights, string primaryKey, string secondaryKey, string keyName, string claimType, string claimValue, System.DateTimeOffset? modifiedOn, System.DateTimeOffset? createdOn, int? revision, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent NotificationHubAvailabilityContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), bool? isAvailiable = default(bool?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult NotificationHubAvailabilityResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), bool? isAvailiable = default(bool?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent NotificationHubCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string notificationHubName = null, System.TimeSpan? registrationTtl = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubData NotificationHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null, string notificationHubName = null, System.TimeSpan? registrationTtl = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.BrowserCredential browserCredential = null, Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential xiaomiCredential = null, Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential fcmV1Credential = null, long? dailyMaxActiveDevices = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.NotificationHubData NotificationHubData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string notificationHubName, System.TimeSpan? registrationTtl, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent NotificationHubNamespaceCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string namespaceName = null, string provisioningState = null, string region = null, string metricId = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.Uri serviceBusEndpoint = null, string subscriptionId = null, string scaleUnit = null, bool? isEnabled = default(bool?), bool? isCritical = default(bool?), string dataCenter = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType? namespaceType = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData NotificationHubNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null, string namespaceName = null, Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? operationProvisioningState = default(Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? namespaceStatus = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus?), bool? isEnabled = default(bool?), bool? isCritical = default(bool?), string subscriptionId = null, string region = null, string metricId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? hubNamespaceType = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt?), Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? replicationRegion = default(Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion?), Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference? zoneRedundancy = default(Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls networkAcls = null, Azure.ResourceManager.NotificationHubs.Models.PnsCredentials pnsCredentials = null, System.Uri serviceBusEndpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> privateEndpointConnections = null, string scaleUnit = null, string dataCenter = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData NotificationHubNamespaceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string namespaceName, string provisioningState, string region, string metricId, string status, System.DateTimeOffset? createdOn, System.DateTimeOffset? updatedOn, System.Uri serviceBusEndpoint, string subscriptionId, string scaleUnit, bool? isEnabled, bool? isCritical, string dataCenter, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType? namespaceType, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties NotificationHubNamespaceProperties(string namespaceName = null, Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? provisioningState = default(Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? status = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus?), bool? isEnabled = default(bool?), bool? isCritical = default(bool?), string subscriptionId = null, string region = null, string metricId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? namespaceType = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt?), Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? replicationRegion = default(Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion?), Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference? zoneRedundancy = default(Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls networkAcls = null, Azure.ResourceManager.NotificationHubs.Models.PnsCredentials pnsCredentials = null, System.Uri serviceBusEndpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> privateEndpointConnections = null, string scaleUnit = null, string dataCenter = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch NotificationHubPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string notificationHubName = null, System.TimeSpan? registrationTtl = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials NotificationHubPnsCredentials(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.BrowserCredential browserCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential xiaomiCredential = null, Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential fcmV1Credential = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials NotificationHubPnsCredentials(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData NotificationHubPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties NotificationHubPrivateEndpointConnectionProperties(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult NotificationHubPubRegistrationResult(string applicationPlatform = null, string pnsHandle = null, string registrationId = null, string outcome = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys NotificationHubResourceKeys(string primaryConnectionString = null, string secondaryConnectionString = null, string primaryKey = null, string secondaryKey = null, string keyName = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceData NotificationHubsPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties NotificationHubsPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult NotificationHubTestSendResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, int? success, int? failure, System.BinaryData results, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult NotificationHubTestSendResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? success = default(int?), int? failure = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult> failureDescription = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState RemotePrivateLinkServiceConnectionState(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus? status = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties SharedAccessAuthorizationRuleProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> accessRights = null, string primaryKey = null, string secondaryKey = null, string keyName = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string claimType = null, string claimValue = null, int? revision = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties SharedAccessAuthorizationRuleProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> rights, string primaryKey, string secondaryKey, string keyName, string claimType, string claimValue, System.DateTimeOffset? modifiedOn, System.DateTimeOffset? createdOn, int? revision) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum AuthorizationRuleAccessRight
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthorizationRuleAccessRightExt : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthorizationRuleAccessRightExt(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt Listen { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt Manage { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt Send { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt left, Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt left, Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrowserCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.BrowserCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.BrowserCredential>
    {
        public BrowserCredential(string subject, string vapidPrivateKey, string vapidPublicKey) { }
        public string Subject { get { throw null; } set { } }
        public string VapidPrivateKey { get { throw null; } set { } }
        public string VapidPublicKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.BrowserCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.BrowserCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.BrowserCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.BrowserCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.BrowserCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.BrowserCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.BrowserCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FcmV1Credential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential>
    {
        public FcmV1Credential(string clientEmail, string privateKey, string projectId) { }
        public string ClientEmail { get { throw null; } set { } }
        public string PrivateKey { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubAdmCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NotificationHubAdmCredential() { }
        public NotificationHubAdmCredential(string clientId, string clientSecret, System.Uri authTokenUri) { }
        public System.Uri AuthTokenUri { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubApnsCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NotificationHubApnsCredential() { }
        public NotificationHubApnsCredential(System.Uri endpoint) { }
        public string ApnsCertificate { get { throw null; } set { } }
        public string AppId { get { throw null; } set { } }
        public string AppName { get { throw null; } set { } }
        public string CertificateKey { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubAvailabilityContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent>
    {
        public NotificationHubAvailabilityContent(Azure.Core.AzureLocation location) { }
        public bool? IsAvailiable { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubAvailabilityResult : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>
    {
        public NotificationHubAvailabilityResult(Azure.Core.AzureLocation location) { }
        public bool? IsAvailiable { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubBaiduCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NotificationHubBaiduCredential() { }
        public NotificationHubBaiduCredential(string baiduApiKey, System.Uri baiduEndpoint, string baiduSecretKey) { }
        public string BaiduApiKey { get { throw null; } set { } }
        public System.Uri BaiduEndpoint { get { throw null; } set { } }
        public string BaiduSecretKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NotificationHubCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent>
    {
        public NotificationHubCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NotificationHubName { get { throw null; } set { } }
        public System.TimeSpan? RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubGcmCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NotificationHubGcmCredential() { }
        public NotificationHubGcmCredential(string gcmApiKey) { }
        public string GcmApiKey { get { throw null; } set { } }
        public System.Uri GcmEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule>
    {
        public NotificationHubIPRule(string ipMask, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> accessRights) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> AccessRights { get { throw null; } }
        public string IPMask { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubMpnsCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NotificationHubMpnsCredential() { }
        public NotificationHubMpnsCredential(string mpnsCertificate, string certificateKey, string thumbprintString) { }
        public string CertificateKey { get { throw null; } set { } }
        public string MpnsCertificate { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NotificationHubNamespaceCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent>
    {
        public NotificationHubNamespaceCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string DataCenter { get { throw null; } set { } }
        public bool? IsCritical { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string NamespaceName { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType? NamespaceType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ScaleUnit { get { throw null; } set { } }
        public System.Uri ServiceBusEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubNamespacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>
    {
        public NotificationHubNamespacePatch() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubNamespaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties>
    {
        public NotificationHubNamespaceProperties() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string DataCenter { get { throw null; } set { } }
        public bool? IsCritical { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string NamespaceName { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? NamespaceType { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls NetworkAcls { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.PnsCredentials PnsCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? ReplicationRegion { get { throw null; } set { } }
        public string ScaleUnit { get { throw null; } set { } }
        public System.Uri ServiceBusEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference? ZoneRedundancy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationHubNamespaceStatus : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationHubNamespaceStatus(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus Created { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus Creating { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum NotificationHubNamespaceType
    {
        Messaging = 0,
        NotificationHub = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationHubNamespaceTypeExt : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationHubNamespaceTypeExt(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt Messaging { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt NotificationHub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationHubNetworkAcls : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls>
    {
        public NotificationHubNetworkAcls() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.NotificationHubIPRule> IPRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> PublicNetworkRuleAccessRights { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>
    {
        public NotificationHubPatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NotificationHubName { get { throw null; } set { } }
        public System.TimeSpan? RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPnsCredentials : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>
    {
        public NotificationHubPnsCredentials(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.BrowserCredential BrowserCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential FcmV1Credential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential XiaomiCredential { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPolicyKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NotificationHubPolicyKey() { }
        public NotificationHubPolicyKey(string policyKey) { }
        public string PolicyKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties>
    {
        public NotificationHubPrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationHubPrivateLinkConnectionStatus : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationHubPrivateLinkConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationHubPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationHubPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationHubPubRegistrationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult>
    {
        internal NotificationHubPubRegistrationResult() { }
        public string ApplicationPlatform { get { throw null; } }
        public string Outcome { get { throw null; } }
        public string PnsHandle { get { throw null; } }
        public string RegistrationId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubResourceKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>
    {
        internal NotificationHubResourceKeys() { }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku>
    {
        public NotificationHubSku(Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationHubSkuName : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationHubSkuName(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationHubsPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationHubsPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState DeletingByProxy { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState UpdatingByProxy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationHubsPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties>
    {
        public NotificationHubsPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubTestSendResult : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>
    {
        public NotificationHubTestSendResult(Azure.Core.AzureLocation location) { }
        public int? Failure { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult> FailureDescription { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.BinaryData Results { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public int? Success { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent>
    {
        public NotificationHubUpdateContent() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.BrowserCredential BrowserCredential { get { throw null; } set { } }
        public long? DailyMaxActiveDevices { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential FcmV1Credential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NotificationHubName { get { throw null; } set { } }
        public System.TimeSpan? RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential XiaomiCredential { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubWnsCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>
    {
        public NotificationHubWnsCredential() { }
        public string CertificateKey { get { throw null; } set { } }
        public string PackageSid { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        public System.Uri WindowsLiveEndpoint { get { throw null; } set { } }
        public string WnsCertificate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationProvisioningState : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState left, Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState left, Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PnsCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.PnsCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.PnsCredentials>
    {
        public PnsCredentials() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.BrowserCredential BrowserCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential FcmV1Credential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential XiaomiCredential { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.PnsCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.PnsCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.PnsCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.PnsCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.PnsCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.PnsCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.PnsCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemotePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState>
    {
        public RemotePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SharedAccessAuthorizationRuleCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent>
    {
        public SharedAccessAuthorizationRuleCreateOrUpdateContent(Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties properties) { }
        public Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties Properties { get { throw null; } }
        Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedAccessAuthorizationRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>
    {
        public SharedAccessAuthorizationRuleProperties() { }
        public SharedAccessAuthorizationRuleProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> accessRights) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> AccessRights { get { throw null; } }
        public string ClaimType { get { throw null; } }
        public string ClaimValue { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string PrimaryKey { get { throw null; } set { } }
        public int? Revision { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> Rights { get { throw null; } }
        public string SecondaryKey { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class XiaomiCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential>
    {
        public XiaomiCredential() { }
        public string AppSecret { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundancyPreference : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundancyPreference(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference Disabled { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference left, Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference left, Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
}
