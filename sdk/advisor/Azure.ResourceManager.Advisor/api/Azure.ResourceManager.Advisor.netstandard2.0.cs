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
        public string Type { get { throw null; } }
        public string TypeId { get { throw null; } set { } }
        public string TypeVersion { get { throw null; } }
        public string WorkloadId { get { throw null; } set { } }
        public string WorkloadName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> CreateAdvisorConfigurationInResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>> CreateAdvisorConfigurationInResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> CreateAdvisorConfigurationInSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>> CreateAdvisorConfigurationInSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GenerateRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GenerateRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> GetAdvisorAssessment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> GetAdvisorAssessmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorAssessmentResource GetAdvisorAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorAssessmentCollection GetAdvisorAssessments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorMetadataEntityCollection GetAdvisorMetadataEntities(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> GetAdvisorMetadataEntity(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>> GetAdvisorMetadataEntityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource GetAdvisorMetadataEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> GetAdvisorRecommendation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>> GetAdvisorRecommendationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorRecommendationResource GetAdvisorRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorRecommendationCollection GetAdvisorRecommendations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> GetAdvisorResiliencyReview(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetAdvisorResiliencyReviewAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource GetAdvisorResiliencyReviewResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorResiliencyReviewCollection GetAdvisorResiliencyReviews(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityCollection GetAdvisorScoreEntities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAdvisorScoreEntity(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAdvisorScoreEntityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityResource GetAdvisorScoreEntityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetAdvisorSuppressionContract(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> GetAdvisorSuppressionContractAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource GetAdvisorSuppressionContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorSuppressionContractCollection GetAdvisorSuppressionContracts(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetAdvisorSuppressionContracts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetAdvisorSuppressionContractsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource GetAdvisorTriageRecommendationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorTriageResource GetAdvisorTriageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloads(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloadsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetGenerateStatusRecommendation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetGenerateStatusRecommendationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdvisorMetadataEntityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>, System.Collections.IEnumerable
    {
        protected AdvisorMetadataEntityCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorMetadataEntityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>
    {
        internal AdvisorMetadataEntityData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.MetadataScenarioType> ApplicableScenarios { get { throw null; } }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail> SupportedValues { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorMetadataEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorMetadataEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorMetadataEntityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorMetadataEntityResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorMetadataEntityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorMetadataEntityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorMetadataEntityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorMetadataEntityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorRecommendationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>, System.Collections.IEnumerable
    {
        protected AdvisorRecommendationCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> Get(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> GetAll(string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> GetAllAsync(string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>> GetAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> GetIfExists(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>> GetIfExistsAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorRecommendationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>
    {
        internal AdvisorRecommendationData() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Actions { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationCategory? Category { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationControlType? Control { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExposedMetadataProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? Impact { get { throw null; } }
        public string ImpactedField { get { throw null; } }
        public string ImpactedValue { get { throw null; } }
        public bool? IsTracked { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string LearnMoreLink { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Metadata { get { throw null; } }
        public string Notes { get { throw null; } }
        public string PotentialBenefits { get { throw null; } }
        public string RecommendationTypeId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Remediation { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata ResourceMetadata { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload ResourceWorkload { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationReview Review { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationRisk? Risk { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationShortDescription ShortDescription { get { throw null; } }
        public string SourceSystem { get { throw null; } }
        public System.Collections.Generic.IList<System.Guid> SuppressionIds { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties TrackedProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorRecommendationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorRecommendationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorRecommendationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorRecommendationResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorRecommendationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string recommendationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetAdvisorSuppressionContract(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> GetAdvisorSuppressionContractAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorSuppressionContractCollection GetAdvisorSuppressionContracts() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorRecommendationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorRecommendationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorRecommendationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> Update(Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>> UpdateAsync(Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? PublishedOn { get { throw null; } }
        public int? RecommendationsCount { get { throw null; } }
        public string ReviewName { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus? ReviewStatus { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        public string WorkloadName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string reviewId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> GetAdvisorTriageRecommendation(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>> GetAdvisorTriageRecommendationAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorTriageRecommendationCollection GetAdvisorTriageRecommendations() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity> TimeSeries { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AdvisorSuppressionContractCollection : Azure.ResourceManager.ArmCollection
    {
        protected AdvisorSuppressionContractCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Advisor.AdvisorSuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Advisor.AdvisorSuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdvisorSuppressionContractData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>
    {
        public AdvisorSuppressionContractData() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string SuppressionId { get { throw null; } set { } }
        public string Ttl { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorSuppressionContractData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorSuppressionContractData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorSuppressionContractResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorSuppressionContractResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorSuppressionContractData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string recommendationId, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorSuppressionContractData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorSuppressionContractData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorSuppressionContractData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.AdvisorSuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Advisor.AdvisorSuppressionContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdvisorTriageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageResource>, System.Collections.IEnumerable
    {
        protected AdvisorTriageCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageResource> Get(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorTriageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorTriageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageResource>> GetAsync(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorTriageResource> GetIfExists(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorTriageResource>> GetIfExistsAsync(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AdvisorTriageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AdvisorTriageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorTriageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>
    {
        internal AdvisorTriageData() { }
        public string RecommendationId { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TriageResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorTriageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorTriageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorTriageRecommendationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>, System.Collections.IEnumerable
    {
        protected AdvisorTriageRecommendationCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> Get(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> GetAll(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> GetAllAsync(int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>> GetAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> GetIfExists(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>> GetIfExistsAsync(string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvisorTriageRecommendationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>
    {
        internal AdvisorTriageRecommendationData() { }
        public System.Collections.Generic.IReadOnlyList<string> AppliesToSubscriptions { get { throw null; } }
        public string Description { get { throw null; } }
        public string Notes { get { throw null; } }
        public string PotentialBenefits { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationPriorityName? Priority { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationStatusName? RecommendationStatus { get { throw null; } }
        public string RejectReason { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public string Title { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorTriageRecommendationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorTriageRecommendationResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response ApproveTriageRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApproveTriageRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string reviewId, string recommendationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageResource> GetAdvisorTriage(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageResource>> GetAdvisorTriageAsync(string recommendationResourceId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorTriageCollection GetAdvisorTriages() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RejectTriageRecommendation(Azure.ResourceManager.Advisor.Models.RecommendationRejectContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RejectTriageRecommendationAsync(Azure.ResourceManager.Advisor.Models.RecommendationRejectContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetTriageRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetTriageRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorTriageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvisorTriageResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorTriageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string reviewId, string recommendationId, string recommendationResourceId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorTriageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Advisor.AdvisorTriageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.AdvisorTriageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.AdvisorTriageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerAdvisorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAdvisorContext() { }
        public static Azure.ResourceManager.Advisor.AzureResourceManagerAdvisorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.Advisor.Mocking
{
    public partial class MockableAdvisorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorArmClient() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorAssessmentResource GetAdvisorAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource GetAdvisorMetadataEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource> GetAdvisorRecommendation(Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorRecommendationResource>> GetAdvisorRecommendationAsync(Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorRecommendationResource GetAdvisorRecommendationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorRecommendationCollection GetAdvisorRecommendations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource GetAdvisorResiliencyReviewResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorScoreEntityResource GetAdvisorScoreEntityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetAdvisorSuppressionContract(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource>> GetAdvisorSuppressionContractAsync(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource GetAdvisorSuppressionContractResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorSuppressionContractCollection GetAdvisorSuppressionContracts(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorTriageRecommendationResource GetAdvisorTriageRecommendationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorTriageResource GetAdvisorTriageResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAdvisorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> CreateAdvisorConfigurationInResourceGroup(Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>> CreateAdvisorConfigurationInResourceGroupAsync(Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsByResourceGroup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsByResourceGroupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAdvisorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult> AdvisorPredict(Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult>> AdvisorPredictAsync(Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> CreateAdvisorConfigurationInSubscription(Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>> CreateAdvisorConfigurationInSubscriptionAsync(Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName configurationName, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateRecommendation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateRecommendationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource> GetAdvisorAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorAssessmentResource>> GetAdvisorAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorAssessmentCollection GetAdvisorAssessments() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType> GetAdvisorAssessmentTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsBySubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData> GetAdvisorConfigurationsBySubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource> GetAdvisorResiliencyReview(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorResiliencyReviewResource>> GetAdvisorResiliencyReviewAsync(string reviewId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorResiliencyReviewCollection GetAdvisorResiliencyReviews() { throw null; }
        public virtual Azure.ResourceManager.Advisor.AdvisorScoreEntityCollection GetAdvisorScoreEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource> GetAdvisorScoreEntity(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorScoreEntityResource>> GetAdvisorScoreEntityAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetAdvisorSuppressionContracts(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.AdvisorSuppressionContractResource> GetAdvisorSuppressionContractsAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloads(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.AdvisorWorkload> GetAdvisorWorkloadsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetGenerateStatusRecommendation(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetGenerateStatusRecommendationAsync(System.Guid operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAdvisorTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAdvisorTenantResource() { }
        public virtual Azure.ResourceManager.Advisor.AdvisorMetadataEntityCollection GetAdvisorMetadataEntities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource> GetAdvisorMetadataEntity(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.AdvisorMetadataEntityResource>> GetAdvisorMetadataEntityAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>
    {
        public AdvisorConfigurationData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration> Digests { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration? Duration { get { throw null; } set { } }
        public bool? IsExcluded { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold? LowCpuThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvisorConfigurationName : System.IEquatable<Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvisorConfigurationName(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName left, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName left, Azure.ResourceManager.Advisor.Models.AdvisorConfigurationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvisorCpuThreshold : System.IEquatable<Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvisorCpuThreshold(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold Fifteen { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold Five { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold Ten { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold Twenty { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold left, Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold left, Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvisorDigestConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration>
    {
        public AdvisorDigestConfiguration() { }
        public string ActionGroupResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.RecommendationCategory> Categories { get { throw null; } }
        public int? Frequency { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvisorDigestConfigurationState : System.IEquatable<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvisorDigestConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState Active { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState left, Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState left, Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration left, Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration left, Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvisorPredictionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent>
    {
        public AdvisorPredictionContent() { }
        public System.BinaryData ExtendedProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.AdvisorPredictionType? PredictionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorPredictionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.BinaryData ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? Impact { get { throw null; } }
        public string ImpactedField { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.AdvisorPredictionType? PredictionType { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.RecommendationShortDescription ShortDescription { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.AdvisorPredictionType left, Azure.ResourceManager.Advisor.Models.AdvisorPredictionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorPredictionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.AdvisorPredictionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.AdvisorPredictionType left, Azure.ResourceManager.Advisor.Models.AdvisorPredictionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvisorRecommendationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch>
    {
        public AdvisorRecommendationPatch() { }
        public Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties AdvisorRecommendationPatchTrackedProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorRecommendationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent> ScoreHistory { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvisorWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>
    {
        internal AdvisorWorkload() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.AdvisorWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.AdvisorWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.AdvisorWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.AdvisorWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAdvisorModelFactory
    {
        public static Azure.ResourceManager.Advisor.AdvisorAssessmentData AdvisorAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string workloadId = null, string workloadName = null, string assessmentId = null, string description = null, string typeId = null, string type = null, int? score = default(int?), string state = null, string typeVersion = null, string locale = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorAssessmentType AdvisorAssessmentType(string id = null, string title = null, string description = null, string locale = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorConfigurationData AdvisorConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isExcluded = default(bool?), Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold? lowCpuThreshold = default(Azure.ResourceManager.Advisor.Models.AdvisorCpuThreshold?), Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration? duration = default(Azure.ResourceManager.Advisor.Models.AdvisorLowCpuEvaluationDuration?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration> digests = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorDigestConfiguration AdvisorDigestConfiguration(string name = null, string actionGroupResourceId = null, int? frequency = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.RecommendationCategory> categories = null, string language = null, Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState? state = default(Azure.ResourceManager.Advisor.Models.AdvisorDigestConfigurationState?)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorMetadataEntityData AdvisorMetadataEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.MetadataScenarioType> applicableScenarios = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail> supportedValues = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorPredictionResult AdvisorPredictionResult(System.BinaryData extendedProperties = null, Azure.ResourceManager.Advisor.Models.AdvisorPredictionType? predictionType = default(Azure.ResourceManager.Advisor.Models.AdvisorPredictionType?), Azure.ResourceManager.Advisor.Models.RecommendationCategory? category = default(Azure.ResourceManager.Advisor.Models.RecommendationCategory?), Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? impact = default(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact?), string impactedField = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.Advisor.Models.RecommendationShortDescription shortDescription = null) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorRecommendationData AdvisorRecommendationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Advisor.Models.RecommendationCategory? category = default(Azure.ResourceManager.Advisor.Models.RecommendationCategory?), Azure.ResourceManager.Advisor.Models.RecommendationControlType? control = default(Azure.ResourceManager.Advisor.Models.RecommendationControlType?), Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? impact = default(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact?), string impactedField = null, string impactedValue = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, System.BinaryData> metadata = null, string recommendationTypeId = null, Azure.ResourceManager.Advisor.Models.RecommendationRisk? risk = default(Azure.ResourceManager.Advisor.Models.RecommendationRisk?), Azure.ResourceManager.Advisor.Models.RecommendationShortDescription shortDescription = null, System.Collections.Generic.IEnumerable<System.Guid> suppressionIds = null, System.Collections.Generic.IDictionary<string, string> extendedProperties = null, Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata resourceMetadata = null, string description = null, string label = null, string learnMoreLink = null, string potentialBenefits = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> actions = null, System.Collections.Generic.IDictionary<string, System.BinaryData> remediation = null, System.Collections.Generic.IDictionary<string, System.BinaryData> exposedMetadataProperties = null, bool? isTracked = default(bool?), Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties trackedProperties = null, Azure.ResourceManager.Advisor.Models.RecommendationReview review = null, Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload resourceWorkload = null, string sourceSystem = null, string notes = null) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorResiliencyReviewData AdvisorResiliencyReviewData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewName = null, string workloadName = null, Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus? reviewStatus = default(Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus?), int? recommendationsCount = default(int?), System.DateTimeOffset? publishedOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent AdvisorScoreEntityContent(string date = null, float? score = default(float?), float? consumptionUnits = default(float?), float? impactedResourceCount = default(float?), float? potentialScoreIncrease = default(float?), float? categoryCount = default(float?)) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorScoreEntityData AdvisorScoreEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent lastRefreshedScore = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity> timeSeries = null) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorSuppressionContractData AdvisorSuppressionContractData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string suppressionId = null, string ttl = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorTimeSeriesEntity AdvisorTimeSeriesEntity(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel? aggregationLevel = default(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.AdvisorScoreEntityContent> scoreHistory = null) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorTriageData AdvisorTriageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewId = null, string recommendationId = null, string subscriptionId = null, string resourceGroup = null, string triageResourceType = null, Azure.Core.ResourceIdentifier resourceId = null, string resourceName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.AdvisorTriageRecommendationData AdvisorTriageRecommendationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string reviewId = null, string title = null, Azure.ResourceManager.Advisor.Models.RecommendationPriorityName? priority = default(Azure.ResourceManager.Advisor.Models.RecommendationPriorityName?), System.Collections.Generic.IEnumerable<string> appliesToSubscriptions = null, Azure.ResourceManager.Advisor.Models.RecommendationStatusName? recommendationStatus = default(Azure.ResourceManager.Advisor.Models.RecommendationStatusName?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?), string rejectReason = null, string potentialBenefits = null, string description = null, string notes = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.AdvisorWorkload AdvisorWorkload(string id = null, string name = null, string subscriptionId = null, string subscriptionName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail MetadataSupportedValueDetail(string id = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata RecommendationResourceMetadata(Azure.Core.ResourceIdentifier resourceId = null, string source = null, System.Collections.Generic.IDictionary<string, System.BinaryData> action = null, string singular = null, string plural = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload RecommendationResourceWorkload(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationReview RecommendationReview(string id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationShortDescription RecommendationShortDescription(string problem = null, string solution = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetadataScenarioType : System.IEquatable<Azure.ResourceManager.Advisor.Models.MetadataScenarioType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetadataScenarioType(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.MetadataScenarioType Alerts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.MetadataScenarioType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.MetadataScenarioType left, Azure.ResourceManager.Advisor.Models.MetadataScenarioType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.MetadataScenarioType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.MetadataScenarioType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.MetadataScenarioType left, Azure.ResourceManager.Advisor.Models.MetadataScenarioType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MetadataSupportedValueDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail>
    {
        internal MetadataSupportedValueDetail() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact left, Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationBusinessImpact? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationCategory left, Azure.ResourceManager.Advisor.Models.RecommendationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationCategory? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationControlType left, Azure.ResourceManager.Advisor.Models.RecommendationControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationControlType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationControlType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationPriority left, Azure.ResourceManager.Advisor.Models.RecommendationPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationPriority (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationPriority? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationPriorityName left, Azure.ResourceManager.Advisor.Models.RecommendationPriorityName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationPriorityName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationPriorityName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationPriorityName left, Azure.ResourceManager.Advisor.Models.RecommendationPriorityName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendationRejectContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectContent>
    {
        public RecommendationRejectContent() { }
        public Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason? ReasonForRejection { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationRejectContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationRejectContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.RecommendationRejectContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationRejectContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationRejectContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationResourceMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata>
    {
        internal RecommendationResourceMetadata() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Action { get { throw null; } }
        public string Plural { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string Singular { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationResourceWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>
    {
        internal RecommendationResourceWorkload() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationResourceWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendationReview : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>
    {
        internal RecommendationReview() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationReview JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationReview PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.RecommendationReview System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationReview System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationReview>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationRisk : System.IEquatable<Azure.ResourceManager.Advisor.Models.RecommendationRisk>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationRisk(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RecommendationRisk Error { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationRisk None { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RecommendationRisk Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RecommendationRisk other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationRisk left, Azure.ResourceManager.Advisor.Models.RecommendationRisk right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationRisk (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationRisk? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationRisk left, Azure.ResourceManager.Advisor.Models.RecommendationRisk right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendationShortDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationShortDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationShortDescription>
    {
        internal RecommendationShortDescription() { }
        public string Problem { get { throw null; } }
        public string Solution { get { throw null; } }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationShortDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.RecommendationShortDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.RecommendationShortDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationShortDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.RecommendationShortDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.RecommendationShortDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationShortDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationShortDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.RecommendationShortDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationState left, Azure.ResourceManager.Advisor.Models.RecommendationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationState? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason left, Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RecommendationStatusName left, Azure.ResourceManager.Advisor.Models.RecommendationStatusName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationStatusName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RecommendationStatusName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RecommendationStatusName left, Azure.ResourceManager.Advisor.Models.RecommendationStatusName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RejectingRecommendationReason : System.IEquatable<Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RejectingRecommendationReason(string value) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason NotARisk { get { throw null; } }
        public static Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason RiskAccepted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason left, Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason left, Azure.ResourceManager.Advisor.Models.RejectingRecommendationReason right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus left, Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus left, Azure.ResourceManager.Advisor.Models.ResiliencyReviewStatus right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel left, Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel left, Azure.ResourceManager.Advisor.Models.ScoreAggregationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackedRecommendationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>
    {
        public TrackedRecommendationProperties() { }
        public System.DateTimeOffset? PostponedUntil { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationPriority? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationStateChangeReason? Reason { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.RecommendationState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Advisor.Models.TrackedRecommendationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
