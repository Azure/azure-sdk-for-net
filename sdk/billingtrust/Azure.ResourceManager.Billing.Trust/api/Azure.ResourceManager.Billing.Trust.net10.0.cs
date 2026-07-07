namespace Azure.ResourceManager.Billing.Trust
{
    public partial class AzureResourceManagerBillingTrustContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerBillingTrustContext() { }
        public static Azure.ResourceManager.Billing.Trust.AzureResourceManagerBillingTrustContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BillingTrustAssessmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>
    {
        public BillingTrustAssessmentData() { }
        public Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingTrustAssessmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingTrustAssessmentResource() { }
        public virtual Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> GetBillingTrustRule(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> GetBillingTrustRuleAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Billing.Trust.BillingTrustRuleCollection GetBillingTrustRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult> GetUploadToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>> GetUploadTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class BillingTrustExtensions
    {
        public static Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource GetBillingTrustAssessment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource GetBillingTrustAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> GetBillingTrustRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> GetBillingTrustRuleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource GetBillingTrustRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.BillingTrustRuleCollection GetBillingTrustRules(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class BillingTrustRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>, System.Collections.IEnumerable
    {
        protected BillingTrustRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Billing.Trust.BillingTrustRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Billing.Trust.BillingTrustRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> GetIfExists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> GetIfExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BillingTrustRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>
    {
        public BillingTrustRuleData() { }
        public Azure.ResourceManager.Billing.Trust.Models.RuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.BillingTrustRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.BillingTrustRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingTrustRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingTrustRuleResource() { }
        public virtual Azure.ResourceManager.Billing.Trust.BillingTrustRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string ruleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Billing.Trust.BillingTrustRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.BillingTrustRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.BillingTrustRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> Update(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> UpdateAsync(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Billing.Trust.Mocking
{
    public partial class MockableBillingTrustArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableBillingTrustArmClient() { }
        public virtual Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource GetBillingTrustAssessment(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource GetBillingTrustAssessmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource> GetBillingTrustRule(Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource>> GetBillingTrustRuleAsync(Azure.Core.ResourceIdentifier scope, string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Billing.Trust.BillingTrustRuleResource GetBillingTrustRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Billing.Trust.BillingTrustRuleCollection GetBillingTrustRules(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.Billing.Trust.Models
{
    public static partial class ArmBillingTrustModelFactory
    {
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties AssessmentProperties(Azure.ResourceManager.Billing.Trust.Models.AssessmentType assessmentType = default(Azure.ResourceManager.Billing.Trust.Models.AssessmentType), Azure.ResourceManager.Billing.Trust.Models.AssessmentState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.AssessmentState?), System.DateTimeOffset? nextEvaluation = default(System.DateTimeOffset?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase> initialValues = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData BillingTrustAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.BillingTrustRuleData BillingTrustRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Trust.Models.RuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch BillingTrustRulePatch(string kind = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties BusinessVerificationRulePatchProperties(Azure.ResourceManager.Billing.Trust.Models.ExternalId externalId = null, System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties BusinessVerificationRuleProperties(Azure.ResourceManager.Billing.Trust.Models.RuleState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.RuleState?), Azure.ResponseError error = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?), Azure.ResourceManager.Billing.Trust.Models.SoldTo soldTo = null, Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber registrationNumber = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.TaxId> taxIds = null, Azure.ResourceManager.Billing.Trust.Models.ExternalId externalId = null, System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.DomainEntry DomainEntry(System.Collections.Generic.IEnumerable<string> domainNames = null, System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Billing.Trust.Models.DomainEntryState? state = default(Azure.ResourceManager.Billing.Trust.Models.DomainEntryState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.EduInitialValue EduInitialValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.DomainEntry> domains = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties EduQualificationRulePatchProperties(System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties EduQualificationRuleProperties(Azure.ResourceManager.Billing.Trust.Models.RuleState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.RuleState?), Azure.ResponseError error = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.DomainEntry> domains = null, System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.ExternalId ExternalId(string type = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult GenerateUploadTokenResult(string token = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase InitialRuleValueBase(string kind = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber RegistrationNumber(System.Collections.Generic.IEnumerable<string> type = null, string value = null, Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement? registrationRequirement = default(Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement?)) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleProperties RuleProperties(string kind = null, Azure.ResourceManager.Billing.Trust.Models.RuleState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.RuleState?), Azure.ResponseError error = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.SoldTo SoldTo(string addressLine1 = null, string addressLine2 = null, string addressLine3 = null, string city = null, string country = null, string companyName = null, string district = null, string email = null, string firstName = null, string lastName = null, string middleName = null, string phoneNumber = null, string postalCode = null, string region = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.TaxId TaxId(string value = null, string country = null, string scope = null, Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus? status = default(Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus?), string type = null) { throw null; }
    }
    public partial class AssessmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties>
    {
        public AssessmentProperties(Azure.ResourceManager.Billing.Trust.Models.AssessmentType assessmentType) { }
        public Azure.ResourceManager.Billing.Trust.Models.AssessmentType AssessmentType { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.AssessmentState? EvaluationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase> InitialValues { get { throw null; } }
        public System.DateTimeOffset? NextEvaluation { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.AssessmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentState : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.AssessmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState Expired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState Failed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState FailedWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState Pending { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState Running { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState SucceededWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentState UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.AssessmentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.AssessmentState left, Azure.ResourceManager.Billing.Trust.Models.AssessmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.AssessmentState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.AssessmentState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.AssessmentState left, Azure.ResourceManager.Billing.Trust.Models.AssessmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentType : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.AssessmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentType(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentType BusinessVerification { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentType Edu { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentType PayeeEnrollment { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.AssessmentType PayeeProfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.AssessmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.AssessmentType left, Azure.ResourceManager.Billing.Trust.Models.AssessmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.AssessmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.AssessmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.AssessmentType left, Azure.ResourceManager.Billing.Trust.Models.AssessmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingTrustProvisioningState : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingTrustProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BillingTrustRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch>
    {
        internal BillingTrustRulePatch() { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BusinessVerificationRulePatchProperties : Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>
    {
        public BusinessVerificationRulePatchProperties() { }
        public Azure.ResourceManager.Billing.Trust.Models.ExternalId ExternalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> SupplementalDocuments { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BusinessVerificationRuleProperties : Azure.ResourceManager.Billing.Trust.Models.RuleProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>
    {
        public BusinessVerificationRuleProperties() { }
        public Azure.ResourceManager.Billing.Trust.Models.ExternalId ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber RegistrationNumber { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.SoldTo SoldTo { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> SupplementalDocuments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Billing.Trust.Models.TaxId> TaxIds { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.RuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.RuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainEntry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.DomainEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.DomainEntry>
    {
        public DomainEntry(System.Collections.Generic.IEnumerable<string> domainNames) { }
        public System.Collections.Generic.IList<string> DomainNames { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.DomainEntryState? State { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.DomainEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.DomainEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.DomainEntry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.DomainEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.DomainEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.DomainEntry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.DomainEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.DomainEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.DomainEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainEntryState : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.DomainEntryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainEntryState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.DomainEntryState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.DomainEntryState Failed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.DomainEntryState Pending { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.DomainEntryState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.DomainEntryState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.DomainEntryState left, Azure.ResourceManager.Billing.Trust.Models.DomainEntryState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.DomainEntryState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.DomainEntryState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.DomainEntryState left, Azure.ResourceManager.Billing.Trust.Models.DomainEntryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EduInitialValue : Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>
    {
        public EduInitialValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.DomainEntry> domains) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Trust.Models.DomainEntry> Domains { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.EduInitialValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.EduInitialValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EduQualificationRulePatchProperties : Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties>
    {
        public EduQualificationRulePatchProperties() { }
        public System.Collections.Generic.IList<System.Uri> SupplementalDocuments { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EduQualificationRuleProperties : Azure.ResourceManager.Billing.Trust.Models.RuleProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>
    {
        public EduQualificationRuleProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Trust.Models.DomainEntry> Domains { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> SupplementalDocuments { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.RuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.RuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.ExternalId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.ExternalId>
    {
        public ExternalId(string type, string value) { }
        public string Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.ExternalId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.ExternalId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.ExternalId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.ExternalId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.ExternalId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.ExternalId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.ExternalId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.ExternalId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.ExternalId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateUploadTokenResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>
    {
        internal GenerateUploadTokenResult() { }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InitialRuleValueBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase>
    {
        internal InitialRuleValueBase() { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.InitialRuleValueBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistrationNumber : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber>
    {
        internal RegistrationNumber() { }
        public Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement? RegistrationRequirement { get { throw null; } }
        public System.Collections.Generic.IList<string> Type { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RegistrationNumber>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistrationRequirement : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistrationRequirement(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement Optional { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement left, Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement left, Azure.ResourceManager.Billing.Trust.Models.RegistrationRequirement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.RuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RuleProperties>
    {
        internal RuleProperties() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.RuleState? EvaluationState { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.RuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.RuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.RuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.RuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.RuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.RuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.RuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleState : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.RuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState Expired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState Failed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState FailedWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState Pending { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState Running { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState Skipped { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState SucceededWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.RuleState UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.RuleState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.RuleState left, Azure.ResourceManager.Billing.Trust.Models.RuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.RuleState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.RuleState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.RuleState left, Azure.ResourceManager.Billing.Trust.Models.RuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SoldTo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.SoldTo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.SoldTo>
    {
        internal SoldTo() { }
        public string AddressLine1 { get { throw null; } }
        public string AddressLine2 { get { throw null; } }
        public string AddressLine3 { get { throw null; } }
        public string City { get { throw null; } }
        public string CompanyName { get { throw null; } }
        public string Country { get { throw null; } }
        public string District { get { throw null; } }
        public string Email { get { throw null; } }
        public string FirstName { get { throw null; } }
        public string LastName { get { throw null; } }
        public string MiddleName { get { throw null; } }
        public string PhoneNumber { get { throw null; } }
        public string PostalCode { get { throw null; } }
        public string Region { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.SoldTo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.SoldTo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.SoldTo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.SoldTo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.SoldTo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.SoldTo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.SoldTo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.SoldTo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.SoldTo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaxId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.TaxId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.TaxId>
    {
        internal TaxId() { }
        public string Country { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus? Status { get { throw null; } }
        public string Type { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.TaxId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.TaxId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.TaxId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.TaxId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.TaxId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.TaxId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.TaxId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.TaxId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.TaxId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaxIdStatus : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaxIdStatus(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus Other { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus left, Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus left, Azure.ResourceManager.Billing.Trust.Models.TaxIdStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
