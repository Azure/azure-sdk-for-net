namespace Azure.ResourceManager.FrontDoor
{
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetIfExists(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorResource>> GetIfExistsAsync(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorData>
    {
        public FrontDoorData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool> BackendPools { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings BackendPoolsSettings { get { throw null; } set { } }
        public string Cname { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ExtendedProperties { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public string FrontdoorId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.FrontendEndpointData> FrontendEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData> HealthProbeSettings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData> LoadBalancingSettings { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData> RoutingRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData> RulesEngines { get { throw null; } }
        Azure.ResourceManager.FrontDoor.FrontDoorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.FrontDoorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorExperimentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>, System.Collections.IEnumerable
    {
        protected FrontDoorExperimentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.FrontDoor.FrontDoorExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string experimentName, Azure.ResourceManager.FrontDoor.FrontDoorExperimentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> Get(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> GetAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> GetIfExists(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> GetIfExistsAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorExperimentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorExperimentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorExperimentData>
    {
        public FrontDoorExperimentData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties ExperimentEndpointA { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties ExperimentEndpointB { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState? ResourceState { get { throw null; } }
        public System.Uri ScriptFileUri { get { throw null; } }
        public string Status { get { throw null; } }
        Azure.ResourceManager.FrontDoor.FrontDoorExperimentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorExperimentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorExperimentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.FrontDoorExperimentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorExperimentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorExperimentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorExperimentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorExperimentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorExperimentResource() { }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorExperimentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName, string experimentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard> GetLatencyScorecardsReport(Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval aggregationInterval, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>> GetLatencyScorecardsReportAsync(Azure.ResourceManager.FrontDoor.Models.LatencyScorecardAggregationInterval aggregationInterval, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo> GetTimeSeriesReport(Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentResourceGetTimeSeriesReportOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo> GetTimeSeriesReport(System.DateTimeOffset startOn, System.DateTimeOffset endOn, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval aggregationInterval, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>> GetTimeSeriesReportAsync(Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentResourceGetTimeSeriesReportOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>> GetTimeSeriesReportAsync(System.DateTimeOffset startOn, System.DateTimeOffset endOn, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval aggregationInterval, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType timeSeriesType, string endpoint = null, string country = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FrontDoorExtensions
    {
        public static Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult> CheckFrontDoorNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult> CheckFrontDoorNameAvailability(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>> CheckFrontDoorNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>> CheckFrontDoorNameAvailabilityAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoor(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> GetFrontDoorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource GetFrontDoorExperimentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetFrontDoorNetworkExperimentProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> GetFrontDoorNetworkExperimentProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource GetFrontDoorNetworkExperimentProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileCollection GetFrontDoorNetworkExperimentProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetFrontDoorNetworkExperimentProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetFrontDoorNetworkExperimentProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorResource GetFrontDoorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource GetFrontDoorRulesEngineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorCollection GetFrontDoors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyCollection GetFrontDoorWebApplicationFirewallPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> GetFrontDoorWebApplicationFirewallPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource GetFrontDoorWebApplicationFirewallPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontendEndpointResource GetFrontendEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition> GetManagedRuleSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition> GetManagedRuleSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorNetworkExperimentProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>, System.Collections.IEnumerable
    {
        protected FrontDoorNetworkExperimentProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> Get(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> GetAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetIfExists(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> GetIfExistsAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorNetworkExperimentProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData>
    {
        public FrontDoorNetworkExperimentProfileData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState? EnabledState { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState? ResourceState { get { throw null; } }
        Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorNetworkExperimentProfileResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorNetworkExperimentProfileResource() { }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource> GetFrontDoorExperiment(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource>> GetFrontDoorExperimentAsync(string experimentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorExperimentCollection GetFrontDoorExperiments() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint> GetPreconfiguredEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint> GetPreconfiguredEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> GetFrontDoorRulesEngine(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>> GetFrontDoorRulesEngineAsync(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineCollection GetFrontDoorRulesEngines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> GetFrontendEndpoint(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>> GetFrontendEndpointAsync(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontendEndpointCollection GetFrontendEndpoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeContent(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeContentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.FrontDoorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.FrontDoorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult> ValidateCustomDomain(Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>> ValidateCustomDomainAsync(Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorRulesEngineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>, System.Collections.IEnumerable
    {
        protected FrontDoorRulesEngineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rulesEngineName, Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rulesEngineName, Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> Get(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>> GetAsync(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> GetIfExists(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>> GetIfExistsAsync(string rulesEngineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorRulesEngineData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData>
    {
        public FrontDoorRulesEngineData() { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule> Rules { get { throw null; } }
        Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorRulesEngineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorRulesEngineResource() { }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string frontDoorName, string rulesEngineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FrontDoorWebApplicationFirewallPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>, System.Collections.IEnumerable
    {
        protected FrontDoorWebApplicationFirewallPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> GetIfExists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> GetIfExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontDoorWebApplicationFirewallPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData>
    {
        public FrontDoorWebApplicationFirewallPolicyData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> FrontendEndpointLinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet> ManagedRuleSets { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings PolicySettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState? ResourceState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> RoutingRuleLinks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule> Rules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> SecurityPolicyLinks { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName? SkuName { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorWebApplicationFirewallPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontDoorWebApplicationFirewallPolicyResource() { }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> GetIfExists(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>> GetIfExistsAsync(string frontendEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FrontDoor.FrontendEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontendEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FrontendEndpointData : Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontendEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontendEndpointData>
    {
        public FrontendEndpointData() { }
        public Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration CustomHttpsConfiguration { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState? CustomHttpsProvisioningState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate? CustomHttpsProvisioningSubstate { get { throw null; } }
        public string HostName { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState? SessionAffinityEnabledState { get { throw null; } set { } }
        public int? SessionAffinityTtlInSeconds { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.FrontendEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontendEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.FrontendEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.FrontendEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontendEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontendEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.FrontendEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
namespace Azure.ResourceManager.FrontDoor.Mocking
{
    public partial class MockableFrontDoorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableFrontDoorArmClient() { }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorExperimentResource GetFrontDoorExperimentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource GetFrontDoorNetworkExperimentProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorResource GetFrontDoorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineResource GetFrontDoorRulesEngineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource GetFrontDoorWebApplicationFirewallPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontendEndpointResource GetFrontendEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableFrontDoorResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFrontDoorResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoor(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorResource>> GetFrontDoorAsync(string frontDoorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetFrontDoorNetworkExperimentProfile(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource>> GetFrontDoorNetworkExperimentProfileAsync(string profileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileCollection GetFrontDoorNetworkExperimentProfiles() { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorCollection GetFrontDoors() { throw null; }
        public virtual Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyCollection GetFrontDoorWebApplicationFirewallPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPolicy(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyResource>> GetFrontDoorWebApplicationFirewallPolicyAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableFrontDoorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFrontDoorSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult> CheckFrontDoorNameAvailability(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>> CheckFrontDoorNameAvailabilityAsync(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetFrontDoorNetworkExperimentProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileResource> GetFrontDoorNetworkExperimentProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.FrontDoorResource> GetFrontDoorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition> GetManagedRuleSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition> GetManagedRuleSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableFrontDoorTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFrontDoorTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult> CheckFrontDoorNameAvailability(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>> CheckFrontDoorNameAvailabilityAsync(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.FrontDoor.Models
{
    public static partial class ArmFrontDoorModelFactory
    {
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend FrontDoorBackend(string address = null, string privateLinkAlias = null, Azure.Core.ResourceIdentifier privateLinkResourceId = null, Azure.Core.AzureLocation? privateLinkLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus? privateEndpointStatus = default(Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus?), string privateLinkApprovalMessage = null, int? httpPort = default(int?), int? httpsPort = default(int?), Azure.ResourceManager.FrontDoor.Models.BackendEnabledState? enabledState = default(Azure.ResourceManager.FrontDoor.Models.BackendEnabledState?), int? priority = default(int?), int? weight = default(int?), string backendHostHeader = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool FrontDoorBackendPool(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend> backends = null, Azure.Core.ResourceIdentifier loadBalancingSettingsId = null, Azure.Core.ResourceIdentifier healthProbeSettingsId = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorData FrontDoorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string friendlyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData> routingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData> loadBalancingSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData> healthProbeSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool> backendPools = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontendEndpointData> frontendEndpoints = null, Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings backendPoolsSettings = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState? enabledState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorEnabledState?), Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState?), string provisioningState = null, string cname = null, string frontdoorId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData> rulesEngines = null, System.Collections.Generic.IReadOnlyDictionary<string, string> extendedProperties = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorExperimentData FrontDoorExperimentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties experimentEndpointA = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties experimentEndpointB = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState? enabledState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState?), Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState?), string status = null, System.Uri scriptFileUri = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData FrontDoorHealthProbeSettingsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string path = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol? protocol = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol?), int? intervalInSeconds = default(int?), Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod? healthProbeMethod = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod?), Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled? enabledState = default(Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled?), Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData FrontDoorLoadBalancingSettingsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), int? sampleSize = default(int?), int? successfulSamplesRequired = default(int?), int? additionalLatencyMilliseconds = default(int?), Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult FrontDoorNameAvailabilityResult(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState? nameAvailability = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorNetworkExperimentProfileData FrontDoorNetworkExperimentProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.NetworkExperimentResourceState?), Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState? enabledState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData FrontDoorResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorRulesEngineData FrontDoorRulesEngineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule> rules = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo FrontDoorTimeSeriesInfo(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri endpoint = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval? aggregationInterval = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval?), Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType? timeSeriesType = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType?), string country = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint> timeSeriesData = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult FrontDoorValidateCustomDomainResult(bool? isCustomDomainValidated = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontDoorWebApplicationFirewallPolicyData FrontDoorWebApplicationFirewallPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName? skuName = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorSkuName?), Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings policySettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule> rules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet> managedRuleSets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> frontendEndpointLinks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> routingRuleLinks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> securityPolicyLinks = null, string provisioningState = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.FrontendEndpointData FrontendEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string hostName = null, Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState? sessionAffinityEnabledState = default(Azure.ResourceManager.FrontDoor.Models.SessionAffinityEnabledState?), int? sessionAffinityTtlInSeconds = default(int?), Azure.Core.ResourceIdentifier webApplicationFirewallPolicyLinkId = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState?), Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState? customHttpsProvisioningState = default(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState?), Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate? customHttpsProvisioningSubstate = default(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate?), Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration customHttpsConfiguration = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.LatencyMetric LatencyMetric(string name = null, System.DateTimeOffset? endOn = default(System.DateTimeOffset?), float? aValue = default(float?), float? bValue = default(float?), float? delta = default(float?), float? deltaPercent = default(float?), float? acLower95CI = default(float?), float? ahUpper95CI = default(float?), float? bcLower95CI = default(float?), float? bUpper95CI = default(float?)) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.LatencyScorecard LatencyScorecard(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string latencyScorecardId = null, string latencyScorecardName = null, string description = null, System.Uri scorecardEndpointA = null, System.Uri scorecardEndpointB = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string country = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.LatencyMetric> latencyMetrics = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition ManagedRuleDefinition(string ruleId = null, Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState? defaultState = default(Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState?), Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType? defaultAction = default(Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType?), string description = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition ManagedRuleGroupDefinition(string ruleGroupName = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition> rules = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition ManagedRuleSetDefinition(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, string ruleSetId = null, string ruleSetType = null, string ruleSetVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition> ruleGroups = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint PreconfiguredEndpoint(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, string endpoint = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType? endpointType = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType?), string backend = null) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RoutingRuleData RoutingRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.WritableSubResource> frontendEndpoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol> acceptedProtocols = null, System.Collections.Generic.IEnumerable<string> patternsToMatch = null, Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState? enabledState = default(Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState?), Azure.ResourceManager.FrontDoor.Models.RouteConfiguration routeConfiguration = null, Azure.Core.ResourceIdentifier rulesEngineId = null, Azure.Core.ResourceIdentifier webApplicationFirewallPolicyLinkId = null, Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? resourceState = default(Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState?)) { throw null; }
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
    public partial class BackendPoolsSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings>
    {
        public BackendPoolsSettings() { }
        public Azure.ResourceManager.FrontDoor.Models.EnforceCertificateNameCheckEnabledState? EnforceCertificateNameCheck { get { throw null; } set { } }
        public int? SendRecvTimeoutInSeconds { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.BackendPoolsSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackendPrivateEndpointStatus : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackendPrivateEndpointStatus(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus Timeout { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus left, Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus left, Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomHttpsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration>
    {
        public CustomHttpsConfiguration(Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource certificateSource, Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType protocolType, Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion minimumTlsVersion) { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorCertificateSource CertificateSource { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType? CertificateType { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion MinimumTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorTlsProtocolType ProtocolType { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.CustomHttpsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ForwardingConfiguration : Azure.ResourceManager.FrontDoor.Models.RouteConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration>
    {
        public ForwardingConfiguration() { }
        public Azure.Core.ResourceIdentifier BackendPoolId { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration CacheConfiguration { get { throw null; } set { } }
        public string CustomForwardingPath { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorForwardingProtocol? ForwardingProtocol { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ForwardingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorBackend : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend>
    {
        public FrontDoorBackend() { }
        public string Address { get { throw null; } set { } }
        public string BackendHostHeader { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.BackendEnabledState? EnabledState { get { throw null; } set { } }
        public int? HttpPort { get { throw null; } set { } }
        public int? HttpsPort { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.BackendPrivateEndpointStatus? PrivateEndpointStatus { get { throw null; } }
        public string PrivateLinkAlias { get { throw null; } set { } }
        public string PrivateLinkApprovalMessage { get { throw null; } set { } }
        public Azure.Core.AzureLocation? PrivateLinkLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorBackendPool : Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool>
    {
        public FrontDoorBackendPool() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackend> Backends { get { throw null; } }
        public Azure.Core.ResourceIdentifier HealthProbeSettingsId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LoadBalancingSettingsId { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorBackendPool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorCacheConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration>
    {
        public FrontDoorCacheConfiguration() { }
        public System.TimeSpan? CacheDuration { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.DynamicCompressionEnabled? DynamicCompression { get { throw null; } set { } }
        public string QueryParameters { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorQuery? QueryParameterStripDirective { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorCacheConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct FrontDoorEndpointConnectionCertificateType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorEndpointConnectionCertificateType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType Dedicated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointConnectionCertificateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorEndpointPurgeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent>
    {
        public FrontDoorEndpointPurgeContent(System.Collections.Generic.IEnumerable<string> contentPaths) { }
        public System.Collections.Generic.IList<string> ContentPaths { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointPurgeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorEndpointType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType AzureFrontDoor { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType AzureRegion { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType AzureTrafficManager { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType Cdn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorExperimentEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties>
    {
        public FrontDoorExperimentEndpointProperties() { }
        public string Endpoint { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorExperimentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch>
    {
        public FrontDoorExperimentPatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorExperimentResourceGetTimeSeriesReportOptions
    {
        public FrontDoorExperimentResourceGetTimeSeriesReportOptions(System.DateTimeOffset startOn, System.DateTimeOffset endOn, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval aggregationInterval, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType timeSeriesType) { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval AggregationInterval { get { throw null; } }
        public string Country { get { throw null; } set { } }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public string Endpoint { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType TimeSeriesType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorExperimentState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorExperimentState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState right) { throw null; }
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
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod Get { get { throw null; } }
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
    public partial class FrontDoorHealthProbeSettingsData : Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData>
    {
        public FrontDoorHealthProbeSettingsData() { }
        public Azure.ResourceManager.FrontDoor.Models.HealthProbeEnabled? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeMethod? HealthProbeMethod { get { throw null; } set { } }
        public int? IntervalInSeconds { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorHealthProbeSettingsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorLoadBalancingSettingsData : Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData>
    {
        public FrontDoorLoadBalancingSettingsData() { }
        public int? AdditionalLatencyMilliseconds { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public int? SampleSize { get { throw null; } set { } }
        public int? SuccessfulSamplesRequired { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorLoadBalancingSettingsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent>
    {
        public FrontDoorNameAvailabilityContent(string name, Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceType ResourceType { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>
    {
        internal FrontDoorNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState? NameAvailability { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorNameAvailabilityState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorNameAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState Available { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorNameAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorNetworkExperimentProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch>
    {
        public FrontDoorNetworkExperimentProfilePatch() { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorExperimentState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorNetworkExperimentProfilePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct FrontDoorRequiredMinimumTlsVersion : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorRequiredMinimumTlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion Tls1_2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion left, Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion left, Azure.ResourceManager.FrontDoor.Models.FrontDoorRequiredMinimumTlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorResourceData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData>
    {
        public FrontDoorResourceData() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public enum FrontDoorResourceType
    {
        MicrosoftNetworkFrontDoors = 0,
        MicrosoftNetworkFrontDoorsFrontendEndpoints = 1,
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
    public readonly partial struct FrontDoorTimeSeriesAggregationInterval : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorTimeSeriesAggregationInterval(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval Daily { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval Hourly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesAggregationInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorTimeSeriesDataPoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint>
    {
        public FrontDoorTimeSeriesDataPoint() { }
        public System.DateTimeOffset? DateTimeUtc { get { throw null; } set { } }
        public float? Value { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorTimeSeriesInfo : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>
    {
        public FrontDoorTimeSeriesInfo(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval? AggregationInterval { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesDataPoint> TimeSeriesData { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType? TimeSeriesType { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorTimeSeriesInfoAggregationInterval : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorTimeSeriesInfoAggregationInterval(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval Daily { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval Hourly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesInfoAggregationInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorTimeSeriesType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorTimeSeriesType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType LatencyP50 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType LatencyP75 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType LatencyP95 { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType MeasurementCounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType left, Azure.ResourceManager.FrontDoor.Models.FrontDoorTimeSeriesType right) { throw null; }
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
    public partial class FrontDoorValidateCustomDomainContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent>
    {
        public FrontDoorValidateCustomDomainContent(string hostName) { }
        public string HostName { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FrontDoorValidateCustomDomainResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>
    {
        internal FrontDoorValidateCustomDomainResult() { }
        public bool? IsCustomDomainValidated { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorValidateCustomDomainResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorWebApplicationFirewallPolicyMode : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorWebApplicationFirewallPolicyMode(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode Detection { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode Prevention { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode left, Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode left, Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorWebApplicationFirewallPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch>
    {
        public FrontDoorWebApplicationFirewallPolicyPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontDoorWebApplicationFirewallPolicyResourceState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontDoorWebApplicationFirewallPolicyResourceState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState Creating { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState Deleting { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState Disabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState Enabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState Enabling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState left, Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FrontDoorWebApplicationFirewallPolicySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings>
    {
        public FrontDoorWebApplicationFirewallPolicySettings() { }
        public string CustomBlockResponseBody { get { throw null; } set { } }
        public int? CustomBlockResponseStatusCode { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.PolicyEnabledState? EnabledState { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicyMode? Mode { get { throw null; } set { } }
        public System.Uri RedirectUri { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.PolicyRequestBodyCheck? RequestBodyCheck { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.FrontDoorWebApplicationFirewallPolicySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontendEndpointCustomHttpsProvisioningState : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontendEndpointCustomHttpsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState Disabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState Disabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState Enabled { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState Enabling { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState left, Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState left, Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontendEndpointCustomHttpsProvisioningSubstate : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontendEndpointCustomHttpsProvisioningSubstate(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate CertificateDeleted { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate CertificateDeployed { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate DeletingCertificate { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate DeployingCertificate { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate DomainControlValidationRequestApproved { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate DomainControlValidationRequestRejected { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate DomainControlValidationRequestTimedOut { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate IssuingCertificate { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate PendingDomainControlValidationRequestApproval { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate SubmittingDomainControlValidationRequest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate left, Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate left, Azure.ResourceManager.FrontDoor.Models.FrontendEndpointCustomHttpsProvisioningSubstate right) { throw null; }
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
    public partial class LatencyMetric : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.LatencyMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyMetric>
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
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.LatencyMetric System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.LatencyMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.LatencyMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.LatencyMetric System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LatencyScorecard : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>
    {
        public LatencyScorecard(Azure.Core.AzureLocation location) { }
        public string Country { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.LatencyMetric> LatencyMetrics { get { throw null; } }
        public string LatencyScorecardId { get { throw null; } }
        public string LatencyScorecardName { get { throw null; } }
        public System.Uri ScorecardEndpointA { get { throw null; } }
        public System.Uri ScorecardEndpointB { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.LatencyScorecard System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.LatencyScorecard System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.LatencyScorecard>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ManagedRuleDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition>
    {
        internal ManagedRuleDefinition() { }
        public Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType? DefaultAction { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState? DefaultState { get { throw null; } }
        public string Description { get { throw null; } }
        public string RuleId { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ManagedRuleExclusion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion>
    {
        public ManagedRuleExclusion(Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable matchVariable, Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator selectorMatchOperator, string selector) { }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionMatchVariable MatchVariable { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusionSelectorMatchOperator SelectorMatchOperator { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ManagedRuleGroupDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition>
    {
        internal ManagedRuleGroupDefinition() { }
        public string Description { get { throw null; } }
        public string RuleGroupName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleDefinition> Rules { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleGroupOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride>
    {
        public ManagedRuleGroupOverride(string ruleGroupName) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion> Exclusions { get { throw null; } }
        public string RuleGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride> Rules { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride>
    {
        public ManagedRuleOverride(string ruleId) { }
        public Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType? Action { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion> Exclusions { get { throw null; } }
        public string RuleId { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedRuleSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet>
    {
        public ManagedRuleSet(string ruleSetType, string ruleSetVersion) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleExclusion> Exclusions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupOverride> RuleGroupOverrides { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetActionType? RuleSetAction { get { throw null; } set { } }
        public string RuleSetType { get { throw null; } set { } }
        public string RuleSetVersion { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ManagedRuleSetDefinition : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition>
    {
        public ManagedRuleSetDefinition(Azure.Core.AzureLocation location) { }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.FrontDoor.Models.ManagedRuleGroupDefinition> RuleGroups { get { throw null; } }
        public string RuleSetId { get { throw null; } }
        public string RuleSetType { get { throw null; } }
        public string RuleSetVersion { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.ManagedRuleSetDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PreconfiguredEndpoint : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint>
    {
        public PreconfiguredEndpoint(Azure.Core.AzureLocation location) { }
        public string Backend { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorEndpointType? EndpointType { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.PreconfiguredEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedirectConfiguration : Azure.ResourceManager.FrontDoor.Models.RouteConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration>
    {
        public RedirectConfiguration() { }
        public string CustomFragment { get { throw null; } set { } }
        public string CustomHost { get { throw null; } set { } }
        public string CustomPath { get { throw null; } set { } }
        public string CustomQueryString { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectProtocol? RedirectProtocol { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorRedirectType? RedirectType { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RedirectConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RouteConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RouteConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RouteConfiguration>
    {
        protected RouteConfiguration() { }
        Azure.ResourceManager.FrontDoor.Models.RouteConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RouteConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RouteConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.RouteConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RouteConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RouteConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RouteConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingRuleData : Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData>
    {
        public RoutingRuleData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.FrontDoorProtocol> AcceptedProtocols { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RoutingRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> FrontendEndpoints { get { throw null; } }
        public System.Collections.Generic.IList<string> PatternsToMatch { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.FrontDoorResourceState? ResourceState { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RouteConfiguration RouteConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RulesEngineId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WebApplicationFirewallPolicyLinkId { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.RoutingRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.RoutingRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RoutingRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RuleMatchActionType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RuleMatchActionType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType Allow { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType Block { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType Log { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType Redirect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType left, Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType left, Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulesEngineAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineAction>
    {
        public RulesEngineAction() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction> RequestHeaderActions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction> ResponseHeaderActions { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RouteConfiguration RouteConfigurationOverride { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RulesEngineHeaderAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction>
    {
        public RulesEngineHeaderAction(Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType headerActionType, string headerName) { }
        public Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType HeaderActionType { get { throw null; } set { } }
        public string HeaderName { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulesEngineHeaderActionType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulesEngineHeaderActionType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType Append { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType Delete { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType left, Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType left, Azure.ResourceManager.FrontDoor.Models.RulesEngineHeaderActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RulesEngineMatchCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition>
    {
        public RulesEngineMatchCondition(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable rulesEngineMatchVariable, Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator rulesEngineOperator, System.Collections.Generic.IEnumerable<string> rulesEngineMatchValue) { }
        public bool? IsNegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RulesEngineMatchValue { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchVariable RulesEngineMatchVariable { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.RulesEngineOperator RulesEngineOperator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform> Transforms { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RulesEngineMatchTransform : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RulesEngineMatchTransform(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform Lowercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform Trim { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform Uppercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform UriDecode { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform UriEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform left, Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform left, Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchTransform right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class RulesEngineRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule>
    {
        public RulesEngineRule(string name, int priority, Azure.ResourceManager.FrontDoor.Models.RulesEngineAction action) { }
        public Azure.ResourceManager.FrontDoor.Models.RulesEngineAction Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.RulesEngineMatchCondition> MatchConditions { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.MatchProcessingBehavior? MatchProcessingBehavior { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.RulesEngineRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.RulesEngineRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class WebApplicationCustomRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule>
    {
        public WebApplicationCustomRule(int priority, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType ruleType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition> matchConditions, Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType action) { }
        public Azure.ResourceManager.FrontDoor.Models.RuleMatchActionType Action { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.CustomRuleEnabledState? EnabledState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition> MatchConditions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public int? RateLimitDurationInMinutes { get { throw null; } set { } }
        public int? RateLimitThreshold { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType RuleType { get { throw null; } set { } }
        Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationCustomRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebApplicationRuleMatchCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition>
    {
        public WebApplicationRuleMatchCondition(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable matchVariable, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator @operator, System.Collections.Generic.IEnumerable<string> matchValue) { }
        public bool? IsNegateCondition { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MatchValue { get { throw null; } }
        public Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable MatchVariable { get { throw null; } set { } }
        public Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator Operator { get { throw null; } set { } }
        public string Selector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType> Transforms { get { throw null; } }
        Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebApplicationRuleMatchOperator : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebApplicationRuleMatchOperator(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator Any { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator BeginsWith { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator EndsWith { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator GeoMatch { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator IPMatch { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator RegEX { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebApplicationRuleMatchTransformType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebApplicationRuleMatchTransformType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType Lowercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType RemoveNulls { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType Trim { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType Uppercase { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType UriDecode { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType UriEncode { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchTransformType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebApplicationRuleMatchVariable : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebApplicationRuleMatchVariable(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable Cookies { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable PostArgs { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable QueryString { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable RemoteAddr { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable RequestBody { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable RequestHeader { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable RequestMethod { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable RequestUri { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable SocketAddr { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleMatchVariable right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WebApplicationRuleType : System.IEquatable<Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WebApplicationRuleType(string value) { throw null; }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType MatchRule { get { throw null; } }
        public static Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType RateLimitRule { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType left, Azure.ResourceManager.FrontDoor.Models.WebApplicationRuleType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
