namespace Azure.ResourceManager.NotificationHubs
{
    public partial class NamespaceAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.SharedAccessAuthorizationRuleResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.PolicykeyResource policykeyResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.PolicykeyResource policykeyResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceNotificationHubAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected NamespaceNotificationHubAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceNotificationHubAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceNotificationHubAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.SharedAccessAuthorizationRuleResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys> RegenerateKeys(Azure.ResourceManager.NotificationHubs.Models.PolicykeyResource policykeyResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.ResourceListKeys>> RegenerateKeysAsync(Azure.ResourceManager.NotificationHubs.Models.PolicykeyResource policykeyResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleCreateOrUpdateParameters sharedAccessAuthorizationRuleCreateOrUpdateParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NamespaceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityResult> CheckNotificationHubAvailabilityNotificationHub(Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityParameters checkAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityResult>> CheckNotificationHubAvailabilityNotificationHubAsync(Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityParameters checkAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource> GetNamespaceAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource>> GetNamespaceAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleCollection GetNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> GetNotificationHubResource(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetNotificationHubResourceAsync(string notificationHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubResourceCollection GetNotificationHubResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource> Update(Azure.ResourceManager.NotificationHubs.Models.NamespaceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NamespaceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceResource>, System.Collections.IEnumerable
    {
        protected NamespaceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.Models.NamespaceResourceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.NotificationHubs.Models.NamespaceResourceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NotificationHubs.NamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NotificationHubs.NamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NamespaceResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public bool? Critical { get { throw null; } set { } }
        public string DataCenter { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NamespaceType? NamespaceType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ScaleUnit { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class NotificationHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationHubResource() { }
        public virtual Azure.ResourceManager.NotificationHubs.NotificationHubResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string notificationHubName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.DebugSendResponse> DebugSend(System.BinaryData anyObject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.DebugSendResponse>> DebugSendAsync(System.BinaryData anyObject = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource> GetNamespaceNotificationHubAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource>> GetNamespaceNotificationHubAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleCollection GetNamespaceNotificationHubAuthorizationRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.Models.PnsCredentialsResource> GetPnsCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.PnsCredentialsResource>> GetPnsCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource> Update(Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> UpdateAsync(Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationHubResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NotificationHubs.NotificationHubResource>, System.Collections.IEnumerable
    {
        protected NotificationHubResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NotificationHubs.NotificationHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string notificationHubName, Azure.ResourceManager.NotificationHubs.Models.NotificationHubResourceCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class NotificationHubResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NotificationHubs.Models.AdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.ApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.BaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.GcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.MpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.WnsCredential WnsCredential { get { throw null; } set { } }
    }
    public static partial class NotificationHubsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityResult> CheckAvailabilityNamespace(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityParameters checkAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityResult>> CheckAvailabilityNamespaceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.NotificationHubs.Models.CheckAvailabilityParameters checkAvailabilityParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NamespaceAuthorizationRuleResource GetNamespaceAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NamespaceNotificationHubAuthorizationRuleResource GetNamespaceNotificationHubAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NamespaceResource GetNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource> GetNamespaceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NotificationHubs.NamespaceResource>> GetNamespaceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NamespaceResourceCollection GetNamespaceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NotificationHubs.NamespaceResource> GetNamespaceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NotificationHubs.NamespaceResource> GetNamespaceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.NotificationHubResource GetNotificationHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SharedAccessAuthorizationRuleResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SharedAccessAuthorizationRuleResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ClaimType { get { throw null; } }
        public string ClaimValue { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string KeyName { get { throw null; } }
        public string ModifiedTime { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AccessRight> Rights { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.NotificationHubs.Models
{
    public enum AccessRight
    {
        Manage = 0,
        Send = 1,
        Listen = 2,
    }
    public partial class AdmCredential
    {
        public AdmCredential() { }
        public System.Uri AuthTokenUri { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
    }
    public partial class ApnsCredential
    {
        public ApnsCredential() { }
        public string ApnsCertificate { get { throw null; } set { } }
        public string AppId { get { throw null; } set { } }
        public string AppName { get { throw null; } set { } }
        public string CertificateKey { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string KeyId { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
    }
    public partial class BaiduCredential
    {
        public BaiduCredential() { }
        public string BaiduApiKey { get { throw null; } set { } }
        public string BaiduEndPoint { get { throw null; } set { } }
        public string BaiduSecretKey { get { throw null; } set { } }
    }
    public partial class CheckAvailabilityParameters : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CheckAvailabilityParameters(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? IsAvailiable { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
    }
    public partial class CheckAvailabilityResult : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CheckAvailabilityResult(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? IsAvailiable { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
    }
    public partial class DebugSendResponse : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DebugSendResponse(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public float? Failure { get { throw null; } set { } }
        public System.BinaryData Results { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public float? Success { get { throw null; } set { } }
    }
    public partial class GcmCredential
    {
        public GcmCredential() { }
        public string GcmEndpoint { get { throw null; } set { } }
        public string GoogleApiKey { get { throw null; } set { } }
    }
    public partial class MpnsCredential
    {
        public MpnsCredential() { }
        public string CertificateKey { get { throw null; } set { } }
        public string MpnsCertificate { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
    }
    public partial class NamespaceResourceCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NamespaceResourceCreateOrUpdateContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public bool? Critical { get { throw null; } set { } }
        public string DataCenter { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NamespaceType? NamespaceType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string ScaleUnit { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } set { } }
    }
    public partial class NamespaceResourcePatch
    {
        public NamespaceResourcePatch() { }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum NamespaceType
    {
        Messaging = 0,
        NotificationHub = 1,
    }
    public partial class NotificationHubResourceCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubResourceCreateOrUpdateContent(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NotificationHubs.Models.AdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.ApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.BaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.GcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.MpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.WnsCredential WnsCredential { get { throw null; } set { } }
    }
    public partial class NotificationHubResourcePatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationHubResourcePatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NotificationHubs.Models.AdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.ApnsCredential ApnsCredential { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties> AuthorizationRules { get { throw null; } }
        public Azure.ResourceManager.NotificationHubs.Models.BaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.GcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.MpnsCredential MpnsCredential { get { throw null; } set { } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string RegistrationTtl { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.WnsCredential WnsCredential { get { throw null; } set { } }
    }
    public partial class NotificationHubsSku
    {
        public NotificationHubsSku(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationHubsSkuName : System.IEquatable<Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationHubsSkuName(string value) { throw null; }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName left, Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PnsCredentialsResource : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PnsCredentialsResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.NotificationHubs.Models.AdmCredential AdmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.ApnsCredential ApnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.BaiduCredential BaiduCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.GcmCredential GcmCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.MpnsCredential MpnsCredential { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.NotificationHubsSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NotificationHubs.Models.WnsCredential WnsCredential { get { throw null; } set { } }
    }
    public partial class PolicykeyResource
    {
        public PolicykeyResource() { }
        public string PolicyKey { get { throw null; } set { } }
    }
    public partial class ResourceListKeys
    {
        internal ResourceListKeys() { }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class SharedAccessAuthorizationRuleCreateOrUpdateParameters
    {
        public SharedAccessAuthorizationRuleCreateOrUpdateParameters(Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties properties) { }
        public Azure.ResourceManager.NotificationHubs.Models.SharedAccessAuthorizationRuleProperties Properties { get { throw null; } }
    }
    public partial class SharedAccessAuthorizationRuleProperties
    {
        public SharedAccessAuthorizationRuleProperties() { }
        public string ClaimType { get { throw null; } }
        public string ClaimValue { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string KeyName { get { throw null; } }
        public string ModifiedTime { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NotificationHubs.Models.AccessRight> Rights { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public partial class WnsCredential
    {
        public WnsCredential() { }
        public string PackageSid { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        public string WindowsLiveEndpoint { get { throw null; } set { } }
    }
}
