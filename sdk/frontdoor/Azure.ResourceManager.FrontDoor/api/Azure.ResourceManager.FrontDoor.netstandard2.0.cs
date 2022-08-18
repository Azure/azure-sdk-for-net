namespace Azure.ResourceManager.FrontDoor
{
    public partial class ExperimentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.ExperimentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.ExperimentResource>, System.Collections.IEnumerable
    {
        protected ExperimentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ExperimentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.FrontDoor.ExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ExperimentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.FrontDoor.ExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource> Get(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.ExperimentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.ExperimentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource>> GetAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.ExperimentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.ExperimentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.ExperimentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.ExperimentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExperimentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ExperimentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.State? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.Endpoint EndpointA { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.Endpoint EndpointB { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState? ResourceState { get { throw null; } }
        public System.Uri ScriptFileUri { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ExperimentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExperimentResource() { }
        public virtual Azure.ResourceManager.FrontDoor.ExperimentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string experimentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard> GetLatencyScorecardsReport(Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval aggregationInterval, string endDateTimeUTC = null, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>> GetLatencyScorecardsReportAsync(Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval aggregationInterval, string endDateTimeUTC = null, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.Timeseries> GetTimeseriesReport(System.DateTimeOffset startDateTimeUTC, System.DateTimeOffset endDateTimeUTC, Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval aggregationInterval, Azure.ResourceManager.FrontDoor.Models.TimeseriesType timeseriesType, string endpoint = null, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.Timeseries>> GetTimeseriesReportAsync(System.DateTimeOffset startDateTimeUTC, System.DateTimeOffset endDateTimeUTC, Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval aggregationInterval, Azure.ResourceManager.FrontDoor.Models.TimeseriesType timeseriesType, string endpoint = null, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ExperimentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.ExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ExperimentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.ExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorResource>, System.Collections.IEnumerable
    {
        protected FrontDoorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string frontDoorName, Azure.ResourceManager.FrontDoor.FrontDoorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string frontDoorName, Azure.ResourceManager.FrontDoor.FrontDoorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> Get(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> GetAsync(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FrontDoorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.BackendPool> BackendPools { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings BackendPoolsSettings { get { throw null; } set { } }
        public string Cname { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ExtendedProperties { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public string FrontdoorId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.FrontendEndpointData> FrontendEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.HealthProbeSettingsModel> HealthProbeSettings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.LoadBalancingSettingsModel> LoadBalancingSettings { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RoutingRule> RoutingRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.FrontDoor.RulesEngineData> RulesEngines { get { throw null; } }
    }
    public static partial class FrontDoorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityOutput> CheckFrontDoorNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityOutput>> CheckFrontDoorNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityOutput> CheckFrontDoorNameAvailabilityWithSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityOutput>> CheckFrontDoorNameAvailabilityWithSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.FrontDoor.Models.CheckNameAvailabilityInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.ExperimentResource GetExperimentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> GetFrontDoorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorResource GetFrontDoorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorCollection GetFrontDoors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontendEndpointResource GetFrontendEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition> GetManagedRuleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition> GetManagedRuleSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource> GetProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource>> GetProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.ProfileResource GetProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FrontDoor.ProfileCollection GetProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FrontDoor.ProfileResource> GetProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.ProfileResource> GetProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.RulesEngineResource GetRulesEngineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyCollection GetWebApplicationFirewallPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> GetWebApplicationFirewallPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> GetWebApplicationFirewallPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource GetWebApplicationFirewallPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class FrontDoorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorResource() { }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string frontDoorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> GetFrontendEndpoint(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>> GetFrontendEndpointAsync(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontendEndpointCollection GetFrontendEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.RulesEngineResource> GetRulesEngine(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.RulesEngineResource>> GetRulesEngineAsync(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.RulesEngineCollection GetRulesEngines() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeContentEndpoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.PurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeContentEndpointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.PurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.FrontDoorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.FrontDoorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.ValidateCustomDomainOutput> ValidateCustomDomain(Azure.ResourceManager.FrontDoor.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.ValidateCustomDomainOutput>> ValidateCustomDomainAsync(Azure.ResourceManager.FrontDoor.Models.ValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontendEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>, System.Collections.IEnumerable
    {
        protected FrontendEndpointCollection() { }
        public virtual Azure.Response<bool> Exists(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> Get(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>> GetAsync(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontendEndpointData : Azure.ResourceManager.FrontDoor.Models.SubResource
    {
        public FrontendEndpointData() { }
        public Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration CustomHttpsConfiguration { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState? CustomHttpsProvisioningState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate? CustomHttpsProvisioningSubstate { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState? SessionAffinityEnabledState { get { throw null; } set { } }
        public int? SessionAffinityTtlSeconds { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
    }
    public partial class FrontendEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontendEndpointResource() { }
        public virtual Azure.ResourceManager.FrontDoor.FrontendEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string frontDoorName, string frontendEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableHttps(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableHttpsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableHttps(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration customHttpsConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableHttpsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration customHttpsConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.ProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.ProfileResource>, System.Collections.IEnumerable
    {
        protected ProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.FrontDoor.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.FrontDoor.ProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.ProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.ProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.ProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.ProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.ProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.ProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProfileData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ProfileData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.FrontDoor.Models.State? EnabledState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState? ResourceState { get { throw null; } }
    }
    public partial class ProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProfileResource() { }
        public virtual Azure.ResourceManager.FrontDoor.ProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource> GetExperiment(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ExperimentResource>> GetExperimentAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.ExperimentCollection GetExperiments() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint> GetPreconfiguredEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint> GetPreconfiguredEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.ProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.ProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.ProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.ProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RulesEngineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.RulesEngineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.RulesEngineResource>, System.Collections.IEnumerable
    {
        protected RulesEngineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.RulesEngineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rulesEngineName, Azure.ResourceManager.FrontDoor.RulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.RulesEngineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rulesEngineName, Azure.ResourceManager.FrontDoor.RulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.RulesEngineResource> Get(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.RulesEngineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.RulesEngineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.RulesEngineResource>> GetAsync(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.RulesEngineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.RulesEngineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.RulesEngineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.RulesEngineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RulesEngineData : Azure.ResourceManager.Models.ResourceData
    {
        public RulesEngineData() { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule> Rules { get { throw null; } }
    }
    public partial class RulesEngineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RulesEngineResource() { }
        public virtual Azure.ResourceManager.FrontDoor.RulesEngineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string frontDoorName, string rulesEngineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.RulesEngineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.RulesEngineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.RulesEngineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.RulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.RulesEngineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.RulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WebApplicationFirewallPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>, System.Collections.IEnumerable
    {
        protected WebApplicationFirewallPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WebApplicationFirewallPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WebApplicationFirewallPolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> FrontendEndpointLinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet> ManagedRuleSets { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.PolicySettings PolicySettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.PolicyResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> RoutingRuleLinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.CustomRule> Rules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> SecurityPolicyLinks { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName? SkuName { get { throw null; } set { } }
    }
    public partial class WebApplicationFirewallPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WebApplicationFirewallPolicyResource() { }
        public virtual Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.WebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.WebApplicationFirewallPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.WebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.FrontDoor.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ActionType Block { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ActionType Log { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ActionType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.ActionType left, Azure.ResourceManager.FrontDoor.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.ActionType left, Azure.ResourceManager.FrontDoor.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AggregationInterval : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.AggregationInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AggregationInterval(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.AggregationInterval Daily { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.AggregationInterval Hourly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.AggregationInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.AggregationInterval left, Azure.ResourceManager.FrontDoor.Models.AggregationInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.AggregationInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.AggregationInterval left, Azure.ResourceManager.FrontDoor.Models.AggregationInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Availability : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.Availability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Availability(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.Availability Available { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Availability Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.Availability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.Availability left, Azure.ResourceManager.FrontDoor.Models.Availability right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.Availability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.Availability left, Azure.ResourceManager.FrontDoor.Models.Availability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Backend
    {
        public Backend() { }
        public string Address { get { throw null; } set { } }
        public string BackendHostHeader { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.BackendEnabledState? EnabledState { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus? PrivateEndpointStatus { get { throw null; } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public string PrivateLinkLocation { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackendEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.BackendEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackendEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.BackendEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.BackendEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.BackendEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.BackendEnabledState left, Azure.ResourceManager.FrontDoor.Models.BackendEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.BackendEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.BackendEnabledState left, Azure.ResourceManager.FrontDoor.Models.BackendEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackendPool : Azure.ResourceManager.FrontDoor.Models.SubResource
    {
        public BackendPool() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.Backend> Backends { get { throw null; } }
        public Azure.Core.ResourceIdentifier HealthProbeSettingsId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LoadBalancingSettingsId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class BackendPoolsSettings
    {
        public BackendPoolsSettings() { }
        public Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState? EnforceCertificateNameCheck { get { throw null; } set { } }
        public int? SendRecvTimeoutSeconds { get { throw null; } set { } }
    }
    public partial class CacheConfiguration
    {
        public CacheConfiguration() { }
        public System.TimeSpan? CacheDuration { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled? DynamicCompression { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery? QueryParameterStripDirective { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityInput
    {
        public CheckNameAvailabilityInput(string name, Azure.ResourceManager.FrontDoor.Models.ResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.ResourceType ResourceType { get { throw null; } }
    }
    public partial class CheckNameAvailabilityOutput
    {
        internal CheckNameAvailabilityOutput() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.Availability? NameAvailability { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class CustomHttpsConfiguration
    {
        public CustomHttpsConfiguration(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource certificateSource, Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType protocolType, Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion minimumTlsVersion) { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource CertificateSource { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType? CertificateType { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType ProtocolType { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomHttpsProvisioningState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomHttpsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState Disabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState Enabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState Enabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState left, Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState left, Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomHttpsProvisioningSubstate : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomHttpsProvisioningSubstate(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate CertificateDeleted { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate CertificateDeployed { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate DeletingCertificate { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate DeployingCertificate { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate DomainControlValidationRequestApproved { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate DomainControlValidationRequestRejected { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate DomainControlValidationRequestTimedOut { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate IssuingCertificate { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate PendingDomainControlValidationREquestApproval { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate SubmittingDomainControlValidationRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate left, Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate left, Azure.ResourceManager.FrontDoor.Models.CustomHttpsProvisioningSubstate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRule
    {
        public CustomRule(int priority, Azure.ResourceManager.FrontDoor.Models.RuleType ruleType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.MatchCondition> matchConditions, Azure.ResourceManager.FrontDoor.Models.ActionType action) { }
        public Azure.ResourceManager.FrontDoor.Models.ActionType Action { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.MatchCondition> MatchConditions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public int? RateLimitDurationInMinutes { get { throw null; } set { } }
        public int? RateLimitThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.RuleType RuleType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomRuleEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomRuleEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState left, Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState left, Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DynamicCompressionEnabled : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DynamicCompressionEnabled(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled left, Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled left, Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Endpoint
    {
        public Endpoint() { }
        public string EndpointValue { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.EndpointType AFD { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.EndpointType ATM { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.EndpointType AzureRegion { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.EndpointType CDN { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.EndpointType left, Azure.ResourceManager.FrontDoor.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.EndpointType left, Azure.ResourceManager.FrontDoor.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnforceCertificateNameCheckEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnforceCertificateNameCheckEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState left, Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState left, Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExperimentPatch
    {
        public ExperimentPatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.State? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ForwardingConfiguration : Azure.ResourceManager.FrontDoor.Models.RouteConfiguration
    {
        public ForwardingConfiguration() { }
        public Azure.Core.ResourceIdentifier BackendPoolId { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.CacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public string CustomForwardingPath { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorCertificateSource : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorCertificateSource(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource FrontDoor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource left, Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource left, Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorCertificateType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorForwardingProtocol : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorForwardingProtocol(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol HttpOnly { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol HttpsOnly { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol MatchRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol left, Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol left, Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorHealthProbeMethod : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorHealthProbeMethod(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod GET { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod Head { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod left, Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod left, Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorProtocol : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorProtocol(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol Https { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol left, Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol left, Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorQuery : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorQuery(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery StripAll { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery StripAllExcept { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery StripNone { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery StripOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery left, Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery left, Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorRedirectProtocol : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorRedirectProtocol(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol HttpOnly { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol HttpsOnly { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol MatchRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol left, Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol left, Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorRedirectType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorRedirectType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType Found { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType Moved { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType PermanentRedirect { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType TemporaryRedirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorResourceState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorResourceState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Enabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Enabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Migrated { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState Migrating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorSkuName : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorSkuName(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName ClassicAzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName PremiumAzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName StandardAzureFrontDoor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName left, Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName left, Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorTlsProtocolType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorTlsProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType ServerNameIndication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HeaderAction
    {
        public HeaderAction(Azure.ResourceManager.FrontDoor.Models.HeaderActionType headerActionType, string headerName) { }
        public Azure.ResourceManager.FrontDoor.Models.HeaderActionType HeaderActionType { get { throw null; } set { } }
        public string HeaderName { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HeaderActionType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.HeaderActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HeaderActionType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.HeaderActionType Append { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.HeaderActionType Delete { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.HeaderActionType Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.HeaderActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.HeaderActionType left, Azure.ResourceManager.FrontDoor.Models.HeaderActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.HeaderActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.HeaderActionType left, Azure.ResourceManager.FrontDoor.Models.HeaderActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthProbeEnabled : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthProbeEnabled(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled left, Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled left, Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthProbeSettingsModel : Azure.ResourceManager.FrontDoor.Models.SubResource
    {
        public HealthProbeSettingsModel() { }
        public Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod? HealthProbeMethod { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class LatencyMetric
    {
        public LatencyMetric() { }
        public float? ACLower95CI { get { throw null; } }
        public float? AHUpper95CI { get { throw null; } }
        public float? AValue { get { throw null; } }
        public float? BCLower95CI { get { throw null; } }
        public float? BUpper95CI { get { throw null; } }
        public float? BValue { get { throw null; } }
        public float? Delta { get { throw null; } }
        public float? DeltaPercent { get { throw null; } }
        public string EndDateTimeUTC { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class LatencyScorecard : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LatencyScorecard(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Country { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? EndDateTimeUTC { get { throw null; } }
        public string EndpointA { get { throw null; } }
        public string EndpointB { get { throw null; } }
        public string IdPropertiesId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.LatencyMetric> LatencyMetrics { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public System.DateTimeOffset? StartDateTimeUTC { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LatencyScorecardAggregationInterval : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LatencyScorecardAggregationInterval(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval Daily { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval Monthly { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoadBalancingSettingsModel : Azure.ResourceManager.FrontDoor.Models.SubResource
    {
        public LoadBalancingSettingsModel() { }
        public int? AdditionalLatencyMilliseconds { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public int? SampleSize { get { throw null; } set { } }
        public int? SuccessfulSamplesRequired { get { throw null; } set { } }
    }
    public partial class ManagedRuleDefinition
    {
        internal ManagedRuleDefinition() { }
        public Azure.ResourceManager.FrontDoor.Models.ActionType? DefaultAction { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState? DefaultState { get { throw null; } }
        public string Description { get { throw null; } }
        public string RuleId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedRuleEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedRuleEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedRuleExclusion
    {
        public ManagedRuleExclusion(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable matchVariable, Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator selectorMatchOperator, string selector) { }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable MatchVariable { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator SelectorMatchOperator { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedRuleExclusionMatchVariable : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedRuleExclusionMatchVariable(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable QueryStringArgNames { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable RequestBodyJsonArgNames { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable RequestBodyPostArgNames { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable RequestCookieNames { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable RequestHeaderNames { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedRuleExclusionSelectorMatchOperator : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedRuleExclusionSelectorMatchOperator(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator EqualsAny { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator EqualsValue { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedRuleGroupDefinition
    {
        internal ManagedRuleGroupDefinition() { }
        public string Description { get { throw null; } }
        public string RuleGroupName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition> Rules { get { throw null; } }
    }
    public partial class ManagedRuleGroupOverride
    {
        public ManagedRuleGroupOverride(string ruleGroupName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion> Exclusions { get { throw null; } }
        public string RuleGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride> Rules { get { throw null; } }
    }
    public partial class ManagedRuleOverride
    {
        public ManagedRuleOverride(string ruleId) { }
        public Azure.ResourceManager.FrontDoor.Models.ActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion> Exclusions { get { throw null; } }
        public string RuleId { get { throw null; } set { } }
    }
    public partial class ManagedRuleSet
    {
        public ManagedRuleSet(string ruleSetType, string ruleSetVersion) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion> Exclusions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride> RuleGroupOverrides { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType? RuleSetAction { get { throw null; } set { } }
        public string RuleSetType { get { throw null; } set { } }
        public string RuleSetVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedRuleSetActionType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedRuleSetActionType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType Block { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType Log { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType left, Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedRuleSetDefinition : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ManagedRuleSetDefinition(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition> RuleGroups { get { throw null; } }
        public string RuleSetId { get { throw null; } }
        public string RuleSetType { get { throw null; } }
        public string RuleSetVersion { get { throw null; } }
    }
    public partial class MatchCondition
    {
        public MatchCondition(Azure.ResourceManager.FrontDoor.Models.MatchVariable matchVariable, Azure.ResourceManager.FrontDoor.Models.Operator @operator, System.Collections.Generic.IEnumerable<string> matchValue) { }
        public System.Collections.Generic.IList<string> MatchValue { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.MatchVariable MatchVariable { get { throw null; } set { } }
        public bool? NegateCondition { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.Operator Operator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.TransformType> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchProcessingBehavior : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchProcessingBehavior(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior Continue { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior Stop { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior left, Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior left, Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MatchVariable : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.MatchVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MatchVariable(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable Cookies { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable PostArgs { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable QueryString { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable RemoteAddr { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable RequestBody { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable RequestHeader { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable RequestMethod { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable RequestUri { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MatchVariable SocketAddr { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.MatchVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.MatchVariable left, Azure.ResourceManager.FrontDoor.Models.MatchVariable right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.MatchVariable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.MatchVariable left, Azure.ResourceManager.FrontDoor.Models.MatchVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MinimumTLSVersion : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MinimumTLSVersion(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion One0 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion One2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion left, Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion left, Azure.ResourceManager.FrontDoor.Models.MinimumTLSVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkExperimentResourceState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkExperimentResourceState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState Enabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState Enabling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState left, Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState left, Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Operator : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.Operator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Operator(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.Operator Any { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator Contains { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator Equal { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator GeoMatch { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator IPMatch { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator LessThan { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Operator RegEx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.Operator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.Operator left, Azure.ResourceManager.FrontDoor.Models.Operator right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.Operator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.Operator left, Azure.ResourceManager.FrontDoor.Models.Operator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState left, Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState left, Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyMode : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.PolicyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyMode(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyMode Detection { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyMode Prevention { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.PolicyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.PolicyMode left, Azure.ResourceManager.FrontDoor.Models.PolicyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.PolicyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.PolicyMode left, Azure.ResourceManager.FrontDoor.Models.PolicyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyRequestBodyCheck : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyRequestBodyCheck(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck left, Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck left, Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyResourceState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.PolicyResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyResourceState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyResourceState Enabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PolicyResourceState Enabling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.PolicyResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.PolicyResourceState left, Azure.ResourceManager.FrontDoor.Models.PolicyResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.PolicyResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.PolicyResourceState left, Azure.ResourceManager.FrontDoor.Models.PolicyResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicySettings
    {
        public PolicySettings() { }
        public string CustomBlockResponseBody { get { throw null; } set { } }
        public int? CustomBlockResponseStatusCode { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.PolicyMode? Mode { get { throw null; } set { } }
        public System.Uri RedirectUri { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck? RequestBodyCheck { get { throw null; } set { } }
    }
    public partial class PreconfiguredEndpoint : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PreconfiguredEndpoint(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Backend { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.EndpointType? EndpointType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointStatus : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointStatus(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus left, Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus left, Azure.ResourceManager.FrontDoor.Models.PrivateEndpointStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfilePatch
    {
        public ProfilePatch() { }
        public Azure.ResourceManager.FrontDoor.Models.State? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class PurgeContent
    {
        public PurgeContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
    }
    public partial class RedirectConfiguration : Azure.ResourceManager.FrontDoor.Models.RouteConfiguration
    {
        public RedirectConfiguration() { }
        public string CustomFragment { get { throw null; } set { } }
        public string CustomHost { get { throw null; } set { } }
        public string CustomPath { get { throw null; } set { } }
        public string CustomQueryString { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol? RedirectProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType? RedirectType { get { throw null; } set { } }
    }
    public enum ResourceType
    {
        MicrosoftNetworkFrontDoors = 0,
        MicrosoftNetworkFrontDoorsFrontendEndpoints = 1,
    }
    public partial class RouteConfiguration
    {
        public RouteConfiguration() { }
    }
    public partial class RoutingRule : Azure.ResourceManager.FrontDoor.Models.SubResource
    {
        public RoutingRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol> AcceptedProtocols { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> FrontendEndpoints { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RouteConfiguration RouteConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RulesEngineId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingRuleEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingRuleEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState left, Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState left, Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulesEngineAction
    {
        public RulesEngineAction() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.HeaderAction> RequestHeaderActions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.HeaderAction> ResponseHeaderActions { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RouteConfiguration RouteConfigurationOverride { get { throw null; } set { } }
    }
    public partial class RulesEngineMatchCondition
    {
        public RulesEngineMatchCondition(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable rulesEngineMatchVariable, Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator rulesEngineOperator, System.Collections.Generic.IEnumerable<string> rulesEngineMatchValue) { }
        public bool? NegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RulesEngineMatchValue { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RulesEngineMatchVariable { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator RulesEngineOperator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.Transform> Transforms { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulesEngineMatchVariable : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulesEngineMatchVariable(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable IsMobile { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable PostArgs { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable QueryString { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RemoteAddr { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestBody { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestFilename { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestFilenameExtension { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestHeader { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestMethod { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestPath { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestScheme { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RequestUri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable left, Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable left, Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulesEngineOperator : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulesEngineOperator(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator Any { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator GeoMatch { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator IPMatch { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator left, Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator left, Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulesEngineRule
    {
        public RulesEngineRule(string name, int priority, Azure.ResourceManager.FrontDoor.Models.RulesEngineAction action) { }
        public Azure.ResourceManager.FrontDoor.Models.RulesEngineAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition> MatchConditions { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior? MatchProcessingBehavior { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.RuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RuleType MatchRule { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RuleType RateLimitRule { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.RuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.RuleType left, Azure.ResourceManager.FrontDoor.Models.RuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.RuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.RuleType left, Azure.ResourceManager.FrontDoor.Models.RuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionAffinityEnabledState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionAffinityEnabledState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState left, Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState left, Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.State Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.State Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.State left, Azure.ResourceManager.FrontDoor.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.State left, Azure.ResourceManager.FrontDoor.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubResource
    {
        public SubResource() { }
        public string Id { get { throw null; } set { } }
    }
    public partial class Timeseries : Azure.ResourceManager.Models.TrackedResourceData
    {
        public Timeseries(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.FrontDoor.Models.AggregationInterval? AggregationInterval { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string EndDateTimeUTC { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public string StartDateTimeUTC { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.TimeseriesDataPoint> TimeseriesData { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.TimeseriesType? TimeseriesType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeseriesAggregationInterval : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeseriesAggregationInterval(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval Daily { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval Hourly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.TimeseriesAggregationInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TimeseriesDataPoint
    {
        public TimeseriesDataPoint() { }
        public string DateTimeUTC { get { throw null; } set { } }
        public float? Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeseriesType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.TimeseriesType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeseriesType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.TimeseriesType LatencyP50 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TimeseriesType LatencyP75 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TimeseriesType LatencyP95 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TimeseriesType MeasurementCounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.TimeseriesType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.TimeseriesType left, Azure.ResourceManager.FrontDoor.Models.TimeseriesType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.TimeseriesType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.TimeseriesType left, Azure.ResourceManager.FrontDoor.Models.TimeseriesType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Transform : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.Transform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Transform(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.Transform Lowercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Transform RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Transform Trim { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Transform Uppercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Transform UrlDecode { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.Transform UrlEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.Transform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.Transform left, Azure.ResourceManager.FrontDoor.Models.Transform right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.Transform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.Transform left, Azure.ResourceManager.FrontDoor.Models.Transform right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransformType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.TransformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransformType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.TransformType Lowercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TransformType RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TransformType Trim { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TransformType Uppercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TransformType UrlDecode { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.TransformType UrlEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.TransformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.TransformType left, Azure.ResourceManager.FrontDoor.Models.TransformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.TransformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.TransformType left, Azure.ResourceManager.FrontDoor.Models.TransformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidateCustomDomainContent
    {
        public ValidateCustomDomainContent(string hostName) { }
        public string HostName { get { throw null; } }
    }
    public partial class ValidateCustomDomainOutput
    {
        internal ValidateCustomDomainOutput() { }
        public bool? CustomDomainValidated { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class WebApplicationFirewallPolicyPatch
    {
        public WebApplicationFirewallPolicyPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
