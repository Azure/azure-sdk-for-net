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
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetAll(Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> CancelAtManagementGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> CancelAtManagementGroupAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckAtManagementGroupScope(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckAtManagementGroupScopeAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckAtResourceGroupScope(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckAtResourceGroupScopeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckAtSubscriptionScope(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckAtSubscriptionScopeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataCollection GetAllPolicyMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAtManagementGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAtManagementGroupAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetPolicyAttestation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> GetPolicyAttestationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyAttestationResource GetPolicyAttestationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyAttestationCollection GetPolicyAttestations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> GetPolicyMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetPolicyMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataResource GetPolicyMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetPolicyRemediation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetPolicyRemediationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationResource GetPolicyRemediationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationCollection GetPolicyRemediations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForManagementGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForManagementGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForManagementGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForManagementGroupAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForManagementGroupAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForManagementGroupAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForPolicyDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForPolicyDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForResourceGroupLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForResourceGroupLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForSubscriptionLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForSubscriptionLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForManagementGroup(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForManagementGroupAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForPolicyDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForPolicyDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForPolicySetDefinition(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForPolicySetDefinitionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForResourceGroupLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForResourceGroupLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForSubscriptionLevelPolicyAssignment(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForSubscriptionLevelPolicyAssignmentAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation TriggerResourceGroupEvaluation(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerResourceGroupEvaluationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation TriggerSubscriptionEvaluation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerSubscriptionEvaluationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyMetadataCollection : Azure.ResourceManager.ArmCollection
    {
        protected PolicyMetadataCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyMetadataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.PolicyMetadataData>
    {
        internal PolicyMetadataData() { }
        public string AdditionalContentUri { get { throw null; } }
        public string Category { get { throw null; } }
        public string Description { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string MetadataId { get { throw null; } }
        public string Owner { get { throw null; } }
        public string Requirements { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetAll(Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public int? ParallelDeployments { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public int? ResourceCount { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? ResourceDiscoveryMode { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> CancelAtResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> CancelAtResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string remediationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAtResource(Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAtResourceAsync(Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> CancelAtManagementGroup(Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> CancelAtManagementGroupAsync(Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckAtManagementGroupScope(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckAtManagementGroupScopeAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAtManagementGroup(Azure.Core.ResourceIdentifier scope, string remediationName, Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAtManagementGroupAsync(Azure.Core.ResourceIdentifier scope, string remediationName, Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource> GetPolicyAttestation(Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyAttestationResource>> GetPolicyAttestationAsync(Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyAttestationResource GetPolicyAttestationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyAttestationCollection GetPolicyAttestations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyMetadataResource GetPolicyMetadataResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource> GetPolicyRemediation(Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyRemediationResource>> GetPolicyRemediationAsync(Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyRemediationResource GetPolicyRemediationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyRemediationCollection GetPolicyRemediations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForManagementGroup(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForManagementGroup(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForManagementGroup(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForManagementGroupAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForManagementGroupAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForManagementGroupAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForPolicyDefinition(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinition(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinition(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForPolicyDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinition(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinition(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForResource(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResource(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResource(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResource(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForResourceAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResourceAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForResourceGroupLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForResourceGroupLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForSubscriptionLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForSubscriptionLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForManagementGroup(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForManagementGroupAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForPolicyDefinition(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForPolicyDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForPolicySetDefinition(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForPolicySetDefinitionAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForResource(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForResourceAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForResourceGroupLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForResourceGroupLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForSubscriptionLevelPolicyAssignment(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForSubscriptionLevelPolicyAssignmentAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckAtResourceGroupScope(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckAtResourceGroupScopeAsync(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForResourceGroup(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroup(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroup(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResourceGroup(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForResourceGroupAsync(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForResourceGroupAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForResourceGroup(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForResourceGroupAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerResourceGroupEvaluation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerResourceGroupEvaluationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult> CheckAtSubscriptionScope(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>> CheckAtSubscriptionScopeAsync(Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults> GetQueryResultsForSubscription(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscription(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscription(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForSubscription(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>> GetQueryResultsForSubscriptionAsync(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource componentPolicyStatesResource, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord> GetQueryResultsForSubscriptionAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults> SummarizeForSubscription(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>> SummarizeForSubscriptionAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerSubscriptionEvaluation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerSubscriptionEvaluationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePolicyInsightsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePolicyInsightsTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAll(Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyMetadataCollection GetAllPolicyMetadata() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> GetPolicyMetadata(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetPolicyMetadataAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PolicyInsights.Models
{
    public static partial class ArmPolicyInsightsModelFactory
    {
        public static Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence AttestationEvidence(string description = null, System.Uri sourceUri = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions AttestationsListForResourceQueryOptions(int? top = default(int?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent CheckManagementGroupPolicyRestrictionsContent(Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails resourceDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PendingField> pendingFields = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent CheckPolicyRestrictionsContent(Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails resourceDetails, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PendingField> pendingFields) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent CheckPolicyRestrictionsContent(Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails resourceDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PendingField> pendingFields = null, bool? includeAuditEffect = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult CheckPolicyRestrictionsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions> fieldRestrictions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult> policyEvaluations = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails CheckRestrictionEvaluationDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails> evaluatedExpressions = null, Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails ifNotExistsDetails = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails CheckRestrictionsResourceDetails(System.BinaryData resourceContent = null, string apiVersion = null, string scope = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail ComplianceDetail(string complianceState = null, int? count = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails ComponentEventDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Guid? tenantId = default(System.Guid?), string principalOid = null, string policyDefinitionAction = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails ComponentEventDetails(string id = null, string type = null, string name = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), System.Guid? tenantId = default(System.Guid?), string principalOid = null, string policyDefinitionAction = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails ComponentExpressionEvaluationDetails(string result = null, string expression = null, string expressionKind = null, string path = null, System.BinaryData expressionValue = null, System.BinaryData targetValue = null, string @operator = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails ComponentPolicyEvaluationDetails(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails> evaluatedExpressions = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState ComponentPolicyState(string odataId = null, string odataContext = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string componentId = null, string componentType = null, string componentName = null, string resourceId = null, string policyAssignmentId = null, string policyDefinitionId = null, string subscriptionId = null, string resourceType = null, string resourceLocation = null, string resourceGroup = null, string policyAssignmentName = null, string policyAssignmentOwner = null, string policyAssignmentParameters = null, string policyAssignmentScope = null, string policyDefinitionName = null, string policyDefinitionAction = null, string policyDefinitionCategory = null, string policySetDefinitionId = null, string policySetDefinitionName = null, string policySetDefinitionOwner = null, string policySetDefinitionCategory = null, string policySetDefinitionParameters = null, string policyDefinitionReferenceId = null, string complianceState = null, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails policyEvaluationDetails = null, System.Collections.Generic.IEnumerable<string> policyDefinitionGroupNames = null, string policyDefinitionVersion = null, string policySetDefinitionVersion = null, string policyAssignmentVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions ComponentPolicyStatesListQueryResultsForResourceQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string expand = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults ComponentPolicyStatesQueryResults(string odataContext = null, int? odataCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> value = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails ComponentStateDetails(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string complianceState = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails ComponentStateDetails(string id = null, string type = null, string name = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string complianceState = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails ExpressionEvaluationDetails(string result = null, string expression = null, string expressionKind = null, string path = null, System.BinaryData expressionValue = null, System.BinaryData targetValue = null, string @operator = null) { throw null; }
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
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult PolicyEvaluationResult(Azure.ResourceManager.PolicyInsights.Models.PolicyReference policyInfo = null, string evaluationResult = null, Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails evaluationDetails = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEvent PolicyEvent(string odataId = null, string odataContext = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, Azure.Core.ResourceIdentifier policyDefinitionId = null, string effectiveParameters = null, bool? isCompliant = default(bool?), string subscriptionId = null, string resourceTypeString = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), string resourceGroup = null, string resourceTags = null, string policyAssignmentName = null, string policyAssignmentOwner = null, string policyAssignmentParameters = null, string policyAssignmentScope = null, string policyDefinitionName = null, string policyDefinitionAction = null, string policyDefinitionCategory = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, string policySetDefinitionName = null, string policySetDefinitionOwner = null, string policySetDefinitionCategory = null, string policySetDefinitionParameters = null, string managementGroupIds = null, string policyDefinitionReferenceId = null, string complianceState = null, System.Guid? tenantId = default(System.Guid?), string principalOid = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails> components = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions PolicyEventsListQueryResultsForManagementGroupQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions PolicyEventsListQueryResultsForResourceGroupQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions PolicyEventsListQueryResultsForResourceQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string expand = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions PolicyEventsListQueryResultsForSubscriptionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary PolicyGroupSummary(string policyGroupName = null, Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults results = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataData PolicyMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string metadataId = null, string category = null, string title = null, string owner = null, string additionalContentUri = null, System.BinaryData metadata = null, string description = null, string requirements = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataData PolicyMetadataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string metadataId = null, string category = null, string title = null, string owner = null, System.Uri additionalContentUri = null, System.BinaryData metadata = null, string description = null, string requirements = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions PolicyMetadataListQueryOptions(int? top = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyReference PolicyReference(Azure.Core.ResourceIdentifier policyDefinitionId = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, string policyDefinitionReferenceId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationData PolicyRemediationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, string policyDefinitionReferenceId = null, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? resourceDiscoveryMode = default(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode?), string provisioningState = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), Azure.ResourceManager.PolicyInsights.Models.RemediationFilters filter = null, Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary deploymentStatus = null, string statusMessage = null, string correlationId = null, int? resourceCount = default(int?), int? parallelDeployments = default(int?), float? failureThresholdPercentage = default(float?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyRemediationData PolicyRemediationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, string policyDefinitionReferenceId = null, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? resourceDiscoveryMode = default(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode?), string provisioningState = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> filterLocations = null, Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary deploymentStatus = null, string statusMessage = null, string correlationId = null, int? resourceCount = default(int?), int? parallelDeployments = default(int?), float? failureThresholdPercentage = default(float?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyState PolicyState(string odataId = null, string odataContext = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier resourceId = null, Azure.Core.ResourceIdentifier policyAssignmentId = null, Azure.Core.ResourceIdentifier policyDefinitionId = null, string effectiveParameters = null, bool? isCompliant = default(bool?), string subscriptionId = null, string resourceTypeString = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), string resourceGroup = null, string resourceTags = null, string policyAssignmentName = null, string policyAssignmentOwner = null, string policyAssignmentParameters = null, string policyAssignmentScope = null, string policyDefinitionName = null, string policyDefinitionAction = null, string policyDefinitionCategory = null, Azure.Core.ResourceIdentifier policySetDefinitionId = null, string policySetDefinitionName = null, string policySetDefinitionOwner = null, string policySetDefinitionCategory = null, string policySetDefinitionParameters = null, string managementGroupIds = null, string policyDefinitionReferenceId = null, string complianceState = null, Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails policyEvaluationDetails = null, System.Collections.Generic.IEnumerable<string> policyDefinitionGroupNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails> components = null, string policyDefinitionVersion = null, string policySetDefinitionVersion = null, string policyAssignmentVersion = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions PolicyStatesListQueryResultsForManagementGroupQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions PolicyStatesListQueryResultsForResourceGroupQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions PolicyStatesListQueryResultsForResourceQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string expand = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions PolicyStatesListQueryResultsForSubscriptionQueryOptions(int? top = default(int?), string orderBy = null, string select = null, System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null, string apply = null, string skipToken = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions PolicyStatesSummarizeForManagementGroupQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions PolicyStatesSummarizeForPolicyDefinitionQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions PolicyStatesSummarizeForPolicySetDefinitionQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions PolicyStatesSummarizeForResourceGroupQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions PolicyStatesSummarizeForResourceQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions PolicyStatesSummarizeForSubscriptionQueryOptions(int? top = default(int?), System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicySummary PolicySummary(string odataId = null, string odataContext = null, Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults results = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary> policyAssignments = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults PolicySummaryResults(System.Uri queryResultsUri = null, int? nonCompliantResources = default(int?), int? nonCompliantPolicies = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> resourceDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> policyDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> policyGroupDetails = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord PolicyTrackedResourceRecord(Azure.Core.ResourceIdentifier trackedResourceId = null, Azure.ResourceManager.PolicyInsights.Models.PolicyDetails policyDetails = null, Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails createdBy = null, Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails lastModifiedBy = null, System.DateTimeOffset? lastUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions(int? top = default(int?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions(int? top = default(int?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions PolicyTrackedResourcesListQueryResultsForResourceQueryOptions(int? top = default(int?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions(int? top = default(int?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment RemediationDeployment(Azure.Core.ResourceIdentifier remediatedResourceId = null, Azure.Core.ResourceIdentifier deploymentId = null, string status = null, Azure.Core.AzureLocation? resourceLocation = default(Azure.Core.AzureLocation?), Azure.ResponseError error = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary RemediationDeploymentSummary(int? totalDeployments = default(int?), int? successfulDeployments = default(int?), int? failedDeployments = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationFilters RemediationFilters(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> resourceIds = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions RemediationsListDeploymentsAtManagementGroupQueryOptions(int? top = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions RemediationsListDeploymentsAtResourceQueryOptions(int? top = default(int?)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions RemediationsListForResourceQueryOptions(int? top = default(int?), string filter = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata SlimPolicyMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string metadataId = null, string category = null, string title = null, string owner = null, System.Uri additionalContentUri = null, System.BinaryData metadata = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata SlimPolicyMetadata(string metadataId = null, string category = null, string title = null, string owner = null, string additionalContentUri = null, System.BinaryData metadata = null, string id = null, string type = null, string name = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.SummarizeResults SummarizeResults(string odataContext = null, int? odataCount = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> value = null) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails TrackedResourceModificationDetails(Azure.ResourceManager.PolicyInsights.Models.PolicyDetails policyDetails = null, Azure.Core.ResourceIdentifier deploymentId = null, System.DateTimeOffset? deploymentOn = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class AttestationEvidence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>
    {
        public AttestationEvidence() { }
        public string Description { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AttestationsListForResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions>
    {
        public AttestationsListForResourceQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.AttestationsListForResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckManagementGroupPolicyRestrictionsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent>
    {
        public CheckManagementGroupPolicyRestrictionsContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.PendingField> PendingFields { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails ResourceDetails { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckManagementGroupPolicyRestrictionsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckPolicyRestrictionsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult>
    {
        internal CheckPolicyRestrictionsResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult> ContentEvaluationResultPolicyEvaluations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions> FieldRestrictions { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckPolicyRestrictionsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionEvaluationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentEventDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails>
    {
        internal ComponentEventDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string PolicyDefinitionAction { get { throw null; } }
        public string PrincipalOid { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentEventDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentExpressionEvaluationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyEvaluationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string OdataContext { get { throw null; } }
        public string OdataId { get { throw null; } }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>
    {
        public ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>
    {
        public ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions>
    {
        public ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyStatesListQueryResultsForResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions>
    {
        public ComponentPolicyStatesListQueryResultsForResourceQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>
    {
        public ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions>
    {
        public ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesListQueryResultsForSubscriptionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentPolicyStatesQueryResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>
    {
        internal ComponentPolicyStatesQueryResults() { }
        public string OdataContext { get { throw null; } }
        public int? OdataCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyState> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesQueryResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComponentPolicyStatesResource : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComponentPolicyStatesResource(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource left, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource left, Azure.ResourceManager.PolicyInsights.Models.ComponentPolicyStatesResource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComponentStateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails>
    {
        internal ComponentStateDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ComponentStateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.FieldRestriction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.FieldRestriction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult left, Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult left, Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FieldRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions>
    {
        internal FieldRestrictions() { }
        public string Field { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction> Restrictions { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PendingField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PendingField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState left, Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string EvaluationResult { get { throw null; } }
        public string PolicyEffect { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyReference PolicyInfo { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string OdataContext { get { throw null; } }
        public string OdataId { get { throw null; } }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForManagementGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions>
    {
        public PolicyEventsListQueryResultsForManagementGroupQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForManagementGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions>
    {
        public PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicyDefinitionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions>
    {
        public PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForPolicySetDefinitionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>
    {
        public PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForResourceGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions>
    {
        public PolicyEventsListQueryResultsForResourceGroupQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions>
    {
        public PolicyEventsListQueryResultsForResourceQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>
    {
        public PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyEventsListQueryResultsForSubscriptionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions>
    {
        public PolicyEventsListQueryResultsForSubscriptionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyEventsListQueryResultsForSubscriptionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyEventType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyEventType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyEventType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType left, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyEventType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyEventType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyEventType left, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyGroupSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>
    {
        internal PolicyGroupSummary() { }
        public string PolicyGroupName { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyMetadataListQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions>
    {
        public PolicyMetadataListQueryOptions() { }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyMetadataListQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyReference>
    {
        internal PolicyReference() { }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string OdataContext { get { throw null; } }
        public string OdataId { get { throw null; } }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForManagementGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions>
    {
        public PolicyStatesListQueryResultsForManagementGroupQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForManagementGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>
    {
        public PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicyDefinitionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions>
    {
        public PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForPolicySetDefinitionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>
    {
        public PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForResourceGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions>
    {
        public PolicyStatesListQueryResultsForResourceGroupQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions>
    {
        public PolicyStatesListQueryResultsForResourceQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>
    {
        public PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesListQueryResultsForSubscriptionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions>
    {
        public PolicyStatesListQueryResultsForSubscriptionQueryOptions() { }
        public string Apply { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesListQueryResultsForSubscriptionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForManagementGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions>
    {
        public PolicyStatesSummarizeForManagementGroupQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForManagementGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForPolicyDefinitionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions>
    {
        public PolicyStatesSummarizeForPolicyDefinitionQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicyDefinitionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForPolicySetDefinitionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions>
    {
        public PolicyStatesSummarizeForPolicySetDefinitionQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForPolicySetDefinitionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions>
    {
        public PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForResourceGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions>
    {
        public PolicyStatesSummarizeForResourceGroupQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions>
    {
        public PolicyStatesSummarizeForResourceQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions>
    {
        public PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionLevelPolicyAssignmentQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyStatesSummarizeForSubscriptionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions>
    {
        public PolicyStatesSummarizeForSubscriptionQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public System.DateTimeOffset? From { get { throw null; } set { } }
        public System.DateTimeOffset? To { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyStatesSummarizeForSubscriptionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyStateSummaryType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyStateSummaryType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType left, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType left, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyStateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyStateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyStateType left, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicySummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicySummary>
    {
        internal PolicySummary() { }
        public string OdataContext { get { throw null; } }
        public string OdataId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary> PolicyAssignments { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicySummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicySummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions>
    {
        public PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForManagementGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions>
    {
        public PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTrackedResourcesListQueryResultsForResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions>
    {
        public PolicyTrackedResourcesListQueryResultsForResourceQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions>
    {
        public PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesListQueryResultsForSubscriptionQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyTrackedResourceType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyTrackedResourceType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType left, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourceType? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationFilters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationFilters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.RemediationFilters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationFilters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationFilters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemediationsListDeploymentsAtManagementGroupQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions>
    {
        public RemediationsListDeploymentsAtManagementGroupQueryOptions() { }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtManagementGroupQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemediationsListDeploymentsAtResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions>
    {
        public RemediationsListDeploymentsAtResourceQueryOptions() { }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListDeploymentsAtResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemediationsListForResourceQueryOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions>
    {
        public RemediationsListForResourceQueryOptions() { }
        public string Filter { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.RemediationsListForResourceQueryOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode left, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode left, Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SlimPolicyMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>
    {
        internal SlimPolicyMetadata() { }
        public string AdditionalContentUri { get { throw null; } }
        public string Category { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string MetadataId { get { throw null; } }
        public string Name { get { throw null; } }
        public string Owner { get { throw null; } }
        public string Title { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SummarizeResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>
    {
        internal SummarizeResults() { }
        public string OdataContext { get { throw null; } }
        public int? OdataCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.SummarizeResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.SummarizeResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.SummarizeResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.SummarizeResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.SummarizeResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrackedResourceModificationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>
    {
        internal TrackedResourceModificationDetails() { }
        public Azure.Core.ResourceIdentifier DeploymentId { get { throw null; } }
        public System.DateTimeOffset? DeploymentOn { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyDetails PolicyDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
