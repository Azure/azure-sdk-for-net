namespace Azure.ResourceManager.EventHubs
{
    public partial class EventHubAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected EventHubAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string eventHubName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys> RegenerateKeys(Azure.ResourceManager.EventHubs.Models.EventHubsRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.EventHubs.Models.EventHubsRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubResource>, System.Collections.IEnumerable
    {
        protected EventHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventHubName, Azure.ResourceManager.EventHubs.EventHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventHubName, Azure.ResourceManager.EventHubs.EventHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubResource> Get(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubResource> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubResource> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubResource>> GetAsync(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubData() { }
        public Azure.ResourceManager.EventHubs.Models.CaptureDescription CaptureDescription { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public long? MessageRetentionInDays { get { throw null; } set { } }
        public long? PartitionCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PartitionIds { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubEntityStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class EventHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string eventHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource> GetEventHubAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource>> GetEventHubAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleCollection GetEventHubAuthorizationRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> GetEventHubsConsumerGroup(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>> GetEventHubsConsumerGroupAsync(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsConsumerGroupCollection GetEventHubsConsumerGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsApplicationGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>, System.Collections.IEnumerable
    {
        protected EventHubsApplicationGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationGroupName, Azure.ResourceManager.EventHubs.EventHubsApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationGroupName, Azure.ResourceManager.EventHubs.EventHubsApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> Get(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>> GetAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsApplicationGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubsApplicationGroupData() { }
        public string ClientAppGroupIdentifier { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.EventHubsApplicationGroupPolicy> Policies { get { throw null; } }
    }
    public partial class EventHubsApplicationGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsApplicationGroupResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsApplicationGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string applicationGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsAuthorizationRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubsAuthorizationRuleData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight> Rights { get { throw null; } }
    }
    public partial class EventHubsClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsClusterResource>, System.Collections.IEnumerable
    {
        protected EventHubsClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.EventHubs.EventHubsClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.EventHubs.EventHubsClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EventHubsClusterData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsClusterSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public bool? SupportsScaling { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class EventHubsClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsClusterResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties> GetConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties>> GetConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetNamespaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetNamespacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties> PatchConfiguration(Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties clusterQuotaConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties>> PatchConfigurationAsync(Azure.ResourceManager.EventHubs.Models.ClusterQuotaConfigurationProperties clusterQuotaConfigurationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsConsumerGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>, System.Collections.IEnumerable
    {
        protected EventHubsConsumerGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string consumerGroupName, Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string consumerGroupName, Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> Get(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>> GetAsync(string consumerGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsConsumerGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubsConsumerGroupData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string UserMetadata { get { throw null; } set { } }
    }
    public partial class EventHubsConsumerGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsConsumerGroupResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string eventHubName, string consumerGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsDisasterRecoveryAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected EventHubsDisasterRecoveryAuthorizationRuleCollection() { }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsDisasterRecoveryAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsDisasterRecoveryAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias, string authorizationRuleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsDisasterRecoveryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>, System.Collections.IEnumerable
    {
        protected EventHubsDisasterRecoveryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alias, Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alias, Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> Get(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>> GetAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsDisasterRecoveryData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubsDisasterRecoveryData() { }
        public string AlternateName { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string PartnerNamespace { get { throw null; } set { } }
        public long? PendingReplicationOperationsCount { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsDisasterRecoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsDisasterRecoveryRole? Role { get { throw null; } }
    }
    public partial class EventHubsDisasterRecoveryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsDisasterRecoveryResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response BreakPairing(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> BreakPairingAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string alias) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response FailOver(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> FailOverAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource> GetEventHubsDisasterRecoveryAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource>> GetEventHubsDisasterRecoveryAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleCollection GetEventHubsDisasterRecoveryAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EventHubsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityResult> CheckEventHubsNamespaceNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityResult>> CheckEventHubsNamespaceNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventHubs.Models.AvailableCluster> GetAvailableClusterRegionClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.AvailableCluster> GetAvailableClusterRegionClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubAuthorizationRuleResource GetEventHubAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubResource GetEventHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource GetEventHubsApplicationGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource> GetEventHubsCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsClusterResource>> GetEventHubsClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsClusterResource GetEventHubsClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsClusterCollection GetEventHubsClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsClusterResource> GetEventHubsClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsClusterResource> GetEventHubsClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsConsumerGroupResource GetEventHubsConsumerGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryAuthorizationRuleResource GetEventHubsDisasterRecoveryAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource GetEventHubsDisasterRecoveryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> GetEventHubsNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> GetEventHubsNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource GetEventHubsNamespaceAuthorizationRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsNamespaceResource GetEventHubsNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsNamespaceCollection GetEventHubsNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> GetEventHubsNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> GetEventHubsNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetResource GetEventHubsNetworkRuleSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource GetEventHubsPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource GetEventHubsSchemaGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class EventHubsNamespaceAuthorizationRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>, System.Collections.IEnumerable
    {
        protected EventHubsNamespaceAuthorizationRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationRuleName, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> Get(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>> GetAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsNamespaceAuthorizationRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsNamespaceAuthorizationRuleResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string authorizationRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys> RegenerateKeys(Azure.ResourceManager.EventHubs.Models.EventHubsRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeys>> RegenerateKeysAsync(Azure.ResourceManager.EventHubs.Models.EventHubsRegenerateAccessKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsAuthorizationRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>, System.Collections.IEnumerable
    {
        protected EventHubsNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.EventHubs.EventHubsNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.EventHubs.EventHubsNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsNamespaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EventHubsNamespaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AlternateName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterArmId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAutoInflateEnabled { get { throw null; } set { } }
        public bool? KafkaEnabled { get { throw null; } set { } }
        public int? MaximumThroughputUnits { get { throw null; } set { } }
        public string MetricId { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion? MinimumTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceBusEndpoint { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSku Sku { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public bool? ZoneRedundant { get { throw null; } set { } }
    }
    public partial class EventHubsNamespaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsNamespaceResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityResult> CheckEventHubsDisasterRecoveryNameAvailability(Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityResult>> CheckEventHubsDisasterRecoveryNameAvailabilityAsync(Azure.ResourceManager.EventHubs.Models.EventHubsNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdateNetworkSecurityPerimeterConfiguration(Azure.WaitUntil waitUntil, string resourceAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateNetworkSecurityPerimeterConfigurationAsync(Azure.WaitUntil waitUntil, string resourceAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubResource> GetEventHub(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubResource>> GetEventHubAsync(string eventHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubCollection GetEventHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource> GetEventHubsApplicationGroup(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsApplicationGroupResource>> GetEventHubsApplicationGroupAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsApplicationGroupCollection GetEventHubsApplicationGroups() { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryCollection GetEventHubsDisasterRecoveries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource> GetEventHubsDisasterRecovery(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsDisasterRecoveryResource>> GetEventHubsDisasterRecoveryAsync(string alias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource> GetEventHubsNamespaceAuthorizationRule(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleResource>> GetEventHubsNamespaceAuthorizationRuleAsync(string authorizationRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsNamespaceAuthorizationRuleCollection GetEventHubsNamespaceAuthorizationRules() { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetResource GetEventHubsNetworkRuleSet() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> GetEventHubsPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>> GetEventHubsPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionCollection GetEventHubsPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> GetEventHubsSchemaGroup(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>> GetEventHubsSchemaGroupAsync(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventHubs.EventHubsSchemaGroupCollection GetEventHubsSchemaGroups() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfiguration> GetNetworkSecurityPerimeterConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfiguration> GetNetworkSecurityPerimeterConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource> Update(Azure.ResourceManager.EventHubs.EventHubsNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNamespaceResource>> UpdateAsync(Azure.ResourceManager.EventHubs.EventHubsNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsNetworkRuleSetData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubsNetworkRuleSetData() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetIPRules> IPRules { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag? PublicNetworkAccess { get { throw null; } set { } }
        public bool? TrustedServiceAccessEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetVirtualNetworkRules> VirtualNetworkRules { get { throw null; } }
    }
    public partial class EventHubsNetworkRuleSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsNetworkRuleSetResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsNetworkRuleSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected EventHubsPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubsPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class EventHubsPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventHubsSchemaGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>, System.Collections.IEnumerable
    {
        protected EventHubsSchemaGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaGroupName, Azure.ResourceManager.EventHubs.EventHubsSchemaGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaGroupName, Azure.ResourceManager.EventHubs.EventHubsSchemaGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> Get(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> GetAll(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> GetAllAsync(int? skip = default(int?), int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>> GetAsync(string schemaGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventHubsSchemaGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public EventHubsSchemaGroupData() { }
        public System.DateTimeOffset? CreatedAtUtc { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> GroupProperties { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility? SchemaCompatibility { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType? SchemaType { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedAtUtc { get { throw null; } }
    }
    public partial class EventHubsSchemaGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventHubsSchemaGroupResource() { }
        public virtual Azure.ResourceManager.EventHubs.EventHubsSchemaGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string schemaGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsSchemaGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventHubs.EventHubsSchemaGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventHubs.EventHubsSchemaGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EventHubs.Models
{
    public partial class AvailableCluster
    {
        internal AvailableCluster() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
    }
    public partial class CaptureDescription
    {
        public CaptureDescription() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubDestination Destination { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EncodingCaptureDescription? Encoding { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
        public int? SizeLimitInBytes { get { throw null; } set { } }
        public bool? SkipEmptyArchives { get { throw null; } set { } }
    }
    public partial class ClusterQuotaConfigurationProperties
    {
        public ClusterQuotaConfigurationProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Settings { get { throw null; } }
    }
    public enum EncodingCaptureDescription
    {
        Avro = 0,
        AvroDeflate = 1,
    }
    public partial class EventHubDestination
    {
        public EventHubDestination() { }
        public string ArchiveNameFormat { get { throw null; } set { } }
        public string BlobContainer { get { throw null; } set { } }
        public string DataLakeAccountName { get { throw null; } set { } }
        public string DataLakeFolderPath { get { throw null; } set { } }
        public System.Guid? DataLakeSubscriptionId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
    }
    public enum EventHubEntityStatus
    {
        Unknown = 0,
        Active = 1,
        Disabled = 2,
        Restoring = 3,
        SendDisabled = 4,
        ReceiveDisabled = 5,
        Creating = 6,
        Deleting = 7,
        Renaming = 8,
    }
    public partial class EventHubsAccessKeys
    {
        internal EventHubsAccessKeys() { }
        public string AliasPrimaryConnectionString { get { throw null; } }
        public string AliasSecondaryConnectionString { get { throw null; } }
        public string KeyName { get { throw null; } }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsAccessKeyType : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsAccessKeyType(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType PrimaryKey { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType SecondaryKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType left, Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType left, Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsAccessRight : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsAccessRight(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight Listen { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight Manage { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight Send { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight left, Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight left, Azure.ResourceManager.EventHubs.Models.EventHubsAccessRight right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EventHubsApplicationGroupPolicy
    {
        protected EventHubsApplicationGroupPolicy(string name) { }
        public string Name { get { throw null; } set { } }
    }
    public partial class EventHubsClusterSku
    {
        public EventHubsClusterSku(Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsClusterSkuName : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsClusterSkuName(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName left, Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName left, Azure.ResourceManager.EventHubs.Models.EventHubsClusterSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EventHubsDisasterRecoveryProvisioningState
    {
        Accepted = 0,
        Succeeded = 1,
        Failed = 2,
    }
    public enum EventHubsDisasterRecoveryRole
    {
        Primary = 0,
        PrimaryNotReplicating = 1,
        Secondary = 2,
    }
    public partial class EventHubsEncryption
    {
        public EventHubsEncryption() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsKeySource? KeySource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.EventHubsKeyVaultProperties> KeyVaultProperties { get { throw null; } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsKeySource : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsKeySource(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsKeySource MicrosoftKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsKeySource left, Azure.ResourceManager.EventHubs.Models.EventHubsKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsKeySource left, Azure.ResourceManager.EventHubs.Models.EventHubsKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsKeyVaultProperties
    {
        public EventHubsKeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsMetricId : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsMetricId>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsMetricId(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsMetricId IncomingBytes { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsMetricId IncomingMessages { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsMetricId OutgoingBytes { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsMetricId OutgoingMessages { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsMetricId other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsMetricId left, Azure.ResourceManager.EventHubs.Models.EventHubsMetricId right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsMetricId (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsMetricId left, Azure.ResourceManager.EventHubs.Models.EventHubsMetricId right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsNameAvailabilityContent
    {
        public EventHubsNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
    }
    public partial class EventHubsNameAvailabilityResult
    {
        internal EventHubsNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNameUnavailableReason? Reason { get { throw null; } }
    }
    public enum EventHubsNameUnavailableReason
    {
        None = 0,
        InvalidName = 1,
        SubscriptionIsDisabled = 2,
        NameInUse = 3,
        NameInLockdown = 4,
        TooManyNamespaceInCurrentSubscription = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsNetworkRuleIPAction : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsNetworkRuleIPAction(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction left, Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction left, Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsNetworkRuleSetDefaultAction : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsNetworkRuleSetDefaultAction(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction Allow { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction left, Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction left, Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleSetDefaultAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsNetworkRuleSetIPRules
    {
        public EventHubsNetworkRuleSetIPRules() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNetworkRuleIPAction? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
    }
    public partial class EventHubsNetworkRuleSetVirtualNetworkRules
    {
        public EventHubsNetworkRuleSetVirtualNetworkRules() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class EventHubsNetworkSecurityPerimeter
    {
        internal EventHubsNetworkSecurityPerimeter() { }
        public string Id { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string PerimeterGuid { get { throw null; } }
    }
    public partial class EventHubsNetworkSecurityPerimeterConfiguration : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EventHubsNetworkSecurityPerimeterConfiguration(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeter NetworkSecurityPerimeter { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile Profile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventHubs.Models.EventHubsProvisioningIssue> ProvisioningIssues { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation ResourceAssociation { get { throw null; } }
    }
    public partial class EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile
    {
        internal EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRule> AccessRules { get { throw null; } }
        public string AccessRulesVersion { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation
    {
        internal EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode? AccessMode { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsNetworkSecurityPerimeterConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsNetworkSecurityPerimeterConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState InvalidResponse { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState SucceededWithIssues { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState left, Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeterConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsNspAccessRule : Azure.ResourceManager.Models.ResourceData
    {
        internal EventHubsNspAccessRule() { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleProperties Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsNspAccessRuleDirection : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsNspAccessRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection left, Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection left, Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsNspAccessRuleProperties
    {
        internal EventHubsNspAccessRuleProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsNspAccessRuleDirection? Direction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FullyQualifiedDomainNames { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventHubs.Models.EventHubsNetworkSecurityPerimeter> NetworkSecurityPerimeters { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Subscriptions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.EventHubs.Models.EventHubsPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsPrivateLinkConnectionStatus : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsPrivateLinkConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus left, Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus left, Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventHubsPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class EventHubsPrivateLinkServiceConnectionState
    {
        public EventHubsPrivateLinkServiceConnectionState() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsPrivateLinkConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class EventHubsProvisioningIssue
    {
        public EventHubsProvisioningIssue() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsProvisioningIssueProperties Properties { get { throw null; } }
    }
    public partial class EventHubsProvisioningIssueProperties
    {
        internal EventHubsProvisioningIssueProperties() { }
        public string Description { get { throw null; } }
        public string IssueType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess left, Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess left, Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsPublicNetworkAccessFlag : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsPublicNetworkAccessFlag(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag Enabled { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag left, Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag left, Azure.ResourceManager.EventHubs.Models.EventHubsPublicNetworkAccessFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsRegenerateAccessKeyContent
    {
        public EventHubsRegenerateAccessKeyContent(Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType keyType) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsAccessKeyType KeyType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsResourceAssociationAccessMode : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsResourceAssociationAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode AuditMode { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode EnforcedMode { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode LearningMode { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode NoAssociationMode { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode UnspecifiedMode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode left, Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode left, Azure.ResourceManager.EventHubs.Models.EventHubsResourceAssociationAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsSchemaCompatibility : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsSchemaCompatibility(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility Backward { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility Forward { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility left, Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility left, Azure.ResourceManager.EventHubs.Models.EventHubsSchemaCompatibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsSchemaType : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType Avro { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType left, Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType left, Azure.ResourceManager.EventHubs.Models.EventHubsSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsSku
    {
        public EventHubsSku(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier? Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsSkuName : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsSkuName(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsSkuName left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsSkuTier : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier left, Azure.ResourceManager.EventHubs.Models.EventHubsSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubsThrottlingPolicy : Azure.ResourceManager.EventHubs.Models.EventHubsApplicationGroupPolicy
    {
        public EventHubsThrottlingPolicy(string name, long rateLimitThreshold, Azure.ResourceManager.EventHubs.Models.EventHubsMetricId metricId) : base (default(string)) { }
        public Azure.ResourceManager.EventHubs.Models.EventHubsMetricId MetricId { get { throw null; } set { } }
        public long RateLimitThreshold { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubsTlsVersion : System.IEquatable<Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubsTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion left, Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion left, Azure.ResourceManager.EventHubs.Models.EventHubsTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
}
