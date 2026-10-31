namespace Azure.ResourceManager.Sovereign
{
    public partial class AzureResourceManagerSovereignContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSovereignContext() { }
        public static Azure.ResourceManager.Sovereign.AzureResourceManagerSovereignContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class SovereignExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult> CheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult> CheckNameAvailabilityLocal(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>> CheckNameAvailabilityLocalAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource> GetSovereignView(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource>> GetSovereignViewAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Sovereign.SovereignViewResource GetSovereignViewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Sovereign.SovereignViewCollection GetSovereignViews(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Sovereign.SovereignViewResource> GetSovereignViews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sovereign.SovereignViewResource> GetSovereignViewsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SovereignViewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sovereign.SovereignViewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.SovereignViewResource>, System.Collections.IEnumerable
    {
        protected SovereignViewCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sovereign.SovereignViewResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sovereignViewName, Azure.ResourceManager.Sovereign.SovereignViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sovereign.SovereignViewResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sovereignViewName, Azure.ResourceManager.Sovereign.SovereignViewData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource> Get(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sovereign.SovereignViewResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sovereign.SovereignViewResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource>> GetAsync(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Sovereign.SovereignViewResource> GetIfExists(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Sovereign.SovereignViewResource>> GetIfExistsAsync(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Sovereign.SovereignViewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Sovereign.SovereignViewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Sovereign.SovereignViewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.SovereignViewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SovereignViewData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.SovereignViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>
    {
        public SovereignViewData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.SovereignViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.SovereignViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.SovereignViewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SovereignViewResource() { }
        public virtual Azure.ResourceManager.Sovereign.SovereignViewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult> ComplianceDetails(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>> ComplianceDetailsAsync(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult> ComplianceResourceDetails(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>> ComplianceResourceDetailsAsync(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult> ComplianceSummary(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>> ComplianceSummaryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sovereignViewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult> FilterValues(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>> FilterValuesAsync(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult> OperationalStatus(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>> OperationalStatusAsync(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult> Remediate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>> RemediateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult> RemediationResult(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>> RemediationResultAsync(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Sovereign.SovereignViewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.SovereignViewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.SovereignViewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sovereign.SovereignViewResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sovereign.Models.SovereignViewPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sovereign.SovereignViewResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Sovereign.Models.SovereignViewPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Sovereign.Mocking
{
    public partial class MockableSovereignArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSovereignArmClient() { }
        public virtual Azure.ResourceManager.Sovereign.SovereignViewResource GetSovereignViewResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSovereignResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSovereignResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource> GetSovereignView(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.SovereignViewResource>> GetSovereignViewAsync(string sovereignViewName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Sovereign.SovereignViewCollection GetSovereignViews() { throw null; }
    }
    public partial class MockableSovereignSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSovereignSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult> CheckNameAvailabilityLocal(Azure.Core.AzureLocation location, Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>> CheckNameAvailabilityLocalAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Sovereign.SovereignViewResource> GetSovereignViews(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sovereign.SovereignViewResource> GetSovereignViewsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Sovereign.Models
{
    public static partial class ArmSovereignModelFactory
    {
        public static Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent SovereignNameAvailabilityContent(string name = null, string type = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult SovereignNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason? reason = default(Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes SovereignViewAffectedScopes(string name = null, string id = null, Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType type = default(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType), Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState status = default(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState), string actionRequired = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle SovereignViewArmTemplateBundle(string template = null, string parameters = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail SovereignViewComplianceDetail(Azure.Core.ResourceIdentifier policyInitiativeId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, System.DateTimeOffset? evaluatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo SovereignViewComplianceDetailResourceInfo(Azure.Core.ResourceIdentifier resourceId = null, string parentResourceId = null, string location = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail> dimensionDetails = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent SovereignViewComplianceDetailsContent(int top = 0, int? skip = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter> complianceDimensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters> filters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort> sort = null, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch search = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter SovereignViewComplianceDetailsDimensionFilter(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.PolicyComplianceState> states = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters SovereignViewComplianceDetailsFilters(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField field = default(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField), Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator @operator = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator), System.Collections.Generic.IEnumerable<string> value = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult SovereignViewComplianceDetailsResult(Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus reportStatus = null, Azure.ResponseError error = null, System.DateTimeOffset lastEvaluatedOn = default(System.DateTimeOffset), int? totalResources = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo> resources = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch SovereignViewComplianceDetailsSearch(string field = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort SovereignViewComplianceDetailsSort(string field = null, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection direction = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.PolicyComplianceState> sortingOrder = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary SovereignViewComplianceDimensionSummary(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), int totalResources = 0, int compliantCount = 0, int nonCompliantCount = 0, int constrainedCount = 0, int conflictCount = 0, int notApplicableCount = 0, int notEvaluatedCount = 0, int othersCount = 0) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary SovereignViewComplianceOverallSummary(int totalManagementGroups = 0, int totalSubscriptions = 0, int totalResourceGroups = 0, int totalResources = 0, int compliantCount = 0, int nonCompliantCount = 0, int constrainedCount = 0, int conflictCount = 0, int notApplicableCount = 0, int notEvaluatedCount = 0, int othersCount = 0) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent SovereignViewComplianceResourceDetailsContent(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), System.DateTimeOffset? evaluatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult SovereignViewComplianceResourceDetailsResult(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), System.DateTimeOffset evaluatedOn = default(System.DateTimeOffset), Azure.ResourceManager.Sovereign.Models.PolicyComplianceState state = default(Azure.ResourceManager.Sovereign.Models.PolicyComplianceState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation> evaluations = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult SovereignViewComplianceSummaryResult(Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus reportStatus = null, Azure.ResponseError error = null, Azure.Core.ResourceIdentifier resourceId = null, System.DateTimeOffset lastEvaluatedOn = default(System.DateTimeOffset), Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary overallSummary = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary> dimensionSummaries = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.SovereignViewData SovereignViewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Sovereign.Models.SovereignViewProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation SovereignViewDataEvaluation(string evaluationSourceId = null, Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent intent = default(Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent), Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource source = default(Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome> evaluationOutcomes = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome SovereignViewDataEvaluationOutcome(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.Sovereign.Models.PolicyComplianceState state = default(Azure.ResourceManager.Sovereign.Models.PolicyComplianceState), string actualValue = null, string expectedValue = null, string reason = null, string reasonCodeId = null, string additionalInfo = null, string additionalInfoCodeId = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings SovereignViewDataResidencyDimensionSettings(Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope resourceEvaluationScope = default(Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope), System.Collections.Generic.IEnumerable<string> parametersAllowedLocations = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail SovereignViewDimensionDetail(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), Azure.ResourceManager.Sovereign.Models.PolicyComplianceState state = default(Azure.ResourceManager.Sovereign.Models.PolicyComplianceState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail> complianceDetails = null, System.DateTimeOffset evaluatedOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource> sources = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem SovereignViewFilterValueItem(string value = null, string displayName = null, int count = 0) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent SovereignViewFilterValuesContent(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField requestedFilter = default(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters> filters = null, string searchTerm = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult SovereignViewFilterValuesResult(Azure.ResourceManager.Sovereign.Models.SovereignViewDataState dataState = default(Azure.ResourceManager.Sovereign.Models.SovereignViewDataState), Azure.ResponseError error = null, Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField? requestedFilter = default(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField?), int? totalCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem> values = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope SovereignViewManagementGroupScope(Azure.Core.ResourceIdentifier id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent SovereignViewOperationalStatusContent(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode? mode = default(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind> evaluationParameters = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails SovereignViewOperationalStatusDetails(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason reason = default(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes> affectedScopes = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult SovereignViewOperationalStatusResult(string name = null, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState status = default(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails> details = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewPatch SovereignViewPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail SovereignViewPolicyInitiativeDetail(Azure.Core.ResourceIdentifier policyInitiativeId = null, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> policyAssignmentIds = null, string policyVersion = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewProperties SovereignViewProperties(Azure.ResourceManager.Sovereign.Models.SovereignViewScope scope = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail> policyInitiatives = null, Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName? regulatoryDocumentName = default(Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName?), Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState? provisioningState = default(Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState?), Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings dimensionDataResidency = null, bool? isWorkload = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent SovereignViewRemediateContent(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimensionType = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent residencyRemediationRequest = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult SovereignViewRemediateResult(string remediationId = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult SovereignViewRemediationResult(string remediationId = null, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimensionType = default(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension), Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus status = default(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem> results = null, Azure.ResponseError error = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent SovereignViewRemediationResultContent(string remediationId = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem SovereignViewRemediationResultItem(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> resourceIds = null, Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType type = default(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType), Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle result = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus SovereignViewReportStatus(Azure.ResourceManager.Sovereign.Models.ReportState state = default(Azure.ResourceManager.Sovereign.Models.ReportState), System.DateTimeOffset? nextAttemptOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration SovereignViewResidencyRemediationConfiguration(string targetRegion = null, string targetResourceGroupName = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent SovereignViewResidencyRemediationContent(Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration configuration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo> resources = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration SovereignViewResidencyRemediationResourceConfiguration(string sourceRegion = null, string targetResourceGroupName = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo SovereignViewResidencyRemediationResourceInfo(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration configuration = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewScope SovereignViewScope(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope> managementGroups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope> subscriptions = null) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope SovereignViewSubscriptionScope(System.Guid id = default(System.Guid), string name = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataResidencyResourceEvaluationScope : System.IEquatable<Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataResidencyResourceEvaluationScope(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope Residency360 { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope ResourceOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope left, Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope left, Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyComplianceState : System.IEquatable<Azure.ResourceManager.Sovereign.Models.PolicyComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.PolicyComplianceState Compliant { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.PolicyComplianceState Conflict { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.PolicyComplianceState Constrained { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.PolicyComplianceState NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.PolicyComplianceState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.PolicyComplianceState NotEvaluated { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.PolicyComplianceState Others { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.PolicyComplianceState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.PolicyComplianceState left, Azure.ResourceManager.Sovereign.Models.PolicyComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.PolicyComplianceState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.PolicyComplianceState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.PolicyComplianceState left, Azure.ResourceManager.Sovereign.Models.PolicyComplianceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportState : System.IEquatable<Azure.ResourceManager.Sovereign.Models.ReportState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportState(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.ReportState Blocked { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.ReportState Generating { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.ReportState NoDataYet { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.ReportState Refreshing { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.ReportState Retrying { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.ReportState Stale { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.ReportState UpToDate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.ReportState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.ReportState left, Azure.ResourceManager.Sovereign.Models.ReportState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.ReportState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.ReportState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.ReportState left, Azure.ResourceManager.Sovereign.Models.ReportState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent>
    {
        public SovereignNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>
    {
        internal SovereignNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason left, Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason left, Azure.ResourceManager.Sovereign.Models.SovereignNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewAffectedScopes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes>
    {
        internal SovereignViewAffectedScopes() { }
        public string ActionRequired { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState Status { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewArmTemplateBundle : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle>
    {
        internal SovereignViewArmTemplateBundle() { }
        public string Parameters { get { throw null; } }
        public string Template { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail>
    {
        internal SovereignViewComplianceDetail() { }
        public System.DateTimeOffset? EvaluatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyInitiativeId { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceDetailResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo>
    {
        internal SovereignViewComplianceDetailResourceInfo() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail> DimensionDetails { get { throw null; } }
        public string Location { get { throw null; } }
        public string ParentResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceDetailsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent>
    {
        public SovereignViewComplianceDetailsContent(int top) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter> ComplianceDimensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters> Filters { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch Search { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort> Sort { get { throw null; } }
        public int Top { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceDetailsDimensionFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter>
    {
        public SovereignViewComplianceDetailsDimensionFilter(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.PolicyComplianceState> states) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension Dimension { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.PolicyComplianceState> States { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsDimensionFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewComplianceDetailsFilterOperator : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewComplianceDetailsFilterOperator(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator In { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator left, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator left, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewComplianceDetailsFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters>
    {
        public SovereignViewComplianceDetailsFilters(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField field, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator @operator, System.Collections.Generic.IEnumerable<string> value) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField Field { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilterOperator Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceDetailsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>
    {
        internal SovereignViewComplianceDetailsResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset LastEvaluatedOn { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus ReportStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailResourceInfo> Resources { get { throw null; } }
        public int? TotalResources { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceDetailsSearch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch>
    {
        public SovereignViewComplianceDetailsSearch(string field, string value) { }
        public string Field { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceDetailsSort : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort>
    {
        public SovereignViewComplianceDetailsSort(string field, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection direction) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection Direction { get { throw null; } }
        public string Field { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.PolicyComplianceState> SortingOrder { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewComplianceDetailsSortDirection : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewComplianceDetailsSortDirection(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection Asc { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection Desc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection left, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection left, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsSortDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewComplianceDimension : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewComplianceDimension(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension BusinessContinuity { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension ControlledNetworkExposure { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension DataResidency { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension EncryptionAtRest { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension EncryptionInTransit { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension EncryptionInUse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension left, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension left, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewComplianceDimensionSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary>
    {
        internal SovereignViewComplianceDimensionSummary() { }
        public int CompliantCount { get { throw null; } }
        public int ConflictCount { get { throw null; } }
        public int ConstrainedCount { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension Dimension { get { throw null; } }
        public int NonCompliantCount { get { throw null; } }
        public int NotApplicableCount { get { throw null; } }
        public int NotEvaluatedCount { get { throw null; } }
        public int OthersCount { get { throw null; } }
        public int TotalResources { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceOverallSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary>
    {
        internal SovereignViewComplianceOverallSummary() { }
        public int CompliantCount { get { throw null; } }
        public int ConflictCount { get { throw null; } }
        public int ConstrainedCount { get { throw null; } }
        public int NonCompliantCount { get { throw null; } }
        public int NotApplicableCount { get { throw null; } }
        public int NotEvaluatedCount { get { throw null; } }
        public int OthersCount { get { throw null; } }
        public int TotalManagementGroups { get { throw null; } }
        public int TotalResourceGroups { get { throw null; } }
        public int TotalResources { get { throw null; } }
        public int TotalSubscriptions { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceResourceDetailsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent>
    {
        public SovereignViewComplianceResourceDetailsContent(Azure.Core.ResourceIdentifier resourceId, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension Dimension { get { throw null; } }
        public System.DateTimeOffset? EvaluatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceResourceDetailsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>
    {
        internal SovereignViewComplianceResourceDetailsResult() { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension Dimension { get { throw null; } }
        public System.DateTimeOffset EvaluatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation> Evaluations { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.PolicyComplianceState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceResourceDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewComplianceSummaryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>
    {
        internal SovereignViewComplianceSummaryResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimensionSummary> DimensionSummaries { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset LastEvaluatedOn { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceOverallSummary OverallSummary { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus ReportStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceSummaryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewDataEvaluation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation>
    {
        internal SovereignViewDataEvaluation() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome> EvaluationOutcomes { get { throw null; } }
        public string EvaluationSourceId { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent Intent { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource Source { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewDataEvaluationOutcome : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome>
    {
        internal SovereignViewDataEvaluationOutcome() { }
        public string ActualValue { get { throw null; } }
        public string AdditionalInfo { get { throw null; } }
        public string AdditionalInfoCodeId { get { throw null; } }
        public string ExpectedValue { get { throw null; } }
        public string Reason { get { throw null; } }
        public string ReasonCodeId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.PolicyComplianceState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataEvaluationOutcome>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewDataResidencyDimensionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings>
    {
        public SovereignViewDataResidencyDimensionSettings(Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope resourceEvaluationScope, System.Collections.Generic.IList<string> parametersAllowedLocations) { }
        public System.Collections.Generic.IList<string> ParametersAllowedLocations { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.DataResidencyResourceEvaluationScope ResourceEvaluationScope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewDataState : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewDataState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewDataState(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewDataState Error { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewDataState Processed { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewDataState Processing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewDataState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewDataState left, Azure.ResourceManager.Sovereign.Models.SovereignViewDataState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewDataState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewDataState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewDataState left, Azure.ResourceManager.Sovereign.Models.SovereignViewDataState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewDimensionDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail>
    {
        internal SovereignViewDimensionDetail() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetail> ComplianceDetails { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension Dimension { get { throw null; } }
        public System.DateTimeOffset EvaluatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource> Sources { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.PolicyComplianceState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewDimensionDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewEvaluationIntent : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewEvaluationIntent(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent BusinessContinuity { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent GeoReplica { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent LinkedResources { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent left, Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent left, Azure.ResourceManager.Sovereign.Models.SovereignViewEvaluationIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewFilterField : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewFilterField(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField BusinessContinuity { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField ControlledNetworkExposure { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField DataResidency { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField EncryptionAtRest { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField EncryptionInTransit { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField EncryptionInUse { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField ParentResourceName { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField Region { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField ResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField ResourceName { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField ResourceType { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField Subscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField left, Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField left, Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewFilterValueItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem>
    {
        internal SovereignViewFilterValueItem() { }
        public int Count { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewFilterValuesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent>
    {
        public SovereignViewFilterValuesContent(Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField requestedFilter) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDetailsFilters> Filters { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField RequestedFilter { get { throw null; } }
        public string SearchTerm { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewFilterValuesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>
    {
        internal SovereignViewFilterValuesResult() { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewDataState DataState { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewFilterField? RequestedFilter { get { throw null; } }
        public int? TotalCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValueItem> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewFilterValuesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewLinkedResourceEvaluationSource : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewLinkedResourceEvaluationSource(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource AzureResourceGraph { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource BusinessContinuity { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource LogAnalytics { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource left, Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource left, Azure.ResourceManager.Sovereign.Models.SovereignViewLinkedResourceEvaluationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewManagementGroupScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope>
    {
        public SovereignViewManagementGroupScope(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewOperationalStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent>
    {
        public SovereignViewOperationalStatusContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind> EvaluationParameters { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode? Mode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewOperationalStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails>
    {
        internal SovereignViewOperationalStatusDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewAffectedScopes> AffectedScopes { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewOperationalStatusEvaluationKind : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewOperationalStatusEvaluationKind(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind PermissionsEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind PolicyAssignmentEvaluation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusEvaluationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewOperationalStatusMode : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewOperationalStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode Detailed { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode Summary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewOperationalStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>
    {
        internal SovereignViewOperationalStatusResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusDetails> Details { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewOperationalStatusState : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewOperationalStatusState(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState Healthy { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewOperationalStatusUnhealthyReason : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewOperationalStatusUnhealthyReason(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason MIMissing { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason MIPermissionMissing { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason PolicyAssignmentMissing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason left, Azure.ResourceManager.Sovereign.Models.SovereignViewOperationalStatusUnhealthyReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPatch>
    {
        public SovereignViewPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewPolicyInitiativeDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail>
    {
        public SovereignViewPolicyInitiativeDetail(Azure.Core.ResourceIdentifier policyInitiativeId, Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimension, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> policyAssignmentIds, string policyVersion) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension Dimension { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> PolicyAssignmentIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyInitiativeId { get { throw null; } set { } }
        public string PolicyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewProperties>
    {
        public SovereignViewProperties(Azure.ResourceManager.Sovereign.Models.SovereignViewScope scope, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail> policyInitiatives) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewDataResidencyDimensionSettings DimensionDataResidency { get { throw null; } set { } }
        public bool? IsWorkload { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewPolicyInitiativeDetail> PolicyInitiatives { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName? RegulatoryDocumentName { get { throw null; } set { } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewScope Scope { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewProvisioningState : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState left, Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState left, Azure.ResourceManager.Sovereign.Models.SovereignViewProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewRegulatoryDocumentName : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewRegulatoryDocumentName(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName SovereignControlBaseline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName left, Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName left, Azure.ResourceManager.Sovereign.Models.SovereignViewRegulatoryDocumentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewRemediateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent>
    {
        public SovereignViewRemediateContent(Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension dimensionType, Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent residencyRemediationRequest) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension DimensionType { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent ResidencyRemediationRequest { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewRemediateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>
    {
        internal SovereignViewRemediateResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string RemediationId { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewRemediationPayloadType : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewRemediationPayloadType(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType ArmTemplateBundle { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType left, Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType left, Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewRemediationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>
    {
        internal SovereignViewRemediationResult() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewComplianceDimension DimensionType { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string RemediationId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem> Results { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewRemediationResultContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent>
    {
        public SovereignViewRemediationResultContent(string remediationId) { }
        public string RemediationId { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewRemediationResultItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem>
    {
        internal SovereignViewRemediationResultItem() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ResourceIds { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewArmTemplateBundle Result { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationPayloadType Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationResultItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewRemediationStatus : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewRemediationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus left, Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus left, Azure.ResourceManager.Sovereign.Models.SovereignViewRemediationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewReportStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus>
    {
        internal SovereignViewReportStatus() { }
        public System.DateTimeOffset? NextAttemptOn { get { throw null; } }
        public Azure.ResourceManager.Sovereign.Models.ReportState State { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewReportStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewResidencyRemediationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration>
    {
        public SovereignViewResidencyRemediationConfiguration(string targetRegion) { }
        public string TargetRegion { get { throw null; } }
        public string TargetResourceGroupName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewResidencyRemediationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent>
    {
        public SovereignViewResidencyRemediationContent(Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration configuration, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo> resources) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationConfiguration Configuration { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo> Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewResidencyRemediationResourceConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration>
    {
        public SovereignViewResidencyRemediationResourceConfiguration(string sourceRegion) { }
        public string SourceRegion { get { throw null; } }
        public string TargetResourceGroupName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SovereignViewResidencyRemediationResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo>
    {
        public SovereignViewResidencyRemediationResourceInfo(Azure.Core.ResourceIdentifier id, Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration configuration) { }
        public Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceConfiguration Configuration { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewResidencyRemediationResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewResourceEvaluationSource : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewResourceEvaluationSource(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource Policy { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource SovereignIntelligence { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource left, Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource left, Azure.ResourceManager.Sovereign.Models.SovereignViewResourceEvaluationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewScope>
    {
        public SovereignViewScope() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewManagementGroupScope> ManagementGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope> Subscriptions { get { throw null; } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewScope JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewScope PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewScopeOperationalStatusState : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewScopeOperationalStatusState(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState left, Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState left, Azure.ResourceManager.Sovereign.Models.SovereignViewScopeOperationalStatusState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SovereignViewScopeType : System.IEquatable<Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SovereignViewScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType Subscription { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType left, Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType left, Azure.ResourceManager.Sovereign.Models.SovereignViewScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SovereignViewSubscriptionScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope>
    {
        public SovereignViewSubscriptionScope(System.Guid id) { }
        public System.Guid Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sovereign.Models.SovereignViewSubscriptionScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
