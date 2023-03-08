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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubAuthorizationRuleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubAuthorizationRuleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationHubNamespaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubNamespaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
namespace Azure.ResourceManager.NotificationHubs.Mock
{
    public partial class NotificationHubNamespaceResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected NotificationHubNamespaceResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult> CheckNotificationHubNamespaceAvailability(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityResult>> CheckNotificationHubNamespaceAvailabilityAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceResource> GetNotificationHubNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubNamespaceCollection GetNotificationHubNamespaces() { throw null; }
    }
}
namespace Azure.ResourceManager.NotificationHubs.Models
{
    public enum AuthorizationRuleAccessRight
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    public partial class NotificationHubAdmCredential
    {
        public NotificationHubAdmCredential() { }
        public System.Uri AuthTokenUri { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
    }
    public partial class NotificationHubApnsCredential
    {
        public NotificationHubApnsCredential() { }
        public string ApnsCertificate { get { throw null; } set { } }
        public string AppId { get { throw null; } set { } }
        public string AppName { get { throw null; } set { } }
        public string CertificateKey { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
    }
    public partial class NotificationHubAvailabilityContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubAvailabilityContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? IsAvailiable { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
    }
    public partial class NotificationHubAvailabilityResult : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubAvailabilityResult(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? IsAvailiable { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
    }
    public partial class NotificationHubBaiduCredential
    {
        public NotificationHubBaiduCredential() { }
        public string BaiduApiKey { get { throw null; } set { } }
        public System.Uri BaiduEndpoint { get { throw null; } set { } }
        public string BaiduSecretKey { get { throw null; } set { } }
    }
    public partial class NotificationHubCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubCreateOrUpdateContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    }
    public partial class NotificationHubGcmCredential
    {
        public NotificationHubGcmCredential() { }
        public string GcmApiKey { get { throw null; } set { } }
        public System.Uri GcmEndpoint { get { throw null; } set { } }
    }
    public partial class NotificationHubMpnsCredential
    {
        public NotificationHubMpnsCredential() { }
        public string CertificateKey { get { throw null; } set { } }
        public string MpnsCertificate { get { throw null; } set { } }
        public System.BinaryData Thumbprint { get { throw null; } set { } }
    }
    public partial class NotificationHubNamespaceCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubNamespaceCreateOrUpdateContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    }
    public partial class NotificationHubNamespacePatch
    {
        public NotificationHubNamespacePatch() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum NotificationHubNamespaceType
    {
        Messaging = 0,
        NotificationHub = 1,
    }
    public partial class NotificationHubPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    }
    public partial class NotificationHubPnsCredentials : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubPnsCredentials(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubAdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubApnsCredential ApnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubBaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubGcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubMpnsCredential MpnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubWnsCredential WnsCredential { get { throw null; } set { } }
    }
    public partial class NotificationHubPolicyKey
    {
        public NotificationHubPolicyKey() { }
        public string PolicyKey { get { throw null; } set { } }
    }
    public partial class NotificationHubResourceKeys
    {
        internal NotificationHubResourceKeys() { }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class NotificationHubSku
    {
        public NotificationHubSku(Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSkuName Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
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
    public partial class NotificationHubTestSendResult : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubTestSendResult(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public int? Failure { get { throw null; } set { } }
        public System.BinaryData Results { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubSku Sku { get { throw null; } set { } }
        public int? Success { get { throw null; } set { } }
    }
    public partial class NotificationHubWnsCredential
    {
        public NotificationHubWnsCredential() { }
        public string PackageSid { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        public System.Uri WindowsLiveEndpoint { get { throw null; } set { } }
    }
    public partial class SharedAccessAuthorizationRuleCreateOrUpdateContent
    {
        public SharedAccessAuthorizationRuleCreateOrUpdateContent(Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties properties) { }
        public Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties Properties { get { throw null; } }
    }
    public partial class SharedAccessAuthorizationRuleProperties
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
    }
}
