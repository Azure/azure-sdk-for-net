namespace Azure.ResourceManager.NotificationHubs
{
    public partial class NotificationHubAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NotificationHubAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string ClaimType { get { throw null; } }
        public string ClaimValue { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> Rights { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.IEnumerable
    {
        protected NotificationHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Get(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NotificationHubName { get { throw null; } set { } }
        public System.TimeSpan? RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.NotificationHubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubNamespaceAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NotificationHubNamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class NotificationHubNamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubNamespaceAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey notificationHubPolicyKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>, System.Collections.IEnumerable
    {
        protected NotificationHubNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubNamespaceResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubCollection GetNotificationHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> Update(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult> DebugSend(System.BinaryData anyObject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>> DebugSendAsync(System.BinaryData anyObject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Update(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubResource GetNotificationHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubResource GetNotificationHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NotificationHubs.Models
{
    public static partial class ArmNotificationHubsModelFactory
    {
        public static Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleData NotificationHubAuthorizationRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> rights = null, string primaryKey = null, string secondaryKey = null, string keyName = null, string claimType = null, string claimValue = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), int? revision = default(int?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent NotificationHubAvailabilityContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null, bool? isAvailiable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult NotificationHubAvailabilityResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), bool? isAvailiable = default(bool?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubCreateOrUpdateContent NotificationHubCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string notificationHubName = null, System.TimeSpan? registrationTtl = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubData NotificationHubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string notificationHubName = null, System.TimeSpan? registrationTtl = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceCreateOrUpdateContent NotificationHubNamespaceCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string namespaceName = null, string provisioningState = null, string region = null, string metricId = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.Uri serviceBusEndpoint = null, string subscriptionId = null, string scaleUnit = null, bool? isEnabled = default(bool?), bool? isCritical = default(bool?), string dataCenter = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType? namespaceType = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceData NotificationHubNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string namespaceName = null, string provisioningState = null, string region = null, string metricId = null, string status = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), System.Uri serviceBusEndpoint = null, string subscriptionId = null, string scaleUnit = null, bool? isEnabled = default(bool?), bool? isCritical = default(bool?), string dataCenter = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType? namespaceType = default(Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespaceType?), Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPatch NotificationHubPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string notificationHubName = null, System.TimeSpan? registrationTtl = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> authorizationRules = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials NotificationHubPnsCredentials(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential apnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential wnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential gcmCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential mpnsCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential admCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential baiduCredential = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys NotificationHubResourceKeys(string primaryConnectionString = null, string secondaryConnectionString = null, string primaryKey = null, string secondaryKey = null, string keyName = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult NotificationHubTestSendResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), int? success = default(int?), int? failure = default(int?), System.BinaryData results = null, Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku sku = null) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties SharedAccessAuthorizationRuleProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> rights = null, string primaryKey = null, string secondaryKey = null, string keyName = null, string claimType = null, string claimValue = null, System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), int? revision = default(int?)) { throw null; }
    }
    public enum AuthorizationRuleAccessRight
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    public partial class NotificationHubAdmCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>
    {
        public NotificationHubAdmCredential() { }
        public System.Uri AuthTokenUri { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubApnsCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential>
    {
        public NotificationHubApnsCredential() { }
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
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubBaiduCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>
    {
        public NotificationHubBaiduCredential() { }
        public string BaiduApiKey { get { throw null; } set { } }
        public System.Uri BaiduEndpoint { get { throw null; } set { } }
        public string BaiduSecretKey { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
        public NotificationHubGcmCredential() { }
        public string GcmApiKey { get { throw null; } set { } }
        public System.Uri GcmEndpoint { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubMpnsCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>
    {
        public NotificationHubMpnsCredential() { }
        public string CertificateKey { get { throw null; } set { } }
        public string MpnsCertificate { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string ThumbprintString { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum NotificationHubNamespaceType
    {
        Messaging = 0,
        NotificationHub = 1,
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
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPnsCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubPolicyKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>
    {
        public NotificationHubPolicyKey() { }
        public string PolicyKey { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubPolicyKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubResourceKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceKeys>
    {
        internal NotificationHubResourceKeys() { }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
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
    public partial class NotificationHubTestSendResult : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>
    {
        public NotificationHubTestSendResult(Azure.Core.AzureLocation location) { }
        public int? Failure { get { throw null; } set { } }
        public System.BinaryData Results { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public int? Success { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubTestSendResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationHubWnsCredential : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>
    {
        public NotificationHubWnsCredential() { }
        public string PackageSid { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        public System.Uri WindowsLiveEndpoint { get { throw null; } set { } }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
        public string ClaimType { get { throw null; } }
        public string ClaimValue { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string KeyName { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AuthorizationRuleAccessRight> Rights { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
