namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ResourceHealthAvailabilityStatusData : Azure.ResourceManager.Models.ResourceData
    {
        internal ResourceHealthAvailabilityStatusData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties Properties { get { throw null; } }
    }
    public partial class ResourceHealthAvailabilityStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceHealthAvailabilityStatusResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusResource> Get(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusResource>> GetAsync(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceHealthChildAvailabilityStatusResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceHealthChildAvailabilityStatusResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthChildAvailabilityStatusResource> Get(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthChildAvailabilityStatusResource>> GetAsync(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceHealthEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>, System.Collections.IEnumerable
    {
        protected ResourceHealthEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> Get(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetAll(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetAllAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> GetAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceHealthEventData : Azure.ResourceManager.Models.ResourceData
    {
        internal ResourceHealthEventData() { }
        public string AdditionalInformationMessage { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventArticle Article { get { throw null; } }
        public string Description { get { throw null; } }
        public int? Duration { get { throw null; } }
        public bool? EnableChatWithUs { get { throw null; } }
        public bool? EnableMicrosoftSupport { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventLevelValue? EventLevel { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventSourceValue? EventSource { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventTypeValue? EventType { get { throw null; } }
        public string ExternalIncidentId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EventFaq> Faqs { get { throw null; } }
        public string Header { get { throw null; } }
        public string HirStage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EventImpact> Impact { get { throw null; } }
        public System.DateTimeOffset? ImpactMitigationOn { get { throw null; } }
        public System.DateTimeOffset? ImpactStartOn { get { throw null; } }
        public string ImpactType { get { throw null; } }
        public bool? IsHIR { get { throw null; } }
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue? Level { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EventLink> Links { get { throw null; } }
        public bool? PlatformInitiated { get { throw null; } }
        public int? Priority { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventRecommendedActions RecommendedActions { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventStatusValue? Status { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class ResourceHealthEventImpactedResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceHealthEventImpactedResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string eventTrackingId, string impactedResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceHealthEventImpactedResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>, System.Collections.IEnumerable
    {
        protected ResourceHealthEventImpactedResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> Get(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>> GetAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceHealthEventImpactedResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal ResourceHealthEventImpactedResourceData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem> Info { get { throw null; } }
        public string TargetRegion { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
        public string TargetResourceType { get { throw null; } }
    }
    public partial class ResourceHealthEventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceHealthEventResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string eventTrackingId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> FetchDetailsBySubscriptionIdAndTrackingId(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> FetchDetailsBySubscriptionIdAndTrackingIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> Get(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> GetAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> GetResourceHealthEventImpactedResource(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>> GetResourceHealthEventImpactedResourceAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceCollection GetResourceHealthEventImpactedResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventId(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesBySubscriptionIdAndEventIdAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceHealthExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusData> GetChildResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusData> GetChildResourcesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData> GetEventsBySingleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData> GetEventsBySingleResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusResource GetResourceHealthAvailabilityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthAvailabilityStatusResource GetResourceHealthAvailabilityStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthChildAvailabilityStatusResource GetResourceHealthChildAvailabilityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthChildAvailabilityStatusResource GetResourceHealthChildAvailabilityStatusResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetResourceHealthEvent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> GetResourceHealthEventAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource GetResourceHealthEventImpactedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource GetResourceHealthEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventCollection GetResourceHealthEvents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityCollection GetResourceHealthMetadataEntities(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> GetResourceHealthMetadataEntity(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>> GetResourceHealthMetadataEntityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource GetResourceHealthMetadataEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetServiceEmergingIssue(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceHealth.Models.IssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>> GetServiceEmergingIssueAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceHealth.Models.IssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource GetServiceEmergingIssueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueCollection GetServiceEmergingIssues(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> GetTenantResourceHealthEvent(this Azure.ResourceManager.Resources.TenantResource tenantResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>> GetTenantResourceHealthEventAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource GetTenantResourceHealthEventImpactedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource GetTenantResourceHealthEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventCollection GetTenantResourceHealthEvents(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class ResourceHealthMetadataEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>, System.Collections.IEnumerable
    {
        protected ResourceHealthMetadataEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceHealthMetadataEntityData : Azure.ResourceManager.Models.ResourceData
    {
        internal ResourceHealthMetadataEntityData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario> ApplicableScenarios { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DependsOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail> SupportedValues { get { throw null; } }
    }
    public partial class ResourceHealthMetadataEntityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceHealthMetadataEntityResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceEmergingIssueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>, System.Collections.IEnumerable
    {
        protected ServiceEmergingIssueCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> Get(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>> GetAsync(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceEmergingIssueData : Azure.ResourceManager.Models.ResourceData
    {
        internal ServiceEmergingIssueData() { }
        public System.DateTimeOffset? RefreshTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType> StatusActiveEvents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType> StatusBanners { get { throw null; } }
    }
    public partial class ServiceEmergingIssueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceEmergingIssueResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent issueName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantResourceHealthEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>, System.Collections.IEnumerable
    {
        protected TenantResourceHealthEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> Get(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> GetAll(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> GetAllAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>> GetAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantResourceHealthEventImpactedResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantResourceHealthEventImpactedResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string eventTrackingId, string impactedResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantResourceHealthEventImpactedResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>, System.Collections.IEnumerable
    {
        protected TenantResourceHealthEventImpactedResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> Get(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>> GetAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TenantResourceHealthEventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantResourceHealthEventResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string eventTrackingId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> FetchDetailsByTenantIdAndTrackingId(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>> FetchDetailsByTenantIdAndTrackingIdAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> Get(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>> GetAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventId(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData> GetSecurityAdvisoryImpactedResourcesByTenantIdAndEventIdAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> GetTenantResourceHealthEventImpactedResource(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>> GetTenantResourceHealthEventImpactedResourceAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResourceCollection GetTenantResourceHealthEventImpactedResources() { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceHealth.Models
{
    public partial class AvailabilityStateRecentlyResolved
    {
        internal AvailabilityStateRecentlyResolved() { }
        public System.DateTimeOffset? ResolvedOn { get { throw null; } }
        public System.DateTimeOffset? UnavailableOccuredOn { get { throw null; } }
        public string UnavailableSummary { get { throw null; } }
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
    public partial class EmergingIssueActiveEventType
    {
        internal EmergingIssueActiveEventType() { }
        public string Cloud { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact> Impacts { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public bool? Published { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel? Severity { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventStageValue? Stage { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Title { get { throw null; } }
        public string TrackingId { get { throw null; } }
    }
    public partial class EmergingIssueBannerType
    {
        internal EmergingIssueBannerType() { }
        public string Cloud { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class EmergingIssueImpact
    {
        internal EmergingIssueImpact() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ImpactedRegion> Regions { get { throw null; } }
    }
    public partial class EventArticle
    {
        internal EventArticle() { }
        public string ArticleContent { get { throw null; } }
        public string ArticleId { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
    }
    public partial class EventFaq
    {
        internal EventFaq() { }
        public string Answer { get { throw null; } }
        public string LocaleCode { get { throw null; } }
        public string Question { get { throw null; } }
    }
    public partial class EventImpact
    {
        internal EventImpact() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ImpactedServiceRegion> ImpactedRegions { get { throw null; } }
        public string ImpactedService { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventInsightLevelValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventInsightLevelValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue Critical { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue left, Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue left, Azure.ResourceManager.ResourceHealth.Models.EventInsightLevelValue right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class EventLink
    {
        internal EventLink() { }
        public string BladeName { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventLinkDisplayText DisplayText { get { throw null; } }
        public string ExtensionName { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue? LinkType { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
    }
    public partial class EventLinkDisplayText
    {
        internal EventLinkDisplayText() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventLinkTypeValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventLinkTypeValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue Button { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue Hyperlink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue left, Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue left, Azure.ResourceManager.ResourceHealth.Models.EventLinkTypeValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventRecommendedActions
    {
        internal EventRecommendedActions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EventRecommendedActionsItem> Actions { get { throw null; } }
        public string LocaleCode { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class EventRecommendedActionsItem
    {
        internal EventRecommendedActionsItem() { }
        public string ActionText { get { throw null; } }
        public int? GroupId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSeverityLevel : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSeverityLevel(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel Error { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel Information { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel left, Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel left, Azure.ResourceManager.ResourceHealth.Models.EventSeverityLevel right) { throw null; }
        public override string ToString() { throw null; }
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
    public readonly partial struct EventStageValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventStageValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventStageValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventStageValue Active { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventStageValue Archived { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.EventStageValue Resolve { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventStageValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventStageValue left, Azure.ResourceManager.ResourceHealth.Models.EventStageValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventStageValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventStageValue left, Azure.ResourceManager.ResourceHealth.Models.EventStageValue right) { throw null; }
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
    public partial class EventUpdate
    {
        internal EventUpdate() { }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? UpdateOn { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EventUpdate> Updates { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IssueNameContent : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.IssueNameContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IssueNameContent(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.IssueNameContent Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent left, Azure.ResourceManager.ResourceHealth.Models.IssueNameContent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.IssueNameContent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.IssueNameContent left, Azure.ResourceManager.ResourceHealth.Models.IssueNameContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetadataEntityScenario : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetadataEntityScenario(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario Alerts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario left, Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario left, Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario right) { throw null; }
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
        public string ActionUrlComment { get { throw null; } }
        public string ActionUrlText { get { throw null; } }
    }
    public partial class ResourceHealthAvailabilityStatusProperties
    {
        internal ResourceHealthAvailabilityStatusProperties() { }
        public string ArticleId { get { throw null; } }
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
        public Azure.ResourceManager.ResourceHealth.Models.AvailabilityStateRecentlyResolved RecentlyResolved { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.RecommendedAction> RecommendedActions { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public System.DateTimeOffset? ResolutionETA { get { throw null; } }
        public System.DateTimeOffset? RootCauseAttributionOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent> ServiceImpactingEvents { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class ResourceHealthKeyValueItem
    {
        internal ResourceHealthKeyValueItem() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
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
}
