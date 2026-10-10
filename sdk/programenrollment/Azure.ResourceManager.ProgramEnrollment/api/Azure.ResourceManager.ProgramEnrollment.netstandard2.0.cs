namespace Azure.ResourceManager.ProgramEnrollment
{
    public partial class AzureResourceManagerProgramEnrollmentContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerProgramEnrollmentContext() { }
        public static Azure.ResourceManager.ProgramEnrollment.AzureResourceManagerProgramEnrollmentContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EduEnrollmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>, System.Collections.IEnumerable
    {
        protected EduEnrollmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string enrollmentName, Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string enrollmentName, Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> Get(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> GetAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetIfExists(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> GetIfExistsAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EduEnrollmentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>
    {
        public EduEnrollmentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EduEnrollmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EduEnrollmentResource() { }
        public virtual Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string enrollmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> Update(Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> UpdateAsync(Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ProgramEnrollmentExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetEduEnrollment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> GetEduEnrollmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource GetEduEnrollmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProgramEnrollment.EduEnrollmentCollection GetEduEnrollments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetEduEnrollments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetEduEnrollmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ProgramEnrollment.Mocking
{
    public partial class MockableProgramEnrollmentArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableProgramEnrollmentArmClient() { }
        public virtual Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource GetEduEnrollmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableProgramEnrollmentResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProgramEnrollmentResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetEduEnrollment(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource>> GetEduEnrollmentAsync(string enrollmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProgramEnrollment.EduEnrollmentCollection GetEduEnrollments() { throw null; }
    }
    public partial class MockableProgramEnrollmentSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProgramEnrollmentSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetEduEnrollments(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgramEnrollment.EduEnrollmentResource> GetEduEnrollmentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ProgramEnrollment.Models
{
    public static partial class ArmProgramEnrollmentModelFactory
    {
        public static Azure.ResourceManager.ProgramEnrollment.EduEnrollmentData EduEnrollmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch EduEnrollmentPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties EduEnrollmentProperties(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState? provisioningState = default(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup> domains = null, Azure.ResponseError failureReason = null) { throw null; }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup ProgramEnrollmentDomainGroup(System.Collections.Generic.IEnumerable<string> domainNames = null, System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState? state = default(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState?), Azure.ResponseError failureReason = null) { throw null; }
    }
    public partial class EduEnrollmentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch>
    {
        public EduEnrollmentPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EduEnrollmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties>
    {
        public EduEnrollmentProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup> domains) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup> Domains { get { throw null; } }
        public Azure.ResponseError FailureReason { get { throw null; } }
        public Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.EduEnrollmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProgramEnrollmentDomainGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup>
    {
        public ProgramEnrollmentDomainGroup(System.Collections.Generic.IEnumerable<string> domainNames) { }
        public System.Collections.Generic.IList<string> DomainNames { get { throw null; } }
        public Azure.ResponseError FailureReason { get { throw null; } }
        public Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState? State { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProgramEnrollmentDomainGroupState : System.IEquatable<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProgramEnrollmentDomainGroupState(string value) { throw null; }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState Failed { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState Pending { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState left, Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState left, Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentDomainGroupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProgramEnrollmentProvisioningState : System.IEquatable<Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProgramEnrollmentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState left, Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState left, Azure.ResourceManager.ProgramEnrollment.Models.ProgramEnrollmentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
