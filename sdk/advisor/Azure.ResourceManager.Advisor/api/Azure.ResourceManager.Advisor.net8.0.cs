namespace Azure.ResourceManager.Advisor
{
    public static partial class AdvisorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData> CreateConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData> CreateConfiguration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData>> CreateConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData>> CreateConfigurationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GenerateRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GenerateRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityCollection GetAdvisorScoreEntities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAdvisorScoreEntity(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAdvisorScoreEntityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityResource GetAdvisorScoreEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource> GetAssessmentResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource>> GetAssessmentResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AssessmentResultResource GetAssessmentResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AssessmentResultCollection GetAssessmentResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult> GetAssessmentTypesOperationGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult> GetAssessmentTypesOperationGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurationsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetGenerateStatusRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetGenerateStatusRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.MetadataEntityCollection GetMetadataEntities(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource> GetMetadataEntity(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource>> GetMetadataEntityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.MetadataEntityResource GetMetadataEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.OperationEntity> GetOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.OperationEntity> GetOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource> GetResiliencyReview(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource>> GetResiliencyReviewAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.ResiliencyReviewResource GetResiliencyReviewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.ResiliencyReviewCollection GetResiliencyReviews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetResourceRecommendationBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetResourceRecommendationBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource GetResourceRecommendationBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseCollection GetResourceRecommendationBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Advisor.SuppressionContractResource GetSuppressionContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContracts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContractsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.WorkloadResult> GetWorkloadsOperationGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.WorkloadResult> GetWorkloadsOperationGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.PredictionResult> PredictAdvisorClient(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.PredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.PredictionResult>> PredictAdvisorClientAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.PredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Advisor.Models.ScoreEntity LastRefreshedScore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity> TimeSeries { get { throw null; } }
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
    public partial class AssessmentResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AssessmentResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AssessmentResultResource>, System.Collections.IEnumerable
    {
        protected AssessmentResultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AssessmentResultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Advisor.AssessmentResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AssessmentResultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Advisor.AssessmentResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AssessmentResultResource> GetAll(string top = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AssessmentResultResource> GetAllAsync(string top = null, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AssessmentResultResource> GetIfExists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AssessmentResultResource>> GetIfExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AssessmentResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AssessmentResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AssessmentResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AssessmentResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessmentResultData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AssessmentResultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>
    {
        public AssessmentResultData() { }
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
        Azure.ResourceManager.Advisor.AssessmentResultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AssessmentResultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssessmentResultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AssessmentResultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessmentResultResource() { }
        public virtual Azure.ResourceManager.Advisor.AssessmentResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AssessmentResultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AssessmentResultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AssessmentResultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AssessmentResultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.AssessmentResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AssessmentResultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.AssessmentResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResiliencyReviewCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.ResiliencyReviewResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.ResiliencyReviewResource>, System.Collections.IEnumerable
    {
        protected ResiliencyReviewCollection() { }
        public virtual Azure.Response<bool> Exists(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource> Get(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.ResiliencyReviewResource> GetAll(int? top = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.ResiliencyReviewResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource>> GetAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.ResiliencyReviewResource> GetIfExists(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.ResiliencyReviewResource>> GetIfExistsAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.ResiliencyReviewResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.ResiliencyReviewResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.ResiliencyReviewResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.ResiliencyReviewResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResiliencyReviewData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>
    {
        internal ResiliencyReviewData() { }
        public string PublishedAt { get { throw null; } }
        public int? RecommendationsCount { get { throw null; } }
        public string ReviewName { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ReviewStatus? ReviewStatus { get { throw null; } }
        public string UpdatedAt { get { throw null; } }
        public string WorkloadName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.ResiliencyReviewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.ResiliencyReviewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResiliencyReviewResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResiliencyReviewResource() { }
        public virtual Azure.ResourceManager.Advisor.ResiliencyReviewData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response ApproveTriageRecommendationTriageRecommendation(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApproveTriageRecommendationTriageRecommendationAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string reviewId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.TriageRecommendation> GetTriageRecommendation(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.TriageRecommendation>> GetTriageRecommendationAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.TriageRecommendation> GetTriageRecommendations(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.TriageRecommendation> GetTriageRecommendationsAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.TriageResource> GetTriageResource(string recommendationId, string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.TriageResource>> GetTriageResourceAsync(string recommendationId, string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.TriageResource> GetTriageResources(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.TriageResource> GetTriageResourcesAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectTriageRecommendationTriageRecommendation(string recommendationId, Azure.ResourceManager.Advisor.Models.RecommendationRejectBody recommendationRejectBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectTriageRecommendationTriageRecommendationAsync(string recommendationId, Azure.ResourceManager.Advisor.Models.RecommendationRejectBody recommendationRejectBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetTriageRecommendationTriageRecommendation(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetTriageRecommendationTriageRecommendationAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.ResiliencyReviewData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.ResiliencyReviewData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.ResiliencyReviewData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Advisor.Models.Category? Category { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.Control? Control { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExposedMetadataProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.Impact? Impact { get { throw null; } set { } }
        public string ImpactedField { get { throw null; } set { } }
        public string ImpactedValue { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } set { } }
        public string LearnMoreLink { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Metadata { get { throw null; } }
        public string Notes { get { throw null; } set { } }
        public string PotentialBenefits { get { throw null; } set { } }
        public string RecommendationTypeId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Remediation { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ResourceMetadata ResourceMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload ResourceWorkload { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview Review { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.Risk? Risk { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.ShortDescription ShortDescription { get { throw null; } set { } }
        public string SourceSystem { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Guid> SuppressionIds { get { throw null; } }
        public bool? Tracked { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.Advisor.AdvisorScoreEntityResource GetAdvisorScoreEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AssessmentResultResource GetAssessmentResultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.MetadataEntityResource GetMetadataEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.ResiliencyReviewResource GetResiliencyReviewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetResourceRecommendationBase(Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetResourceRecommendationBaseAsync(Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource GetResourceRecommendationBaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.ResourceRecommendationBaseCollection GetResourceRecommendationBases(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Advisor.SuppressionContractResource GetSuppressionContractResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAdvisorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData> CreateConfiguration(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData>> CreateConfigurationAsync(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAdvisorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData> CreateConfiguration(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.ConfigData>> CreateConfigurationAsync(Azure.ResourceManager.Advisor.Models.ConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.ConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorScoreEntityCollection GetAdvisorScoreEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAdvisorScoreEntity(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAdvisorScoreEntityAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource> GetAssessmentResult(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AssessmentResultResource>> GetAssessmentResultAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AssessmentResultCollection GetAssessmentResults() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult> GetAssessmentTypesOperationGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult> GetAssessmentTypesOperationGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetGenerateStatusRecommendation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGenerateStatusRecommendationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource> GetResiliencyReview(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResiliencyReviewResource>> GetResiliencyReviewAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.ResiliencyReviewCollection GetResiliencyReviews() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContracts(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContractsAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.WorkloadResult> GetWorkloadsOperationGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.WorkloadResult> GetWorkloadsOperationGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.PredictionResult> PredictAdvisorClient(Azure.ResourceManager.Advisor.Models.PredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.PredictionResult>> PredictAdvisorClientAsync(Azure.ResourceManager.Advisor.Models.PredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAdvisorTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorTenantResource() { }
        public virtual Azure.ResourceManager.Advisor.MetadataEntityCollection GetMetadataEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource> GetMetadataEntity(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.MetadataEntityResource>> GetMetadataEntityAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.OperationEntity> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.OperationEntity> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Advisor.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Aggregated : System.IEquatable<Azure.ResourceManager.Advisor.Models.Aggregated>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Aggregated(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Aggregated Day { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Aggregated Month { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Aggregated Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Aggregated other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Aggregated left, Azure.ResourceManager.Advisor.Models.Aggregated right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Aggregated (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Aggregated left, Azure.ResourceManager.Advisor.Models.Aggregated right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmAdvisorModelFactory
    {
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityData AdvisorScoreEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Advisor.Models.ScoreEntity lastRefreshedScore = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity> timeSeries = null) { throw null; }
        public static Azure.ResourceManager.Advisor.AssessmentResultData AssessmentResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string workloadId = null, string workloadName = null, string assessmentId = null, string description = null, string typeId = null, int? score = default(int?), string state = null, string typeVersion = null, string locale = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AssessmentTypeResult AssessmentTypeResult(string id = null, string title = null, string description = null, string locale = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.ConfigData ConfigData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? exclude = default(bool?), Azure.ResourceManager.Advisor.Models.CpuThreshold? lowCpuThreshold = default(Azure.ResourceManager.Advisor.Models.CpuThreshold?), Azure.ResourceManager.Advisor.Models.Duration? duration = default(Azure.ResourceManager.Advisor.Models.Duration?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.DigestConfig> digests = null) { throw null; }
        public static Azure.ResourceManager.Advisor.MetadataEntityData MetadataEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.Scenario> applicableScenarios = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail> supportedValues = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail MetadataSupportedValueDetail(string id = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.OperationDisplayInfo OperationDisplayInfo(string description = null, string operation = null, string provider = null, string resource = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.OperationEntity OperationEntity(string name = null, Azure.ResourceManager.Advisor.Models.OperationDisplayInfo display = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.PredictionResult PredictionResult(System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> extendedProperties = null, Azure.ResourceManager.Advisor.Models.PredictionType? predictionType = default(Azure.ResourceManager.Advisor.Models.PredictionType?), Azure.ResourceManager.Advisor.Models.Category? category = default(Azure.ResourceManager.Advisor.Models.Category?), Azure.ResourceManager.Advisor.Models.Impact? impact = default(Azure.ResourceManager.Advisor.Models.Impact?), string impactedField = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), Azure.ResourceManager.Advisor.Models.ShortDescription shortDescription = null) { throw null; }
        public static Azure.ResourceManager.Advisor.ResiliencyReviewData ResiliencyReviewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewName = null, string workloadName = null, Azure.ResourceManager.Advisor.Models.ReviewStatus? reviewStatus = default(Azure.ResourceManager.Advisor.Models.ReviewStatus?), int? recommendationsCount = default(int?), string publishedAt = null, string updatedAt = null) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseData ResourceRecommendationBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Advisor.Models.Category? category = default(Azure.ResourceManager.Advisor.Models.Category?), Azure.ResourceManager.Advisor.Models.Control? control = default(Azure.ResourceManager.Advisor.Models.Control?), Azure.ResourceManager.Advisor.Models.Impact? impact = default(Azure.ResourceManager.Advisor.Models.Impact?), string impactedField = null, string impactedValue = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, System.BinaryData> metadata = null, string recommendationTypeId = null, Azure.ResourceManager.Advisor.Models.Risk? risk = default(Azure.ResourceManager.Advisor.Models.Risk?), Azure.ResourceManager.Advisor.Models.ShortDescription shortDescription = null, System.Collections.Generic.IEnumerable<System.Guid> suppressionIds = null, System.Collections.Generic.IDictionary<string, string> extendedProperties = null, Azure.ResourceManager.Advisor.Models.ResourceMetadata resourceMetadata = null, string description = null, string label = null, string learnMoreLink = null, string potentialBenefits = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> actions = null, System.Collections.Generic.IDictionary<string, System.BinaryData> remediation = null, System.Collections.Generic.IDictionary<string, System.BinaryData> exposedMetadataProperties = null, bool? tracked = default(bool?), Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties trackedProperties = null, Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview review = null, Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload resourceWorkload = null, string sourceSystem = null, string notes = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.ScoreEntity ScoreEntity(string date = null, float? score = default(float?), float? consumptionUnits = default(float?), float? impactedResourceCount = default(float?), float? potentialScoreIncrease = default(float?), float? categoryCount = default(float?)) { throw null; }
        public static Azure.ResourceManager.Advisor.SuppressionContractData SuppressionContractData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string suppressionId = null, string ttl = null, System.DateTimeOffset? expirationTimeStamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.TimeSeriesEntity TimeSeriesEntity(Azure.ResourceManager.Advisor.Models.Aggregated? aggregationLevel = default(Azure.ResourceManager.Advisor.Models.Aggregated?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.ScoreEntity> scoreHistory = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.TriageRecommendation TriageRecommendation(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewId = null, string title = null, Azure.ResourceManager.Advisor.Models.PriorityName? priority = default(Azure.ResourceManager.Advisor.Models.PriorityName?), System.Collections.Generic.IEnumerable<string> appliesToSubscriptions = null, Azure.ResourceManager.Advisor.Models.RecommendationStatusName? recommendationStatus = default(Azure.ResourceManager.Advisor.Models.RecommendationStatusName?), string updatedAt = null, string rejectReason = null, string potentialBenefits = null, string description = null, string notes = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.TriageResource TriageResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewId = null, string recommendationId = null, string subscriptionId = null, string resourceGroup = null, Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.WorkloadResult WorkloadResult(string id = null, string name = null, string subscriptionId = null, string subscriptionName = null) { throw null; }
    }
    public partial class AssessmentTypeResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult>
    {
        internal AssessmentTypeResult() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Locale { get { throw null; } }
        public string Title { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AssessmentTypeResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AssessmentTypeResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AssessmentTypeResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Category : System.IEquatable<Azure.ResourceManager.Advisor.Models.Category>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Category(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Category Cost { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Category HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Category OperationalExcellence { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Category Performance { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Category Security { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Category other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Category left, Azure.ResourceManager.Advisor.Models.Category right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Category (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Category left, Azure.ResourceManager.Advisor.Models.Category right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfigData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ConfigData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ConfigData>
    {
        public ConfigData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.DigestConfig> Digests { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.Duration? Duration { get { throw null; } set { } }
        public bool? Exclude { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.CpuThreshold? LowCpuThreshold { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ConfigData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ConfigData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ConfigData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ConfigData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ConfigData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ConfigData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ConfigData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct Control : System.IEquatable<Azure.ResourceManager.Advisor.Models.Control>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Control(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Control BusinessContinuity { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control HighAvailability { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control MonitoringAndAlerting { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control Other { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control Personalized { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control PrioritizedRecommendations { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control Scalability { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Control ServiceUpgradeAndRetirement { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Control other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Control left, Azure.ResourceManager.Advisor.Models.Control right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Control (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Control left, Azure.ResourceManager.Advisor.Models.Control right) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.Category> Categories { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Duration : System.IEquatable<Azure.ResourceManager.Advisor.Models.Duration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Duration(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Duration _14 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Duration _21 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Duration _30 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Duration _60 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Duration _7 { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Duration _90 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Duration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Duration left, Azure.ResourceManager.Advisor.Models.Duration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Duration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Duration left, Azure.ResourceManager.Advisor.Models.Duration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Impact : System.IEquatable<Azure.ResourceManager.Advisor.Models.Impact>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Impact(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Impact High { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Impact Low { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Impact Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Impact other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Impact left, Azure.ResourceManager.Advisor.Models.Impact right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Impact (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Impact left, Azure.ResourceManager.Advisor.Models.Impact right) { throw null; }
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
    public partial class OperationDisplayInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.OperationDisplayInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationDisplayInfo>
    {
        internal OperationDisplayInfo() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.OperationDisplayInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.OperationDisplayInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.OperationDisplayInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.OperationDisplayInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationDisplayInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationDisplayInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationDisplayInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.OperationEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationEntity>
    {
        internal OperationEntity() { }
        public Azure.ResourceManager.Advisor.Models.OperationDisplayInfo Display { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.OperationEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.OperationEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.OperationEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.OperationEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.OperationEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.PredictionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionContent>
    {
        public PredictionContent() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.PredictionType? PredictionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.PredictionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.PredictionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.PredictionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.PredictionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.PredictionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionResult>
    {
        internal PredictionResult() { }
        public Azure.ResourceManager.Advisor.Models.Category? Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.Impact? Impact { get { throw null; } }
        public string ImpactedField { get { throw null; } }
        public System.DateTimeOffset? LastUpdated { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.PredictionType? PredictionType { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ShortDescription ShortDescription { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.PredictionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.PredictionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.PredictionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.PredictionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.PredictionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PredictionType : System.IEquatable<Azure.ResourceManager.Advisor.Models.PredictionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PredictionType(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.PredictionType PredictiveRightsizing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.PredictionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.PredictionType left, Azure.ResourceManager.Advisor.Models.PredictionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.PredictionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.PredictionType left, Azure.ResourceManager.Advisor.Models.PredictionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Priority : System.IEquatable<Azure.ResourceManager.Advisor.Models.Priority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Priority(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Priority Critical { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Priority High { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Priority Informational { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Priority Low { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Priority Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Priority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Priority left, Azure.ResourceManager.Advisor.Models.Priority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Priority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Priority left, Azure.ResourceManager.Advisor.Models.Priority right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PriorityName : System.IEquatable<Azure.ResourceManager.Advisor.Models.PriorityName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PriorityName(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.PriorityName High { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.PriorityName Low { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.PriorityName Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.PriorityName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.PriorityName left, Azure.ResourceManager.Advisor.Models.PriorityName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.PriorityName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.PriorityName left, Azure.ResourceManager.Advisor.Models.PriorityName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.Advisor.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.Reason AlternativeSolution { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Reason ExcessiveInvestment { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Reason Incompatible { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Reason RiskAccepted { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Reason TooComplex { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.Reason Unclear { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.Reason left, Azure.ResourceManager.Advisor.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.Reason left, Azure.ResourceManager.Advisor.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonForRejectionName : System.IEquatable<Azure.ResourceManager.Advisor.Models.ReasonForRejectionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonForRejectionName(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.ReasonForRejectionName NotARisk { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ReasonForRejectionName RiskAccepted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.ReasonForRejectionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.ReasonForRejectionName left, Azure.ResourceManager.Advisor.Models.ReasonForRejectionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ReasonForRejectionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.ReasonForRejectionName left, Azure.ResourceManager.Advisor.Models.ReasonForRejectionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendationPropertiesResourceWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload>
    {
        public RecommendationPropertiesResourceWorkload() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesResourceWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationPropertiesReview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview>
    {
        public RecommendationPropertiesReview() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationPropertiesReview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationRejectBody : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>
    {
        public RecommendationRejectBody() { }
        public Azure.ResourceManager.Advisor.Models.ReasonForRejectionName? ReasonForRejection { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationRejectBody System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationRejectBody System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct ReviewStatus : System.IEquatable<Azure.ResourceManager.Advisor.Models.ReviewStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReviewStatus(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.ReviewStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ReviewStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ReviewStatus New { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.ReviewStatus Triaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.ReviewStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.ReviewStatus left, Azure.ResourceManager.Advisor.Models.ReviewStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ReviewStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.ReviewStatus left, Azure.ResourceManager.Advisor.Models.ReviewStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ScoreEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ScoreEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ScoreEntity>
    {
        internal ScoreEntity() { }
        public float? CategoryCount { get { throw null; } }
        public float? ConsumptionUnits { get { throw null; } }
        public string Date { get { throw null; } }
        public float? ImpactedResourceCount { get { throw null; } }
        public float? PotentialScoreIncrease { get { throw null; } }
        public float? Score { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ScoreEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ScoreEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.ScoreEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.ScoreEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ScoreEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ScoreEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.ScoreEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.Advisor.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.State Approved { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.State Completed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.State Dismissed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.State InProgress { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.State Pending { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.State Postponed { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.State Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.State left, Azure.ResourceManager.Advisor.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.State left, Azure.ResourceManager.Advisor.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeSeriesEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity>
    {
        internal TimeSeriesEntity() { }
        public Azure.ResourceManager.Advisor.Models.Aggregated? AggregationLevel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Advisor.Models.ScoreEntity> ScoreHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TimeSeriesEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TimeSeriesEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TimeSeriesEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrackedRecommendationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>
    {
        public TrackedRecommendationProperties() { }
        public System.DateTimeOffset? PostponedOn { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.Priority? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.Reason? Reason { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.State? State { get { throw null; } set { } }
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
        public Azure.ResourceManager.Advisor.Models.PriorityName? Priority { get { throw null; } }
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
    public partial class TriageResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TriageResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageResource>
    {
        internal TriageResource() { }
        public string RecommendationId { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TriageResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TriageResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TriageResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TriageResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TriageResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.WorkloadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.WorkloadResult>
    {
        internal WorkloadResult() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.WorkloadResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.WorkloadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.WorkloadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.WorkloadResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.WorkloadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.WorkloadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.WorkloadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
