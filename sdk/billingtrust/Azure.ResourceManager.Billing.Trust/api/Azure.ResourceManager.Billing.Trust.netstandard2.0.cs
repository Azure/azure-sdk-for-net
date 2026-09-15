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
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties Properties { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Billing.Trust.BillingTrustAssessmentData BillingTrustAssessmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties BillingTrustAssessmentProperties(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType assessmentType = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType), Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState?), System.DateTimeOffset? nextEvaluation = default(System.DateTimeOffset?), Azure.ResponseError error = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase> initialValues = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry BillingTrustDomainEntry(System.Collections.Generic.IEnumerable<string> domainNames = null, System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState? state = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId BillingTrustExternalId(string type = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase BillingTrustInitialRuleValueBase(string kind = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber BillingTrustRegistrationNumber(System.Collections.Generic.IEnumerable<string> type = null, string value = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement? registrationRequirement = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement?)) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.BillingTrustRuleData BillingTrustRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch BillingTrustRulePatch(string kind = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties BillingTrustRuleProperties(string kind = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState?), Azure.ResponseError error = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo BillingTrustSoldTo(string addressLine1 = null, string addressLine2 = null, string addressLine3 = null, string city = null, string country = null, string companyName = null, string district = null, string email = null, string firstName = null, string lastName = null, string middleName = null, string phoneNumber = null, string postalCode = null, string region = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId BillingTrustTaxId(string value = null, string country = null, string scope = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus? status = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus?), string type = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties BusinessVerificationRulePatchProperties(Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId externalId = null, System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties BusinessVerificationRuleProperties(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState?), Azure.ResponseError error = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?), Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo soldTo = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber registrationNumber = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId> taxIds = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId externalId = null, System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.EduInitialValue EduInitialValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry> domains = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.EduQualificationRulePatchProperties EduQualificationRulePatchProperties(System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties EduQualificationRuleProperties(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState? evaluationState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState?), Azure.ResponseError error = null, Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? provisioningState = default(Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry> domains = null, System.Collections.Generic.IEnumerable<System.Uri> supplementalDocuments = null) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.GenerateUploadTokenResult GenerateUploadTokenResult(string token = null) { throw null; }
    }
    public partial class BillingTrustAssessmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties>
    {
        public BillingTrustAssessmentProperties(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType assessmentType) { }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType AssessmentType { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState? EvaluationState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase> InitialValues { get { throw null; } }
        public System.DateTimeOffset? NextEvaluation { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingTrustAssessmentState : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingTrustAssessmentState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState Expired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState Failed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState FailedWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState Pending { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState Running { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState SucceededWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingTrustAssessmentType : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingTrustAssessmentType(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType BusinessVerification { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType Edu { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType PayeeEnrollment { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType PayeeProfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustAssessmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingTrustDomainEntry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry>
    {
        public BillingTrustDomainEntry(System.Collections.Generic.IEnumerable<string> domainNames) { }
        public System.Collections.Generic.IList<string> DomainNames { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState? State { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingTrustDomainEntryState : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingTrustDomainEntryState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState Failed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState Pending { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntryState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingTrustExternalId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId>
    {
        public BillingTrustExternalId(string type, string value) { }
        public string Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BillingTrustInitialRuleValueBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase>
    {
        internal BillingTrustInitialRuleValueBase() { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BillingTrustRegistrationNumber : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber>
    {
        internal BillingTrustRegistrationNumber() { }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement? RegistrationRequirement { get { throw null; } }
        public System.Collections.Generic.IList<string> Type { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingTrustRegistrationRequirement : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingTrustRegistrationRequirement(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement Optional { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationRequirement right) { throw null; }
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
    public abstract partial class BillingTrustRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties>
    {
        internal BillingTrustRuleProperties() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState? EvaluationState { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingTrustRuleState : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingTrustRuleState(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState Expired { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState Failed { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState FailedWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState Pending { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState Running { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState Skipped { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState SucceededWithOverride { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BillingTrustSoldTo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo>
    {
        internal BillingTrustSoldTo() { }
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
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingTrustTaxId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId>
    {
        internal BillingTrustTaxId() { }
        public string Country { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus? Status { get { throw null; } }
        public string Type { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BillingTrustTaxIdStatus : System.IEquatable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BillingTrustTaxIdStatus(string value) { throw null; }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus Other { get { throw null; } }
        public static Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus left, Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxIdStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BusinessVerificationRulePatchProperties : Azure.ResourceManager.Billing.Trust.Models.BillingTrustRulePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRulePatchProperties>
    {
        public BusinessVerificationRulePatchProperties() { }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId ExternalId { get { throw null; } set { } }
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
    public partial class BusinessVerificationRuleProperties : Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>
    {
        public BusinessVerificationRuleProperties() { }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustExternalId ExternalId { get { throw null; } set { } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustRegistrationNumber RegistrationNumber { get { throw null; } }
        public Azure.ResourceManager.Billing.Trust.Models.BillingTrustSoldTo SoldTo { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> SupplementalDocuments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Billing.Trust.Models.BillingTrustTaxId> TaxIds { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.BusinessVerificationRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EduInitialValue : Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduInitialValue>
    {
        public EduInitialValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry> domains) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry> Domains { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustInitialRuleValueBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EduQualificationRuleProperties : Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>
    {
        public EduQualificationRuleProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Billing.Trust.Models.BillingTrustDomainEntry> Domains { get { throw null; } }
        public System.Collections.Generic.IList<System.Uri> SupplementalDocuments { get { throw null; } }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Billing.Trust.Models.BillingTrustRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Billing.Trust.Models.EduQualificationRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
