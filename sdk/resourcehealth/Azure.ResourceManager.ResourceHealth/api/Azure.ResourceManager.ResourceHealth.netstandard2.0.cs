namespace Azure.ResourceManager.ResourceHealth
{
    public partial class AvailabilityStatusData : Azure.ResourceManager.Models.ResourceData
    {
        internal AvailabilityStatusData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.AvailabilityStatusProperties Properties { get { throw null; } }
    }
    public partial class AvailabilityStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilityStatusResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.AvailabilityStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.AvailabilityStatusResource> Get(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.AvailabilityStatusResource>> GetAsync(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmergingIssuesGetResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource>, System.Collections.IEnumerable
    {
        protected EmergingIssuesGetResultCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource> Get(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource>> GetAsync(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmergingIssuesGetResultData : Azure.ResourceManager.Models.ResourceData
    {
        internal EmergingIssuesGetResultData() { }
        public System.DateTimeOffset? RefreshTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.StatusActiveEvent> StatusActiveEvents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.StatusBanner> StatusBanners { get { throw null; } }
    }
    public partial class EmergingIssuesGetResultResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EmergingIssuesGetResultResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter issueName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventData() { }
        public string AdditionalInformationMessage { get { throw null; } }
        public string ArticleContent { get { throw null; } }
        public string Description { get { throw null; } }
        public int? Duration { get { throw null; } }
        public bool? EnableChatWithUs { get { throw null; } }
        public bool? EnableMicrosoftSupport { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventLevelValue? EventLevel { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventSourceValue? EventSource { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventTypeValue? EventType { get { throw null; } }
        public string ExternalIncidentId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.Faq> Faqs { get { throw null; } }
        public string Header { get { throw null; } }
        public string HirStage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.Impact> Impact { get { throw null; } }
        public System.DateTimeOffset? ImpactMitigationOn { get { throw null; } }
        public System.DateTimeOffset? ImpactStartOn { get { throw null; } }
        public string ImpactType { get { throw null; } }
        public bool? IsHIR { get { throw null; } }
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.LevelValue? Level { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.Link> Links { get { throw null; } }
        public bool? PlatformInitiated { get { throw null; } }
        public int? Priority { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventPropertiesRecommendedActions RecommendedActions { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventStatusValue? Status { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class EventImpactedResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventImpactedResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.EventImpactedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string eventTrackingId, string impactedResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.EventImpactedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.EventImpactedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventImpactedResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.EventImpactedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.EventImpactedResource>, System.Collections.IEnumerable
    {
        protected EventImpactedResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.EventImpactedResource> Get(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.EventImpactedResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.EventImpactedResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.EventImpactedResource>> GetAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.EventImpactedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.EventImpactedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.EventImpactedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.EventImpactedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventImpactedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventImpactedResourceData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.KeyValueItem> Info { get { throw null; } }
        public string TargetRegion { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
        public string TargetResourceType { get { throw null; } }
    }
    public partial class MetadataEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.MetadataEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.MetadataEntityResource>, System.Collections.IEnumerable
    {
        protected MetadataEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.MetadataEntityResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.MetadataEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.MetadataEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.MetadataEntityResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.MetadataEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.MetadataEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.MetadataEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.MetadataEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetadataEntityData : Azure.ResourceManager.Models.ResourceData
    {
        internal MetadataEntityData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.Scenario> ApplicableScenarios { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DependsOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail> SupportedValues { get { throw null; } }
    }
    public partial class MetadataEntityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MetadataEntityResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.MetadataEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.MetadataEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.MetadataEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceHealthExtensions
    {
        public static Azure.ResourceManager.ResourceHealth.AvailabilityStatusResource GetAvailabilityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.AvailabilityStatusResource GetAvailabilityStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource> GetEmergingIssuesGetResult(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource>> GetEmergingIssuesGetResultAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultResource GetEmergingIssuesGetResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultCollection GetEmergingIssuesGetResults(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.EventImpactedResource GetEventImpactedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.MetadataEntityCollection GetMetadataEntities(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.MetadataEntityResource> GetMetadataEntity(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.MetadataEntityResource>> GetMetadataEntityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.MetadataEntityResource GetMetadataEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> GetSubscriptionEvent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>> GetSubscriptionEventAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.SubscriptionEventResource GetSubscriptionEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.SubscriptionEventCollection GetSubscriptionEvents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource> GetTenantEvent(this Azure.ResourceManager.Resources.TenantResource tenantResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource>> GetTenantEventAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.TenantEventResource GetTenantEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.TenantEventCollection GetTenantEvents(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class SubscriptionEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>, System.Collections.IEnumerable
    {
        protected SubscriptionEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> Get(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> GetAll(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> GetAllAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>> GetAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionEventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionEventResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.EventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string eventTrackingId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> FetchDetailsBySubscriptionIdAndTrackingId(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>> FetchDetailsBySubscriptionIdAndTrackingIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource> Get(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.SubscriptionEventResource>> GetAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.EventImpactedResource> GetEventImpactedResource(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.EventImpactedResource>> GetEventImpactedResourceAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.EventImpactedResourceCollection GetEventImpactedResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.EventImpactedResource> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventId(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.EventImpactedResource> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventIdAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.TenantEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.TenantEventResource>, System.Collections.IEnumerable
    {
        protected TenantEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource> Get(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.TenantEventResource> GetAll(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.TenantEventResource> GetAllAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource>> GetAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.TenantEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.TenantEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.TenantEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.TenantEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantEventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantEventResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.EventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string eventTrackingId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource> FetchDetailsByTenantIdAndTrackingId(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource>> FetchDetailsByTenantIdAndTrackingIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource> Get(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantEventResource>> GetAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.EventImpactedResource> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventId(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.EventImpactedResource> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventIdAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceHealth.Models
{
    public static partial class ArmResourceHealthModelFactory
    {
        public static Azure.ResourceManager.ResourceHealth.AvailabilityStatusData AvailabilityStatusData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.ResourceHealth.Models.AvailabilityStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.AvailabilityStatusProperties AvailabilityStatusProperties(Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue? availabilityState = default(Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue?), string title = null, string summary = null, string detailedStatus = null, string reasonType = null, string context = null, string category = null, System.DateTimeOffset? rootCauseAttributionOn = default(System.DateTimeOffset?), string healthEventType = null, string healthEventCause = null, string healthEventCategory = null, string healthEventId = null, System.DateTimeOffset? resolutionETA = default(System.DateTimeOffset?), System.DateTimeOffset? occuredOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType? reasonChronicity = default(Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType?), System.DateTimeOffset? reportedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResourceHealth.Models.AvailabilityStatusPropertiesRecentlyResolved recentlyResolved = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.RecommendedAction> recommendedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent> serviceImpactingEvents = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.AvailabilityStatusPropertiesRecentlyResolved AvailabilityStatusPropertiesRecentlyResolved(System.DateTimeOffset? unavailableOccuredOn = default(System.DateTimeOffset?), System.DateTimeOffset? resolvedOn = default(System.DateTimeOffset?), string unavailableSummary = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact EmergingIssueImpact(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ImpactedRegion> regions = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.EmergingIssuesGetResultData EmergingIssuesGetResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? refreshTimestamp = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.StatusBanner> statusBanners = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.StatusActiveEvent> statusActiveEvents = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.EventData EventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceHealth.Models.EventTypeValue? eventType = default(Azure.ResourceManager.ResourceHealth.Models.EventTypeValue?), Azure.ResourceManager.ResourceHealth.Models.EventSourceValue? eventSource = default(Azure.ResourceManager.ResourceHealth.Models.EventSourceValue?), Azure.ResourceManager.ResourceHealth.Models.EventStatusValue? status = default(Azure.ResourceManager.ResourceHealth.Models.EventStatusValue?), string title = null, string summary = null, string header = null, Azure.ResourceManager.ResourceHealth.Models.LevelValue? level = default(Azure.ResourceManager.ResourceHealth.Models.LevelValue?), Azure.ResourceManager.ResourceHealth.Models.EventLevelValue? eventLevel = default(Azure.ResourceManager.ResourceHealth.Models.EventLevelValue?), string externalIncidentId = null, string articleContent = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.Link> links = null, System.DateTimeOffset? impactStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? impactMitigationOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.Impact> impact = null, Azure.ResourceManager.ResourceHealth.Models.EventPropertiesRecommendedActions recommendedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.Faq> faqs = null, bool? isHIR = default(bool?), bool? enableMicrosoftSupport = default(bool?), string description = null, bool? platformInitiated = default(bool?), bool? enableChatWithUs = default(bool?), int? priority = default(int?), System.DateTimeOffset? lastUpdateOn = default(System.DateTimeOffset?), string hirStage = null, string additionalInformationMessage = null, int? duration = default(int?), string impactType = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.EventImpactedResourceData EventImpactedResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string targetResourceType = null, string targetResourceId = null, string targetRegion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.KeyValueItem> info = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventPropertiesRecommendedActions EventPropertiesRecommendedActions(string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.EventPropertiesRecommendedActionsItem> actions = null, string localeCode = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventPropertiesRecommendedActionsItem EventPropertiesRecommendedActionsItem(int? groupId = default(int?), string actionText = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.Faq Faq(string question = null, string answer = null, string localeCode = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.Impact Impact(string impactedService = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ImpactedServiceRegion> impactedRegions = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ImpactedRegion ImpactedRegion(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ImpactedServiceRegion ImpactedServiceRegion(string impactedRegion = null, Azure.ResourceManager.ResourceHealth.Models.EventStatusValue? status = default(Azure.ResourceManager.ResourceHealth.Models.EventStatusValue?), System.Collections.Generic.IEnumerable<string> impactedSubscriptions = null, System.Collections.Generic.IEnumerable<string> impactedTenants = null, System.DateTimeOffset? lastUpdateOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.Update> updates = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.KeyValueItem KeyValueItem(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.Link Link(Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue? linkType = default(Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue?), Azure.ResourceManager.ResourceHealth.Models.LinkDisplayText displayText = null, string extensionName = null, string bladeName = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.LinkDisplayText LinkDisplayText(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.MetadataEntityData MetadataEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.Scenario> applicableScenarios = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail> supportedValues = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail MetadataSupportedValueDetail(string id = null, string displayName = null, System.Collections.Generic.IEnumerable<string> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.RecommendedAction RecommendedAction(string action = null, System.Uri actionUri = null, string actionUrlText = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent ServiceImpactingEvent(System.DateTimeOffset? eventStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? eventStatusLastModifiedOn = default(System.DateTimeOffset?), string correlationId = null, string statusValue = null, Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties incidentProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties ServiceImpactingEventIncidentProperties(string title = null, string service = null, string region = null, string incidentType = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.StatusActiveEvent StatusActiveEvent(string title = null, string description = null, string trackingId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string cloud = null, Azure.ResourceManager.ResourceHealth.Models.SeverityValue? severity = default(Azure.ResourceManager.ResourceHealth.Models.SeverityValue?), Azure.ResourceManager.ResourceHealth.Models.StageValue? stage = default(Azure.ResourceManager.ResourceHealth.Models.StageValue?), bool? published = default(bool?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact> impacts = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.StatusBanner StatusBanner(string title = null, string message = null, string cloud = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.Update Update(string summary = null, System.DateTimeOffset? updateOn = default(System.DateTimeOffset?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityStateValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityStateValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue Available { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue Degraded { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue Unavailable { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue left, Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue left, Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvailabilityStatusProperties
    {
        internal AvailabilityStatusProperties() { }
        public Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateValue? AvailabilityState { get { throw null; } }
        public string Category { get { throw null; } }
        public string Context { get { throw null; } }
        public string DetailedStatus { get { throw null; } }
        public string HealthEventCategory { get { throw null; } }
        public string HealthEventCause { get { throw null; } }
        public string HealthEventId { get { throw null; } }
        public string HealthEventType { get { throw null; } }
        public System.DateTimeOffset? OccuredOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType? ReasonChronicity { get { throw null; } }
        public string ReasonType { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.AvailabilityStatusPropertiesRecentlyResolved RecentlyResolved { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.RecommendedAction> RecommendedActions { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public System.DateTimeOffset? ResolutionETA { get { throw null; } }
        public System.DateTimeOffset? RootCauseAttributionOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent> ServiceImpactingEvents { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class AvailabilityStatusPropertiesRecentlyResolved
    {
        internal AvailabilityStatusPropertiesRecentlyResolved() { }
        public System.DateTimeOffset? ResolvedOn { get { throw null; } }
        public System.DateTimeOffset? UnavailableOccuredOn { get { throw null; } }
        public string UnavailableSummary { get { throw null; } }
    }
    public partial class EmergingIssueImpact
    {
        internal EmergingIssueImpact() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ImpactedRegion> Regions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventLevelValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventLevelValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventLevelValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventLevelValue Critical { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventLevelValue Error { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventLevelValue Informational { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventLevelValue Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventLevelValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventLevelValue left, Azure.ResourceManager.ResourceHealth.Models.EventLevelValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventLevelValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventLevelValue left, Azure.ResourceManager.ResourceHealth.Models.EventLevelValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventPropertiesRecommendedActions
    {
        internal EventPropertiesRecommendedActions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EventPropertiesRecommendedActionsItem> Actions { get { throw null; } }
        public string LocaleCode { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class EventPropertiesRecommendedActionsItem
    {
        internal EventPropertiesRecommendedActionsItem() { }
        public string ActionText { get { throw null; } }
        public int? GroupId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSourceValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventSourceValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSourceValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventSourceValue ResourceHealth { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventSourceValue ServiceHealth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventSourceValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventSourceValue left, Azure.ResourceManager.ResourceHealth.Models.EventSourceValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventSourceValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventSourceValue left, Azure.ResourceManager.ResourceHealth.Models.EventSourceValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventStatusValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventStatusValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventStatusValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventStatusValue Active { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventStatusValue Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventStatusValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventStatusValue left, Azure.ResourceManager.ResourceHealth.Models.EventStatusValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventStatusValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventStatusValue left, Azure.ResourceManager.ResourceHealth.Models.EventStatusValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventTypeValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventTypeValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventTypeValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventTypeValue EmergingIssues { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventTypeValue HealthAdvisory { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventTypeValue PlannedMaintenance { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventTypeValue RCA { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventTypeValue SecurityAdvisory { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventTypeValue ServiceIssue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventTypeValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventTypeValue left, Azure.ResourceManager.ResourceHealth.Models.EventTypeValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventTypeValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventTypeValue left, Azure.ResourceManager.ResourceHealth.Models.EventTypeValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Faq
    {
        internal Faq() { }
        public string Answer { get { throw null; } }
        public string LocaleCode { get { throw null; } }
        public string Question { get { throw null; } }
    }
    public partial class Impact
    {
        internal Impact() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ImpactedServiceRegion> ImpactedRegions { get { throw null; } }
        public string ImpactedService { get { throw null; } }
    }
    public partial class ImpactedRegion
    {
        internal ImpactedRegion() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ImpactedServiceRegion
    {
        internal ImpactedServiceRegion() { }
        public string ImpactedRegion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ImpactedSubscriptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ImpactedTenants { get { throw null; } }
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventStatusValue? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.Update> Updates { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IssueNameParameter : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IssueNameParameter(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter left, Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter left, Azure.ResourceManager.ResourceHealth.Models.IssueNameParameter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyValueItem
    {
        internal KeyValueItem() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LevelValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.LevelValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LevelValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.LevelValue Critical { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.LevelValue Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.LevelValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.LevelValue left, Azure.ResourceManager.ResourceHealth.Models.LevelValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.LevelValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.LevelValue left, Azure.ResourceManager.ResourceHealth.Models.LevelValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Link
    {
        internal Link() { }
        public string BladeName { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.LinkDisplayText DisplayText { get { throw null; } }
        public string ExtensionName { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue? LinkType { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
    }
    public partial class LinkDisplayText
    {
        internal LinkDisplayText() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkTypeValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkTypeValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue Button { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue Hyperlink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue left, Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue left, Azure.ResourceManager.ResourceHealth.Models.LinkTypeValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataSupportedValueDetail
    {
        internal MetadataSupportedValueDetail() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ResourceTypes { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonChronicityType : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonChronicityType(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType Persistent { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType Transient { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType left, Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType left, Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendedAction
    {
        internal RecommendedAction() { }
        public string Action { get { throw null; } }
        public System.Uri ActionUri { get { throw null; } }
        public string ActionUrlText { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Scenario : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.Scenario>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Scenario(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.Scenario Alerts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.Scenario other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.Scenario left, Azure.ResourceManager.ResourceHealth.Models.Scenario right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.Scenario (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.Scenario left, Azure.ResourceManager.ResourceHealth.Models.Scenario right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceImpactingEvent
    {
        internal ServiceImpactingEvent() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EventStartOn { get { throw null; } }
        public System.DateTimeOffset? EventStatusLastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties IncidentProperties { get { throw null; } }
        public string StatusValue { get { throw null; } }
    }
    public partial class ServiceImpactingEventIncidentProperties
    {
        internal ServiceImpactingEventIncidentProperties() { }
        public string IncidentType { get { throw null; } }
        public string Region { get { throw null; } }
        public string Service { get { throw null; } }
        public string Title { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeverityValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.SeverityValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeverityValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.SeverityValue Error { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.SeverityValue Information { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.SeverityValue Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.SeverityValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.SeverityValue left, Azure.ResourceManager.ResourceHealth.Models.SeverityValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.SeverityValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.SeverityValue left, Azure.ResourceManager.ResourceHealth.Models.SeverityValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StageValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.StageValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StageValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.StageValue Active { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.StageValue Archived { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.StageValue Resolve { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.StageValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.StageValue left, Azure.ResourceManager.ResourceHealth.Models.StageValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.StageValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.StageValue left, Azure.ResourceManager.ResourceHealth.Models.StageValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StatusActiveEvent
    {
        internal StatusActiveEvent() { }
        public string Cloud { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact> Impacts { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public bool? Published { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.SeverityValue? Severity { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.StageValue? Stage { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Title { get { throw null; } }
        public string TrackingId { get { throw null; } }
    }
    public partial class StatusBanner
    {
        internal StatusBanner() { }
        public string Cloud { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class Update
    {
        internal Update() { }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? UpdateOn { get { throw null; } }
    }
}
