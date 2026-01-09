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
        public static Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource> GetResourceRecommendationBase(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource>> GetResourceRecommendationBaseAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string recommendationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseResource GetResourceRecommendationBaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseCollection GetResourceRecommendationBases(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Advisor.SuppressionContractResource GetSuppressionContractResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContracts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Advisor.SuppressionContractResource> GetSuppressionContractsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Advisor.Models.Category? Category { get { throw null; } set { } }
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
        public string PotentialBenefits { get { throw null; } set { } }
        public string RecommendationTypeId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Remediation { get { throw null; } }
        public Azure.ResourceManager.Advisor.Models.ResourceMetadata ResourceMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.Risk? Risk { get { throw null; } set { } }
        public Azure.ResourceManager.Advisor.Models.ShortDescription ShortDescription { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Guid> SuppressionIds { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Advisor.Models.ConfigData> GetConfigurationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ArmAdvisorModelFactory
    {
        public static Azure.ResourceManager.Advisor.Models.ConfigData ConfigData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? exclude = default(bool?), Azure.ResourceManager.Advisor.Models.CpuThreshold? lowCpuThreshold = default(Azure.ResourceManager.Advisor.Models.CpuThreshold?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.DigestConfig> digests = null) { throw null; }
        public static Azure.ResourceManager.Advisor.MetadataEntityData MetadataEntityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.Scenario> applicableScenarios = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail> supportedValues = null) { throw null; }
        public static Azure.ResourceManager.Advisor.Models.MetadataSupportedValueDetail MetadataSupportedValueDetail(string id = null, string displayName = null) { throw null; }
        public static Azure.ResourceManager.Advisor.ResourceRecommendationBaseData ResourceRecommendationBaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Advisor.Models.Category? category = default(Azure.ResourceManager.Advisor.Models.Category?), Azure.ResourceManager.Advisor.Models.Impact? impact = default(Azure.ResourceManager.Advisor.Models.Impact?), string impactedField = null, string impactedValue = null, System.DateTimeOffset? lastUpdated = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, System.BinaryData> metadata = null, string recommendationTypeId = null, Azure.ResourceManager.Advisor.Models.Risk? risk = default(Azure.ResourceManager.Advisor.Models.Risk?), Azure.ResourceManager.Advisor.Models.ShortDescription shortDescription = null, System.Collections.Generic.IEnumerable<System.Guid> suppressionIds = null, System.Collections.Generic.IDictionary<string, string> extendedProperties = null, Azure.ResourceManager.Advisor.Models.ResourceMetadata resourceMetadata = null, string description = null, string label = null, string learnMoreLink = null, string potentialBenefits = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> actions = null, System.Collections.Generic.IDictionary<string, System.BinaryData> remediation = null, System.Collections.Generic.IDictionary<string, System.BinaryData> exposedMetadataProperties = null) { throw null; }
        public static Azure.ResourceManager.Advisor.SuppressionContractData SuppressionContractData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string suppressionId = null, string ttl = null, System.DateTimeOffset? expirationTimeStamp = default(System.DateTimeOffset?)) { throw null; }
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
}
