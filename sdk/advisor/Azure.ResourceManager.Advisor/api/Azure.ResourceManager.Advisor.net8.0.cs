namespace Azure.ResourceManager.Advisor
{
    public partial class AdvisorAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>, System.Collections.IEnumerable
    {
        protected AdvisorAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Advisor.AdvisorAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Advisor.AdvisorAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> GetAll(string top = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> GetAllAsync(string top = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>
    {
        public AdvisorAssessmentData() { }
        public string AssessmentId { get { throw null; } }
        public string Description { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public int? Score { get { throw null; } }
        public string State { get { throw null; } }
        public string TypeId { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } }
        public string WorkloadId { get { throw null; } set { } }
        public string WorkloadName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorAssessmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorAssessmentResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.AdvisorAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.AdvisorAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AdvisorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult> AdvisorPredict(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>> AdvisorPredictAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> CreateAdvisorConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> CreateAdvisorConfiguration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>> CreateAdvisorConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>> CreateAdvisorConfigurationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GenerateRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GenerateRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> GetAdvisorAssessment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> GetAdvisorAssessmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorAssessmentResource GetAdvisorAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorAssessmentCollection GetAdvisorAssessments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> GetAdvisorResiliencyReview(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetAdvisorResiliencyReviewAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource GetAdvisorResiliencyReviewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorResiliencyReviewCollection GetAdvisorResiliencyReviews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityCollection GetAdvisorScoreEntities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAdvisorScoreEntity(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAdvisorScoreEntityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityResource GetAdvisorScoreEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloads(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloadsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetGenerateStatusRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetGenerateStatusRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.MetadataEntityCollection GetMetadataEntities(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource> GetMetadataEntity(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource>> GetMetadataEntityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.MetadataEntityResource GetMetadataEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetResourceRecommendationBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetResourceRecommendationBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource GetResourceRecommendationBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseCollection GetResourceRecommendationBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Advisor.SuppressionContractResource GetSuppressionContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContracts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContractsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdvisorResiliencyReviewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>, System.Collections.IEnumerable
    {
        protected AdvisorResiliencyReviewCollection() { }
        public virtual Azure.Response<bool> Exists(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> Get(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> GetAll(int? top = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> GetIfExists(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetIfExistsAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorResiliencyReviewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>
    {
        internal AdvisorResiliencyReviewData() { }
        public string PublishedAt { get { throw null; } }
        public int? RecommendationsCount { get { throw null; } }
        public string ReviewName { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus? ReviewStatus { get { throw null; } }
        public string UpdatedAt { get { throw null; } }
        public string WorkloadName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorResiliencyReviewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorResiliencyReviewResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response ApproveTriageRecommendationTriageRecommendation(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApproveTriageRecommendationTriageRecommendationAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string reviewId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.TriageRecommendation> GetTriageRecommendation(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.TriageRecommendation>> GetTriageRecommendationAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.TriageRecommendation> GetTriageRecommendations(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.TriageRecommendation> GetTriageRecommendationsAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData> GetTriageResource(string recommendationId, string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>> GetTriageResourceAsync(string recommendationId, string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData> GetTriageResources(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData> GetTriageResourcesAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectTriageRecommendationTriageRecommendation(string recommendationId, Azure.ResourceManager.Advisor.Models.RecommendationRejectBody recommendationRejectBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectTriageRecommendationTriageRecommendationAsync(string recommendationId, Azure.ResourceManager.Advisor.Models.RecommendationRejectBody recommendationRejectBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetTriageRecommendationTriageRecommendation(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetTriageRecommendationTriageRecommendationAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorScoreEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>, System.Collections.IEnumerable
    {
        protected AdvisorScoreEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorScoreEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>
    {
        internal AdvisorScoreEntityData() { }
        public Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent LastRefreshedScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity> TimeSeries { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorScoreEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorScoreEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorScoreEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorScoreEntityResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorScoreEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorScoreEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorScoreEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorScoreEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerAdvisorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAdvisorContext() { }
        public static Azure.ResourceManager.Advisor.AzureResourceManagerAdvisorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MetadataEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.MetadataEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.MetadataEntityResource>, System.Collections.IEnumerable
    {
        protected MetadataEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.MetadataEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.MetadataEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.MetadataEntityResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.MetadataEntityResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.MetadataEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.MetadataEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.MetadataEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.MetadataEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MetadataEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.MetadataEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>
    {
        internal MetadataEntityData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Advisor.Models.Scenario> ApplicableScenarios { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DependsOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail> SupportedValues { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.MetadataEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.MetadataEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetadataEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.MetadataEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MetadataEntityResource() { }
        public virtual Azure.ResourceManager.Advisor.MetadataEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.MetadataEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.MetadataEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.MetadataEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceRecommendationBaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>, System.Collections.IEnumerable
    {
        protected ResourceRecommendationBaseCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> Get(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetAll(string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetAllAsync(string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetIfExists(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetIfExistsAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceRecommendationBaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>
    {
        public ResourceRecommendationBaseData() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Actions { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationCategory? Category { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationControlType? Control { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExposedMetadataProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? Impact { get { throw null; } set { } }
        public string ImpactedField { get { throw null; } set { } }
        public string ImpactedValue { get { throw null; } set { } }
        public bool? IsTracked { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public string LearnMoreLink { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Metadata { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public string PotentialBenefits { get { throw null; } set { } }
        public string RecommendationTypeId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Remediation { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ResourceMetadata ResourceMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload ResourceWorkload { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationReview Review { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.Risk? Risk { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.ShortDescription ShortDescription { get { throw null; } set { } }
        public string SourceSystem { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Guid> SuppressionIds { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties TrackedProperties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.ResourceRecommendationBaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.ResourceRecommendationBaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceRecommendationBaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceRecommendationBaseResource() { }
        public virtual Azure.ResourceManager.Advisor.ResourceRecommendationBaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string recommendationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContract(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.SuppressionContractResource>> GetSuppressionContractAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.SuppressionContractCollection GetSuppressionContracts() { throw null; }
        Azure.ResourceManager.Advisor.ResourceRecommendationBaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.ResourceRecommendationBaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResourceRecommendationBaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> Update(Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> UpdateAsync(Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SuppressionContractCollection : Azure.ResourceManager.ArmCollection
    {
        protected SuppressionContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.SuppressionContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Advisor.SuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.SuppressionContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Advisor.SuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.SuppressionContractResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.SuppressionContractResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.SuppressionContractResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.SuppressionContractResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SuppressionContractData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.SuppressionContractData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>
    {
        public SuppressionContractData() { }
        public System.DateTimeOffset? ExpirationTimeStamp { get { throw null; } }
        public string SuppressionId { get { throw null; } set { } }
        public string Ttl { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.SuppressionContractData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.SuppressionContractData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuppressionContractResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.SuppressionContractData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SuppressionContractResource() { }
        public virtual Azure.ResourceManager.Advisor.SuppressionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string recommendationId, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.SuppressionContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.SuppressionContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.SuppressionContractData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.SuppressionContractData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.SuppressionContractData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.SuppressionContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.SuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.SuppressionContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.SuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Advisor.Mocking
{
    public partial class MockableAdvisorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorArmClient() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorAssessmentResource GetAdvisorAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource GetAdvisorResiliencyReviewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorScoreEntityResource GetAdvisorScoreEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.MetadataEntityResource GetMetadataEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetResourceRecommendationBase(Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetResourceRecommendationBaseAsync(Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource GetResourceRecommendationBaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.ResourceRecommendationBaseCollection GetResourceRecommendationBases(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Advisor.SuppressionContractResource GetSuppressionContractResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAdvisorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> CreateAdvisorConfiguration(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>> CreateAdvisorConfigurationAsync(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAdvisorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult> AdvisorPredict(Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>> AdvisorPredictAsync(Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> CreateAdvisorConfiguration(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>> CreateAdvisorConfigurationAsync(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> GetAdvisorAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> GetAdvisorAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorAssessmentCollection GetAdvisorAssessments() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigData> GetAdvisorConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> GetAdvisorResiliencyReview(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetAdvisorResiliencyReviewAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorResiliencyReviewCollection GetAdvisorResiliencyReviews() { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorScoreEntityCollection GetAdvisorScoreEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAdvisorScoreEntity(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAdvisorScoreEntityAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloads(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloadsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetGenerateStatusRecommendation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGenerateStatusRecommendationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContracts(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContractsAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAdvisorTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorTenantResource() { }
        public virtual Azure.ResourceManager.Advisor.MetadataEntityCollection GetMetadataEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource> GetMetadataEntity(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource>> GetMetadataEntityAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Advisor.Models
{
    public partial class AdvisorAssessmentType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>
    {
        internal AdvisorAssessmentType() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Locale { get { throw null; } }
        public string Title { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorConfigData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>
    {
        public AdvisorConfigData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.DigestConfig> Digests { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration? Duration { get { throw null; } set { } }
        public bool? Exclude { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.CpuThreshold? LowCpuThreshold { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorConfigData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorConfigData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvisorLowCpuEvaluationDuration : System.IEquatable<Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvisorLowCpuEvaluationDuration(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration _14 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration _21 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration _30 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration _60 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration _7 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration _90 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration left, Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration left, Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvisorPredictionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>
    {
        public AdvisorPredictionContent() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.AdvisorPredictionType? PredictionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorPredictionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>
    {
        internal AdvisorPredictionResult() { }
        public Azure.ResourceManager.Advisor.Models.RecommendationCategory? Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? Impact { get { throw null; } }
        public string ImpactedField { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.AdvisorPredictionType? PredictionType { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ShortDescription ShortDescription { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvisorPredictionType : System.IEquatable<Azure.ResourceManager.Advisor.Models.AdvisorPredictionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvisorPredictionType(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorPredictionType PredictiveRightsizing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.AdvisorPredictionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorPredictionType left, Azure.ResourceManager.Advisor.Models.AdvisorPredictionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorPredictionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorPredictionType left, Azure.ResourceManager.Advisor.Models.AdvisorPredictionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvisorReasonForRejectionName : System.IEquatable<Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvisorReasonForRejectionName(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName NotARisk { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName RiskAccepted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName left, Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName left, Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvisorScoreEntityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent>
    {
        internal AdvisorScoreEntityContent() { }
        public float? CategoryCount { get { throw null; } }
        public float? ConsumptionUnits { get { throw null; } }
        public string Date { get { throw null; } }
        public float? ImpactedResourceCount { get { throw null; } }
        public float? PotentialScoreIncrease { get { throw null; } }
        public float? Score { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorTimeSeriesEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>
    {
        internal AdvisorTimeSeriesEntity() { }
        public Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel? AggregationLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent> ScoreHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorTriageResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>
    {
        internal AdvisorTriageResourceData() { }
        public string RecommendationId { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>
    {
        internal AdvisorWorkload() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAdvisorModelFactory
    {
        public static Azure.ResourceManager.Advisor.AdvisorAssessmentData AdvisorAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string workloadId = null, string workloadName = null, string assessmentId = null, string description = null, string typeId = null, int? score = default(int?), string state = null, string typeVersion = null, string locale = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType AdvisorAssessmentType(string id = null, string title = null, string description = null, string locale = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorConfigData AdvisorConfigData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? exclude = default(bool?), Azure.ResourceManager.Advisor.Models.CpuThreshold? lowCpuThreshold = default(Azure.ResourceManager.Advisor.Models.CpuThreshold?), Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration? duration = default(Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.DigestConfig> digests = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult AdvisorPredictionResult(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> extendedProperties = null, Azure.ResourceManager.Advisor.Models.AdvisorPredictionType? predictionType = default(Azure.ResourceManager.Advisor.Models.AdvisorPredictionType?), Azure.ResourceManager.Advisor.Models.RecommendationCategory? category = default(Azure.ResourceManager.Advisor.Models.RecommendationCategory?), Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? impact = default(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact?), string impactedField = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Advisor.Models.ShortDescription shortDescription = null) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData AdvisorResiliencyReviewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewName = null, string workloadName = null, Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus? reviewStatus = default(Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus?), int? recommendationsCount = default(int?), string publishedAt = null, string updatedAt = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent AdvisorScoreEntityContent(string date = null, float? score = default(float?), float? consumptionUnits = default(float?), float? impactedResourceCount = default(float?), float? potentialScoreIncrease = default(float?), float? categoryCount = default(float?)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityData AdvisorScoreEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent lastRefreshedScore = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity> timeSeries = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity AdvisorTimeSeriesEntity(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel? aggregationLevel = default(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent> scoreHistory = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorTriageResourceData AdvisorTriageResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewId = null, string recommendationId = null, string subscriptionId = null, string resourceGroup = null, Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorWorkload AdvisorWorkload(string id = null, string name = null, string subscriptionId = null, string subscriptionName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.MetadataEntityData MetadataEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.Scenario> applicableScenarios = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail> supportedValues = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail MetadataSupportedValueDetail(string id = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseData ResourceRecommendationBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Advisor.Models.RecommendationCategory? category = default(Azure.ResourceManager.Advisor.Models.RecommendationCategory?), Azure.ResourceManager.Advisor.Models.RecommendationControlType? control = default(Azure.ResourceManager.Advisor.Models.RecommendationControlType?), Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? impact = default(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact?), string impactedField = null, string impactedValue = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, System.BinaryData> metadata = null, string recommendationTypeId = null, Azure.ResourceManager.Advisor.Models.Risk? risk = default(Azure.ResourceManager.Advisor.Models.Risk?), Azure.ResourceManager.Advisor.Models.ShortDescription shortDescription = null, System.Collections.Generic.IEnumerable<System.Guid> suppressionIds = null, System.Collections.Generic.IDictionary<string, string> extendedProperties = null, Azure.ResourceManager.Advisor.Models.ResourceMetadata resourceMetadata = null, string description = null, string label = null, string learnMoreLink = null, string potentialBenefits = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> actions = null, System.Collections.Generic.IDictionary<string, System.BinaryData> remediation = null, System.Collections.Generic.IDictionary<string, System.BinaryData> exposedMetadataProperties = null, bool? isTracked = default(bool?), Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties trackedProperties = null, Azure.ResourceManager.Advisor.Models.RecommendationReview review = null, Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload resourceWorkload = null, string sourceSystem = null, string notes = null) { throw null; }
        public static Azure.ResourceManager.Advisor.SuppressionContractData SuppressionContractData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string suppressionId = null, string ttl = null, System.DateTimeOffset? expirationTimeStamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.TriageRecommendation TriageRecommendation(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewId = null, string title = null, Azure.ResourceManager.Advisor.Models.RecommendationPriorityName? priority = default(Azure.ResourceManager.Advisor.Models.RecommendationPriorityName?), System.Collections.Generic.IEnumerable<string> appliesToSubscriptions = null, Azure.ResourceManager.Advisor.Models.RecommendationStatusName? recommendationStatus = default(Azure.ResourceManager.Advisor.Models.RecommendationStatusName?), string updatedAt = null, string rejectReason = null, string potentialBenefits = null, string description = null, string notes = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationName : System.IEquatable<Azure.ResourceManager.Advisor.Models.ConfigurationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationName(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.ConfigurationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.ConfigurationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.ConfigurationName left, Azure.ResourceManager.Advisor.Models.ConfigurationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ConfigurationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.ConfigurationName left, Azure.ResourceManager.Advisor.Models.ConfigurationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CpuThreshold : System.IEquatable<Azure.ResourceManager.Advisor.Models.CpuThreshold>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CpuThreshold(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.CpuThreshold Fifteen { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.CpuThreshold Five { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.CpuThreshold Ten { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.CpuThreshold Twenty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.CpuThreshold other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.CpuThreshold left, Azure.ResourceManager.Advisor.Models.CpuThreshold right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.CpuThreshold (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.CpuThreshold left, Azure.ResourceManager.Advisor.Models.CpuThreshold right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DigestConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.DigestConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.DigestConfig>
    {
        public DigestConfig() { }
        public string ActionGroupResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.RecommendationCategory> Categories { get { throw null; } }
        public int? Frequency { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.DigestConfigState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.DigestConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.DigestConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.DigestConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.DigestConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.DigestConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.DigestConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.DigestConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigestConfigState : System.IEquatable<Azure.ResourceManager.Advisor.Models.DigestConfigState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigestConfigState(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.DigestConfigState Active { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.DigestConfigState Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.DigestConfigState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.DigestConfigState left, Azure.ResourceManager.Advisor.Models.DigestConfigState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.DigestConfigState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.DigestConfigState left, Azure.ResourceManager.Advisor.Models.DigestConfigState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataSupportedValueDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>
    {
        internal MetadataSupportedValueDetail() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationBusinessImpact : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationBusinessImpact(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact High { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact Low { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact left, Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact left, Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationCategory : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationCategory(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationCategory Cost { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationCategory HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationCategory OperationalExcellence { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationCategory Performance { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationCategory Security { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationCategory left, Azure.ResourceManager.Advisor.Models.RecommendationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationCategory left, Azure.ResourceManager.Advisor.Models.RecommendationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationControlType : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationControlType(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType BusinessContinuity { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType MonitoringAndAlerting { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType Other { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType Personalized { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType PrioritizedRecommendations { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType Scalability { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationControlType ServiceUpgradeAndRetirement { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationControlType left, Azure.ResourceManager.Advisor.Models.RecommendationControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationControlType left, Azure.ResourceManager.Advisor.Models.RecommendationControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationPriority : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationPriority(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriority Critical { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriority High { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriority Informational { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriority Low { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriority Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationPriority left, Azure.ResourceManager.Advisor.Models.RecommendationPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationPriority left, Azure.ResourceManager.Advisor.Models.RecommendationPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationPriorityName : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationPriorityName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationPriorityName(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriorityName High { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriorityName Low { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationPriorityName Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationPriorityName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationPriorityName left, Azure.ResourceManager.Advisor.Models.RecommendationPriorityName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationPriorityName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationPriorityName left, Azure.ResourceManager.Advisor.Models.RecommendationPriorityName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendationRejectBody : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>
    {
        public RecommendationRejectBody() { }
        public Azure.ResourceManager.Advisor.Models.AdvisorReasonForRejectionName? ReasonForRejection { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationRejectBody System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationRejectBody System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationResourceWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>
    {
        public RecommendationResourceWorkload() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationReview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>
    {
        public RecommendationReview() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationReview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationReview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationState : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationState(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationState Approved { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationState Completed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationState Dismissed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationState Postponed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationState Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationState left, Azure.ResourceManager.Advisor.Models.RecommendationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationState left, Azure.ResourceManager.Advisor.Models.RecommendationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationStateChangeReason : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationStateChangeReason(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason AlternativeSolution { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason ExcessiveInvestment { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason Incompatible { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason RiskAccepted { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason TooComplex { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason Unclear { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason left, Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason left, Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationStatusName : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationStatusName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationStatusName(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStatusName Approved { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStatusName Pending { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationStatusName Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationStatusName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationStatusName left, Azure.ResourceManager.Advisor.Models.RecommendationStatusName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationStatusName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationStatusName left, Azure.ResourceManager.Advisor.Models.RecommendationStatusName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResiliencyReviewStatus : System.IEquatable<Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResiliencyReviewStatus(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus New { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus Triaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus left, Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus left, Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceMetadata>
    {
        public ResourceMetadata() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Action { get { throw null; } }
        public string Plural { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Singular { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceRecommendationBasePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch>
    {
        public ResourceRecommendationBasePatch() { }
        public Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties TrackedProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ResourceRecommendationBasePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Risk : System.IEquatable<Azure.ResourceManager.Advisor.Models.Risk>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Risk(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Risk Error { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Risk None { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Risk Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Risk other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Risk left, Azure.ResourceManager.Advisor.Models.Risk right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Risk (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Risk left, Azure.ResourceManager.Advisor.Models.Risk right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Scenario : System.IEquatable<Azure.ResourceManager.Advisor.Models.Scenario>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Scenario(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Scenario Alerts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Scenario other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Scenario left, Azure.ResourceManager.Advisor.Models.Scenario right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Scenario (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Scenario left, Azure.ResourceManager.Advisor.Models.Scenario right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScoreAggregationLevel : System.IEquatable<Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScoreAggregationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel Day { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel Month { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel left, Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel left, Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShortDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ShortDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ShortDescription>
    {
        public ShortDescription() { }
        public string Problem { get { throw null; } set { } }
        public string Solution { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ShortDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ShortDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ShortDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ShortDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ShortDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ShortDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ShortDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrackedRecommendationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>
    {
        public TrackedRecommendationProperties() { }
        public System.DateTimeOffset? PostponedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationPriority? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason? Reason { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriageRecommendation : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TriageRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageRecommendation>
    {
        internal TriageRecommendation() { }
        public System.Collections.Generic.IReadOnlyList<string> AppliesToSubscriptions { get { throw null; } }
        public string Description { get { throw null; } }
        public string Notes { get { throw null; } }
        public string PotentialBenefits { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationPriorityName? Priority { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationStatusName? RecommendationStatus { get { throw null; } }
        public string RejectReason { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public string Title { get { throw null; } }
        public string UpdatedAt { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TriageRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TriageRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TriageRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TriageRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
