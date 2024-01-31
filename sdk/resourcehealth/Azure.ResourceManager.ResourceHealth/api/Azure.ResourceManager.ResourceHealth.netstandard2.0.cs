namespace Azure.ResourceManager.ResourceHealth
{
    public partial class ResourceHealthEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>, System.Collections.IEnumerable
    {
        protected ResourceHealthEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> Get(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetAll(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetAllAsync(string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> GetAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetIfExists(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> GetIfExistsAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceHealthEventData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData>
    {
        internal ResourceHealthEventData() { }
        public string AdditionalInformationMessage { get { throw null; } }
        public string ArgQuery { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle Article { get { throw null; } }
        public string Description { get { throw null; } }
        public int? Duration { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue? EventLevel { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue? EventSource { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue? EventSubType { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue? EventType { get { throw null; } }
        public string ExternalIncidentId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq> Faqs { get { throw null; } }
        public string Header { get { throw null; } }
        public string HirStage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact> Impact { get { throw null; } }
        public System.DateTimeOffset? ImpactMitigationOn { get { throw null; } }
        public System.DateTimeOffset? ImpactStartOn { get { throw null; } }
        public string ImpactType { get { throw null; } }
        public bool? IsChatWithUsEnabled { get { throw null; } }
        public bool? IsHirEvent { get { throw null; } }
        public bool? IsMicrosoftSupportEnabled { get { throw null; } }
        public bool? IsPlatformInitiated { get { throw null; } }
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue? Level { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink> Links { get { throw null; } }
        public string MaintenanceId { get { throw null; } }
        public string MaintenanceType { get { throw null; } }
        public int? Priority { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions RecommendedActions { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue? Status { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.ResourceHealthEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.ResourceHealthEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> GetIfExists(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>> GetIfExistsAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceHealthEventImpactedResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData>
    {
        internal ResourceHealthEventImpactedResourceData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem> Info { get { throw null; } }
        public string MaintenanceEndTime { get { throw null; } }
        public string MaintenanceStartTime { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Status { get { throw null; } }
        public string TargetRegion { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        public Azure.Core.ResourceType? TargetResourceType { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatus(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData> GetHealthEventsOfSingleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetResourceHealthEvent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> GetResourceHealthEventAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource GetResourceHealthEventImpactedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource GetResourceHealthEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventCollection GetResourceHealthEvents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityCollection GetResourceHealthMetadataEntities(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> GetResourceHealthMetadataEntity(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>> GetResourceHealthMetadataEntityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource GetResourceHealthMetadataEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetServiceEmergingIssue(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>> GetServiceEmergingIssueAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceHealthMetadataEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData>
    {
        internal ResourceHealthMetadataEntityData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario> ApplicableScenarios { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DependsOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail> SupportedValues { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> Get(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>> GetAsync(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetIfExists(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>> GetIfExistsAsync(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceEmergingIssueData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData>
    {
        internal ServiceEmergingIssueData() { }
        public System.DateTimeOffset? RefreshedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType> StatusActiveEvents { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType> StatusBanners { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceEmergingIssueResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceEmergingIssueResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> GetIfExists(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>> GetIfExistsAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource> GetIfExists(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource>> GetIfExistsAsync(string impactedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    public partial class MockableResourceHealthArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceHealthArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatus(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData> GetHealthEventsOfSingleResource(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(Azure.Core.ResourceIdentifier scope, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(Azure.Core.ResourceIdentifier scope, string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResource GetResourceHealthEventImpactedResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource GetResourceHealthEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource GetResourceHealthMetadataEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource GetServiceEmergingIssueResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventImpactedResource GetTenantResourceHealthEventImpactedResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource GetTenantResourceHealthEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourceHealthResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceHealthResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroup(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroupAsync(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourceHealthSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceHealthSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(string filter = null, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource> GetResourceHealthEvent(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthEventResource>> GetResourceHealthEventAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthEventCollection GetResourceHealthEvents() { throw null; }
    }
    public partial class MockableResourceHealthTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceHealthTenantResource() { }
        public virtual Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityCollection GetResourceHealthMetadataEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource> GetResourceHealthMetadataEntity(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityResource>> GetResourceHealthMetadataEntityAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource> GetServiceEmergingIssue(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueResource>> GetServiceEmergingIssueAsync(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent issueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueCollection GetServiceEmergingIssues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource> GetTenantResourceHealthEvent(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventResource>> GetTenantResourceHealthEventAsync(string eventTrackingId, string filter = null, string queryStartTime = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceHealth.TenantResourceHealthEventCollection GetTenantResourceHealthEvents() { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceHealth.Models
{
    public static partial class ArmResourceHealthModelFactory
    {
        public static Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType EmergingIssueActiveEventType(string title = null, string description = null, string trackingId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), string cloud = null, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel? severity = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel?), Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue? stage = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue?), bool? isPublished = default(bool?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact> impacts = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType EmergingIssueBannerType(string title = null, string message = null, string cloud = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact EmergingIssueImpact(string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion> regions = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion EmergingIssueImpactedRegion(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail MetadataSupportedValueDetail(string id = null, string displayName = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceType> resourceTypes = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved ResourceHealthAvailabilityStateRecentlyResolved(System.DateTimeOffset? unavailableOccuredOn = default(System.DateTimeOffset?), System.DateTimeOffset? resolvedOn = default(System.DateTimeOffset?), string unavailableSummary = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus ResourceHealthAvailabilityStatus(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties ResourceHealthAvailabilityStatusProperties(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue? availabilityState = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue?), string title = null, string summary = null, string detailedStatus = null, string reasonType = null, string context = null, string category = null, string articleId = null, System.DateTimeOffset? rootCauseAttributionOn = default(System.DateTimeOffset?), string healthEventType = null, string healthEventCause = null, string healthEventCategory = null, string healthEventId = null, System.DateTimeOffset? resolutionEta = default(System.DateTimeOffset?), System.DateTimeOffset? occuredOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType? reasonChronicity = default(Azure.ResourceManager.ResourceHealth.Models.ReasonChronicityType?), System.DateTimeOffset? reportedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved recentlyResolved = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction> recommendedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent> serviceImpactingEvents = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle ResourceHealthEventArticle(string articleContent = null, string articleId = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventData ResourceHealthEventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue? eventType = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue?), Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue? eventSubType = default(Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue?), Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue? eventSource = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue?), Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue? status = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue?), string title = null, string summary = null, string header = null, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue? level = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue?), Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue? eventLevel = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue?), string externalIncidentId = null, string reason = null, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle article = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink> links = null, System.DateTimeOffset? impactStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? impactMitigationOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact> impact = null, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions recommendedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq> faqs = null, bool? isHirEvent = default(bool?), bool? isMicrosoftSupportEnabled = default(bool?), string description = null, bool? isPlatformInitiated = default(bool?), bool? isChatWithUsEnabled = default(bool?), int? priority = default(int?), System.DateTimeOffset? lastUpdateOn = default(System.DateTimeOffset?), string hirStage = null, string additionalInformationMessage = null, int? duration = default(int?), string impactType = null, string maintenanceId = null, string maintenanceType = null, string argQuery = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq ResourceHealthEventFaq(string question = null, string answer = null, string localeCode = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact ResourceHealthEventImpact(string impactedService = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion> impactedRegions = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthEventImpactedResourceData ResourceHealthEventImpactedResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceType? targetResourceType = default(Azure.Core.ResourceType?), Azure.Core.ResourceIdentifier targetResourceId = null, string targetRegion = null, string resourceName = null, string resourceGroup = null, string status = null, string maintenanceStartTime = null, string maintenanceEndTime = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem> info = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion ResourceHealthEventImpactedServiceRegion(string impactedRegion = null, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue? status = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue?), System.Collections.Generic.IEnumerable<string> impactedSubscriptions = null, System.Collections.Generic.IEnumerable<string> impactedTenants = null, System.DateTimeOffset? lastUpdateOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate> updates = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink ResourceHealthEventLink(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue? linkType = default(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue?), Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText displayText = null, string extensionName = null, string bladeName = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText ResourceHealthEventLinkDisplayText(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions ResourceHealthEventRecommendedActions(string message = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem> actions = null, string localeCode = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem ResourceHealthEventRecommendedActionsItem(int? groupId = default(int?), string actionText = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate ResourceHealthEventUpdate(string summary = null, System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem ResourceHealthKeyValueItem(string key = null, string value = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ResourceHealthMetadataEntityData ResourceHealthMetadataEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.MetadataEntityScenario> applicableScenarios = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail> supportedValues = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction ResourceHealthRecommendedAction(string action = null, System.Uri actionUri = null, string actionUriComment = null, string actionUriText = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.ServiceEmergingIssueData ServiceEmergingIssueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? refreshedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType> statusBanners = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType> statusActiveEvents = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent ServiceImpactingEvent(System.DateTimeOffset? eventStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? eventStatusLastModifiedOn = default(System.DateTimeOffset?), string correlationId = null, string statusValue = null, Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties incidentProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties ServiceImpactingEventIncidentProperties(string title = null, string service = null, string region = null, string incidentType = null) { throw null; }
    }
    public partial class EmergingIssueActiveEventType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType>
    {
        internal EmergingIssueActiveEventType() { }
        public string Cloud { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact> Impacts { get { throw null; } }
        public bool? IsPublished { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel? Severity { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue? Stage { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Title { get { throw null; } }
        public string TrackingId { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueActiveEventType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmergingIssueBannerType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType>
    {
        internal EmergingIssueBannerType() { }
        public string Cloud { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueBannerType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmergingIssueImpact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact>
    {
        internal EmergingIssueImpact() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion> Regions { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmergingIssueImpactedRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion>
    {
        internal EmergingIssueImpactedRegion() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueImpactedRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmergingIssueNameContent : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmergingIssueNameContent(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent left, Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent left, Azure.ResourceManager.ResourceHealth.Models.EmergingIssueNameContent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubTypeValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubTypeValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue Retirement { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue left, Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue left, Azure.ResourceManager.ResourceHealth.Models.EventSubTypeValue right) { throw null; }
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
    public partial class MetadataSupportedValueDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail>
    {
        internal MetadataSupportedValueDetail() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceType> ResourceTypes { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.MetadataSupportedValueDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ResourceHealthAvailabilityStateRecentlyResolved : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved>
    {
        internal ResourceHealthAvailabilityStateRecentlyResolved() { }
        public System.DateTimeOffset? ResolvedOn { get { throw null; } }
        public System.DateTimeOffset? UnavailableOccuredOn { get { throw null; } }
        public string UnavailableSummary { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthAvailabilityStateValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthAvailabilityStateValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue Available { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue Degraded { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue Unavailable { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceHealthAvailabilityStatus : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>
    {
        internal ResourceHealthAvailabilityStatus() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties Properties { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthAvailabilityStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties>
    {
        internal ResourceHealthAvailabilityStatusProperties() { }
        public string ArticleId { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateValue? AvailabilityState { get { throw null; } }
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
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStateRecentlyResolved RecentlyResolved { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction> RecommendedActions { get { throw null; } }
        public System.DateTimeOffset? ReportedOn { get { throw null; } }
        public System.DateTimeOffset? ResolutionEta { get { throw null; } }
        public System.DateTimeOffset? RootCauseAttributionOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent> ServiceImpactingEvents { get { throw null; } }
        public string Summary { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthAvailabilityStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthEventArticle : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle>
    {
        internal ResourceHealthEventArticle() { }
        public string ArticleContent { get { throw null; } }
        public string ArticleId { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventArticle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthEventFaq : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq>
    {
        internal ResourceHealthEventFaq() { }
        public string Answer { get { throw null; } }
        public string LocaleCode { get { throw null; } }
        public string Question { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventFaq>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthEventImpact : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact>
    {
        internal ResourceHealthEventImpact() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion> ImpactedRegions { get { throw null; } }
        public string ImpactedService { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpact>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthEventImpactedServiceRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion>
    {
        internal ResourceHealthEventImpactedServiceRegion() { }
        public string ImpactedRegion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ImpactedSubscriptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ImpactedTenants { get { throw null; } }
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate> Updates { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventImpactedServiceRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventInsightLevelValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventInsightLevelValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue Critical { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventInsightLevelValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventLevelValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventLevelValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue Critical { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue Error { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue Informational { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLevelValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceHealthEventLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink>
    {
        internal ResourceHealthEventLink() { }
        public string BladeName { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText DisplayText { get { throw null; } }
        public string ExtensionName { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue? LinkType { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthEventLinkDisplayText : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText>
    {
        internal ResourceHealthEventLinkDisplayText() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkDisplayText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventLinkTypeValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventLinkTypeValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue Button { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue Hyperlink { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventLinkTypeValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceHealthEventRecommendedActions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions>
    {
        internal ResourceHealthEventRecommendedActions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem> Actions { get { throw null; } }
        public string LocaleCode { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthEventRecommendedActionsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem>
    {
        internal ResourceHealthEventRecommendedActionsItem() { }
        public string ActionText { get { throw null; } }
        public int? GroupId { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventRecommendedActionsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventSeverityLevel : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventSeverityLevel(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel Error { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel Information { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSeverityLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventSourceValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventSourceValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue ResourceHealth { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue ServiceHealth { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventSourceValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventStageValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventStageValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue Active { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue Archived { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue Resolve { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStageValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventStatusValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventStatusValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue Active { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue Resolved { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventStatusValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthEventTypeValue : System.IEquatable<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthEventTypeValue(string value) { throw null; }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue EmergingIssues { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue HealthAdvisory { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue PlannedMaintenance { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue Rca { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue SecurityAdvisory { get { throw null; } }
        public static Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue ServiceIssue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue left, Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventTypeValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceHealthEventUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate>
    {
        internal ResourceHealthEventUpdate() { }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthEventUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthKeyValueItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem>
    {
        internal ResourceHealthKeyValueItem() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthKeyValueItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthRecommendedAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction>
    {
        internal ResourceHealthRecommendedAction() { }
        public string Action { get { throw null; } }
        public System.Uri ActionUri { get { throw null; } }
        public string ActionUriComment { get { throw null; } }
        public string ActionUriText { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ResourceHealthRecommendedAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceImpactingEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent>
    {
        internal ServiceImpactingEvent() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EventStartOn { get { throw null; } }
        public System.DateTimeOffset? EventStatusLastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties IncidentProperties { get { throw null; } }
        public string StatusValue { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceImpactingEventIncidentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties>
    {
        internal ServiceImpactingEventIncidentProperties() { }
        public string IncidentType { get { throw null; } }
        public string Region { get { throw null; } }
        public string Service { get { throw null; } }
        public string Title { get { throw null; } }
        Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceHealth.Models.ServiceImpactingEventIncidentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
