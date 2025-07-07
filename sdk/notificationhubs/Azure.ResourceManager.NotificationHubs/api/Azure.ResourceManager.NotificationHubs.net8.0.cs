namespace Azure.ResourceManager.NotificationHubs
{
    public partial class AzureResourceManagerNotificationHubsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNotificationHubsContext() { }
        public static Azure.ResourceManager.NotificationHubs.AzureResourceManagerNotificationHubsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NamespaceAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceNotificationHubAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NamespaceNotificationHubAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> GetIfExists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceNotificationHubAuthorizationRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceNotificationHubAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string SecondaryKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.IEnumerable
    {
        protected NotificationHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.NotificationHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.NotificationHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Get(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAll(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAllAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.BrowserCredential BrowserCredential { get { throw null; } set { } }
        public long? DailyMaxActiveDevices { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential FcmV1Credential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public string RegistrationTtl { get { throw null; } set { } }
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
    public partial class NotificationHubNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>, System.Collections.IEnumerable
    {
        protected NotificationHubNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAll(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAllAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubNamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>
    {
        public NotificationHubNamespaceData(Azure.Core.AzureLocation location, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DataCenter { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? HubNamespaceType { get { throw null; } set { } }
        public bool? IsCritical { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? NamespaceStatus { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls NetworkAcls { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? OperationProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.PnsCredentials PnsCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? ReplicationRegion { get { throw null; } set { } }
        public string ScaleUnit { get { throw null; } set { } }
        public System.Uri ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
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
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataCollection GetAllNotificationHubsPrivateLinkResourceData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> GetNamespaceAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> GetNamespaceAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleCollection GetNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetNotificationHub(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetNotificationHubAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource> GetNotificationHubPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource>> GetNotificationHubPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionCollection GetNotificationHubPrivateEndpointConnections() { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubCollection GetNotificationHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> GetNotificationHubsPrivateLinkResourceData(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>> GetNotificationHubsPrivateLinkResourceDataAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult> DebugSend(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>> DebugSendAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> GetNamespaceNotificationHubAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> GetNamespaceNotificationHubAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleCollection GetNamespaceNotificationHubAuthorizationRules() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Update(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NotificationHubsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult> CheckAvailabilityNamespacesOperationGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>> CheckAvailabilityNamespacesOperationGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource GetNamespaceAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource GetNamespaceNotificationHubAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> GetNotificationHubNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource GetNotificationHubNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceCollection GetNotificationHubNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource GetNotificationHubPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubResource GetNotificationHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource GetNotificationHubsPrivateLinkResourceDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NotificationHubs.Models.Info> GetOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.Models.Info> GetOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubsPrivateLinkResourceDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>, System.Collections.IEnumerable
    {
        protected NotificationHubsPrivateLinkResourceDataCollection() { }
        public virtual Azure.Response<bool> Exists(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> Get(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>> GetAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> GetIfExists(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>> GetIfExistsAsync(string subResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubsPrivateLinkResourceDataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>
    {
        internal NotificationHubsPrivateLinkResourceDataData() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubsPrivateLinkResourceDataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubsPrivateLinkResourceDataResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string subResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.NotificationHubs.Mocking
{
    public partial class MockableNotificationHubsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNotificationHubsArmClient() { }
        public virtual Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource GetNamespaceAuthorizationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource GetNamespaceNotificationHubAuthorizationRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource GetNotificationHubNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionResource GetNotificationHubPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubResource GetNotificationHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataResource GetNotificationHubsPrivateLinkResourceDataResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult> CheckAvailabilityNamespacesOperationGroup(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>> CheckAvailabilityNamespacesOperationGroupAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(string skipToken = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableNotificationHubsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNotificationHubsTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.Models.Info> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.Models.Info> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.NotificationHubs.Models.Availability Availability(string timeGrain = null, string blobDuration = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.Info Info(string name = null, Azure.ResourceManager.NotificationHubs.Models.OperationDisplay display = null, bool? isDataAction = default(bool?), Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification operationServiceSpecification = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.LogSpecification LogSpecification(string name = null, string displayName = null, string blobDuration = null, System.Collections.Generic.IEnumerable<string> categoryGroups = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.MetricSpecification MetricSpecification(string name = null, string displayName = null, string displayDescription = null, string unit = null, string aggregationType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.Availability> availabilities = null, System.Collections.Generic.IEnumerable<string> supportedTimeGrainTypes = null, string metricFilterPattern = null, bool? fillGapWithZero = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData NotificationHubAuthorizationRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> accessRights = null, string primaryKey = null, string secondaryKey = null, string keyName = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string claimType = null, string claimValue = null, int? revision = default(int?)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent NotificationHubAvailabilityContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), bool? isAvailiable = default(bool?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult NotificationHubAvailabilityResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isAvailiable = default(bool?), string location = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubData NotificationHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string registrationTtl = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.BrowserCredential browserCredential = null, Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential xiaomiCredential = null, Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential fcmV1Credential = null, long? dailyMaxActiveDevices = default(long?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData NotificationHubNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null, Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? operationProvisioningState = default(Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? namespaceStatus = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus?), bool? isEnabled = default(bool?), bool? isCritical = default(bool?), string subscriptionId = null, string region = null, string metricId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? hubNamespaceType = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt?), Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? replicationRegion = default(Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion?), Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference? zoneRedundancy = default(Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls networkAcls = null, Azure.ResourceManager.NotificationHubs.Models.PnsCredentials pnsCredentials = null, System.Uri serviceBusEndpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> privateEndpointConnections = null, string scaleUnit = null, string dataCenter = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceProperties NotificationHubNamespaceProperties(string name = null, Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? operationProvisioningState = default(Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? namespaceStatus = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus?), bool? isEnabled = default(bool?), bool? isCritical = default(bool?), string subscriptionId = null, string region = null, string metricId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? hubNamespaceType = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt?), Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? replicationRegion = default(Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion?), Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference? zoneRedundancy = default(Azure.ResourceManager.NotificationHubs.Models.ZoneRedundancyPreference?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls networkAcls = null, Azure.ResourceManager.NotificationHubs.Models.PnsCredentials pnsCredentials = null, System.Uri serviceBusEndpoint = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> privateEndpointConnections = null, string scaleUnit = null, string dataCenter = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch NotificationHubPatch(string name = null, string registrationTtl = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.BrowserCredential browserCredential = null, Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential xiaomiCredential = null, Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential fcmV1Credential = null, long? dailyMaxActiveDevices = default(long?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials NotificationHubPnsCredentials(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.BrowserCredential browserCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential xiaomiCredential = null, Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential fcmV1Credential = null, string location = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData NotificationHubPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateEndpointConnectionProperties NotificationHubPrivateEndpointConnectionProperties(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState privateLinkServiceConnectionState = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult NotificationHubPubRegistrationResult(string applicationPlatform = null, string pnsHandle = null, string registrationId = null, string outcome = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys NotificationHubResourceKeys(string primaryConnectionString = null, string secondaryConnectionString = null, string primaryKey = null, string secondaryKey = null, string keyName = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubsPrivateLinkResourceDataData NotificationHubsPrivateLinkResourceDataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsPrivateLinkResourceProperties NotificationHubsPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult NotificationHubTestSendResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? success = default(long?), long? failure = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult> failureDescription = null, string location = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.OperationDisplay OperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState RemotePrivateLinkServiceConnectionState(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus? status = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPrivateLinkConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification ServiceSpecification(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.LogSpecification> logSpecifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification> metricSpecifications = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties SharedAccessAuthorizationRuleProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> accessRights = null, string primaryKey = null, string secondaryKey = null, string keyName = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string claimType = null, string claimValue = null, int? revision = default(int?)) { throw null; }
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
    public partial class Availability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.Availability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Availability>
    {
        internal Availability() { }
        public string BlobDuration { get { throw null; } }
        public string TimeGrain { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.Availability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.Availability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.Availability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.Availability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Availability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Availability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Availability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class Info : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.Info>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Info>
    {
        internal Info() { }
        public Azure.ResourceManager.NotificationHubs.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification OperationServiceSpecification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.Info System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.Info>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.Info>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.Info System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Info>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Info>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.Info>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.LogSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.LogSpecification>
    {
        internal LogSpecification() { }
        public string BlobDuration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> CategoryGroups { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.LogSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.LogSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.LogSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.LogSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.LogSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.LogSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.LogSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification>
    {
        internal MetricSpecification() { }
        public string AggregationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.Models.Availability> Availabilities { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? FillGapWithZero { get { throw null; } }
        public string MetricFilterPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedTimeGrainTypes { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.MetricSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.MetricSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubAdmCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>
    {
        public NotificationHubAdmCredential(string clientId, string clientSecret, string authTokenUri) { }
        public string AuthTokenUri { get { throw null; } set { } }
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
        public NotificationHubApnsCredential(System.Uri endpoint) { }
        public string ApnsCertificate { get { throw null; } set { } }
        public string AppId { get { throw null; } set { } }
        public string AppName { get { throw null; } set { } }
        public string CertificateKey { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
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
    public partial class NotificationHubAvailabilityResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>
    {
        internal NotificationHubAvailabilityResult() { }
        public bool? IsAvailiable { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubBaiduCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>
    {
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
    public partial class NotificationHubGcmCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>
    {
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
        public NotificationHubMpnsCredential(string mpnsCertificate, string certificateKey, string thumbprintString) { }
        public string CertificateKey { get { throw null; } set { } }
        public string MpnsCertificate { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DataCenter { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceTypeExt? HubNamespaceType { get { throw null; } set { } }
        public bool? IsCritical { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public string MetricId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceStatus? NamespaceStatus { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubNetworkAcls NetworkAcls { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.OperationProvisioningState? OperationProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.PnsCredentials PnsCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.NotificationHubPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.AllowedReplicationRegion? ReplicationRegion { get { throw null; } set { } }
        public string ScaleUnit { get { throw null; } set { } }
        public System.Uri ServiceBusEndpoint { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
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
    public partial class NotificationHubPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>
    {
        public NotificationHubPatch() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.BrowserCredential BrowserCredential { get { throw null; } set { } }
        public long? DailyMaxActiveDevices { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential FcmV1Credential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential XiaomiCredential { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPnsCredentials : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>
    {
        internal NotificationHubPnsCredentials() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.BrowserCredential BrowserCredential { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.FcmV1Credential FcmV1Credential { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.XiaomiCredential XiaomiCredential { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPolicyKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>
    {
        public NotificationHubPolicyKey(Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType policyKey) { }
        public Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType PolicyKey { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.RemotePrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
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
        internal NotificationHubsPrivateLinkResourceProperties() { }
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
    public partial class NotificationHubTestSendResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>
    {
        internal NotificationHubTestSendResult() { }
        public long? Failure { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPubRegistrationResult> FailureDescription { get { throw null; } }
        public string Location { get { throw null; } }
        public long? Success { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.OperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.OperationDisplay>
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.OperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.OperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.OperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.OperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.OperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.OperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.OperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyKeyType : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyKeyType(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType PrimaryKey { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType SecondaryKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType left, Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType left, Azure.ResourceManager.NotificationHubs.Models.PolicyKeyType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ServiceSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification>
    {
        internal ServiceSpecification() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.Models.LogSpecification> LogSpecifications { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NotificationHubs.Models.MetricSpecification> MetricSpecifications { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.ServiceSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedAccessAuthorizationRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>
    {
        public SharedAccessAuthorizationRuleProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> accessRights) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRightExt> AccessRights { get { throw null; } }
        public string ClaimType { get { throw null; } }
        public string ClaimValue { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string PrimaryKey { get { throw null; } set { } }
        public int? Revision { get { throw null; } }
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
