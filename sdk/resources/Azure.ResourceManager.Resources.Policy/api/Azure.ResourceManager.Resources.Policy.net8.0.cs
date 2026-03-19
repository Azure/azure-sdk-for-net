namespace Azure.ResourceManager.Resources.Policy
{
    public partial class AzureResourceManagerResourcesPolicyContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesPolicyContext() { }
        public static Azure.ResourceManager.Resources.Policy.AzureResourceManagerResourcesPolicyContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class PolicyAssignmentCollection : Azure.ResourceManager.ArmCollection
    {
        protected PolicyAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyAssignmentName, Azure.ResourceManager.Resources.Policy.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyAssignmentName, Azure.ResourceManager.Resources.Policy.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> Get(string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetAsync(string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetIfExists(string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetIfExistsAsync(string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>
    {
        public PolicyAssignmentData() { }
        public Azure.ResourceManager.Resources.Policy.Models.AssignmentType? AssignmentType { get { throw null; } set { } }
        public string DefinitionVersion { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EffectiveDefinitionVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.EnforcementMode? EnforcementMode { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.Identity Identity { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public string LatestDefinitionVersion { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage> NonComplianceMessages { get { throw null; } }
        public System.Collections.Generic.IList<string> NotScopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.Override> Overrides { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector> ResourceSelectors { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings SelfServeExemptionSettings { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyAssignmentResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string policyAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> Update(Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> UpdateAsync(Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>, System.Collections.IEnumerable
    {
        protected PolicyDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyDefinitionName, Azure.ResourceManager.Resources.Policy.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyDefinitionName, Azure.ResourceManager.Resources.Policy.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> Get(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>> GetAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> GetIfExists(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>> GetIfExistsAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>
    {
        public PolicyDefinitionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings ExternalEvaluationEnforcementSettings { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> Parameters { get { throw null; } }
        public System.BinaryData PolicyRule { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Versions { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string policyDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> GetPolicyDefinitionVersion(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>> GetPolicyDefinitionVersionAsync(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionCollection GetPolicyDefinitionVersions() { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyDefinitionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>, System.Collections.IEnumerable
    {
        protected PolicyDefinitionVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyDefinitionVersion, Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyDefinitionVersion, Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> Get(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>> GetAsync(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> GetIfExists(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>> GetIfExistsAsync(string policyDefinitionVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyDefinitionVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>
    {
        public PolicyDefinitionVersionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings ExternalEvaluationEnforcementSettings { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> Parameters { get { throw null; } }
        public System.BinaryData PolicyRule { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDefinitionVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyDefinitionVersionResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string policyDefinitionName, string policyDefinitionVersion) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicySetDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>, System.Collections.IEnumerable
    {
        protected PolicySetDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policySetDefinitionName, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policySetDefinitionName, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> Get(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> GetAll(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> GetAllAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> GetAsync(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> GetIfExists(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> GetIfExistsAsync(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicySetDefinitionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>
    {
        public PolicySetDefinitionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Versions { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicySetDefinitionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicySetDefinitionResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string policySetDefinitionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> GetPolicySetDefinitionVersion(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>> GetPolicySetDefinitionVersionAsync(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionCollection GetPolicySetDefinitionVersions() { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicySetDefinitionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>, System.Collections.IEnumerable
    {
        protected PolicySetDefinitionVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyDefinitionVersion, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyDefinitionVersion, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> Get(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> GetAll(string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> GetAllAsync(string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>> GetAsync(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> GetIfExists(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>> GetIfExistsAsync(string policyDefinitionVersion, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicySetDefinitionVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>
    {
        public PolicySetDefinitionVersionData() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> Parameters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup> PolicyDefinitionGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference> PolicyDefinitions { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyType? PolicyType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicySetDefinitionVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicySetDefinitionVersionResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string policySetDefinitionName, string policyDefinitionVersion) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourcesPolicyExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult> Acquire(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>> AcquireAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult> AcquireAtManagementGroup(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>> AcquireAtManagementGroupAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> CreateById(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, Azure.ResourceManager.Resources.Policy.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> CreateByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, Azure.ResourceManager.Resources.Policy.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> DeleteById(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> DeleteByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetById(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource GetPolicyAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyAssignmentCollection GetPolicyAssignments(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> GetPolicyDefinition(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>> GetPolicyDefinitionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource GetPolicyDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult> GetPolicyDefinitions(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyDefinitionCollection GetPolicyDefinitions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult> GetPolicyDefinitions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>> GetPolicyDefinitionsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>> GetPolicyDefinitionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource GetPolicyDefinitionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> GetPolicySetDefinition(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> GetPolicySetDefinitionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource GetPolicySetDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult> GetPolicySetDefinitions(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionCollection GetPolicySetDefinitions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult> GetPolicySetDefinitions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>> GetPolicySetDefinitionsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>> GetPolicySetDefinitionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource GetPolicySetDefinitionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> UpdateById(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> UpdateByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Policy.Mocking
{
    public partial class MockableResourcesPolicyArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesPolicyArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignment(Azure.Core.ResourceIdentifier scope, string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource GetPolicyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyAssignmentCollection GetPolicyAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource GetPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource GetPolicyDefinitionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource GetPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource GetPolicySetDefinitionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourcesPolicyManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesPolicyManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult> AcquireAtManagementGroup(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>> AcquireAtManagementGroupAsync(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult> GetPolicyDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>> GetPolicyDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult> GetPolicySetDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>> GetPolicySetDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourcesPolicyResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesPolicyResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourcesPolicySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesPolicySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult> Acquire(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>> AcquireAsync(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource> GetPolicyDefinition(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource>> GetPolicyDefinitionAsync(string policyDefinitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionCollection GetPolicyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> GetPolicySetDefinition(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> GetPolicySetDefinitionAsync(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionCollection GetPolicySetDefinitions() { throw null; }
    }
    public partial class MockableResourcesPolicyTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesPolicyTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> CreateById(string policyAssignmentId, Azure.ResourceManager.Resources.Policy.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> CreateByIdAsync(string policyAssignmentId, Azure.ResourceManager.Resources.Policy.PolicyAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> DeleteById(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> DeleteByIdAsync(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetById(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetByIdAsync(string policyAssignmentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult> GetPolicyDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>> GetPolicyDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult> GetPolicySetDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>> GetPolicySetDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> UpdateById(string policyAssignmentId, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> UpdateByIdAsync(string policyAssignmentId, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Policy.Models
{
    public static partial class ArmResourcesPolicyModelFactory
    {
        public static Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult ExternalEvaluationEndpointInvocationResult(Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo policyInfo = null, Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult? result = default(Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult?), string endpointKind = null, string message = null, System.DateTimeOffset? retryAfter = default(System.DateTimeOffset?), System.BinaryData claims = null, Azure.ResourceManager.Resources.Policy.Models.PolicyAction? policyAction = default(Azure.ResourceManager.Resources.Policy.Models.PolicyAction?), System.BinaryData policyEvaluationDetails = null, System.BinaryData additionalInfo = null, System.DateTimeOffset? expiration = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings ExternalEvaluationEnforcementSettings(string missingTokenAction = null, string resultLifespan = null, Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings endpointSettings = null, System.Collections.Generic.IEnumerable<string> roleDefinitionIds = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.Identity Identity(string principalId = null, string tenantId = null, Azure.ResourceManager.Resources.Policy.Models.ResourceIdentityType? type = default(Azure.ResourceManager.Resources.Policy.Models.ResourceIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.Override Override(Azure.ResourceManager.Resources.Policy.Models.OverrideKind? kind = default(Azure.ResourceManager.Resources.Policy.Models.OverrideKind?), string value = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.Selector> selectors = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue ParameterDefinitionsValue(Azure.ResourceManager.Resources.Policy.Models.ParameterType? type = default(Azure.ResourceManager.Resources.Policy.Models.ParameterType?), System.Collections.Generic.IEnumerable<System.BinaryData> allowedValues = null, System.BinaryData defaultValue = null, System.BinaryData schema = null, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata ParameterDefinitionsValueMetadata(string displayName = null, string description = null, string strongType = null, bool? assignPermissions = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyAssignmentData PolicyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string policyDefinitionId = null, string definitionVersion = null, string latestDefinitionVersion = null, string effectiveDefinitionVersion = null, string scope = null, System.Collections.Generic.IEnumerable<string> notScopes = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue> parameters = null, string description = null, System.BinaryData metadata = null, Azure.ResourceManager.Resources.Policy.Models.EnforcementMode? enforcementMode = default(Azure.ResourceManager.Resources.Policy.Models.EnforcementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage> nonComplianceMessages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector> resourceSelectors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.Override> overrides = null, Azure.ResourceManager.Resources.Policy.Models.AssignmentType? assignmentType = default(Azure.ResourceManager.Resources.Policy.Models.AssignmentType?), string instanceId = null, Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings selfServeExemptionSettings = null, string location = null, Azure.ResourceManager.Resources.Policy.Models.Identity identity = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyDefinitionData PolicyDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string mode = null, string displayName = null, string description = null, System.BinaryData policyRule = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> parameters = null, string version = null, System.Collections.Generic.IEnumerable<string> versions = null, Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings externalEvaluationEnforcementSettings = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference PolicyDefinitionReference(string policyDefinitionId = null, string definitionVersion = null, string latestDefinitionVersion = null, string effectiveDefinitionVersion = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue> parameters = null, string policyDefinitionReferenceId = null, System.Collections.Generic.IEnumerable<string> groupNames = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData PolicyDefinitionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string mode = null, string displayName = null, string description = null, System.BinaryData policyRule = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> parameters = null, string version = null, Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings externalEvaluationEnforcementSettings = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult PolicyDefinitionVersionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo PolicyLogInfo(string policyDefinitionId = null, string policySetDefinitionId = null, string policyDefinitionReferenceId = null, string policySetDefinitionName = null, string policySetDefinitionDisplayName = null, string policySetDefinitionVersion = null, string policySetDefinitionCategory = null, string policyDefinitionName = null, string policyDefinitionDisplayName = null, string policyDefinitionVersion = null, string policyDefinitionEffect = null, System.Collections.Generic.IEnumerable<string> policyDefinitionGroupNames = null, string policyAssignmentId = null, string policyAssignmentName = null, string policyAssignmentDisplayName = null, string policyAssignmentVersion = null, string policyAssignmentScope = null, string resourceLocation = null, string ancestors = null, string complianceReasonCode = null, System.Collections.Generic.IEnumerable<string> policyExemptionIds = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData PolicySetDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string displayName = null, string description = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference> policyDefinitions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup> policyDefinitionGroups = null, string version = null, System.Collections.Generic.IEnumerable<string> versions = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData PolicySetDefinitionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string displayName = null, string description = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference> policyDefinitions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup> policyDefinitionGroups = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult PolicySetDefinitionVersionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails PolicyTokenEvaluatedRequestDetails(string uri = null, string resourceId = null, string apiVersion = null, string authorizationAction = null, string httpMethod = null, string contentHash = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo PolicyTokenOperationInfo(string uri = null, string httpMethod = null, System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent PolicyTokenRequestContent(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo operation = null, string changeReference = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult PolicyTokenResponseResult(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult? result = default(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult?), Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails requestDetails = null, string message = null, System.DateTimeOffset? retryAfter = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult> results = null, string changeReference = null, string token = null, string tokenId = null, System.DateTimeOffset? expiration = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ResourceSelector ResourceSelector(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.Selector> selectors = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.Selector Selector(Azure.ResourceManager.Resources.Policy.Models.SelectorKind? kind = default(Azure.ResourceManager.Resources.Policy.Models.SelectorKind?), System.Collections.Generic.IEnumerable<string> @in = null, System.Collections.Generic.IEnumerable<string> notIn = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings SelfServeExemptionSettings(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> policyDefinitionReferenceIds = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue UserAssignedIdentitiesValue(string principalId = null, string clientId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentType : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.AssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.AssignmentType Custom { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AssignmentType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AssignmentType System { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AssignmentType SystemHidden { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.AssignmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.AssignmentType left, Azure.ResourceManager.Resources.Policy.Models.AssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AssignmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.AssignmentType left, Azure.ResourceManager.Resources.Policy.Models.AssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforcementMode : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.EnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforcementMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.EnforcementMode Default { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.EnforcementMode DoNotEnforce { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.EnforcementMode Enroll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.EnforcementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.EnforcementMode left, Azure.ResourceManager.Resources.Policy.Models.EnforcementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.EnforcementMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.EnforcementMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.EnforcementMode left, Azure.ResourceManager.Resources.Policy.Models.EnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalEndpointResult : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalEndpointResult(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult left, Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult left, Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExternalEvaluationEndpointInvocationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>
    {
        internal ExternalEvaluationEndpointInvocationResult() { }
        public System.BinaryData AdditionalInfo { get { throw null; } }
        public System.BinaryData Claims { get { throw null; } }
        public string EndpointKind { get { throw null; } }
        public System.DateTimeOffset? Expiration { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyAction? PolicyAction { get { throw null; } }
        public System.BinaryData PolicyEvaluationDetails { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo PolicyInfo { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.ExternalEndpointResult? Result { get { throw null; } }
        public System.DateTimeOffset? RetryAfter { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalEvaluationEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings>
    {
        public ExternalEvaluationEndpointSettings() { }
        public System.BinaryData Details { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExternalEvaluationEnforcementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings>
    {
        public ExternalEvaluationEnforcementSettings() { }
        public Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointSettings EndpointSettings { get { throw null; } set { } }
        public string MissingTokenAction { get { throw null; } set { } }
        public string ResultLifespan { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RoleDefinitionIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEnforcementSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Identity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Identity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Identity>
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.ResourceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Identity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Identity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.Identity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Identity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Identity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.Identity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Identity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Identity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Identity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NonComplianceMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage>
    {
        public NonComplianceMessage(string message) { }
        public string Message { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.NonComplianceMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Override : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Override>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Override>
    {
        public Override() { }
        public Azure.ResourceManager.Resources.Policy.Models.OverrideKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.Selector> Selectors { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Override JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Override PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.Override System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Override>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Override>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.Override System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Override>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Override>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Override>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OverrideKind : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.OverrideKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OverrideKind(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.OverrideKind DefinitionVersion { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.OverrideKind PolicyEffect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.OverrideKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.OverrideKind left, Azure.ResourceManager.Resources.Policy.Models.OverrideKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.OverrideKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.OverrideKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.OverrideKind left, Azure.ResourceManager.Resources.Policy.Models.OverrideKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterDefinitionsValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue>
    {
        public ParameterDefinitionsValue() { }
        public System.Collections.Generic.IList<System.BinaryData> AllowedValues { get { throw null; } }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata Metadata { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.ParameterType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParameterDefinitionsValueMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata>
    {
        public ParameterDefinitionsValueMetadata() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? AssignPermissions { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string StrongType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterDefinitionsValueMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterType : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterType DateTime { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.ParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.ParameterType left, Azure.ResourceManager.Resources.Policy.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.ParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.ParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.ParameterType left, Azure.ResourceManager.Resources.Policy.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterValuesValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue>
    {
        public ParameterValuesValue() { }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyAction : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAction Audit { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAction Deny { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAction Error { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAction Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyAction left, Azure.ResourceManager.Resources.Policy.Models.PolicyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyAction left, Azure.ResourceManager.Resources.Policy.Models.PolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyAssignmentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>
    {
        public PolicyAssignmentPatch() { }
        public Azure.ResourceManager.Resources.Policy.Models.Identity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.Override> Overrides { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector> ResourceSelectors { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings SelfServeExemptionSettings { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDefinitionGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup>
    {
        public PolicyDefinitionGroup(string name) { }
        public string AdditionalMetadataId { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDefinitionReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference>
    {
        public PolicyDefinitionReference(string policyDefinitionId) { }
        public string DefinitionVersion { get { throw null; } set { } }
        public string EffectiveDefinitionVersion { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupNames { get { throw null; } }
        public string LatestDefinitionVersion { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.ParameterValuesValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDefinitionVersionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>
    {
        internal PolicyDefinitionVersionListResult() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyLogInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo>
    {
        internal PolicyLogInfo() { }
        public string Ancestors { get { throw null; } }
        public string ComplianceReasonCode { get { throw null; } }
        public string PolicyAssignmentDisplayName { get { throw null; } }
        public string PolicyAssignmentId { get { throw null; } }
        public string PolicyAssignmentName { get { throw null; } }
        public string PolicyAssignmentScope { get { throw null; } }
        public string PolicyAssignmentVersion { get { throw null; } }
        public string PolicyDefinitionDisplayName { get { throw null; } }
        public string PolicyDefinitionEffect { get { throw null; } }
        public System.Collections.Generic.IList<string> PolicyDefinitionGroupNames { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionName { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public string PolicyDefinitionVersion { get { throw null; } }
        public System.Collections.Generic.IList<string> PolicyExemptionIds { get { throw null; } }
        public string PolicySetDefinitionCategory { get { throw null; } }
        public string PolicySetDefinitionDisplayName { get { throw null; } }
        public string PolicySetDefinitionId { get { throw null; } }
        public string PolicySetDefinitionName { get { throw null; } }
        public string PolicySetDefinitionVersion { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicySetDefinitionVersionListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>
    {
        internal PolicySetDefinitionVersionListResult() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTokenEvaluatedRequestDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails>
    {
        internal PolicyTokenEvaluatedRequestDetails() { }
        public string ApiVersion { get { throw null; } }
        public string AuthorizationAction { get { throw null; } }
        public string ContentHash { get { throw null; } }
        public string HttpMethod { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTokenOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo>
    {
        public PolicyTokenOperationInfo(string uri, string httpMethod) { }
        public System.BinaryData Content { get { throw null; } set { } }
        public string HttpMethod { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTokenRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent>
    {
        public PolicyTokenRequestContent(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo operation) { }
        public string ChangeReference { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo Operation { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTokenResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>
    {
        internal PolicyTokenResponseResult() { }
        public string ChangeReference { get { throw null; } }
        public System.DateTimeOffset? Expiration { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails RequestDetails { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult? Result { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult> Results { get { throw null; } }
        public System.DateTimeOffset? RetryAfter { get { throw null; } }
        public string Token { get { throw null; } }
        public string TokenId { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyTokenResult : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyTokenResult(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult left, Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult left, Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyType : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyType BuiltIn { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyType Custom { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyType Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyType left, Azure.ResourceManager.Resources.Policy.Models.PolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyType left, Azure.ResourceManager.Resources.Policy.Models.PolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        None = 2,
    }
    public partial class ResourceSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector>
    {
        public ResourceSelector() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.Selector> Selectors { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ResourceSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ResourceSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ResourceSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ResourceSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Selector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Selector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Selector>
    {
        public Selector() { }
        public System.Collections.Generic.IList<string> In { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.SelectorKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotIn { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Selector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Selector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.Selector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Selector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Selector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.Selector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Selector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Selector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Selector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelectorKind : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.SelectorKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelectorKind(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.SelectorKind PolicyDefinitionReferenceId { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.SelectorKind ResourceLocation { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.SelectorKind ResourceType { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.SelectorKind ResourceWithoutLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.SelectorKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.SelectorKind left, Azure.ResourceManager.Resources.Policy.Models.SelectorKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.SelectorKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.SelectorKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.SelectorKind left, Azure.ResourceManager.Resources.Policy.Models.SelectorKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfServeExemptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings>
    {
        public SelfServeExemptionSettings() { }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PolicyDefinitionReferenceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.SelfServeExemptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentitiesValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue>
    {
        public UserAssignedIdentitiesValue() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.UserAssignedIdentitiesValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
