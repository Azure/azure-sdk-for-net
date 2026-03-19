namespace Azure.ResourceManager.Resources.Policy
{
    public partial class AzureResourceManagerResourcesPolicyContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesPolicyContext() { }
        public static Azure.ResourceManager.Resources.Policy.AzureResourceManagerResourcesPolicyContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DataPolicyManifestCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>, System.Collections.IEnumerable
    {
        protected DataPolicyManifestCollection() { }
        public virtual Azure.Response<bool> Exists(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> Get(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>> GetAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> GetIfExists(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>> GetIfExistsAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataPolicyManifestData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>
    {
        internal DataPolicyManifestData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail> Custom { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.DataEffect> Effects { get { throw null; } }
        public System.Collections.Generic.IList<string> FieldValues { get { throw null; } }
        public bool? IsBuiltInOnly { get { throw null; } }
        public System.Collections.Generic.IList<string> Namespaces { get { throw null; } }
        public string PolicyMode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases> ResourceTypeAliases { get { throw null; } }
        public System.Collections.Generic.IList<string> Standard { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.DataPolicyManifestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.DataPolicyManifestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataPolicyManifestResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataPolicyManifestResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.DataPolicyManifestData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string policyMode) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.Policy.DataPolicyManifestData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.DataPolicyManifestData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.DataPolicyManifestData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType? AssignmentType { get { throw null; } set { } }
        public string DefinitionVersion { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string EffectiveDefinitionVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity Identity { get { throw null; } set { } }
        public string InstanceId { get { throw null; } }
        public string LatestDefinitionVersion { get { throw null; } }
        public string Location { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage> NonComplianceMessages { get { throw null; } }
        public System.Collections.Generic.IList<string> NotScopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride> Overrides { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue> Parameters { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector> ResourceSelectors { get { throw null; } }
        public string Scope { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings SelfServeExemptionSettings { get { throw null; } set { } }
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
        public Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings ExternalEvaluationEnforcementSettings { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> Parameters { get { throw null; } }
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
        public Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings ExternalEvaluationEnforcementSettings { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Mode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> Parameters { get { throw null; } }
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
    public partial class PolicyExemptionCollection : Azure.ResourceManager.ArmCollection
    {
        protected PolicyExemptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyExemptionName, Azure.ResourceManager.Resources.Policy.PolicyExemptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyExemptionName, Azure.ResourceManager.Resources.Policy.PolicyExemptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> Get(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource>> GetAsync(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetIfExists(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource>> GetIfExistsAsync(string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyExemptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>
    {
        public PolicyExemptionData() { }
        public Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation? AssignmentScopeValidation { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory ExemptionCategory { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string PolicyAssignmentId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PolicyDefinitionReferenceIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector> ResourceSelectors { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyExemptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyExemptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyExemptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyExemptionResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyExemptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string policyExemptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.Policy.PolicyExemptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.PolicyExemptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.PolicyExemptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> Update(Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource>> UpdateAsync(Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> Parameters { get { throw null; } }
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
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> Parameters { get { throw null; } }
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
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> GetDataPolicyManifest(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>> GetDataPolicyManifestAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource GetDataPolicyManifestResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.DataPolicyManifestCollection GetDataPolicyManifests(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemption(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource>> GetPolicyExemptionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyExemptionResource GetPolicyExemptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyExemptionCollection GetPolicyExemptions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> GetPolicySetDefinition(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> GetPolicySetDefinitionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource GetPolicySetDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult> GetPolicySetDefinitions(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionCollection GetPolicySetDefinitions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult> GetPolicySetDefinitions(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>> GetPolicySetDefinitionsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>> GetPolicySetDefinitionsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource GetPolicySetDefinitionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource> GetVariable(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource>> GetVariableAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.VariableResource GetVariableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.Policy.VariableResource> GetVariables(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.VariableCollection GetVariables(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.VariableResource> GetVariablesAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.VariableValueResource GetVariableValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> UpdateById(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> UpdateByIdAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string policyAssignmentId, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VariableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.VariableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.VariableResource>, System.Collections.IEnumerable
    {
        protected VariableCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string variableName, Azure.ResourceManager.Resources.Policy.VariableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string variableName, Azure.ResourceManager.Resources.Policy.VariableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource> Get(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.VariableResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.VariableResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource>> GetAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.VariableResource> GetIfExists(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.VariableResource>> GetIfExistsAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Policy.VariableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.VariableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Policy.VariableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.VariableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VariableData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>
    {
        public VariableData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn> Columns { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.VariableData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.VariableData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VariableResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VariableResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.VariableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string variableName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.VariableValueResource> GetVariableValue(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.VariableValueResource>> GetVariableValueAsync(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.VariableValueCollection GetVariableValues() { throw null; }
        Azure.ResourceManager.Resources.Policy.VariableData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.VariableData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.VariableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.VariableData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VariableValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.VariableValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.VariableValueResource>, System.Collections.IEnumerable
    {
        protected VariableValueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableValueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string variableValueName, Azure.ResourceManager.Resources.Policy.VariableValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableValueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string variableValueName, Azure.ResourceManager.Resources.Policy.VariableValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.VariableValueResource> Get(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.VariableValueResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.VariableValueResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.VariableValueResource>> GetAsync(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.VariableValueResource> GetIfExists(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.Policy.VariableValueResource>> GetIfExistsAsync(string variableValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.Policy.VariableValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.Policy.VariableValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.Policy.VariableValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.VariableValueResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VariableValueData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableValueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>
    {
        public VariableValueData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.VariableValueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.VariableValueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VariableValueResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableValueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VariableValueResource() { }
        public virtual Azure.ResourceManager.Resources.Policy.VariableValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string variableName, string variableValueName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.VariableValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.VariableValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.Policy.VariableValueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.VariableValueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.VariableValueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableValueResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.VariableValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Policy.VariableValueResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Policy.VariableValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Policy.Mocking
{
    public partial class MockableResourcesPolicyArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesPolicyArmClient() { }
        public virtual Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource GetDataPolicyManifestResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignment(Azure.Core.ResourceIdentifier scope, string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource>> GetPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, string policyAssignmentName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource GetPolicyAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyAssignmentCollection GetPolicyAssignments(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionResource GetPolicyDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionResource GetPolicyDefinitionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemption(Azure.Core.ResourceIdentifier scope, string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource>> GetPolicyExemptionAsync(Azure.Core.ResourceIdentifier scope, string policyExemptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyExemptionResource GetPolicyExemptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicyExemptionCollection GetPolicyExemptions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource GetPolicySetDefinitionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionResource GetPolicySetDefinitionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.VariableResource GetVariableResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.VariableValueResource GetVariableValueResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult> GetPolicySetDefinitions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult>> GetPolicySetDefinitionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.VariableResource> GetVariables(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.VariableResource> GetVariablesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourcesPolicyResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesPolicyResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignments(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyAssignmentResource> GetPolicyAssignmentsAsync(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptions(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Policy.PolicyExemptionResource> GetPolicyExemptionsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource> GetPolicySetDefinition(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionResource>> GetPolicySetDefinitionAsync(string policySetDefinitionName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.PolicySetDefinitionCollection GetPolicySetDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource> GetVariable(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.VariableResource>> GetVariableAsync(string variableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.VariableCollection GetVariables() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource> GetDataPolicyManifest(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Policy.DataPolicyManifestResource>> GetDataPolicyManifestAsync(string policyMode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.Policy.DataPolicyManifestCollection GetDataPolicyManifests() { throw null; }
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
    public partial class Alias : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Alias>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Alias>
    {
        internal Alias() { }
        public Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata DefaultMetadata { get { throw null; } }
        public string DefaultPath { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.AliasPattern DefaultPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.AliasPath> Paths { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.AliasType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Alias JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.Alias PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.Alias System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Alias>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.Alias>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.Alias System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Alias>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Alias>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.Alias>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AliasPath : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPath>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPath>
    {
        internal AliasPath() { }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata Metadata { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.AliasPattern Pattern { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.AliasPath JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.AliasPath PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.AliasPath System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.AliasPath System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AliasPathAttributes : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AliasPathAttributes(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes Modifiable { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes left, Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes left, Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AliasPathMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata>
    {
        internal AliasPathMetadata() { }
        public Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes? Attributes { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AliasPathTokenType : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AliasPathTokenType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType Any { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType Number { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType left, Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType left, Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AliasPattern : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPattern>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPattern>
    {
        internal AliasPattern() { }
        public string Phrase { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.AliasPatternType? Type { get { throw null; } }
        public string Variable { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.AliasPattern JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.AliasPattern PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.AliasPattern System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPattern>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.AliasPattern>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.AliasPattern System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPattern>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPattern>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.AliasPattern>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AliasPatternType
    {
        NotSpecified = 0,
        Extract = 1,
    }
    public enum AliasType
    {
        NotSpecified = 0,
        PlainText = 1,
        Mask = 2,
    }
    public static partial class ArmResourcesPolicyModelFactory
    {
        public static Azure.ResourceManager.Resources.Policy.Models.Alias Alias(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.AliasPath> paths = null, Azure.ResourceManager.Resources.Policy.Models.AliasType? type = default(Azure.ResourceManager.Resources.Policy.Models.AliasType?), string defaultPath = null, Azure.ResourceManager.Resources.Policy.Models.AliasPattern defaultPattern = null, Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata defaultMetadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPath AliasPath(string path = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, Azure.ResourceManager.Resources.Policy.Models.AliasPattern pattern = null, Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata metadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPathMetadata AliasPathMetadata(Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType? type = default(Azure.ResourceManager.Resources.Policy.Models.AliasPathTokenType?), Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes? attributes = default(Azure.ResourceManager.Resources.Policy.Models.AliasPathAttributes?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.AliasPattern AliasPattern(string phrase = null, string variable = null, Azure.ResourceManager.Resources.Policy.Models.AliasPatternType? type = default(Azure.ResourceManager.Resources.Policy.Models.AliasPatternType?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.DataEffect DataEffect(string name = null, System.BinaryData detailsSchema = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail DataManifestCustomResourceFunctionDetail(string name = null, string fullyQualifiedResourceType = null, System.Collections.Generic.IEnumerable<string> defaultProperties = null, bool? allowCustomProperties = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.DataPolicyManifestData DataPolicyManifestData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> namespaces = null, string policyMode = null, bool? isBuiltInOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases> resourceTypeAliases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.DataEffect> effects = null, System.Collections.Generic.IEnumerable<string> fieldValues = null, System.Collections.Generic.IEnumerable<string> standard = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail> custom = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult ExternalEvaluationEndpointInvocationResult(Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo policyInfo = null, Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult? result = default(Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult?), string endpointKind = null, string message = null, System.DateTimeOffset? retryAfter = default(System.DateTimeOffset?), System.BinaryData claims = null, Azure.ResourceManager.Resources.Policy.Models.PolicyAction? policyAction = default(Azure.ResourceManager.Resources.Policy.Models.PolicyAction?), System.BinaryData policyEvaluationDetails = null, System.BinaryData additionalInfo = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyAssignmentData PolicyAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string policyDefinitionId = null, string definitionVersion = null, string latestDefinitionVersion = null, string effectiveDefinitionVersion = null, string scope = null, System.Collections.Generic.IEnumerable<string> notScopes = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue> parameters = null, string description = null, System.BinaryData metadata = null, Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode? enforcementMode = default(Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage> nonComplianceMessages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector> resourceSelectors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride> overrides = null, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType? assignmentType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType?), string instanceId = null, Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings selfServeExemptionSettings = null, string location = null, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity PolicyAssignmentIdentity(string principalId = null, string tenantId = null, Azure.ResourceManager.Resources.Policy.Models.PolicyIdentityType? type = default(Azure.ResourceManager.Resources.Policy.Models.PolicyIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyDefinitionData PolicyDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string mode = null, string displayName = null, string description = null, System.BinaryData policyRule = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> parameters = null, string version = null, System.Collections.Generic.IEnumerable<string> versions = null, Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings externalEvaluationEnforcementSettings = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference PolicyDefinitionReference(string policyDefinitionId = null, string definitionVersion = null, string latestDefinitionVersion = null, string effectiveDefinitionVersion = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue> parameters = null, string policyDefinitionReferenceId = null, System.Collections.Generic.IEnumerable<string> groupNames = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData PolicyDefinitionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string mode = null, string displayName = null, string description = null, System.BinaryData policyRule = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> parameters = null, string version = null, Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings externalEvaluationEnforcementSettings = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionVersionListResult PolicyDefinitionVersionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicyDefinitionVersionData> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicyExemptionData PolicyExemptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string policyAssignmentId = null, System.Collections.Generic.IEnumerable<string> policyDefinitionReferenceIds = null, Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory? exemptionCategory = default(Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?), string displayName = null, string description = null, System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector> resourceSelectors = null, Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation? assignmentScopeValidation = default(Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings PolicyExternalEvaluationEnforcementSettings(string missingTokenAction = null, string resultLifespan = null, Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings endpointSettings = null, System.Collections.Generic.IEnumerable<string> roleDefinitionIds = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo PolicyLogInfo(string policyDefinitionId = null, string policySetDefinitionId = null, string policyDefinitionReferenceId = null, string policySetDefinitionName = null, string policySetDefinitionDisplayName = null, string policySetDefinitionVersion = null, string policySetDefinitionCategory = null, string policyDefinitionName = null, string policyDefinitionDisplayName = null, string policyDefinitionVersion = null, string policyDefinitionEffect = null, System.Collections.Generic.IEnumerable<string> policyDefinitionGroupNames = null, string policyAssignmentId = null, string policyAssignmentName = null, string policyAssignmentDisplayName = null, string policyAssignmentVersion = null, string policyAssignmentScope = null, string resourceLocation = null, string ancestors = null, string complianceReasonCode = null, System.Collections.Generic.IEnumerable<string> policyExemptionIds = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyOverride PolicyOverride(Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind? kind = default(Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind?), string value = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicySelector> selectors = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata PolicyParameterMetadata(Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType? type = default(Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType?), System.Collections.Generic.IEnumerable<System.BinaryData> allowedValues = null, System.BinaryData defaultValue = null, System.BinaryData schema = null, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties metadata = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties PolicyParameterMetadataProperties(string displayName = null, string description = null, string strongType = null, bool? assignPermissions = default(bool?), System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector PolicyResourceSelector(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicySelector> selectors = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelector PolicySelector(Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind? kind = default(Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind?), System.Collections.Generic.IEnumerable<string> @in = null, System.Collections.Generic.IEnumerable<string> notIn = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings PolicySelfServeExemptionSettings(bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> policyDefinitionReferenceIds = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionData PolicySetDefinitionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string displayName = null, string description = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference> policyDefinitions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup> policyDefinitionGroups = null, string version = null, System.Collections.Generic.IEnumerable<string> versions = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData PolicySetDefinitionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Policy.Models.PolicyType? policyType = default(Azure.ResourceManager.Resources.Policy.Models.PolicyType?), string displayName = null, string description = null, System.BinaryData metadata = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata> parameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionReference> policyDefinitions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyDefinitionGroup> policyDefinitionGroups = null, string version = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySetDefinitionVersionListResult PolicySetDefinitionVersionListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.PolicySetDefinitionVersionData> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails PolicyTokenEvaluatedRequestDetails(string uri = null, string resourceId = null, string apiVersion = null, string authorizationAction = null, string httpMethod = null, string contentHash = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo PolicyTokenOperationInfo(string uri = null, string httpMethod = null, System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenRequestContent PolicyTokenRequestContent(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenOperationInfo operation = null, string changeReference = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResponseResult PolicyTokenResponseResult(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult? result = default(Azure.ResourceManager.Resources.Policy.Models.PolicyTokenResult?), Azure.ResourceManager.Resources.Policy.Models.PolicyTokenEvaluatedRequestDetails requestDetails = null, string message = null, System.DateTimeOffset? retryAfter = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult> results = null, string changeReference = null, string token = null, string tokenId = null, System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity PolicyUserAssignedIdentity(string principalId = null, string clientId = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases ResourceTypeAliases(string resourceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.Alias> aliases = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.VariableData VariableData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn> columns = null) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.VariableValueData VariableValueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue> values = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssignmentScopeValidation : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssignmentScopeValidation(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation Default { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation DoNotValidate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation left, Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation left, Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataEffect : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.DataEffect>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataEffect>
    {
        internal DataEffect() { }
        public System.BinaryData DetailsSchema { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.DataEffect JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.DataEffect PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.DataEffect System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.DataEffect>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.DataEffect>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.DataEffect System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataEffect>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataEffect>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataEffect>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataManifestCustomResourceFunctionDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail>
    {
        internal DataManifestCustomResourceFunctionDetail() { }
        public bool? AllowCustomProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> DefaultProperties { get { throw null; } }
        public string FullyQualifiedResourceType { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.DataManifestCustomResourceFunctionDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExemptionCategory : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExemptionCategory(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory Mitigated { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory Waiver { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory left, Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory left, Azure.ResourceManager.Resources.Policy.Models.ExemptionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExternalEvaluationEndpointInvocationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ExternalEvaluationEndpointInvocationResult>
    {
        internal ExternalEvaluationEndpointInvocationResult() { }
        public System.BinaryData AdditionalInfo { get { throw null; } }
        public System.BinaryData Claims { get { throw null; } }
        public string EndpointKind { get { throw null; } }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyAction? PolicyAction { get { throw null; } }
        public System.BinaryData PolicyEvaluationDetails { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyLogInfo PolicyInfo { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult? Result { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyAction : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAction Allow { get { throw null; } }
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
    public partial class PolicyAssignmentIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity>
    {
        public PolicyAssignmentIdentity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyAssignmentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentPatch>
    {
        public PolicyAssignmentPatch() { }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride> Overrides { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector> ResourceSelectors { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings SelfServeExemptionSettings { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyAssignmentType : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType Custom { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType System { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType SystemHidden { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType left, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType left, Azure.ResourceManager.Resources.Policy.Models.PolicyAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
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
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue> Parameters { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyEnforcementMode : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyEnforcementMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode Default { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode DoNotEnforce { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode Enroll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode left, Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode left, Azure.ResourceManager.Resources.Policy.Models.PolicyEnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyExemptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch>
    {
        public PolicyExemptionPatch() { }
        public Azure.ResourceManager.Resources.Policy.Models.AssignmentScopeValidation? AssignmentScopeValidation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector> ResourceSelectors { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExemptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyExternalEndpointResult : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyExternalEndpointResult(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult left, Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult left, Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEndpointResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyExternalEvaluationEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings>
    {
        public PolicyExternalEvaluationEndpointSettings() { }
        public System.BinaryData Details { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyExternalEvaluationEnforcementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings>
    {
        public PolicyExternalEvaluationEnforcementSettings() { }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEndpointSettings EndpointSettings { get { throw null; } set { } }
        public string MissingTokenAction { get { throw null; } set { } }
        public string ResultLifespan { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RoleDefinitionIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyExternalEvaluationEnforcementSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum PolicyIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        None = 2,
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
    public partial class PolicyNonComplianceMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage>
    {
        public PolicyNonComplianceMessage(string message) { }
        public string Message { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyNonComplianceMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride>
    {
        public PolicyOverride() { }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicySelector> Selectors { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyOverride JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyOverride PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyOverrideKind : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyOverrideKind(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind DefinitionVersion { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind PolicyEffect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind left, Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind left, Azure.ResourceManager.Resources.Policy.Models.PolicyOverrideKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyParameterMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata>
    {
        public PolicyParameterMetadata() { }
        public System.Collections.Generic.IList<System.BinaryData> AllowedValues { get { throw null; } }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties Metadata { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyParameterMetadataProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties>
    {
        public PolicyParameterMetadataProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? AssignPermissions { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string StrongType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterMetadataProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyParameterType : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType DateTime { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType Integer { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType left, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType left, Azure.ResourceManager.Resources.Policy.Models.PolicyParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue>
    {
        public PolicyParameterValue() { }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyResourceSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector>
    {
        public PolicyResourceSelector() { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.PolicySelector> Selectors { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyResourceSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicySelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelector>
    {
        public PolicySelector() { }
        public System.Collections.Generic.IList<string> In { get { throw null; } }
        public Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NotIn { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicySelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicySelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicySelectorKind : System.IEquatable<Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicySelectorKind(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind GroupPrincipalId { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind PolicyDefinitionReferenceId { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind ResourceLocation { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind ResourceType { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind ResourceWithoutLocation { get { throw null; } }
        public static Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind UserPrincipalId { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind left, Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind left, Azure.ResourceManager.Resources.Policy.Models.PolicySelectorKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicySelfServeExemptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings>
    {
        public PolicySelfServeExemptionSettings() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PolicyDefinitionReferenceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicySelfServeExemptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.DateTimeOffset? ExpiresOn { get { throw null; } }
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
    public partial class PolicyUserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity>
    {
        public PolicyUserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyVariableColumn : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn>
    {
        public PolicyVariableColumn(string columnName) { }
        public string ColumnName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableColumn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyVariableValueColumnValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue>
    {
        public PolicyVariableValueColumnValue(string columnName, System.BinaryData columnValue) { }
        public string ColumnName { get { throw null; } set { } }
        public System.BinaryData ColumnValue { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.PolicyVariableValueColumnValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeAliases : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases>
    {
        internal ResourceTypeAliases() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Policy.Models.Alias> Aliases { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Policy.Models.ResourceTypeAliases>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
