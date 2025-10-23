namespace Azure.ResourceManager.PolicyInsights
{
    public partial class AzureResourceManagerPolicyInsightsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPolicyInsightsContext() { }
        public static Azure.ResourceManager.PolicyInsights.AzureResourceManagerPolicyInsightsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class PolicyAttestationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>, System.Collections.IEnumerable
    {
        protected PolicyAttestationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attestationName, Azure.ResourceManager.PolicyInsights.PolicyAttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attestationName, Azure.ResourceManager.PolicyInsights.PolicyAttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> Get(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetAll(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> GetAsync(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetIfExists(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> GetIfExistsAsync(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyAttestationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>
    {
        public PolicyAttestationData(Azure.Core.ResourceIdentifier policyAssignmentId) { }
        public System.DateTimeOffset? AssessOn { get { throw null; } set { } }
        public string Comments { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState? ComplianceState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence> Evidence { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastComplianceStateChangeOn { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Owner { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyAttestationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyAttestationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyAttestationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyAttestationResource() { }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyAttestationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string attestationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PolicyInsights.PolicyAttestationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyAttestationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyAttestationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.PolicyAttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.PolicyAttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PolicyInsightsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckPolicyRestrictions(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckPolicyRestrictions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckPolicyRestrictions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataCollection GetAllPolicyMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetPolicyAttestation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> GetPolicyAttestationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyAttestationResource GetPolicyAttestationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyAttestationCollection GetPolicyAttestations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.Resources.PolicyAssignmentResource policyAssignmentResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.Resources.PolicyAssignmentResource policyAssignmentResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> GetPolicyMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetPolicyMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataResource GetPolicyMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetPolicyRemediation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetPolicyRemediationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationResource GetPolicyRemediationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationCollection GetPolicyRemediations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.Resources.PolicyAssignmentResource policyAssignmentResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.Resources.PolicyAssignmentResource policyAssignmentResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStates(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStatesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupComponentPolicyStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupComponentPolicyStatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(this Azure.ResourceManager.Resources.PolicyAssignmentResource policyAssignmentResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(this Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(this Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(this Azure.ResourceManager.Resources.PolicyAssignmentResource policyAssignmentResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation TriggerPolicyStateEvaluation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation TriggerPolicyStateEvaluation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerPolicyStateEvaluationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerPolicyStateEvaluationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyMetadataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>, System.Collections.IEnumerable
    {
        protected PolicyMetadataCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAll(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>
    {
        internal PolicyMetadataData() { }
        public System.Uri AdditionalContentUri { get { throw null; } }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string MetadataId { get { throw null; } }
        public string Owner { get { throw null; } }
        public string Requirements { get { throw null; } }
        public string Title { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyMetadataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyMetadataResource() { }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PolicyInsights.PolicyMetadataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyMetadataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyRemediationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>, System.Collections.IEnumerable
    {
        protected PolicyRemediationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string remediationName, Azure.ResourceManager.PolicyInsights.PolicyRemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string remediationName, Azure.ResourceManager.PolicyInsights.PolicyRemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> Get(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetAll(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetAsync(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetIfExists(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetIfExistsAsync(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyRemediationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>
    {
        public PolicyRemediationData() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary DeploymentStatus { get { throw null; } }
        public float? FailureThresholdPercentage { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.RemediationFilters Filter { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> FilterLocations { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public int? ParallelDeployments { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public int? ResourceCount { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? ResourceDiscoveryMode { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyRemediationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyRemediationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyRemediationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyRemediationResource() { }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyRemediationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string remediationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeployments(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PolicyInsights.PolicyRemediationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.PolicyRemediationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyRemediationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.PolicyRemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.PolicyRemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    public partial class MockablePolicyInsightsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetPolicyAttestation(Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> GetPolicyAttestationAsync(Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyAttestationResource GetPolicyAttestationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyAttestationCollection GetPolicyAttestations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyMetadataResource GetPolicyMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetPolicyRemediation(Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetPolicyRemediationAsync(Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyRemediationResource GetPolicyRemediationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyRemediationCollection GetPolicyRemediations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStates(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStatesAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckPolicyRestrictions(Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsPolicyAssignmentResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsPolicyAssignmentResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckPolicyRestrictions(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupComponentPolicyStates(Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupComponentPolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStates(Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerPolicyStateEvaluation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerPolicyStateEvaluationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsSubscriptionPolicyDefinitionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsSubscriptionPolicyDefinitionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsSubscriptionPolicySetDefinitionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsSubscriptionPolicySetDefinitionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckPolicyRestrictions(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourceType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStates(Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEvents(string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEventsAsync(string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinitionPolicyStates(string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinitionPolicyStatesAsync(string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEvents(string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEventsAsync(string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStates(string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStatesAsync(string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStates(Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates(Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStateType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicyDefinitionPolicyStates(string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicyDefinitionPolicyStatesAsync(string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicySetDefinitionPolicyStates(string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicySetDefinitionPolicyStatesAsync(string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStates(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStatesAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStateSummaryType, Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings policyQuerySettings = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerPolicyStateEvaluation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerPolicyStateEvaluationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsTenantResource() { }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyMetadataCollection GetAllPolicyMetadata() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> GetPolicyMetadata(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetPolicyMetadataAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyInsightsResourceGroupMockingExtension : Azure.ResourceManager.ArmResource
    {
        public PolicyInsightsResourceGroupMockingExtension() { }
    }
    public partial class PolicyInsightsSubscriptionMockingExtension : Azure.ResourceManager.ArmResource
    {
        public PolicyInsightsSubscriptionMockingExtension() { }
    }
}
namespace Azure.ResourceManager.PolicyInsights.Models
{
    public static partial class ArmPolicyInsightsModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent CheckPolicyRestrictionsContent(Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails resourceDetails, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PendingField> pendingFields) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent CheckPolicyRestrictionsContent(Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails resourceDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PendingField> pendingFields = null, bool? includeAuditEffect = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult CheckPolicyRestrictionsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions> fieldRestrictions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult> policyEvaluations = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails CheckRestrictionEvaluationDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails> evaluatedExpressions = null, Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails ifNotExistsDetails = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails CheckRestrictionsResourceDetails(System.BinaryData resourceContent = null, string apiVersion = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail ComplianceDetail(string complianceState = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails ComponentEventDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Guid? tenantId = default(System.Guid?), string principalOid = null, string policyDefinitionAction = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails ComponentExpressionEvaluationDetails(string result = null, string expression = null, string expressionKind = null, string path = null, System.BinaryData expressionValue = null, System.BinaryData targetValue = null, string @operator = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails ComponentPolicyEvaluationDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails> evaluatedExpressions = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState ComponentPolicyState(string odataId = null, string odataContext = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string componentId = null, string componentType = null, string componentName = null, string resourceId = null, string policyAssignmentId = null, string policyDefinitionId = null, string subscriptionId = null, string resourceType = null, string resourceLocation = null, string resourceGroup = null, string policyAssignmentName = null, string policyAssignmentOwner = null, string policyAssignmentParameters = null, string policyAssignmentScope = null, string policyDefinitionName = null, string policyDefinitionAction = null, string policyDefinitionCategory = null, string policySetDefinitionId = null, string policySetDefinitionName = null, string policySetDefinitionOwner = null, string policySetDefinitionCategory = null, string policySetDefinitionParameters = null, string policyDefinitionReferenceId = null, string complianceState = null, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails policyEvaluationDetails = null, System.Collections.Generic.IEnumerable<string> policyDefinitionGroupNames = null, string policyDefinitionVersion = null, string policySetDefinitionVersion = null, string policyAssignmentVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails ComponentStateDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string complianceState = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails ExpressionEvaluationDetails(string result = null, string expression = null, string expressionKind = null, string path = null, System.BinaryData expressionValue = null, System.BinaryData targetValue = null, string @operator = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PolicyInsights.Models.FieldRestriction FieldRestriction(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult? result, string defaultValue, System.Collections.Generic.IEnumerable<string> values, Azure.ResourceManager.PolicyInsights.Models.PolicyReference policy) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.FieldRestriction FieldRestriction(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult? result = default(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult?), string defaultValue = null, System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.PolicyInsights.Models.PolicyReference policy = null, string policyEffect = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions FieldRestrictions(string field = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction> restrictions = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails IfNotExistsEvaluationDetails(Azure.Core.ResourceIdentifier resourceId = null, int? totalResources = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PendingField PendingField(string field = null, System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary PolicyAssignmentSummary(Azure.Core.ResourceIdentifier policyAssignmentId = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults results = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary> policyDefinitions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary> policyGroups = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyAttestationData PolicyAttestationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, string policyDefinitionReferenceId = null, Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState? complianceState = default(Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string owner = null, string comments = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence> evidence = null, string provisioningState = null, System.DateTimeOffset? lastComplianceStateChangeOn = default(System.DateTimeOffset?), System.DateTimeOffset? assessOn = default(System.DateTimeOffset?), System.BinaryData metadata = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary PolicyDefinitionSummary(Azure.Core.ResourceIdentifier policyDefinitionId = null, string policyDefinitionReferenceId = null, System.Collections.Generic.IEnumerable<string> policyDefinitionGroupNames = null, string effect = null, Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults results = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyDetails PolicyDetails(Azure.Core.ResourceIdentifier policyDefinitionId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, string policyAssignmentDisplayName = null, string policyAssignmentScope = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, string policyDefinitionReferenceId = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails PolicyEvaluationDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails> evaluatedExpressions = null, Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails ifNotExistsDetails = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult PolicyEvaluationResult(Azure.ResourceManager.PolicyInsights.Models.PolicyReference policyInfo = null, string evaluationResult = null, Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails checkRestrictionEvaluationDetails = null, string policyEffect = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult PolicyEvaluationResult(Azure.ResourceManager.PolicyInsights.Models.PolicyReference policyInfo = null, string evaluationResult = null, Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails evaluationDetails = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEvent PolicyEvent(string odataId = null, string odataContext = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, Azure.Core.ResourceIdentifier policyDefinitionId = null, string effectiveParameters = null, bool? isCompliant = default(bool?), string subscriptionId = null, string resourceTypeString = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), string resourceGroup = null, string resourceTags = null, string policyAssignmentName = null, string policyAssignmentOwner = null, string policyAssignmentParameters = null, string policyAssignmentScope = null, string policyDefinitionName = null, string policyDefinitionAction = null, string policyDefinitionCategory = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, string policySetDefinitionName = null, string policySetDefinitionOwner = null, string policySetDefinitionCategory = null, string policySetDefinitionParameters = null, string managementGroupIds = null, string policyDefinitionReferenceId = null, string complianceState = null, System.Guid? tenantId = default(System.Guid?), string principalOid = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails> components = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary PolicyGroupSummary(string policyGroupName = null, Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults results = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataData PolicyMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string metadataId = null, string category = null, string title = null, string owner = null, System.Uri additionalContentUri = null, System.BinaryData metadata = null, string description = null, string requirements = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyReference PolicyReference(Azure.Core.ResourceIdentifier policyDefinitionId = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, string policyDefinitionReferenceId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationData PolicyRemediationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, string policyDefinitionReferenceId = null, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? resourceDiscoveryMode = default(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode?), string provisioningState = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.PolicyInsights.Models.RemediationFilters filter = null, Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary deploymentStatus = null, string statusMessage = null, string correlationId = null, int? resourceCount = default(int?), int? parallelDeployments = default(int?), float? failureThresholdPercentage = default(float?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationData PolicyRemediationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, string policyDefinitionReferenceId = null, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? resourceDiscoveryMode = default(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode?), string provisioningState = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> filterLocations = null, Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary deploymentStatus = null, string statusMessage = null, string correlationId = null, int? resourceCount = default(int?), int? parallelDeployments = default(int?), float? failureThresholdPercentage = default(float?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyState PolicyState(string odataId = null, string odataContext = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, Azure.Core.ResourceIdentifier policyDefinitionId = null, string effectiveParameters = null, bool? isCompliant = default(bool?), string subscriptionId = null, string resourceTypeString = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), string resourceGroup = null, string resourceTags = null, string policyAssignmentName = null, string policyAssignmentOwner = null, string policyAssignmentParameters = null, string policyAssignmentScope = null, string policyDefinitionName = null, string policyDefinitionAction = null, string policyDefinitionCategory = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, string policySetDefinitionName = null, string policySetDefinitionOwner = null, string policySetDefinitionCategory = null, string policySetDefinitionParameters = null, string managementGroupIds = null, string policyDefinitionReferenceId = null, string complianceState = null, Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails policyEvaluationDetails = null, System.Collections.Generic.IEnumerable<string> policyDefinitionGroupNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails> components = null, string policyDefinitionVersion = null, string policySetDefinitionVersion = null, string policyAssignmentVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicySummary PolicySummary(string odataId = null, string odataContext = null, Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults results = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary> policyAssignments = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults PolicySummaryResults(System.Uri queryResultsUri = null, int? nonCompliantResources = default(int?), int? nonCompliantPolicies = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> resourceDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> policyDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> policyGroupDetails = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord PolicyTrackedResourceRecord(Azure.Core.ResourceIdentifier trackedResourceId = null, Azure.ResourceManager.PolicyInsights.Models.PolicyDetails policyDetails = null, Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails createdBy = null, Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails lastModifiedBy = null, System.DateTimeOffset? lastUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment RemediationDeployment(Azure.Core.ResourceIdentifier remediatedResourceId = null, Azure.Core.ResourceIdentifier deploymentId = null, string status = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), Azure.ResponseError error = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary RemediationDeploymentSummary(int? totalDeployments = default(int?), int? successfulDeployments = default(int?), int? failedDeployments = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata SlimPolicyMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string metadataId = null, string category = null, string title = null, string owner = null, System.Uri additionalContentUri = null, System.BinaryData metadata = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails TrackedResourceModificationDetails(Azure.ResourceManager.PolicyInsights.Models.PolicyDetails policyDetails = null, Azure.Core.ResourceIdentifier deploymentId = null, System.DateTimeOffset? deploymentOn = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions
    {
        public ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource) { }
        public string Apply { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource ComponentPolicyStatesResource { get { throw null; } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class AttestationEvidence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>
    {
        public AttestationEvidence() { }
        public string Description { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckManagementGroupPolicyRestrictionsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>
    {
        public CheckManagementGroupPolicyRestrictionsContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.PendingField> PendingFields { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails ResourceDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckPolicyRestrictionsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>
    {
        public CheckPolicyRestrictionsContent(Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails resourceDetails) { }
        public bool? IncludeAuditEffect { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.PendingField> PendingFields { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails ResourceDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckPolicyRestrictionsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>
    {
        internal CheckPolicyRestrictionsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions> FieldRestrictions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult> PolicyEvaluations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckRestrictionEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails>
    {
        internal CheckRestrictionEvaluationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails> EvaluatedExpressions { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails IfNotExistsDetails { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckRestrictionsResourceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails>
    {
        public CheckRestrictionsResourceDetails(System.BinaryData resourceContent) { }
        public string ApiVersion { get { throw null; } set { } }
        public System.BinaryData ResourceContent { get { throw null; } }
        public string Scope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComplianceDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>
    {
        internal ComplianceDetail() { }
        public string ComplianceState { get { throw null; } }
        public int? Count { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentEventDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>
    {
        internal ComponentEventDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string PolicyDefinitionAction { get { throw null; } }
        public string PrincipalOid { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentExpressionEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails>
    {
        internal ComponentExpressionEvaluationDetails() { }
        public string Expression { get { throw null; } }
        public string ExpressionKind { get { throw null; } }
        public System.BinaryData ExpressionValue { get { throw null; } }
        public string Operator { get { throw null; } }
        public string Path { get { throw null; } }
        public string Result { get { throw null; } }
        public System.BinaryData TargetValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails>
    {
        internal ComponentPolicyEvaluationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails> EvaluatedExpressions { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>
    {
        internal ComponentPolicyState() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public string ComponentId { get { throw null; } }
        public string ComponentName { get { throw null; } }
        public string ComponentType { get { throw null; } }
        public string ODataContext { get { throw null; } }
        public string ODataId { get { throw null; } }
        public string PolicyAssignmentId { get { throw null; } }
        public string PolicyAssignmentName { get { throw null; } }
        public string PolicyAssignmentOwner { get { throw null; } }
        public string PolicyAssignmentParameters { get { throw null; } }
        public string PolicyAssignmentScope { get { throw null; } }
        public string PolicyAssignmentVersion { get { throw null; } }
        public string PolicyDefinitionAction { get { throw null; } }
        public string PolicyDefinitionCategory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PolicyDefinitionGroupNames { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionName { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public string PolicyDefinitionVersion { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails PolicyEvaluationDetails { get { throw null; } }
        public string PolicySetDefinitionCategory { get { throw null; } }
        public string PolicySetDefinitionId { get { throw null; } }
        public string PolicySetDefinitionName { get { throw null; } }
        public string PolicySetDefinitionOwner { get { throw null; } }
        public string PolicySetDefinitionParameters { get { throw null; } }
        public string PolicySetDefinitionVersion { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentPolicyStatesResource : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentPolicyStatesResource(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource left, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource left, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComponentStateDetails : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>
    {
        internal ComponentStateDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExpressionEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails>
    {
        internal ExpressionEvaluationDetails() { }
        public string Expression { get { throw null; } }
        public string ExpressionKind { get { throw null; } }
        public System.BinaryData ExpressionValue { get { throw null; } }
        public string Operator { get { throw null; } }
        public string Path { get { throw null; } }
        public string Result { get { throw null; } }
        public System.BinaryData TargetValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FieldRestriction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction>
    {
        internal FieldRestriction() { }
        public string DefaultValue { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyReference Policy { get { throw null; } }
        public string PolicyEffect { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult? Result { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.FieldRestriction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.FieldRestriction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FieldRestrictionResult : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FieldRestrictionResult(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult Audit { get { throw null; } }
        public static Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult Deny { get { throw null; } }
        public static Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult Removed { get { throw null; } }
        public static Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult Required { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult left, Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult left, Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FieldRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>
    {
        internal FieldRestrictions() { }
        public string Field { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction> Restrictions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IfNotExistsEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails>
    {
        internal IfNotExistsEvaluationDetails() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public int? TotalResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingField : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PendingField>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PendingField>
    {
        public PendingField(string field) { }
        public string Field { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PendingField System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PendingField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PendingField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PendingField System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PendingField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PendingField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PendingField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyAssignmentSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary>
    {
        internal PolicyAssignmentSummary() { }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary> PolicyDefinitions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary> PolicyGroups { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyComplianceState : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyComplianceState(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState Compliant { get { throw null; } }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState NonCompliant { get { throw null; } }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState left, Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState left, Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyDefinitionSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary>
    {
        internal PolicyDefinitionSummary() { }
        public string Effect { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PolicyDefinitionGroupNames { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDetails>
    {
        internal PolicyDetails() { }
        public string PolicyAssignmentDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public string PolicyAssignmentScope { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEvaluationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails>
    {
        internal PolicyEvaluationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails> EvaluatedExpressions { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails IfNotExistsDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult>
    {
        internal PolicyEvaluationResult() { }
        public Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails CheckRestrictionEvaluationDetails { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails EvaluationDetails { get { throw null; } }
        public string EvaluationResult { get { throw null; } }
        public string PolicyEffect { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyReference PolicyInfo { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>
    {
        internal PolicyEvent() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails> Components { get { throw null; } }
        public string EffectiveParameters { get { throw null; } }
        public bool? IsCompliant { get { throw null; } }
        public string ManagementGroupIds { get { throw null; } }
        public string ODataContext { get { throw null; } }
        public string ODataId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public string PolicyAssignmentName { get { throw null; } }
        public string PolicyAssignmentOwner { get { throw null; } }
        public string PolicyAssignmentParameters { get { throw null; } }
        public string PolicyAssignmentScope { get { throw null; } }
        public string PolicyDefinitionAction { get { throw null; } }
        public string PolicyDefinitionCategory { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionName { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public string PolicySetDefinitionCategory { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
        public string PolicySetDefinitionName { get { throw null; } }
        public string PolicySetDefinitionOwner { get { throw null; } }
        public string PolicySetDefinitionParameters { get { throw null; } }
        public string PrincipalOid { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } }
        public string ResourceTags { get { throw null; } }
        public string ResourceTypeString { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyEventType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyEventType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType left, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType left, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyGroupSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>
    {
        internal PolicyGroupSummary() { }
        public string PolicyGroupName { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyQuerySettings
    {
        public PolicyQuerySettings() { }
        public string Apply { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class PolicyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>
    {
        internal PolicyReference() { }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>
    {
        internal PolicyState() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails> Components { get { throw null; } }
        public string EffectiveParameters { get { throw null; } }
        public bool? IsCompliant { get { throw null; } }
        public string ManagementGroupIds { get { throw null; } }
        public string ODataContext { get { throw null; } }
        public string ODataId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public string PolicyAssignmentName { get { throw null; } }
        public string PolicyAssignmentOwner { get { throw null; } }
        public string PolicyAssignmentParameters { get { throw null; } }
        public string PolicyAssignmentScope { get { throw null; } }
        public string PolicyAssignmentVersion { get { throw null; } }
        public string PolicyDefinitionAction { get { throw null; } }
        public string PolicyDefinitionCategory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PolicyDefinitionGroupNames { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionName { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public string PolicyDefinitionVersion { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails PolicyEvaluationDetails { get { throw null; } }
        public string PolicySetDefinitionCategory { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
        public string PolicySetDefinitionName { get { throw null; } }
        public string PolicySetDefinitionOwner { get { throw null; } }
        public string PolicySetDefinitionParameters { get { throw null; } }
        public string PolicySetDefinitionVersion { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } }
        public string ResourceTags { get { throw null; } }
        public string ResourceTypeString { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyStateSummaryType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyStateSummaryType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType left, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType left, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyStateType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyStateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyStateType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStateType Default { get { throw null; } }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStateType Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType left, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyStateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType left, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicySummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>
    {
        internal PolicySummary() { }
        public string ODataContext { get { throw null; } }
        public string ODataId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary> PolicyAssignments { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicySummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicySummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicySummaryResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults>
    {
        internal PolicySummaryResults() { }
        public int? NonCompliantPolicies { get { throw null; } }
        public int? NonCompliantResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> PolicyDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> PolicyGroupDetails { get { throw null; } }
        public System.Uri QueryResultsUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> ResourceDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTrackedResourceRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>
    {
        internal PolicyTrackedResourceRecord() { }
        public Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyDetails PolicyDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier TrackedResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyTrackedResourceType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyTrackedResourceType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType left, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType left, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemediationDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment>
    {
        internal RemediationDeployment() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DeploymentId { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier RemediatedResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? ResourceLocation { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemediationDeploymentSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary>
    {
        internal RemediationDeploymentSummary() { }
        public int? FailedDeployments { get { throw null; } }
        public int? SuccessfulDeployments { get { throw null; } }
        public int? TotalDeployments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemediationFilters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>
    {
        public RemediationFilters() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceDiscoveryMode : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceDiscoveryMode(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode ExistingNonCompliant { get { throw null; } }
        public static Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode ReEvaluateCompliance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode left, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode left, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGroupResourceGetQueryResultsForResourceGroupComponentPolicyStatesOptions
    {
        public ResourceGroupResourceGetQueryResultsForResourceGroupComponentPolicyStatesOptions(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource) { }
        public string Apply { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource ComponentPolicyStatesResource { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class ResourceGroupResourceGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesOptions
    {
        public ResourceGroupResourceGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesOptions(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource) { }
        public string Apply { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource ComponentPolicyStatesResource { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string PolicyAssignmentName { get { throw null; } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class SlimPolicyMetadata : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>
    {
        internal SlimPolicyMetadata() { }
        public System.Uri AdditionalContentUri { get { throw null; } }
        public string Category { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string MetadataId { get { throw null; } }
        public string Owner { get { throw null; } }
        public string Title { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions
    {
        public SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions(string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource) { }
        public string Apply { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource ComponentPolicyStatesResource { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string PolicyDefinitionName { get { throw null; } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions
    {
        public SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource) { }
        public string Apply { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource ComponentPolicyStatesResource { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions
    {
        public SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions(string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource) { }
        public string Apply { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource ComponentPolicyStatesResource { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string PolicyAssignmentName { get { throw null; } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class TrackedResourceModificationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>
    {
        internal TrackedResourceModificationDetails() { }
        public Azure.Core.ResourceIdentifier DeploymentId { get { throw null; } }
        public System.DateTimeOffset? DeploymentOn { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyDetails PolicyDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
