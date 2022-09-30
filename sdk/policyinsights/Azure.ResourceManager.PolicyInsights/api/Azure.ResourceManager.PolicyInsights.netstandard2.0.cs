namespace Azure.ResourceManager.PolicyInsights
{
    public partial class AttestationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.AttestationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.AttestationResource>, System.Collections.IEnumerable
    {
        protected AttestationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.AttestationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attestationName, Azure.ResourceManager.PolicyInsights.AttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.AttestationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attestationName, Azure.ResourceManager.PolicyInsights.AttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.AttestationResource> Get(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.AttestationResource> GetAll(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.AttestationResource> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.AttestationResource>> GetAsync(string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PolicyInsights.AttestationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.AttestationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PolicyInsights.AttestationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.AttestationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttestationData : Azure.ResourceManager.Models.ResourceData
    {
        public AttestationData(Azure.Core.ResourceIdentifier policyAssignmentId) { }
        public string Comments { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyComplianceState? ComplianceState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.AttestationEvidence> Evidence { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastComplianceStateChangeOn { get { throw null; } }
        public string Owner { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class AttestationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttestationResource() { }
        public virtual Azure.ResourceManager.PolicyInsights.AttestationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string attestationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.AttestationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.AttestationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.AttestationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.AttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.AttestationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.AttestationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.AttestationResource> GetAttestation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.AttestationResource>> GetAttestationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string attestationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.AttestationResource GetAttestationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.AttestationCollection GetAttestations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetPolicyEventQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> GetPolicyMetadata(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetPolicyMetadataAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.PolicyMetadataResource GetPolicyMetadataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetPolicyStateQueryResultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResource> GetQueryResultsForManagementGroupPolicyTrackedResources(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResource> GetQueryResultsForManagementGroupPolicyTrackedResourcesAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEvents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEventsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinitionPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicyDefinitionPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEvents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEventsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResource> GetQueryResultsForResourceGroupPolicyTrackedResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResource> GetQueryResultsForResourceGroupPolicyTrackedResourcesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyEventType policyEventsResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateType policyStatesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResource> GetQueryResultsForSubscriptionPolicyTrackedResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResource> GetQueryResultsForSubscriptionPolicyTrackedResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType policyTrackedResourcesResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource> GetRemediation(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource>> GetRemediationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.RemediationResource GetRemediationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.RemediationCollection GetRemediations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicyDefinitionPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicyDefinitionPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicySetDefinitionPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForPolicySetDefinitionPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policySetDefinitionName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForResourceGroupPolicyStates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForResourceGroupPolicyStatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string policyAssignmentName, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyState(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyState(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStateAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.PolicySummary> SummarizePolicyStateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PolicyInsights.Models.PolicyStateSummaryType policyStatesSummaryResource, Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAll(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.Models.SlimPolicyMetadata>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyMetadataData : Azure.ResourceManager.Models.ResourceData
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
    }
    public partial class PolicyMetadataResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyMetadataResource() { }
        public virtual Azure.ResourceManager.PolicyInsights.PolicyMetadataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.PolicyMetadataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RemediationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.RemediationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.RemediationResource>, System.Collections.IEnumerable
    {
        protected RemediationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.RemediationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string remediationName, Azure.ResourceManager.PolicyInsights.RemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.RemediationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string remediationName, Azure.ResourceManager.PolicyInsights.RemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource> Get(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.RemediationResource> GetAll(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.RemediationResource> GetAllAsync(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource>> GetAsync(string remediationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PolicyInsights.RemediationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PolicyInsights.RemediationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PolicyInsights.RemediationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PolicyInsights.RemediationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RemediationData : Azure.ResourceManager.Models.ResourceData
    {
        public RemediationData() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.RemediationDeploymentSummary DeploymentStatus { get { throw null; } }
        public float? FailureThresholdPercentage { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> FilterLocations { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public int? ParallelDeployments { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } set { } }
        public string PolicyDefinitionReferenceId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public int? ResourceCount { get { throw null; } set { } }
        public Azure.ResourceManager.PolicyInsights.Models.ResourceDiscoveryMode? ResourceDiscoveryMode { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
    }
    public partial class RemediationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RemediationResource() { }
        public virtual Azure.ResourceManager.PolicyInsights.RemediationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource> CancelAtResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource>> CancelAtResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceId, string remediationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.RemediationResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.RemediationResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PolicyInsights.RemediationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeployments(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PolicyInsights.Models.RemediationDeployment> GetDeploymentsAsync(Azure.ResourceManager.PolicyInsights.Models.QueryOptions queryOptions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.RemediationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.RemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PolicyInsights.RemediationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PolicyInsights.RemediationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PolicyInsights.Models
{
    public partial class AttestationEvidence
    {
        public AttestationEvidence() { }
        public string Description { get { throw null; } set { } }
        public System.Uri SourceUri { get { throw null; } set { } }
    }
    public partial class CheckManagementGroupPolicyRestrictionsContent
    {
        public CheckManagementGroupPolicyRestrictionsContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.PendingField> PendingFields { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails ResourceDetails { get { throw null; } set { } }
    }
    public partial class CheckPolicyRestrictionsContent
    {
        public CheckPolicyRestrictionsContent(Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails resourceDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PolicyInsights.Models.PendingField> PendingFields { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.CheckRestrictionsResourceDetails ResourceDetails { get { throw null; } }
    }
    public partial class CheckPolicyRestrictionsResult
    {
        internal CheckPolicyRestrictionsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictions> FieldRestrictions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationResult> PolicyEvaluations { get { throw null; } }
    }
    public partial class CheckRestrictionsResourceDetails
    {
        public CheckRestrictionsResourceDetails(System.BinaryData resourceContent) { }
        public string ApiVersion { get { throw null; } set { } }
        public System.BinaryData ResourceContent { get { throw null; } }
        public string Scope { get { throw null; } set { } }
    }
    public partial class ComplianceDetail
    {
        internal ComplianceDetail() { }
        public string ComplianceState { get { throw null; } }
        public int? Count { get { throw null; } }
    }
    public partial class ComponentEventDetails : Azure.ResourceManager.Models.ResourceData
    {
        internal ComponentEventDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string PolicyDefinitionAction { get { throw null; } }
        public string PrincipalOid { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class ComponentStateDetails : Azure.ResourceManager.Models.ResourceData
    {
        internal ComponentStateDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ComplianceState { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class ExpressionEvaluationDetails
    {
        internal ExpressionEvaluationDetails() { }
        public string Expression { get { throw null; } }
        public string ExpressionKind { get { throw null; } }
        public System.BinaryData ExpressionValue { get { throw null; } }
        public string Operator { get { throw null; } }
        public string Path { get { throw null; } }
        public string Result { get { throw null; } }
        public System.BinaryData TargetValue { get { throw null; } }
    }
    public partial class FieldRestriction
    {
        internal FieldRestriction() { }
        public string DefaultValue { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyReference Policy { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult? Result { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FieldRestrictionResult : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.FieldRestrictionResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FieldRestrictionResult(string value) { throw null; }
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
    public partial class FieldRestrictions
    {
        internal FieldRestrictions() { }
        public string Field { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.FieldRestriction> Restrictions { get { throw null; } }
    }
    public partial class IfNotExistsEvaluationDetails
    {
        internal IfNotExistsEvaluationDetails() { }
        public string ResourceId { get { throw null; } }
        public int? TotalResources { get { throw null; } }
    }
    public partial class PendingField
    {
        public PendingField(string field) { }
        public string Field { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
    }
    public partial class PolicyAssignmentSummary
    {
        internal PolicyAssignmentSummary() { }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyDefinitionSummary> PolicyDefinitions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyGroupSummary> PolicyGroups { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
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
    public partial class PolicyDefinitionSummary
    {
        internal PolicyDefinitionSummary() { }
        public string Effect { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PolicyDefinitionGroupNames { get { throw null; } }
        public string PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
    }
    public partial class PolicyDetails
    {
        internal PolicyDetails() { }
        public string PolicyAssignmentDisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public string PolicyAssignmentScope { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
    }
    public partial class PolicyEvaluationDetails
    {
        internal PolicyEvaluationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ExpressionEvaluationDetails> EvaluatedExpressions { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.IfNotExistsEvaluationDetails IfNotExistsDetails { get { throw null; } }
    }
    public partial class PolicyEvaluationResult
    {
        internal PolicyEvaluationResult() { }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyEvaluationDetails EvaluationDetails { get { throw null; } }
        public string EvaluationResult { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyReference PolicyInfo { get { throw null; } }
    }
    public partial class PolicyEvent
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
        public string ResourceType { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
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
    public partial class PolicyGroupSummary
    {
        internal PolicyGroupSummary() { }
        public string PolicyGroupName { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
    }
    public partial class PolicyReference
    {
        internal PolicyReference() { }
        public Azure.Core.ResourceIdentifier PolicyAssignmentId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicyDefinitionId { get { throw null; } }
        public string PolicyDefinitionReferenceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PolicySetDefinitionId { get { throw null; } }
    }
    public partial class PolicyState
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
        public string ResourceType { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
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
    public partial class PolicySummary
    {
        internal PolicySummary() { }
        public string OdataContext { get { throw null; } }
        public string OdataId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.PolicyAssignmentSummary> PolicyAssignments { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicySummaryResults Results { get { throw null; } }
    }
    public partial class PolicySummaryResults
    {
        internal PolicySummaryResults() { }
        public int? NonCompliantPolicies { get { throw null; } }
        public int? NonCompliantResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> PolicyDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> PolicyGroupDetails { get { throw null; } }
        public System.Uri QueryResultsUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PolicyInsights.Models.ComplianceDetail> ResourceDetails { get { throw null; } }
    }
    public partial class PolicyTrackedResource
    {
        internal PolicyTrackedResource() { }
        public Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails CreatedBy { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.TrackedResourceModificationDetails LastModifiedBy { get { throw null; } }
        public System.DateTimeOffset? LastUpdateUtc { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyDetails PolicyDetails { get { throw null; } }
        public string TrackedResourceId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyTrackedResourcesResourceType : System.IEquatable<Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyTrackedResourcesResourceType(string value) { throw null; }
        public static Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType left, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType left, Azure.ResourceManager.PolicyInsights.Models.PolicyTrackedResourcesResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueryOptions
    {
        public QueryOptions() { }
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
    public partial class RemediationDeployment
    {
        internal RemediationDeployment() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string RemediatedResourceId { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class RemediationDeploymentSummary
    {
        internal RemediationDeploymentSummary() { }
        public int? FailedDeployments { get { throw null; } }
        public int? SuccessfulDeployments { get { throw null; } }
        public int? TotalDeployments { get { throw null; } }
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
    public partial class SlimPolicyMetadata : Azure.ResourceManager.Models.ResourceData
    {
        internal SlimPolicyMetadata() { }
        public System.Uri AdditionalContentUri { get { throw null; } }
        public string Category { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string MetadataId { get { throw null; } }
        public string Owner { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class TrackedResourceModificationDetails
    {
        internal TrackedResourceModificationDetails() { }
        public string DeploymentId { get { throw null; } }
        public System.DateTimeOffset? DeploymentOn { get { throw null; } }
        public Azure.ResourceManager.PolicyInsights.Models.PolicyDetails PolicyDetails { get { throw null; } }
    }
}
