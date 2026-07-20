namespace Azure.ResourceManager.Education
{
    public partial class AzureResourceManagerEducationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEducationContext() { }
        public static Azure.ResourceManager.Education.AzureResourceManagerEducationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class EducationExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Education.GrantDetailsResource> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, bool? includeAllocatedBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Education.GrantDetailsResource> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, bool? includeAllocatedBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Education.JoinRequestDetailsCollection GetAllJoinRequestDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Education.StudentDetailsCollection GetAllStudentDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Education.StudentLabDetailsCollection GetAllStudentLabDetails(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Education.GrantDetailsResource GetGrantDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Education.GrantDetailsResource GetGrantDetailsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource> GetJoinRequestDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource>> GetJoinRequestDetailsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Education.JoinRequestDetailsResource GetJoinRequestDetailsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Education.LabDetailsResource GetLabDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.Education.LabDetailsResource GetLabDetailsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource> GetStudentDetails(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource>> GetStudentDetailsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Education.StudentDetailsResource GetStudentDetailsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource> GetStudentLabDetails(this Azure.ResourceManager.Resources.TenantResource tenantResource, string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource>> GetStudentLabDetailsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Education.StudentLabDetailsResource GetStudentLabDetailsResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response RedeemInvitationCode(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Education.Models.EducationRedeemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RedeemInvitationCodeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Education.Models.EducationRedeemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GrantDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.GrantDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>
    {
        internal GrantDetailsData() { }
        public Azure.ResourceManager.Education.Models.EducationAmount AllocatedBudget { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public Azure.ResourceManager.Education.Models.EducationAmount OfferCap { get { throw null; } }
        public Azure.ResourceManager.Education.Models.EducationGrantType? OfferType { get { throw null; } }
        public Azure.ResourceManager.Education.Models.EducationGrantStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.GrantDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.GrantDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.GrantDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.GrantDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GrantDetailsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.GrantDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GrantDetailsResource() { }
        public virtual Azure.ResourceManager.Education.GrantDetailsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string billingProfileName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.GrantDetailsResource> Get(bool? includeAllocatedBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.GrantDetailsResource>> GetAsync(bool? includeAllocatedBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Education.GrantDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.GrantDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.GrantDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.GrantDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.GrantDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JoinRequestDetailsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Education.JoinRequestDetailsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Education.JoinRequestDetailsResource>, System.Collections.IEnumerable
    {
        protected JoinRequestDetailsCollection() { }
        public virtual Azure.Response<bool> Exists(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource> Get(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Education.JoinRequestDetailsResource> GetAll(bool? includeDenied = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Education.JoinRequestDetailsResource> GetAllAsync(bool? includeDenied = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource>> GetAsync(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Education.JoinRequestDetailsResource> GetIfExists(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Education.JoinRequestDetailsResource>> GetIfExistsAsync(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Education.JoinRequestDetailsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Education.JoinRequestDetailsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Education.JoinRequestDetailsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Education.JoinRequestDetailsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JoinRequestDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.JoinRequestDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>
    {
        internal JoinRequestDetailsData() { }
        public string Email { get { throw null; } }
        public string FirstName { get { throw null; } }
        public string LastName { get { throw null; } }
        public Azure.ResourceManager.Education.Models.JoinRequestStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.JoinRequestDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.JoinRequestDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JoinRequestDetailsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.JoinRequestDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JoinRequestDetailsResource() { }
        public virtual Azure.ResourceManager.Education.JoinRequestDetailsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Approve(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApproveAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string billingProfileName, string invoiceSectionName, string joinRequestName) { throw null; }
        public virtual Azure.Response Deny(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DenyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Education.JoinRequestDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.JoinRequestDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.JoinRequestDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.LabDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>
    {
        public LabDetailsData() { }
        public Azure.ResourceManager.Education.Models.EducationAmount BudgetPerStudent { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string InvitationCode { get { throw null; } }
        public int? MaxStudentCount { get { throw null; } }
        public Azure.ResourceManager.Education.Models.LabStatus? Status { get { throw null; } }
        public string TotalAllocatedBudgetCurrency { get { throw null; } }
        public float? TotalAllocatedBudgetValue { get { throw null; } }
        public string TotalBudgetCurrency { get { throw null; } }
        public float? TotalBudgetValue { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.LabDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.LabDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.LabDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.LabDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabDetailsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.LabDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabDetailsResource() { }
        public virtual Azure.ResourceManager.Education.LabDetailsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Education.LabDetailsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Education.LabDetailsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Education.LabDetailsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Education.LabDetailsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string billingProfileName, string invoiceSectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.LabDetailsResource> GenerateInviteCode(Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent content, bool? onlyUpdateStudentCountParameter = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.LabDetailsResource>> GenerateInviteCodeAsync(Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent content, bool? onlyUpdateStudentCountParameter = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.LabDetailsResource> Get(bool? includeBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Education.JoinRequestDetailsCollection GetAllJoinRequestDetails() { throw null; }
        public virtual Azure.ResourceManager.Education.StudentDetailsCollection GetAllStudentDetails() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.LabDetailsResource>> GetAsync(bool? includeBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource> GetJoinRequestDetails(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource>> GetJoinRequestDetailsAsync(string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource> GetStudentDetails(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource>> GetStudentDetailsAsync(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Education.LabDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.LabDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.LabDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.LabDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.LabDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StudentDetailsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Education.StudentDetailsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Education.StudentDetailsResource>, System.Collections.IEnumerable
    {
        protected StudentDetailsCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Education.StudentDetailsResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string studentAlias, Azure.ResourceManager.Education.StudentDetailsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Education.StudentDetailsResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string studentAlias, Azure.ResourceManager.Education.StudentDetailsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource> Get(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Education.StudentDetailsResource> GetAll(bool? includeDeleted = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Education.StudentDetailsResource> GetAllAsync(bool? includeDeleted = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource>> GetAsync(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Education.StudentDetailsResource> GetIfExists(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Education.StudentDetailsResource>> GetIfExistsAsync(string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Education.StudentDetailsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Education.StudentDetailsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Education.StudentDetailsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Education.StudentDetailsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StudentDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>
    {
        public StudentDetailsData() { }
        public Azure.ResourceManager.Education.Models.EducationAmount Budget { get { throw null; } set { } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public string Email { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public Azure.ResourceManager.Education.Models.StudentRole? Role { get { throw null; } set { } }
        public Azure.ResourceManager.Education.Models.StudentLabStatus? Status { get { throw null; } }
        public string SubscriptionAlias { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? SubscriptionInviteLastSentOn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.StudentDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.StudentDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StudentDetailsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StudentDetailsResource() { }
        public virtual Azure.ResourceManager.Education.StudentDetailsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountName, string billingProfileName, string invoiceSectionName, string studentAlias) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Education.StudentDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.StudentDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Education.StudentDetailsResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Education.StudentDetailsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Education.StudentDetailsResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Education.StudentDetailsData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StudentLabDetailsCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Education.StudentLabDetailsResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Education.StudentLabDetailsResource>, System.Collections.IEnumerable
    {
        protected StudentLabDetailsCollection() { }
        public virtual Azure.Response<bool> Exists(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource> Get(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Education.StudentLabDetailsResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Education.StudentLabDetailsResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource>> GetAsync(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Education.StudentLabDetailsResource> GetIfExists(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Education.StudentLabDetailsResource>> GetIfExistsAsync(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Education.StudentLabDetailsResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Education.StudentLabDetailsResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Education.StudentLabDetailsResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Education.StudentLabDetailsResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StudentLabDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentLabDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>
    {
        internal StudentLabDetailsData() { }
        public Azure.ResourceManager.Education.Models.EducationAmount Budget { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string LabScope { get { throw null; } }
        public Azure.ResourceManager.Education.Models.StudentRole? Role { get { throw null; } }
        public Azure.ResourceManager.Education.Models.StudentLabStatus? Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.StudentLabDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.StudentLabDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StudentLabDetailsResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentLabDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StudentLabDetailsResource() { }
        public virtual Azure.ResourceManager.Education.StudentLabDetailsData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string studentLabName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Education.StudentLabDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.StudentLabDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.StudentLabDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Education.Mocking
{
    public partial class MockableEducationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEducationArmClient() { }
        public virtual Azure.ResourceManager.Education.JoinRequestDetailsCollection GetAllJoinRequestDetails(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Education.StudentDetailsCollection GetAllStudentDetails(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Education.GrantDetailsResource GetGrantDetails(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Education.GrantDetailsResource GetGrantDetailsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource> GetJoinRequestDetails(Azure.Core.ResourceIdentifier scope, string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.JoinRequestDetailsResource>> GetJoinRequestDetailsAsync(Azure.Core.ResourceIdentifier scope, string joinRequestName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Education.JoinRequestDetailsResource GetJoinRequestDetailsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Education.LabDetailsResource GetLabDetails(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Education.LabDetailsResource GetLabDetailsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource> GetStudentDetails(Azure.Core.ResourceIdentifier scope, string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentDetailsResource>> GetStudentDetailsAsync(Azure.Core.ResourceIdentifier scope, string studentAlias, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Education.StudentDetailsResource GetStudentDetailsResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Education.StudentLabDetailsResource GetStudentLabDetailsResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEducationTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEducationTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Education.GrantDetailsResource> GetAll(bool? includeAllocatedBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Education.GrantDetailsResource> GetAllAsync(bool? includeAllocatedBudget = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Education.StudentLabDetailsCollection GetAllStudentLabDetails() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource> GetStudentLabDetails(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Education.StudentLabDetailsResource>> GetStudentLabDetailsAsync(string studentLabName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RedeemInvitationCode(Azure.ResourceManager.Education.Models.EducationRedeemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RedeemInvitationCodeAsync(Azure.ResourceManager.Education.Models.EducationRedeemContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Education.Models
{
    public static partial class ArmEducationModelFactory
    {
        public static Azure.ResourceManager.Education.Models.EducationAmount EducationAmount(string currency = null, float? value = default(float?)) { throw null; }
        public static Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent EducationInviteCodeGenerateContent(int? maxStudentCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Education.Models.EducationRedeemContent EducationRedeemContent(string redeemCode = null, string firstName = null, string lastName = null) { throw null; }
        public static Azure.ResourceManager.Education.GrantDetailsData GrantDetailsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Education.Models.EducationAmount offerCap = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), Azure.ResourceManager.Education.Models.EducationGrantType? offerType = default(Azure.ResourceManager.Education.Models.EducationGrantType?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.Education.Models.EducationGrantStatus? status = default(Azure.ResourceManager.Education.Models.EducationGrantStatus?), Azure.ResourceManager.Education.Models.EducationAmount allocatedBudget = null) { throw null; }
        public static Azure.ResourceManager.Education.JoinRequestDetailsData JoinRequestDetailsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string firstName = null, string lastName = null, string email = null, Azure.ResourceManager.Education.Models.JoinRequestStatus? status = default(Azure.ResourceManager.Education.Models.JoinRequestStatus?)) { throw null; }
        public static Azure.ResourceManager.Education.StudentDetailsData StudentDetailsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string firstName = null, string lastName = null, string email = null, Azure.ResourceManager.Education.Models.StudentRole? role = default(Azure.ResourceManager.Education.Models.StudentRole?), Azure.ResourceManager.Education.Models.EducationAmount budget = null, string subscriptionId = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.Education.Models.StudentLabStatus? status = default(Azure.ResourceManager.Education.Models.StudentLabStatus?), System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), string subscriptionAlias = null, System.DateTimeOffset? subscriptionInviteLastSentOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Education.StudentLabDetailsData StudentLabDetailsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.Education.Models.StudentRole? role = default(Azure.ResourceManager.Education.Models.StudentRole?), Azure.ResourceManager.Education.Models.EducationAmount budget = null, string subscriptionId = null, Azure.ResourceManager.Education.Models.StudentLabStatus? status = default(Azure.ResourceManager.Education.Models.StudentLabStatus?), System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), string labScope = null) { throw null; }
    }
    public partial class EducationAmount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationAmount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationAmount>
    {
        public EducationAmount() { }
        public string Currency { get { throw null; } set { } }
        public float? Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Education.Models.EducationAmount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Education.Models.EducationAmount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.Models.EducationAmount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationAmount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationAmount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.Models.EducationAmount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationAmount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationAmount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationAmount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EducationGrantStatus : System.IEquatable<Azure.ResourceManager.Education.Models.EducationGrantStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EducationGrantStatus(string value) { throw null; }
        public static Azure.ResourceManager.Education.Models.EducationGrantStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.EducationGrantStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Education.Models.EducationGrantStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Education.Models.EducationGrantStatus left, Azure.ResourceManager.Education.Models.EducationGrantStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.EducationGrantStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.EducationGrantStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Education.Models.EducationGrantStatus left, Azure.ResourceManager.Education.Models.EducationGrantStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EducationGrantType : System.IEquatable<Azure.ResourceManager.Education.Models.EducationGrantType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EducationGrantType(string value) { throw null; }
        public static Azure.ResourceManager.Education.Models.EducationGrantType Academic { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.EducationGrantType Student { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Education.Models.EducationGrantType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Education.Models.EducationGrantType left, Azure.ResourceManager.Education.Models.EducationGrantType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.EducationGrantType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.EducationGrantType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Education.Models.EducationGrantType left, Azure.ResourceManager.Education.Models.EducationGrantType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EducationInviteCodeGenerateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent>
    {
        public EducationInviteCodeGenerateContent() { }
        public int? MaxStudentCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationInviteCodeGenerateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EducationRedeemContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationRedeemContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationRedeemContent>
    {
        public EducationRedeemContent(string redeemCode, string firstName, string lastName) { }
        public string FirstName { get { throw null; } }
        public string LastName { get { throw null; } }
        public string RedeemCode { get { throw null; } }
        protected virtual Azure.ResourceManager.Education.Models.EducationRedeemContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Education.Models.EducationRedeemContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Education.Models.EducationRedeemContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationRedeemContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Education.Models.EducationRedeemContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Education.Models.EducationRedeemContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationRedeemContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationRedeemContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Education.Models.EducationRedeemContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JoinRequestStatus : System.IEquatable<Azure.ResourceManager.Education.Models.JoinRequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JoinRequestStatus(string value) { throw null; }
        public static Azure.ResourceManager.Education.Models.JoinRequestStatus Denied { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.JoinRequestStatus Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Education.Models.JoinRequestStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Education.Models.JoinRequestStatus left, Azure.ResourceManager.Education.Models.JoinRequestStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.JoinRequestStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.JoinRequestStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Education.Models.JoinRequestStatus left, Azure.ResourceManager.Education.Models.JoinRequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabStatus : System.IEquatable<Azure.ResourceManager.Education.Models.LabStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabStatus(string value) { throw null; }
        public static Azure.ResourceManager.Education.Models.LabStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.LabStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.LabStatus Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Education.Models.LabStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Education.Models.LabStatus left, Azure.ResourceManager.Education.Models.LabStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.LabStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.LabStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Education.Models.LabStatus left, Azure.ResourceManager.Education.Models.LabStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StudentLabStatus : System.IEquatable<Azure.ResourceManager.Education.Models.StudentLabStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StudentLabStatus(string value) { throw null; }
        public static Azure.ResourceManager.Education.Models.StudentLabStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.StudentLabStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.StudentLabStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.StudentLabStatus Expired { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.StudentLabStatus Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Education.Models.StudentLabStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Education.Models.StudentLabStatus left, Azure.ResourceManager.Education.Models.StudentLabStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.StudentLabStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.StudentLabStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Education.Models.StudentLabStatus left, Azure.ResourceManager.Education.Models.StudentLabStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StudentRole : System.IEquatable<Azure.ResourceManager.Education.Models.StudentRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StudentRole(string value) { throw null; }
        public static Azure.ResourceManager.Education.Models.StudentRole Admin { get { throw null; } }
        public static Azure.ResourceManager.Education.Models.StudentRole Student { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Education.Models.StudentRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Education.Models.StudentRole left, Azure.ResourceManager.Education.Models.StudentRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.StudentRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Education.Models.StudentRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Education.Models.StudentRole left, Azure.ResourceManager.Education.Models.StudentRole right) { throw null; }
        public override string ToString() { throw null; }
    }
}
